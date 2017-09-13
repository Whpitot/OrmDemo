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
        /// ����ʵ��������ɾ�����޸ĵ�ʱ�򣬾���������캯��
        /// </summary>
        /// <param name="obj"></param>
        public EntryOperate(T obj)
        {
            Type t = obj.GetType();
            ResolveTables(t, obj);
        }
        /// <summary>
        /// ���������� �������ϳ����޸ĵ�ʱ�򣬾������
        /// </summary>
        public EntryOperate()
        { 

        }
        /// <summary>
        /// �õ�ʵ������Ҫ�ύ���Ͳ���Ҫ�ύ���ֶ�.
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
                //�����ֶ�
                PropertyInfo[] p = t.GetProperties();
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].IsDefined(typeof(FieldMapAttribute), false))
                    {
                        ///���� ���Կ��ǼӸ����� �Ƿ�����������ǵģ��ͼӵ�tm����ȥ
                        FieldMapAttribute tp = Attribute.GetCustomAttribute(p[i], typeof(FieldMapAttribute)) as FieldMapAttribute;
                        if (!tp.IsIdentity) //���������
                        {
                               Field Col = new Field(p[i].PropertyType, tp.ColumnName, p[i].GetValue(obj, null),tp.MustInput);
                                if (!Col.isDBNull)//����ǿյĻ� �Ͳ�����.
                                { 
                                    tm.Columns.Add(Col);
                                    if (!tp.CanRepeat) //��������ظ��� �����ӵ��������
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
        /// ����Ƿ����ظ�
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
             
            Fields allcol = tables[0].Columns; //���� �ǲ����޸�tables[0].Columns�������
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
                throw new Exception("�ظ��ˣ������ֶ�");
            }
        }
        #region ˽�з���
        /// <summary>
        /// �õ����еı�������Ȼ������������Ƕ�׵�
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
        /// ���������õ����е������ֶ�
        /// </summary>
        /// <param name="allField">�������е������ֶ�</param>
        /// <param name="pkName">��������</param>
        /// <returns></returns>
       private  Fields GetPkFeilds(Fields allField,string[] pkName)
        {
            Fields pkfields = new Fields();
            for (int i = 0; i < pkName.Length; i++)
            {
                pkfields.Add(allField.GetField(pkName[i].ToString()));
                allField.Remove(pkName[i].ToString()); //����Ҫ�Ƴ�����
            }
            return pkfields;
        }
        #endregion
        #region ���з���
        #region  ����
        //����SQL ���
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
        /// ����ǲ���ӳ�䣬���Ч��
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="?">�ֶ���</param>
        /// <returns></returns>
        public string insert(string tablename, Fields fields)
        {
            string selectr = string.Concat("insert into", tablename, "(", fields.ToFieldNameList(), ")", "values(", fields.ToFieldValueList(), ")\n");
            return selectr;
        }
        /// <summary>
        /// ��һ��ͷ�������������Ҳ�ǲ���Ӱ�� �⼸ʹ��
        /// </summary>
        /// <param name="tableName">��������</param>
        /// <param name="tableNameentry">�������Ƽ���</param>
        /// <param name="fileds">��ͷ��Ϣ</param>
        /// <param name="entryfileds">������Ϣ</param>
        /// <returns></returns>
        public string insert(string tableName, List<string> tableNameentry, Fields fields, List<List<Fields>> entryfileds)
        {
            string selectr = string.Concat("insert into", tableName, "(", fields.ToFieldNameList(), ")", "values(", fields.ToFieldValueList(), ")");
            if (tableNameentry.Count != 0 && entryfileds.Count != 0)
            {
                if (tableNameentry.Count != entryfileds.Count)
                {
                    throw new Exception("�������ֶ�������һ��");
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
        #region �޸�
        //�޸�SQL��� �ʺ� ��ɾ����¼��������¼������
        public string update()
        {
            string operatestr = "";
            Fields allcol = tables[0].Columns; //���� �ǲ����޸�tables[0].Columns�������
            Fields cond = GetPkFeilds(allcol, tables[0].PrimaryKeyName);//
            if (tables.Count>1)
            {// �����з�¼��ʱ�� Ҫɾ����¼���ٲ����¼��Ȼ���޸ĵ���ͷ
                Hashtable hss = GetAllTables();
                //ɾ����¼
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
                //�����¼
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
        /// ���²���ӳ��
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="upfields">�����µ��ֶ�</param>
        /// <param name="condfield">�����ֶ�</param>
        /// <returns></returns>
        public string update(string tablename, Fields upfields, Fields condfield)
        {

            string upstr = string.Concat("update",tablename,"set",upfields.ToUpdateString(),"where",condfield.ToCondition());
            return upstr;
        }
        #endregion
        #region ɾ��
        //ɾ��SQL,  
        /// <summary>
        ///  ɾ��SQL,��isremove��ֵ Ϊfalse ʱ�����޸�ɾ�������� ��ֱ��ɾ��
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
                 Fields allcol = tables[0].Columns; //���� �ǲ����޸�tables[0].Columns�������
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
        /// ɾ������
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
        /// ɾ�����ݶ���ʱ��
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condfileds"></param>
        /// <returns></returns>
        public string delete(List<string> tableName, List<List<Fields>> condfileds)
        {
            string deletestr = "";
            if (tableName.Count != condfileds.Count)
            {
                throw new Exception("������������һ��");
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
        #region ��ѯ
        //��ѯSQL����ô����Ǻܴ�
        public string query()
        {
            Fields allcol = tables[0].Columns; //���� �ǲ����޸�tables[0].Columns�������
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
        /// ����Ƿ����ֶβ��������������(ֻ�����ҵ��ĵ�һ���ֶ���)
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