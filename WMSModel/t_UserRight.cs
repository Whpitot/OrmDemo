using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSModel
{
    using WMSDAL.Map;
    using WMSDAL.Entry;
    using System.Data;
    using WMSDAL.Sql;

    [TableMap("t_UserRight", "FUserID")]
    public class t_UserRight:EntryObject
    {
        [FieldMap("FItemID",DbType.Int32)]
        public int FItemID { get; set; }

        [FieldMap("FUserID", DbType.Int32)]
        public int FUserID { get; set; }

        [FieldMap("FRightID", DbType.Int32)]
        public int FRightID { get; set; }

        public t_UserRight Create()
        {
            t_UserRight _instance = new t_UserRight();
            return _instance;
        }

        public int GetMaxID()
        {
            return SqlCom.GetMaxNum("t_UserRight");
        }

        public int Save(string fuserid,string frightid)
        {
            int count = 0;
            string str = "delete from t_UserRight where FUserid=" + fuserid+"\n";
            //当取消所有权限的时候触发
            if (frightid != "")
            {
                string[] _rightid = frightid.Split('|');
                for (int i = 0; i < _rightid.Length; i++)
                {
                    str += "insert into t_UserRight values( " + fuserid + " , " + _rightid[i] + ",'' ) \n";
                }
            }
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                count= db.ExecNoQuery(str);
            }
            return count;
        }

        public string[] GetRightByUser(int UserID)
        {
            string selestr = " select  FRightID from t_UserRight where FUserID='" + UserID + "' ";
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                DataTable dt = db.DataQuery(selestr).Tables[0];
                string[] str = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str[i]=dt.Rows[i]["FRightID"].ToString();
                }
                return str;
            }
        }
    }

    public interface IUserRight
    {
        t_UserRight Create();

        int Save(string fuserid, string frightid);

        string[] GetRightByUser(int UserID);
    }
}
