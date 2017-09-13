using System;
using System.Collections.Generic;
using System.Text;
using DAl.Sql;
using System.Data;
using System.IO;
namespace DAl
{
    public class Common
    {
        #region  得到最大ID

        /// <summary>
        /// 获取新增FitemID值
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public static int GetMaxFitem(string TableName,string name)
        {
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                var sql = string.Format("select Max({0}) from {1}",name,TableName);
                if (sql == null) {
                    return 1;
                }
                var fitemid=db.GetScalar<int>(sql);
                return ++fitemid;
            }
        }

        /// <summary>
        /// 获取t_item ParentID（FItemID）
        /// </summary>
        /// <param name="num">FNumber</param>
        /// <param name="itemclassid">类型id</param>
        /// <returns>-2获取失败 -1 已有Fnumber >0 获取成功</returns>
        public static int GetParentIDByNumber(int fitemid, string fnumber, int itemclassid)
        {
            string[] arr = fnumber.Split('.');
            var number = arr.Length > 1 ? fnumber.Substring(0, fnumber.Length - arr[arr.Length - 1].Length - ".".Length) : fnumber;
            var fparentId = 0;
            //查询是否有ParentID
            if (arr.Length > 1)
            {
                string selestr = string.Format("select FItemID from t_item where Fnumber= '{0}' and FItemClassID={1} and FDetail=0 and FDeleted=0", number, itemclassid);
                using (DbSession db = Db.Get())
                {
                    db.OpenConnection();
                    DataTable dt = db.Query(selestr);
                    if (dt.Rows.Count > 0)
                    {
                        fparentId = (int)dt.Rows[0]["FItemID"];
                    }
                    else
                    {
                        return -2;//获取 ParentID失败
                    }

                }
            }
            //检测是否存在
            string sql = string.Format("select 1 from t_item where FDeleted=0 and Fnumber='{0}' and FItemID<>{1}  and FItemClassID={2} ", fnumber, fitemid, itemclassid);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                DataTable dt = db.Query(sql);
                if (dt.Rows.Count > 0)
                    return -1;  // 已存在编码

            }
            return fparentId;

        }



        public static int GetMaxNum(string TableName)
        {
            //using (DbSession db = Db.Get())
            //{
            //    db.OpenConnection();
            //    return db.GetScalar<int>("exec GetICMaxNum @tablename,@id", TableName,0);
            //}
            return GetMaxNum(TableName, null);
        }
        public static int GetMaxNum(string TableName, DbSession dbs)
        {
            if (dbs == null)
            {
                using (DbSession db = Db.Get())
                {
                    db.OpenConnection();
                    //return db.GetScalar<int>("exec GetICMaxNum @tablename,@id", TableName, 0);
                    string sql = string.Format("set nocount on declare @finterid int exec GetICMaxNum '{0}' , @finterid  output select @finterid as finterid", TableName);
                    return db.GetScalar<int>(sql);
                }
            }
            else
            {
                //return dbs.GetScalar<int>("exec GetICMaxNum @tablename,@id", TableName, 0);
                string sql = string.Format("set nocount on declare @finterid int exec GetICMaxNum {0} , @finterid  output select @finterid as finterid", TableName);
                return dbs.GetScalar<int>(sql);
            }
        }
        public static string GetNum(string sql)
        {
            return GetNum(sql, null);
        }
        public static string GetBillNum(string tablename, int issave)
        {
            string selestr = "exec GetBillNum '" + tablename + "','" + issave + "'";
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.GetScalar<string>(selestr);
            }
        }
        public static string GetNum(string sql, DbSession dbs)
        {
            if (dbs == null)
            {
                using (DbSession db = Db.Get())
                {
                    db.OpenConnection();
                    return db.GetScalar<string>(sql);
                }
            }
            else
            {
                return dbs.GetScalar<string>(sql);
            }
        }

        /// <summary>
        /// 数据查询，返回DataTable
        /// </summary>
        /// <param name="sql">SQL字符串</param>
        /// <param name="strDB">指定访问数据库标示</param>
        /// <returns></returns>
        public DataTable DTData(string sql, string strDB)
        {
            using (DbSession db = Db.Get(strDB))
            {
                db.OpenConnection();
                return db.Query(sql);
            }
        }

        /// <summary>
        /// 执行数据更新操作
        /// </summary>
        /// <param name="sql">SQL字符串</param>
        /// <param name="strDB">指定访问数据库标示</param>
        public void updateDt(string sql, string strDB)
        {
            using (DbSession db = Db.Get(strDB))
            {

                try
                {
                    db.OpenConnection();
                    db.BeginTrans();
                    db.ExecNoQuery(sql);
                    db.Commit();
                }
                catch
                { 
                    db.Rollback();
                }
            }
        }
        public  DataTable GetInfo(string sql, string FKey)
        {

            using (DbSession db = Db.Get(FKey))
            {
                return db.Query(sql);
            }
        }
        public DataSet DataQuery(string sql, string FKey)
        {

            using (DbSession db = Db.Get(FKey))
            {
                return db.DataQuery(sql);
            }
        }
        public void ExecNoQuery(string sql, string FKey)
        {

            using (DbSession db = Db.Get(FKey))
            {
                db.ExecNoQuery(sql);
            }
        }
        #endregion
    
     

    }
}
 
