using System;
using System.Collections.Generic;
using System.Text;
using DAl.Map;
using System.Collections;
using System.Reflection;
using DAl.Sql;

using System.Data;
namespace DAl.Entry
{

    public class EntryOperate<T> where T:class,new()
    {
        private IList<T> operaObject = new List<T>();
        private IList<TableMap> tables = new List<TableMap>();
        private IList<Field> unique = new List<Field>();
        /// <summary>
        /// 当用实体新增，删除，修改的时候，就用这个构造函数
        /// </summary>
        /// <param name="obj"></param>
        public EntryOperate(T obj)
        {
            Type t = obj.GetType();
            ResolveTables(t, obj);
        }
        /// <summary>
        /// 当用其他的 新增，上除，修改的时候，就用这个
        /// </summary>
        public EntryOperate()
        { 

        }
        /// <summary>
        /// 得到实体中需要提交，和不需要提交的字段.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        private void ResolveTables(Type t, object obj)
        {
            if(t.IsDefined(typeof(TableMapAttribute),false))
            {
                TableMapAttribute tablemap = Attribute.GetCustomAttribute(t,typeof(TableMapAttribute)) as TableMapAttribute;
                TableMap tm = new TableMap();
                tm.TableName =tablemap.TableName;
                tm.PrimaryKeyName = tablemap.PrimaryKey;
                tables.Add(tm);
                //解析字段
                PropertyInfo[] p = t.GetProperties();
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].IsDefined(typeof(FieldMapAttribute), false))
                    {
                        ///这里 可以考虑加个属性 是否主键，如果是的，就加到tm里面去
                        FieldMapAttribute tp = Attribute.GetCustomAttribute(p[i], typeof(FieldMapAttribute)) as FieldMapAttribute;
                        if (!tp.IsIdentity) //解决自增列
                        {
                               Field Col = new Field(p[i].PropertyType, tp.ColumnName, p[i].GetValue(obj, null),tp.MustInput);
                                if (!Col.isDBNull)//如果是空的话 就不加了.
                                { 
                                    tm.Columns.Add(Col);
                                    if (!tp.CanRepeat) //如果不能重复， 就增加到这个里面
                                    {
                                        unique.Add(Col);
                                    }
                                }
                                
                        
                        }
                    }
                    else if (p[i].IsDefined(typeof(ExclusiveAttribute), false))
                    {
                        //FieldMapAttribute tp = Attribute.GetCustomAttribute(p[i], typeof(FieldMapAttribute)) as FieldMapAttribute;
                        //Field Col = new Field(p[i].PropertyType, tp.ColumnName, p[i].GetValue(obj, null));
                        //tm.UnMapingColumns.Add(Col);
                    }
                    else if (p[i].IsDefined(typeof(SubObjectAttribute), false))
                    {
                        SubObjectAttribute sb = Attribute.GetCustomAttribute(p[i], typeof(SubObjectAttribute)) as SubObjectAttribute;
                        Type ty = sb.SubObjectType;
                        if (p[i].GetValue(obj, null) != null)
                        {
                            if (ty.FullName == "ServiceInterface.Entitys.InvoiceTotalEntity")
                            {
                                object o = p[i].GetValue(obj, null) as object;
                                // System.Collections.ArrayList c = p[i].GetValue(obj, null) as System.Collections.ArrayList;
                                ResolveTables(ty, o);

                            }
                            else if (ty.FullName == "ServiceInterface.Entitys.InvoiceCostEntity")
                            {
                                object o = p[i].GetValue(obj, null) as object;
                                // System.Collections.ArrayList c = p[i].GetValue(obj, null) as System.Collections.ArrayList;
                                ResolveTables(ty, o);

                            }
                            else
                            {
                                //  System.Collections.ArrayList c = p[i].GetValue(obj, null) as System.Collections.ArrayList;
                                System.Collections.IList c = p[i].GetValue(obj, null) as System.Collections.IList;
                                for (int k = 0; k < c.Count; k++)
                                {
                                    ResolveTables(ty, c[k]);
                                }
                            }
                        }
                 
                        //if (p[i].GetValue(obj, null) != null)
                        //{
                        //   //  System.Collections.ArrayList c = p[i].GetValue(obj, null) as System.Collections.ArrayList;
                        //   System.Collections.IList c = p[i].GetValue(obj, null) as System.Collections.IList;
                        //    for (int k = 0; k < c.Count; k++)
                        //    {
                        //        ResolveTables(ty, c[k]);
                        //    }
                        //}
                    }
                    else if (p[i].IsDefined(typeof(ItemObjectAttribute), false))
                    {
                        ItemObjectAttribute iob = Attribute.GetCustomAttribute(p[i], typeof(ItemObjectAttribute)) as ItemObjectAttribute;
                        Type ty = iob.ItemObjectType;
                        object dd = p[i].GetValue(obj, null);
                        if (dd!= null)
                        { 
                           PropertyInfo[] infos=ty.GetProperties();
                           string _values = "";
                            for(int s=0;s<infos.Length;s++)
                            {
                                if (infos[s].Name == iob.ItemField)
                                {
                                    _values = infos[s].GetValue(dd, null).ToString();
                                    break;
                                }
                            }
                            if (_values.Trim() != "")
                            {
                                Field Col = new Field(iob.SqlField, _values);
                            }
                        }
                    }

                }
            }
        } 
        /// <summary>
        /// 检查是否能重复
        /// </summary>
        public void CheckInfo()
        {
            string cond = "";
            for (int i = 0; i < unique.Count; i++)
            {
                if (cond.ToString() != "")
                {
                    
                    cond +=" or ";

                }
                cond += unique[i].ToString();
            }
             
            Fields allcol = tables[0].Columns; //这里 是不想修改tables[0].Columns里面的列
            Fields conds = GetPkFeilds(allcol, tables[0].PrimaryKeyName);//
            cond += "  and  " + conds.ToConditionByhu() ;
            string selestr = string.Concat("select count(*) from", tables[0].TableName, "where",cond);
            int ss = 0;
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                ss=db.GetScalar<int>(selestr);
            }
            if (ss == 0)
            {
                throw new Exception("重复了，请检查字段");
            }
        }
        #region 私有方法
        /// <summary>
        /// 得到所有的表名，当然不包括主体多层嵌套的
        ///</summary>
        ///<returns></returns>
        private Hashtable GetAllTables()
        {
            Hashtable hash = new Hashtable();
            for (int i = 1; i < tables.Count; i++)
            {
                if (!hash.Contains(tables[i].TableName.ToString().Trim()))
                {
                    hash.Add(tables[i].TableName.Trim(), tables[i].TableName.Trim());
                }
            }
            return hash;
        }
        /// <summary>
        /// 根据主键得到所有的主键字段
        /// </summary>
        /// <param name="allField">包括所有的主键字段</param>
        /// <param name="pkName">主键名称</param>
        /// <returns></returns>
       private  Fields GetPkFeilds(Fields allField,string[] pkName)
        {
            Fields pkfields = new Fields();
            for (int i = 0; i < pkName.Length; i++)
            {
                pkfields.Add(allField.GetField(pkName[i].ToString()));
                allField.Remove(pkName[i].ToString()); //这里要移除主键
            }
            return pkfields;
        }
        #endregion
        #region 公有方法
        #region  新增
        //新增SQL 语句
         public string insert()
         {
             string selestr = "";
             for (int i = 0; i < tables.Count; i++)
             {
                 selestr += string.Concat("insert into ", tables[i].TableName, "(", tables[i].Columns.ToFieldNameList(), ")", "values", "(", tables[i].Columns.ToFieldValueList(), ")\n");
             }
             return selestr;
         }
        /// <summary>
        /// 这个是不用映射，提高效率
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="?">字段名</param>
        /// <returns></returns>
        public string insert(string tablename, Fields fields)
        {
            string selectr = string.Concat("insert into", tablename, "(", fields.ToFieldNameList(), ")", "values(", fields.ToFieldValueList(), ")\n");
            return selectr;
        }
        /// <summary>
        /// 单一表头，多表体的情况，也是不用影射 这几使用
        /// </summary>
        /// <param name="tableName">主表名称</param>
        /// <param name="tableNameentry">表体名称集合</param>
        /// <param name="fileds">表头信息</param>
        /// <param name="entryfileds">表体信息</param>
        /// <returns></returns>
        public string insert(string tableName, List<string> tableNameentry, Fields fields, List<List<Fields>> entryfileds)
        {
            string selectr = string.Concat("insert into", tableName, "(", fields.ToFieldNameList(), ")", "values(", fields.ToFieldValueList(), ")");
            if (tableNameentry.Count != 0 && entryfileds.Count != 0)
            {
                if (tableNameentry.Count != entryfileds.Count)
                {
                    throw new Exception("表名和字段体名不一致");
                }
                else
                {
                    for (int i = 0; i < tableNameentry.Count; i++)
                    {
                        List<Fields> fds = entryfileds[i];
                        for (int j = 0; j < fds.Count; j++)
                        {
                            Fields fd = fds[i];
                            selectr += insert(tableNameentry[i], fd);
                        }
                    }

                }
            }

            return selectr;
        }
        #endregion
        #region 修改
        //修改SQL语句 适合 先删除分录，后插入分录的例子
        public string update()
        {
            string operatestr = "";
            Fields allcol = tables[0].Columns; //这里 是不想修改tables[0].Columns里面的列
            Fields cond = GetPkFeilds(allcol, tables[0].PrimaryKeyName);//
            if (tables.Count>1)
            {// 当它有分录的时候， 要删除分录，再插入分录，然后修改单据头
                Hashtable hss = GetAllTables();
                //删除分录
                foreach (DictionaryEntry de in hss)
                {
                    if (de.Value.ToString() == "t_InvoiceEntry2" )
                    {
                        string cond2 = "1=1";
                        for (int i = 0; i < cond.Count; i++)
                        {
                            cond2 += " and [FInterID2]=" + cond[0].Value;
                        }
                        operatestr += "\n delete from " + de.Value.ToString() + " where " + cond2 + " ";
                    }
                    else if (de.Value.ToString() == "t_InvoiceEntry3")
                    {
                        string cond2 = "1=1";
                        for (int i = 0; i < cond.Count; i++)
                        {
                            cond2 += " and [FInterID3]=" + cond[0].Value;
                        }
                        operatestr += "\n delete from " + de.Value.ToString() + " where " + cond2 + " ";
                    }
                    else
                    {
                        operatestr += "\n delete from " + de.Value.ToString() + " where " + cond.ToCondition() + " ";
                    }
                }
                //插入分录
                for (int i = 1; i < tables.Count; i++)
                {
                   operatestr += "\n insert into " + tables[i].TableName + "(" + tables[i].Columns.ToFieldNameList() + ") values (" + tables[i].Columns.ToFieldValueList() + ")";
                }
                operatestr += "\n update " + tables[0].TableName + " set " + allcol.ToUpdateString() + " where " + cond.ToCondition() + "";
            }
            else
            {
                operatestr += " update " + tables[0].TableName + " set " + allcol.ToUpdateString() + " where " + cond.ToCondition() + "";
            }
            return operatestr;
        }
        /// <summary>
        /// 更新不用映射
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="upfields">被更新的字段</param>
        /// <param name="condfield">条件字段</param>
        /// <returns></returns>
        public string update(string tablename, Fields upfields, Fields condfield)
        {

            string upstr = string.Concat("update",tablename,"set",upfields.ToUpdateString(),"where",condfield.ToCondition());
            return upstr;
        }
        #endregion
        #region 删除
        //删除SQL,  
        /// <summary>
        ///  删除SQL,当isremove的值 为false 时，就修改删除，否则 就直接删除
        /// </summary>
        /// <param name="isremove"></param>
        /// <returns></returns>
        public string delete(bool isremove, string delFieldName = "FDeleted")
        {
            string operatestr = "";
            if (!isremove)
            {
                operatestr = "update " + tables[0].TableName + " set " + delFieldName + "=1";
                Fields cond = GetPkFeilds(tables[0].Columns, tables[0].PrimaryKeyName);
                operatestr += " where " + cond.ToCondition();
            }
            else
            {
                 Fields allcol = tables[0].Columns; //这里 是不想修改tables[0].Columns里面的列
                 Fields cond = GetPkFeilds(allcol, tables[0].PrimaryKeyName);//
                operatestr = string.Concat("delete from ", tables[0].TableName," where ",cond.ToCondition());
                if (tables.Count > 1)
                {
                    Hashtable hss = GetAllTables();
                    foreach (DictionaryEntry de in hss)
                    {
                        operatestr += "\n delete from " + de.Value.ToString() + "  where  " + cond.ToCondition() + " ";
                    }
                }
    
               
            }
            return operatestr;
        }
        /// <summary>
        /// 删除单表
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="condfields"></param>
        /// <returns></returns>
        public string delete(string tablename, Fields condfields)
        {
            string selestr = string.Concat("delete from ",tablename,"where",condfields.ToCondition(),"\n");
            return selestr;
        }
        /// <summary>
        /// 删除单据多表的时候
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condfileds"></param>
        /// <returns></returns>
        public string delete(List<string> tableName, List<List<Fields>> condfileds)
        {
            string deletestr = "";
            if (tableName.Count != condfileds.Count)
            {
                throw new Exception("表名和条件不一致");
            }
            for (int i = 0; i < tableName.Count; i++)
            {
                List<Fields> fds = condfileds[i];
                for (int j = 0; j < fds.Count; j++)
                {
                    deletestr += delete(tableName[i], fds[j]);
                }
            }

            return deletestr;
        }

        #endregion
        #region 查询
        //查询SQL语句用处不是很大
        public string query()
        {
            Fields allcol = tables[0].Columns; //这里 是不想修改tables[0].Columns里面的列
            Fields cond = GetPkFeilds(allcol, tables[0].PrimaryKeyName);//
            string  operatestr = string.Concat("select * from ",tables[0].TableName , "where", cond.ToCondition());
            if (tables.Count > 1)
            {
                Hashtable hss = GetAllTables();
                foreach (DictionaryEntry de in hss)
                { 
                    operatestr += "\n select *  from " + de.Value.ToString() + " where " + cond.ToCondition() + " ";
                }
            }
            return operatestr;
        }
        public string query(string tablename, Fields sqlcond)
        {
            return query("", tablename, sqlcond);
        }
        public string query(string field, string tablename, Fields sqlcond)
        {
            string selestr = "";
            if (field == "")
            {
                selestr = string.Concat("select * from ", tablename, " where ", sqlcond.ToCondition());
            }
            else
            {
                selestr = string.Concat("select " ,field," from ", tablename, " where ", sqlcond);
            }
            return selestr;
        }
        public string query(List<string> findfield, string tablename, Fields sqlcond)
        {
            string selestr = "";
            if (findfield.Count != 0)
            {
                selestr = query(tablename, sqlcond);
            }
            else
            {
                string queryfield = getfieldstr(findfield);
                
                selestr = query(queryfield, tablename, sqlcond);
            }
            return selestr;
        }
        string getfieldstr(List<string> findfield)
        {
            string queryfield = "";
            for (int i = 0; i < findfield.Count; i++)
            {
                if (queryfield.Trim() != "")
                {
                    queryfield += ",";
                }
                queryfield += string.Concat("[", findfield[i].Trim(), "]");
            }
            return queryfield;
        }
        public string query(string tablename, string condstr, string orderby)
        {
            string selestr = "";
            if (orderby.Trim() == "")
            {
                selestr = string.Concat("select * from ", tablename, "  where 1=1 ", condstr);
            }
            else
            {
                selestr = string.Concat("select * from ", tablename, " where 1=1 ", condstr,"order by",orderby);
            }
            return selestr;
        }
        public string query(List<string> findfield, string tablename, string condstr, string orderby)
        {
            string queryfield = getfieldstr(findfield);
            string selestr="";
            if (queryfield.Trim() == "")
            {
                selestr = query(tablename, condstr, orderby);
            }
            else
            {
                selestr = string.Concat("select",queryfield," from ", tablename, "where 1=1", condstr, "order by", orderby);
             
            }
            return selestr;
        }
       
        #endregion
        #endregion

        /// <summary>
        /// 检查是否有字段不满足必填项设置(只返回找到的第一个字段名)
        /// </summary>
        /// <returns></returns>
        public string GEtMustInputFieldName()
        {
            for (int i = 0; i < tables.Count; i++)
            {
                foreach (var item in tables[i].Columns)
	            {
                    if (!item.CheckMustInput())
                        return item.FieldName;
	            } 
            }
            return "";
        }
    }
}