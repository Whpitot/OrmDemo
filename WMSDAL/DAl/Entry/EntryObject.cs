using System;
using System.Collections.Generic;
using System.Text;
using DAl.Sql;
using System.Data;
using System.Reflection;
using DAl.Map;
using DAl;
using System.Collections;
namespace DAl.Entry
{
    [System.Serializable]
    public class EntryObject  
    {
        public EntryObject()
        {
        
        }
         
        public virtual int GetMaxID(string tableName)
        {
            return Common.GetMaxNum(tableName);
        }
        public virtual string GetBillNum(string tablename,int issave)
        {
            return Common.GetBillNum(tablename, issave);
        }
        public virtual string beforestr()
        {
            return " ";
        }
        private   string _befstr;

        public string    Befstr 
        {
            get { return _befstr; }
            set { _befstr = value; }
        }
        private string _afterstr;

        public string Afterstr
        {
            get { return _afterstr; }
            set { _afterstr = value; }
        }
        public virtual string afterstr()
        {
            return "";
        }
        private string _operatename;
        /// <summary>
        ///操作单据的名称,方便记录日志
       /// </summary>
        public string OperateName
        {
            get { return _operatename; }
            set { _operatename = value; }
        }

       /// <summary>
        /// 新增
       /// </summary>
        public virtual void add()
        {   

            EntryOperate<EntryObject>  obj=new EntryOperate<EntryObject>(this);
           
            using (DbSession db = Db.Get())
            {
                try
                {
                    if (Befstr == null)
                    {
                        Befstr = " ";
                    }
                    db.OpenConnection();
                    db.BeginTrans();
                    string sql = Befstr + Environment.NewLine + beforestr() + Environment.NewLine + obj.insert() + Environment.NewLine + afterstr() + Environment.NewLine + Afterstr + Environment.NewLine;
                    db.ExecNoQuery(sql);
                    db.Commit();
                }
                catch (Exception er)
                {
                    db.Rollback();
                    db.CloseConnection();
                    throw new Exception(er.ToString());
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public virtual void addAgain()
        {

            EntryOperate<EntryObject> obj = new EntryOperate<EntryObject>(this);

            using (DbSession db = Db.Get("k3"))
            {
                try
                {
                    if (Befstr == null)
                    {
                        Befstr = " ";
                    }
                    db.OpenConnection();
                    db.BeginTrans();
                    string sql = Befstr + Environment.NewLine + beforestr() + Environment.NewLine + obj.insert() + Environment.NewLine + afterstr() + Environment.NewLine + Afterstr + Environment.NewLine;
                    db.ExecNoQuery(sql);
                    db.Commit();
                }
                catch (Exception er)
                {
                    db.Rollback();
                    db.CloseConnection();
                    throw new Exception(er.ToString());
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }


       //修改
        public virtual void update()
        {
            EntryOperate<EntryObject>  obj=new EntryOperate<EntryObject>(this);
            using (DbSession db = Db.Get())
            {
                try
                {
                    if (Befstr == null)
                    {
                        Befstr = " ";
                    }
                    db.OpenConnection();
                    db.BeginTrans();
                    string sql = Befstr + beforestr() + obj.update() + afterstr() + Afterstr;
                    db.ExecNoQuery(sql);
                    db.Commit();
                }
                catch (Exception er)
                {
                    db.Rollback();
                    db.CloseConnection();
                    throw new Exception(er.ToString());
                }
                finally
                {
                    db.CloseConnection();
                }
           
        }}
       //删除
        public virtual void deleted(bool isremove, string delFieldName = "FDeleted")
        {
            EntryOperate<EntryObject> obj = new EntryOperate<EntryObject>(this);
            using (DbSession db = Db.Get())
            {
                try
                {
                    db.OpenConnection();
                    db.BeginTrans();
                    db.ExecNoQuery(obj.delete(isremove, delFieldName));
                    db.Commit();
                }
                catch (Exception er)
                {
                    db.Rollback();
                    db.CloseConnection();
                    throw new Exception(er.ToString());
                }
                finally
                {
                    db.CloseConnection();
                }

            }
        }
        /// <summary>
        ///  给实体类赋值
        /// </summary>
        /// <param name="ht"></param>
        public virtual void SetValues(Hashtable ht)
        {
            Type t = this.GetType();
            PropertyInfo[] ps = t.GetProperties();
            foreach (PropertyInfo p in ps)
            {
                if (ht.ContainsKey(p.Name))
                {
                    p.SetValue(this, Convert.ChangeType(ht[p.Name], p.PropertyType), null);
                }
            }
        }
        public DataTable getinfo(string FTableName,Fields sqlcond)
        {
            EntryOperate<EntryObject> obj = new EntryOperate<EntryObject>();
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
               return db.Query(obj.query(FTableName,sqlcond));
            }
        }
        public DataSet getinfo(List<string> findfield, string tablename, string condstr, string orderby)
        {
            EntryOperate<EntryObject> obj = new EntryOperate<EntryObject>();
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.DataQuery(obj.query(findfield,tablename,condstr,orderby));
            }
        }
        public virtual void getInstance(EntryObject obj, DataTable dt)
        {
            Type t = obj.GetType();
            PropertyInfo[] ps = t.GetProperties();
            foreach (PropertyInfo p in ps)
            {
                if (p.IsDefined(typeof(FieldMapAttribute), false))
                {
                    //   FieldMapAttribute fb = Attribute.GetCustomAttribute(p, typeof(FieldMapAttribute)) as FieldMapAttribute;
                    //   string FName = fb.ColumnName;
                    //   p.SetValue(obj,Convert.ChangeType(dt.Rows[0][FName].ToString(),p.PropertyType),null);
                    //}
                    FieldMapAttribute fb = Attribute.GetCustomAttribute(p, typeof(FieldMapAttribute)) as FieldMapAttribute;
                    string FName = fb.ColumnName;
                    if (p.PropertyType == typeof(System.Guid))
                    {
                        p.SetValue(obj, new Guid(dt.Rows[0][FName].ToString()), null);
                    }
                    else
                    {
                        if ((p.PropertyType == typeof(DateTime) || p.PropertyType.Name == "Nullable`1") && dt.Rows[0][FName].ToString().Trim() == "")
                        {

                        }
                        else
                        {
                            if (p.PropertyType.Name == "Nullable`1")
                            {
                                p.SetValue(obj, DateTime.Parse(dt.Rows[0][FName].ToString()), null);
                            }
                            else
                            {
                                p.SetValue(obj, Convert.ChangeType(dt.Rows[0][FName].ToString(), p.PropertyType), null);
                            }
                        }
                    }
                }
                if (p.IsDefined(typeof(ExclusiveAttribute), false))
                {
                    if ((p.PropertyType == typeof(DateTime) || p.PropertyType.Name == "Nullable`1") && dt.Rows[0][p.Name].ToString().Trim() == "")
                    {

                    }
                    else
                    {

                        if (p.PropertyType.Name == "Nullable`1")
                        {
                            p.SetValue(obj, DateTime.Parse(dt.Rows[0][p.Name].ToString()), null);
                        }
                        else
                        {
                            p.SetValue(obj, Convert.ChangeType(dt.Rows[0][p.Name].ToString(), p.PropertyType), null);
                        }
                    }
                }

            }
             
        }
        public virtual void getInstance(EntryObject obj, DataSet ds)
        {
            Type t = obj.GetType();
            PropertyInfo[] ps = t.GetProperties();
            int _entry = 1;
            foreach (PropertyInfo p in ps)
            {
                if (p.IsDefined(typeof(FieldMapAttribute), false))
                { 
                    FieldMapAttribute fb=Attribute.GetCustomAttribute(p,typeof(FieldMapAttribute)) as FieldMapAttribute;
                    string FName=fb.ColumnName;
                    if (p.PropertyType == typeof(System.Guid))
                    {
                        p.SetValue(obj,new Guid(ds.Tables[0].Rows[0][FName].ToString()), null);
                    }
                    else
                    {
                        if ((p.PropertyType == typeof(DateTime) || p.PropertyType.Name == "Nullable`1") && ds.Tables[0].Rows[0][FName].ToString().Trim() == "")
                        {

                        }
                        else
                        {
                            if (p.PropertyType.Name == "Nullable`1")
                            { 
                                p.SetValue(obj,DateTime.Parse(ds.Tables[0].Rows[0][FName].ToString()), null);
                            }
                            else
                            {
                                p.SetValue(obj, Convert.ChangeType(ds.Tables[0].Rows[0][FName].ToString(), p.PropertyType), null);
                            }
                        }
                    }
                }
                if(p.IsDefined(typeof(ExclusiveAttribute),false))
                {
                    if ((p.PropertyType == typeof(DateTime) || p.PropertyType.Name == "Nullable`1") && ds.Tables[0].Rows[0][p.Name].ToString().Trim() == "")
                    {

                    }
                    else
                    {

                        if (p.PropertyType.Name == "Nullable`1")
                        {
                            p.SetValue(obj,DateTime.Parse(ds.Tables[0].Rows[0][p.Name].ToString()), null);
                        }
                        else
                        {
                            p.SetValue(obj, Convert.ChangeType(ds.Tables[0].Rows[0][p.Name].ToString(), p.PropertyType), null);
                        }
                    }
                }
                if(p.IsDefined(typeof(SubObjectAttribute), false))
                {  
                    SubObjectAttribute sb = Attribute.GetCustomAttribute(p, typeof(SubObjectAttribute)) as SubObjectAttribute;

                   Type listentry = sb.ListObjectType;
                   object objentrylist = Activator.CreateInstance(listentry);
                    MethodInfo mi = objentrylist.GetType().GetMethod("Add"); 
                   // ArrayList objentrylist = new ArrayList();
                    Type ty = sb.SubObjectType;
                    for (int i = 0; i <ds.Tables[_entry].Rows.Count; i++)
                    {    // object objentry = ty.Assembly.CreateInstance(ty.FullName);//这里创建了一个实体
                        object objentry;
                        try
                        {
                            objentry = Activator.CreateInstance(ty);
                        }
                        catch (Exception er)
                        {
                            throw er;
                        }
                       
                        Type centry = objentry.GetType();
                        PropertyInfo[] psentry = centry.GetProperties();
                        foreach (PropertyInfo pe in psentry)
                        {
                            
                            if (pe.IsDefined(typeof(FieldMapAttribute), false))
                            {
                              
                                FieldMapAttribute fb = Attribute.GetCustomAttribute(pe, typeof(FieldMapAttribute)) as FieldMapAttribute;
                                string FName = fb.ColumnName;
                                if (ds.Tables[_entry].Columns.Contains(FName))
                                {
                                    if (pe.PropertyType == typeof(System.Guid))
                                    {
                                        pe.SetValue(objentry,new Guid(ds.Tables[_entry].Rows[i][FName].ToString()), null);
                                    }
                                    else
                                    {
                                        pe.SetValue(objentry, Convert.ChangeType(ds.Tables[_entry].Rows[i][FName].ToString(), pe.PropertyType), null);
                                    }
                                }
                            }
                            if (pe.IsDefined(typeof(ExclusiveAttribute), false))
                            {
                                pe.SetValue(objentry, Convert.ChangeType(ds.Tables[_entry].Rows[i][pe.Name].ToString(), pe.PropertyType), null);
                            }
                        }
                        mi.Invoke(objentrylist, new object[] { objentry });
                    }
                 
                    p.SetValue(obj,Convert.ChangeType(objentrylist, p.PropertyType),null);
                    _entry++;
                }
            }
        }
       protected  SqlCheck dd;
       protected void SetCheck()
        {
            if (dd == null)
            {
                dd = new SqlCheck();
            }
            else
            {
                dd.Deletecount = 0;
                dd.Insertcount = 0;
                dd.Selectcount = 0;
            }
        }

       /// <summary>
       /// 检查是否有字段不满足必填项设置(只返回找到的第一个字段名)
       /// </summary>
       /// <returns></returns>
        protected virtual string GetMustinputFieldName()
        {
            EntryOperate<EntryObject> obj = new EntryOperate<EntryObject>(this);
            return obj.GEtMustInputFieldName();
        }
       //通过ID 得到实体
        //public virtual EntryObject getByID()
        //{
        //    using (DbSession db = Db.Get())
        //    {

        //    }
        //}
        //public virtual DataSet GetInfo()
        //{ 
        
        //}

        public virtual DataTable GetData(string sql)
        {
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.DataQuery(sql).Tables[0];
            }
        }

        public virtual void UpDataSql(string sql)
        {
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                db.ExecNoQuery(sql);
            }
        }
    }
}
