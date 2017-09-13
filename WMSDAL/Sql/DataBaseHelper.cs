using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Data.Common;


namespace WMSDAL.Sql
{
    public class DataBaseHelper  //这一层结构是不变的
    {

       

        public static string ConnString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            }
            
        }
                                     
        public static int ExecNoQuery(string SQLstr, params SqlParameter[] pars)
        {
           
            
                using (SqlConnection conn = new SqlConnection(DataBaseHelper.ConnString))
                {
                    if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                    {
                        conn.Open();
                    }
                    SqlTransaction tran = conn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.CommandText = SQLstr;

                    if (pars.Length > 0)
                        cmd.Parameters.AddRange(pars);

                    int count = cmd.ExecuteNonQuery();

                    tran.Commit();
                    tran.Dispose();
                    tran = null;

                    return count;
                }                                
        }
       

        public T GetScalar<T>(string sql, SqlParameter[] pars)
        {
            object val = GetScalar(sql, pars);
            return ConvertType<T>(val);

        }

        public static object GetScalar(string SQLstr,params SqlParameter[] pars)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnString))
                {
                    if (Conn.State == ConnectionState.Closed || Conn.State == ConnectionState.Broken)
                    {
                        Conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQLstr, Conn);
                    if (pars.Length > 0)
                        cmd.Parameters.AddRange(pars);
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Execute sql error:" + ex.Message);
            }
        }
       
       /// <summary>      
       /// 把在datatable中的数据加载到实体
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="table"></param>
       /// <returns></returns>
        public static T[] GetEntities<T>(DataTable table) where T : new() 
        {
            T[] entities = new T[table.Rows.Count];
            int _index = 0;
            foreach (DataRow row in table.Rows)
            {
                T entity = new T();
                foreach (var item in entity.GetType().GetProperties())
                {
                    if (row.Table.Columns.Contains(item.Name))
                        if (!item.PropertyType.IsGenericType)
                        {
                            item.SetValue(entity, row[item.Name] == System.DBNull.Value ? null : Convert.ChangeType(row[item.Name], item.PropertyType), null);
                        }
                        else
                        {
                            if (item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                item.SetValue(entity, row[item.Name] == null || string.IsNullOrEmpty(row[item.Name].ToString()) ? null : Convert.ChangeType(row[item.Name], Nullable.GetUnderlyingType(item.PropertyType)), null);
                            else

                                item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                        }
                }
                
                entities[_index++] = entity;
            }
            return entities;
        }

        //把实体中的值加载到文本框。
        //取得窗体中所有控件的值
        //然后一次赋值即可
        #region ConvertType 类型转化。
        public static T ConvertType<T>(object val, T defaultvalue)
        {
            if (val == null || val == DBNull.Value)
                return defaultvalue;
            try
            {
                Type type = Nullable.GetUnderlyingType(typeof(T));//获取到实际类型
                if (type == null)
                {
                    return (T)Convert.ChangeType(val, typeof(T));
                }
                else
                {
                    return (T)Convert.ChangeType(val, type);
                }
            }
            catch (Exception)
            {
                return defaultvalue;
            }
        }
        public static T ConvertType<T>(object val)
        {
            return ConvertType<T>(val, default(T));
        }

        public static T GetScalar<T>(string sql)
        {
            object val = GetScalar(sql);
            return ConvertType<T>(val);
        }
        #endregion       
    }
}
