using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Data;

namespace WMSDAL.Sql
{
    using WMSDAL;
    public class SqlCom
    {                         
        /// <summary>
        /// 返回表中内码的最大的值
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxNum(string TableName)
        {
           string sql = string.Format("set nocount on declare @finterid int exec GetICMaxNum '{0}' , @finterid  output select @finterid as finterid", TableName);
           return DataBaseHelper.GetScalar<int>(sql);
        }

        //Get a rand number of t_assemble as sign
        public static string GetRandNum(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new Exception(" 必须指定类型代码！");
            }
            string curno = string.Empty;
            string flag = string.Empty;
            string fbillno;
            string sqlstr = string.Format(@"Update ICBillNo Set FCurNo=FCurNo+1 where FBillID= {0} ;
                                          Select FPreLetter,FCurNo,FFormat From ICBillNo where FBillID = {0}", type);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                using (IDataReader reader = db.QueryReader(sqlstr))
                {
                    reader.Read();
                    fbillno = reader["FPreLetter"].ToString() + reader["FFormat"].ToString();
                    String curno2 = reader["FCurNo"].ToString();
                    fbillno = fbillno.Substring(0, fbillno.Length - curno2.Length) + curno2;
                    reader.Close();
                }
            }
            return fbillno;
        }
    }
}
