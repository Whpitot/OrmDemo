using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Reflection;


namespace WMSDAL.Entry
{
    using WMSDAL.Sql;
    using WMSDAL.Map;

    public class EntryObject
    {


        public virtual void add(params SqlParameter[] pars)
        {
            OpreaEntity<EntryObject> obj = new OpreaEntity<EntryObject>(this);
            using (DbSession db = Db.Get())
            {
                try
                {
                    db.OpenConnection();
                    db.BeginTrans();
                    string sql = obj.insert();
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

        public virtual void update()
        {
            OpreaEntity<EntryObject> obj = new OpreaEntity<EntryObject>(this);
            using (DbSession db = Db.Get())
            {
                try
                {
                    db.OpenConnection();
                    db.BeginTrans();
                    string sql = obj.update();
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

        public virtual void deleted(bool isremove)
        {
            OpreaEntity<EntryObject> obj = new OpreaEntity<EntryObject>(this);
            using (DbSession db = Db.Get())
            {
                try
                {
                    db.OpenConnection();
                    db.BeginTrans();
                    db.ExecNoQuery(obj.delete(isremove));
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

        public virtual void GetInstance(EntryObject obj, DataTable dt)
        {
            PropertyInfo[] infos = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in infos)
            {
                if(pi.IsDefined(typeof(FieldMapAttribute),false))
                {
                    FieldMapAttribute fp=Attribute.GetCustomAttribute(pi,typeof(FieldMapAttribute))as FieldMapAttribute;
                    string FName=fp.ColumnName;
                    if (pi.PropertyType == typeof(System.Guid))
                    {
                        pi.SetValue(obj, new Guid(dt.Rows[0][FName].ToString()), null);
                    }                                
                }
            }
        }
    }
}
