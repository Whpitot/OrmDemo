using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Text.RegularExpressions;
using NBear.Mapping;

namespace DAl.Sql
{
    /// <summary>
    /// 数据连接会话
    /// </summary>s
    public partial class DbSession : IDisposable
    {
        #region Construct
        DbProviderFactory _dbprovider;
        public DbSession(string privatename, string conns)
        {
            _dbprovider = DbProviderFactories.GetFactory(privatename);
            _cn = _dbprovider.CreateConnection();
            _cn.ConnectionString = conns;
            _trans = null;

        }
        public DbSession(string cns)
            : this("System.Data.SqlClient", cns)
        {
        }

        #endregion
        #region Transaction
        DbConnection _cn;
        DbTransaction _trans;
        public void OpenConnection()
        {
            _cn.Open();
        }
        public void CloseConnection()
        {
            _cn.Close();
        }
        public bool IsInTransaction
        {
            get { return _trans != null; }
        }
        public IDbTransaction BeginTrans()
        {
            if (IsInTransaction)
            {
                throw new DataException("当前还有事务还未提交");
            }
            _trans = _cn.BeginTransaction();
            return _trans;
        }

        public void Commit()
        {
            _trans.Commit();
            _trans.Dispose();
            _trans = null;
        }

        public void Rollback()
        {
            _trans.Rollback();
            _trans.Dispose();
            _trans = null;
        }
        #endregion
        #region IDisposable 成员

        public void Dispose()
        {
            if (_trans != null) _trans.Dispose();
            if (_cn != null) _cn.Dispose();
        }

        #endregion
        #region 参数构造
        DbParameter[] BuildParams(string sql, params object[] args)
        {
            List<DbParameter> pl = new List<DbParameter>();
            Dictionary<string, object> sql_p = new Dictionary<string, object>();
            MatchCollection ms = Regex.Matches(sql, @"@\w+");
            foreach (Match m in ms)
            {
                if (!sql_p.ContainsKey(m.Value))
                {
                    sql_p.Add(m.Value, null);
                }
            }

            if (sql_p.Count != args.Length)
            {
                throw new DataException("SQL语句要求的参数和实际提供的参数个数不符");
            }

            int i = 0;
            foreach (string key in sql_p.Keys)
            {
                DbParameter p = _dbprovider.CreateParameter();
                p.ParameterName = key;
                p.Direction = ParameterDirection.Input;
                if (args[i] != null && args[i] != DBNull.Value)
                {
                    p.Value = args[i];
                    p.DbType = GetDbType(args[i].GetType());
                }
                else
                {
                    p.Value = DBNull.Value;
                    p.DbType = DbType.String;
                }
                pl.Add(p);

                i++;
            }

            return pl.ToArray();
        }

        private DbType GetDbType(Type type)
        {
            if (type == typeof(int))
                return DbType.Int32;
            if (type == typeof(float))
                return DbType.Single;
            if (type == typeof(decimal))
                return DbType.Decimal;
            if (type == typeof(double))
                return DbType.Double;
            if (type == typeof(string))
                return DbType.String;
            if (type == typeof(DateTime))
                return DbType.DateTime;
            if (type == typeof(Guid))
                return DbType.Guid;
            return DbType.Object;

        }
        #endregion
        #region 数据查询
        public DataTable Query(string sql, params object[] args)
        {
            try
            {
                DbCommand cmd = _dbprovider.CreateCommand();
                cmd.Connection = _cn;
                cmd.Transaction = _trans;
                cmd.CommandTimeout = 3000;
                cmd.CommandText = sql;

                if (args.Length > 0)
                    cmd.Parameters.AddRange(BuildParams(sql, args));

                DbDataAdapter da = _dbprovider.CreateDataAdapter();
                da.SelectCommand = cmd;

                DataTable dt = new DataTable("Table");
                da.Fill(dt);
                Log.Debug("Exec:" + sql);
                return dt;
            }
            catch (Exception ex)
            {
                Log.Error("Execute sql error:" + sql, ex);
                throw;
            }
        }
        public DataSet DataQuery(string sql, params object[] args)
        {
            try
            {
                DbCommand cmd = _dbprovider.CreateCommand();
                cmd.Connection = _cn;
                cmd.Transaction = _trans;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 3000;
                if (args.Length > 0)
                    cmd.Parameters.AddRange(BuildParams(sql, args));

                DbDataAdapter da = _dbprovider.CreateDataAdapter();
                da.SelectCommand = cmd;

                // DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                //  da.Fill(dt);
                Log.Debug("Exec:" + sql);
                return ds;
            }
            catch (Exception ex)
            {
                Log.Error("Execute sql error:" + sql, ex);
                throw;
            }
        }
        public int ExecNoQuery(string sql, params object[] args)
        {
            try
            {
                DbCommand cmd = _dbprovider.CreateCommand();
                cmd.Connection = _cn;
                cmd.Transaction = _trans;
                cmd.CommandText = sql;
                if (args.Length > 0)
                    cmd.Parameters.AddRange(BuildParams(sql, args));

                if (_cn.State == ConnectionState.Closed)
                    throw new DataException("在调用前需打开连接");

                int value = cmd.ExecuteNonQuery();
                Log.Debug("Exec:" + sql);
                return value;
                
            }
            catch (Exception ex)
            {
                Log.Error("Execute sql error:" + sql, ex);
                _trans.Rollback();
                throw;
            }
        }

        //public DataTable Query(string fieldstring, string tablename, IWhereClip where, IOrderByClip orderby)
        //{
        //    string sql = "select " + fieldstring + " from [" + tablename + "]" + where.ToSqlClip() + orderby.ToSqlClip();
        //    return Query(sql);
        //}
        public IDataReader QueryReader(string sql, params object[] args)
        {
            return QueryReader(sql, CommandBehavior.Default, args);
        }
        public IDataReader QueryReader(string sql, CommandBehavior behavior, params object[] args)
        {
            try
            {
                DbCommand cmd = _dbprovider.CreateCommand();
                cmd.Connection = _cn;
                cmd.Transaction = _trans;
                cmd.CommandText = sql;
                if (args.Length > 0)
                    cmd.Parameters.AddRange(BuildParams(sql, args));

                if (_cn.State == ConnectionState.Closed)
                    throw new Exception("在调用前需打开连接");

                Log.Debug("Exec:" + sql);
                return cmd.ExecuteReader(behavior);
            }
            catch (Exception ex)
            {
                Log.Error("Execute sql error:" + sql, ex);
                throw;
            }
        }

        //public IDataReader QueryReader(string fieldstring, string tablename, IWhereClip where, IOrderByClip orderby, CommandBehavior behavior)
        //{
        //    string sql = "select " + fieldstring + " from [" + tablename + "] " + where.ToSqlClip() + orderby.ToSqlClip();
        //    return QueryReader(sql, behavior);
        //}
        //public IDataReader QueryReader(string fieldstring, string tablename, IWhereClip where, IOrderByClip orderby)
        //{
        //    return QueryReader(fieldstring, tablename, where, orderby, CommandBehavior.Default);
        //}

        public T GetScalar<T>(string sql, params object[] args)
        {
            object val = GetScalar(sql, args);
            return ConvertType<T>(val);

        }

        public object GetScalar(string sql, params object[] args)
        {
            try
            {
                DbCommand cmd = _dbprovider.CreateCommand();
                cmd.Connection = _cn;
                cmd.Transaction = _trans;
                cmd.CommandText = sql;
                if (args.Length > 0)
                    cmd.Parameters.AddRange(BuildParams(sql, args));

                if (_cn.State == ConnectionState.Closed)
                    throw new Exception("在调用前需打开连接");

                object val = cmd.ExecuteScalar();
                Log.Debug("Exec:" + sql);
                return val;
            }
            catch (Exception ex)
            {
                Log.Error("Execute sql error:" + sql, ex);
                throw;
            }
        }
        #endregion
        #region ConvertType
        public static T ConvertType<T>(object val, T defaultvalue)
        {
            if (val == null || val == DBNull.Value)
                return defaultvalue;
            try
            {
                Type type = Nullable.GetUnderlyingType(typeof(T));
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
        #endregion
        #region ObjectMapping
        public T QueryObject<T>(string sql, params object[] args) where T : class
        {
            DataTable dt = Query(sql);
            if (dt.Rows.Count == 0)
                return null;
            if (dt.Rows.Count > 1)
                throw new DataException("返回行大于1行");

            return ObjectConvertor.ToObject<T>(dt.Rows[0]);
        }
        public T[] QueryList<T>(string sql, params object[] args) where T : class,new()
        {
            DataTable dt = Query(sql);
            if (dt.Rows.Count == 0)
                return new T[0];

            return GetEntities<T>(dt);
            //return ObjectConvertor.ToArray<T>(dt, typeof(DataTable), typeof(T), string.Empty);
        }

        //public IList<T> QueryList_IList<T>(string sql, params object[] args) where T : new()
        //{
        //    DataTable dt = Query(sql);
        //    if (dt.Rows.Count == 0)
        //        return new T[0];

        //    return GetEntities_IList<T>(dt);
        //    //return ObjectConvertor.ToArray<T>(dt, typeof(DataTable), typeof(T), string.Empty);
        //}
        #endregion

        public static T GetEntity<T>(DataTable table) where T : new()
        {
            T entity = new T();
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in entity.GetType().GetProperties())
                {
                    if (row.Table.Columns.Contains(item.Name))
                    {
                        if (DBNull.Value != row[item.Name])
                        {
                            item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                        }

                    }
                }
            }

            return entity;
        }

        public static T[] GetEntities<T>(DataTable table) where T : new()
        {
            T[] entities = new T[table.Rows.Count];
            int _index=0;
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
                //entities.Add(entity);
                entities[_index++] = entity;
            }
            return entities;
        }


        //public static IList<T> GetEntities_IList<T>(DataTable table) where T : new()
        //{
        //    IList<T> entities = new List<T>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        T entity = new T();
        //        foreach (var item in entity.GetType().GetProperties())
        //        {
        //            item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
        //        }
        //        entities.Add(entity);
        //    }
        //    return entities;
        //}

        public T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in row.Table.Columns)
                {
                    System.Reflection.PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here  
                        throw;
                    }
                }
            }
            return obj;
        }

        public IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
            if (rows != null)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 转换DataTa为IList<T>泛型
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="table">所需转换DataTab</param>
        /// <returns>IList<T></returns>
        public IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return ConvertTo<T>(rows);
        }

        #region FieldsOperation 这个用处不大
        public int GetCount(string table_name, Fields condition)
        {
            string sql = "Select Count(1) as C From [{0}] where {1}";
            string f1;
            if (condition != null && condition.Count > 0)
                f1 = condition.ToCondition();
            else
                f1 = "1=1";
            return GetScalar<int>(string.Format(sql, table_name, f1));
        }
        public int GetCount(string table_name, string condition)
        {
            string sql = "Select Count(1) as C From [{0}] where {1}";
            string f1;
            if (condition != "")
                f1 = condition;
            else
                f1 = "1=1";
            return GetScalar<int>(string.Format(sql, table_name, f1));
        }
        public DataTable Select(string table_name, Fields selectFields, Fields condition, Fields orderby)
        {
            return Select(table_name, selectFields, condition, orderby, 0, 0);
        }
        public DataTable Select(string table_name, Fields selectFields, Fields condition, Fields orderby, int startIndex, int max_rows)
        {

            string sql;
            if (max_rows <= 0)
                sql = "Select {0} From [{1}] where {2} Order by {3}";
            else
            {
                sql = @"select * from(
select {0},row_number() over(order by {3}) as row_index from [{1}]
)t
where {2}
and row_index between {4} and {5}
order by {3}";
                if (orderby == null || orderby.Count == 0)
                    throw new Exception("分页显示必须指定Orderby属性");
            }
            string f1, f2 = table_name, f3, f4;
            if (selectFields != null && selectFields.Count > 0)
            {
                f1 = selectFields.ToFieldNameList();
            }
            else
                f1 = "*";

            if (condition != null && condition.Count > 0)
                f3 = condition.ToCondition();
            else
                f3 = "1=1";

            if (orderby != null && orderby.Count > 0)
                f4 = orderby.ToFieldNameList();
            else
                f4 = "1";

            sql = string.Format(sql, f1, f2, f3, f4, startIndex + 1, startIndex + max_rows);

            try
            {
                DataTable dt = Query(sql);
                if (dt.Columns.Contains("row_index")) dt.Columns.Remove("row_index");
                Log.Debug("Exec:" + sql);
                return dt;
            }
            catch (Exception ex)
            {
                Log.Error("Execute sql error:" + sql, ex);
                throw;
            }
        }
        public void Update(string table_name, Fields UpdateFields, Fields Condition)
        {
            string sql;
            sql = "UPDATE [" + table_name + "] Set " + UpdateFields.ToUpdateString() + " WHERE " + Condition.ToCondition();
            ExecNoQuery(sql);
        }
        public void Insert(string table_name, Fields InsertFields)
        {
            string sql;
            sql = "INSERT INTO [" + table_name + "] (" + InsertFields.ToFieldNameList() + ") Values(" + InsertFields.ToFieldValueList() + ")";
            ExecNoQuery(sql);
        }
        public void Delete(string table_name, Fields DeleteCondtion)
        {
            string sql;
            sql = "DELETE FROM [" + table_name + "] ";
            if (DeleteCondtion != null && DeleteCondtion.Count > 0)
                sql += " WHERE " + DeleteCondtion.ToCondition();
            ExecNoQuery(sql);
        }
        public void UpdateOrInsert(string table_name, Fields KeyFields, Fields newFields)
        {
            string sql;
            sql = "If Exists(Select * From [" + table_name + "] where " + KeyFields.ToCondition() + ")"
                + "\nUpdate [" + table_name + "] Set " + newFields.ToUpdateString() + " where " + KeyFields.ToCondition();
            sql += "\nElse"
                + "\nInsert Into [" + table_name + "] (" + newFields.ToFieldNameList() + ") Values(" + newFields.ToFieldValueList() + ")";
            ExecNoQuery(sql);
        }
        #endregion

        
    }
}

public static class ConvertionExtensions
{
    public static T ConvertTo<T>(this IConvertible convertibleValue)
   {
       if (null == convertibleValue)
       {
           return default(T);
       }
    
       if (!typeof(T).IsGenericType)
       {
           return (T)Convert.ChangeType(convertibleValue, typeof(T));
       }
       else
       {
           Type genericTypeDefinition = typeof(T).GetGenericTypeDefinition();
           if (genericTypeDefinition == typeof(Nullable<>))
           {
               return (T)Convert.ChangeType(convertibleValue, Nullable.GetUnderlyingType(typeof(T)));
           }
       }
       throw new InvalidCastException(string.Format("Invalid cast from type \"{0}\" to type \"{1}\".", convertibleValue.GetType().FullName, typeof(T).FullName));
   }
}