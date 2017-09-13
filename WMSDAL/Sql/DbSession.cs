using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace WMSDAL.Sql
{
    public class DbSession:IDisposable
    {
        DbProviderFactory _dbprovider;
        DbConnection _cn;
        DbTransaction _trans;

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


        public int ExecNoQuery(string sql, params SqlParameter[] pars)
        {
            try
            {
                DbCommand cmd = _dbprovider.CreateCommand();
                cmd.Connection = _cn;
                cmd.Transaction = _trans;
                cmd.CommandText = sql;
                if (pars.Length > 0)
                    cmd.Parameters.AddRange(pars);

                if (_cn.State == ConnectionState.Closed)
                    throw new DataException("在调用前需打开连接");

                int value = cmd.ExecuteNonQuery();
                return value;

            }
            catch (Exception ex)
            {
                //_trans.Rollback();
                throw new Exception("Execute sql error:" + sql,ex);                                
            }
        }


        public DataSet DataQuery(string sql, params SqlParameter[] pars)
        {
            try
            {
                DbCommand cmd = _dbprovider.CreateCommand();
                cmd.Connection = _cn;
                //cmd.Transaction = _trans;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 3000;
                if (pars.Length > 0)
                    cmd.Parameters.AddRange(pars);

                DbDataAdapter da = _dbprovider.CreateDataAdapter();
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();
                da.Fill(ds);              
                return ds;
            }
            catch (Exception ex)
            {
                //_trans.Rollback();
                throw new Exception("Execute sql error:" + sql, ex);   
            }
        }


        #region 把表中的数据加载到实体中去，用于查询数据

        public T QueryObject<T>(string sql, params SqlParameter[] args) where T : class,new()
        {
            DataTable dt = DataQuery(sql, args).Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            if (dt.Rows.Count > 1)
                throw new DataException("返回行大于1行");
            return GetEntity<T>(dt);
        }
    
        public static T GetEntity<T>(DataTable table) where T : new()
        {
            T entity = new T();
            DataRow dataRow = table.Rows[0];
            foreach (var item in entity.GetType().GetProperties())
            {
                if (dataRow.Table.Columns.Contains(item.Name))
                {
                    if (DBNull.Value != dataRow[item.Name]) //如果数据不为null
                    {
                        item.SetValue(entity, Convert.ChangeType(dataRow[item.Name], item.PropertyType), null);
                    }
                }
            }
            return entity;
        }

        public T[] QueryList<T>(string sql, params SqlParameter[] args) where T : class,new()
        {
            DataTable dt = DataQuery(sql, args).Tables[0];
            if (dt.Rows.Count == 0)
                return new T[0];

            return GetEntities<T>(dt);
        }

        //这个方法肯定要改变一下，为什么不直接返回一个泛型列表
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
                        if (!item.PropertyType.IsGenericType)//如果当前类型是泛型类型，则为 true；否则为 false。
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

        public  List<T> QueryEntity<T>(string strSQL,params SqlParameter[] paras) where T:class,new()
        {
            List<T> listEntity = new List<T>();
            DataTable dataTable = DataQuery(strSQL, paras).Tables[0];
            if (dataTable.Rows.Count == 0)
                return listEntity;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                T entity = new T();
                foreach (var propertity in entity.GetType().GetProperties())
                {
                    if (dataTable.Columns.Contains(propertity.Name))
                    {
                        propertity.SetValue(entity, dataRow[propertity.Name]==DBNull.Value?
                            null:Convert.ChangeType(dataRow[propertity.Name],propertity.PropertyType),null);
                    }                    
                }
                listEntity.Add(entity);
            }
            return listEntity;
        }
        #endregion

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
                    cmd.Parameters.AddRange(args);

                if (_cn.State == ConnectionState.Closed)
                    throw new Exception("在调用前需打开连接");

                return cmd.ExecuteReader(behavior);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if (_trans != null) _trans.Dispose();
            if (_cn != null) _cn.Dispose();
        }
        #endregion
    }
}
