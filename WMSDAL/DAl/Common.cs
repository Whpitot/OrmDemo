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
        #region  �õ����ID

        /// <summary>
        /// ��ȡ����FitemIDֵ
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="name">�ֶ���</param>
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
        /// ��ȡt_item ParentID��FItemID��
        /// </summary>
        /// <param name="num">FNumber</param>
        /// <param name="itemclassid">����id</param>
        /// <returns>-2��ȡʧ�� -1 ����Fnumber >0 ��ȡ�ɹ�</returns>
        public static int GetParentIDByNumber(int fitemid, string fnumber, int itemclassid)
        {
            string[] arr = fnumber.Split('.');
            var number = arr.Length > 1 ? fnumber.Substring(0, fnumber.Length - arr[arr.Length - 1].Length - ".".Length) : fnumber;
            var fparentId = 0;
            //��ѯ�Ƿ���ParentID
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
                        return -2;//��ȡ ParentIDʧ��
                    }

                }
            }
            //����Ƿ����
            string sql = string.Format("select 1 from t_item where FDeleted=0 and Fnumber='{0}' and FItemID<>{1}  and FItemClassID={2} ", fnumber, fitemid, itemclassid);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                DataTable dt = db.Query(sql);
                if (dt.Rows.Count > 0)
                    return -1;  // �Ѵ��ڱ���

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
        /// ���ݲ�ѯ������DataTable
        /// </summary>
        /// <param name="sql">SQL�ַ���</param>
        /// <param name="strDB">ָ���������ݿ��ʾ</param>
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
        /// ִ�����ݸ��²���
        /// </summary>
        /// <param name="sql">SQL�ַ���</param>
        /// <param name="strDB">ָ���������ݿ��ʾ</param>
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
 
