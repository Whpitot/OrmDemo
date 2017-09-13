using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using WMSDAL.Map;
using System.Reflection;
using WMSDAL.Sql;
using System.Data;
using System.Data.SqlClient;

namespace WMSDAL.Entry
{
    public class OpreaEntity<T> where T:class,new()
    {
        private IList<TableMap> tables=new List<TableMap>();

        public OpreaEntity(T obj)
        {
            Type t = obj.GetType();
            ResolveTables(t, obj);
        }


        #region 把实体同意加载到表类中，实体映射 ,用于保存数据，这就是所谓的建立一个数的概念
        private void ResolveTables(Type t, object obj)
        { 
            if(t.IsDefined(typeof(TableMapAttribute),false))
            {
                TableMapAttribute tablemap = Attribute.GetCustomAttribute(t, typeof(TableMapAttribute)) as TableMapAttribute;
                TableMap tm = new TableMap();
                tm.TableName = tablemap.TableName;
                tm.PrimaryKeyName = tablemap.PrimaryKey;
                tables.Add(tm);
                //解析字段
                PropertyInfo[] infos = t.GetProperties();
                foreach (PropertyInfo pi in infos)
                {
                    if(pi.IsDefined(typeof(FieldMapAttribute),false))
                    {
                        FieldMapAttribute fieldmap = Attribute.GetCustomAttribute(pi, typeof(FieldMapAttribute)) as FieldMapAttribute;
                        if (!fieldmap.IsIdentity)//解决自增列
                        {
                            Field col = new Field(pi.PropertyType, fieldmap.ColumnName, pi.GetValue(obj, null), fieldmap.MustInput);
                            if (!col.isDBNull)
                            {
                                tm.Columns.Add(col);//加载列
                            }
                        }
                    }
                    else if(pi.IsDefined(typeof(SubObjectAttribute),false))
                    {
                        SubObjectAttribute sb = Attribute.GetCustomAttribute(pi, typeof(SubObjectAttribute)) as SubObjectAttribute;
                        Type ty = sb.SubObjectType;
                        if (pi.GetValue(obj, null) != null)
                        {                        
                                System.Collections.IList c = pi.GetValue(obj, null) as System.Collections.IList;
                                for (int k = 0; k < c.Count; k++)
                                {
                                    ResolveTables(ty, c[k]);
                                }                           
                        }
                    }
                }
            }
        }
        #endregion

        #region 后来修改的ORM，主表的映射完成，从表的映射还要研究
        public string GetUpdateSql(object ModelObject, ref List<SqlParameter> Params)
        {
            string strUpdateSql = "update {0} set {1} where {2} ";
            string tableName = "";
            string strWhere = "";
            int i = 0;
            StringBuilder strSet = new StringBuilder();
            Type obj = ModelObject.GetType();
            if(obj.IsDefined(typeof(TableMapAttribute),false))
            {
                TableMapAttribute tablemap=Attribute.GetCustomAttribute(obj,typeof(TableMapAttribute)) as TableMapAttribute;
               //应该判断为空的情况
                tableName = tablemap.TableName;
                PropertyInfo[] infos = obj.GetProperties();
                FieldMapAttribute fieldmap;
                foreach (PropertyInfo pi in infos)
                {
                    if (pi.IsDefined(typeof(FieldMapAttribute),false))
                    {
                        fieldmap = Attribute.GetCustomAttribute(pi, typeof(FieldMapAttribute)) as FieldMapAttribute;
                        if (fieldmap.IsIdentity)
                        {
                            object keyvalue = pi.GetValue(obj, null);
                            if (Convert.ToString(keyvalue) == "0" || Convert.ToString(keyvalue) == "")
                            {
                                Params.Clear();//碰到异常情况下，不允许修改；
                            }
                            strWhere = fieldmap.ColumnName = "@" + fieldmap.ColumnName;
                        }
                        else
                        {
                            if (i > 0)
                                strSet.Append(",");
                            strSet.Append(fieldmap.ColumnName = "@" + fieldmap.ColumnName);
                            i++;
                        }
                        Params.Add(new SqlParameter("@" + fieldmap.ColumnName, pi.GetValue(obj, null)));
                    }
                }
                if (strSet.Length > 0)
                    return string.Format(strUpdateSql, new string[] { tableName, strSet.ToString(), strWhere });
                return "";            
            }

            return null;
        }
        #endregion



        #region CRUD
        public string insert()
        {
            string str = "";
            for (int i = 0; i < tables.Count; i++)
            {
                str += string.Concat("insert into ", tables[i].TableName, "(", tables[i].Columns.ToFieldNameList(), ")", "values", "(", tables[i].Columns.ToFieldValueList(), ")\n");
            }
            return str;
        }

        public string update()
        {
            Fields cond = GetPkFeilds(tables[0].Columns, tables[0].PrimaryKeyName);
            string str = "";
            if (tables.Count > 1)
            {
                // 当它有分录的时候， 要删除分录，再插入分录，然后修改单据头
                //删除分录

                str += "\n delete from " + tables[1].TableName + " where " + cond.ToCondition() + " ";                    
                //插入分录
                for (int i = 1; i < tables.Count; i++)
                {
                    str += "\n insert into " + tables[i].TableName + "(" + tables[i].Columns.ToFieldNameList() + ") values (" + tables[i].Columns.ToFieldValueList() + ")";
                }
                str += " update " + tables[0].TableName + " set " + tables[0].Columns.ToUpdateString() + " where " + cond.ToCondition() + "";
            }
            else
            {                
                str += " update " + tables[0].TableName + " set " + tables[0].Columns.ToUpdateString() + " where " + cond.ToCondition() + "";               
            }
            return str;
        }


        //删除SQL,  
        /// <summary>
        ///  删除SQL,当isremove的值 为false 时，就修改删除，否则 就直接删除
        /// </summary>
        /// <param name="isremove"></param>
        /// <returns></returns>
        public string delete(bool isremove)
        {
            string operatestr = "";
            if (!isremove)
            {
                operatestr = "update " + tables[0].TableName + " set  FDeleted=1";
                //移除主键
                Fields cond = GetPkFeilds(tables[0].Columns, tables[0].PrimaryKeyName);
                operatestr += " where " + cond.ToCondition();
            }
            else
            {
                Fields allcol = tables[0].Columns; //这里 是不想修改tables[0].Columns里面的列
                Fields cond = GetPkFeilds(allcol, tables[0].PrimaryKeyName);//
                operatestr = string.Concat("delete from ", tables[0].TableName, " where ", cond.ToCondition());                
            }
            return operatestr;
        }
        /// <returns></returns>
        private Fields GetPkFeilds(Fields allField, string pkName)
        {
            Fields pkfields = new Fields();
            pkfields.Add(allField.GetField(pkName));
            for (int i = 0; i < pkName.Length; i++)
            {
                allField.Remove(pkName); //这里要移除主键
            }
            return pkfields;
        }
        #endregion
    }
}
