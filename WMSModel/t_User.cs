using System;
using System.Data;

namespace WMSModel
{
    using WMSDAL.Map;
    using WMSDAL.Sql;
    using WMSDAL.Entry;
    using System.Data.SqlClient;

    [TableMap("t_User", "FItemID")]
    public class t_User:EntryObject
    {
        public t_User()
        { }
        #region Model
        private int _fitemid;
        private string _fname;
        private string _fpwd;
        private string _fnote;
        /// <summary>
        /// 
        /// </summary>
        [MapColumnsToGridView("FItemID", "FItemID", "FItemID", 1, false)]
        [FieldMap("FItemID", DbType.Int32)]
        public int FItemID
        {
            set { _fitemid = value; }
            get { return _fitemid; }
        }

        [MapColumnsToGridView("FNumber", "FNumber", "代码", 1, true)]
        [FieldMap("FNumber", DbType.String)]
        public string FNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [MapColumnsToGridView("FName", "FName", "名称", 1, true)]        
        [FieldMap("FName", DbType.String)]
        public string FName
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>      
        [FieldMap("FPwd", DbType.String)]
        public string FPwd
        {
            set { _fpwd = value; }
            get { return _fpwd; }
        }
        /// <summary>
        /// 
        /// </summary>  
        private System.Int32 _fdeleted;
        [FieldMap("FDeleted", DbType.Int32)]
        public System.Int32 FDeleted
        {
            get { return _fdeleted; }
            set { _fdeleted = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [MapColumnsToGridView("FNote", "FNote", "备注", 3, true)]
        [FieldMap("FNote", DbType.String)]
        public string FNote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }
        /// <summary>
        /// 
        /// </summary>
        [MapColumnsToGridView("FCreateTime", "FCreateTime", "创建时间", 2, true)]        
        private System.DateTime _fcreatetime;
        [FieldMap("FCreateTime", DbType.DateTime)]
        public System.DateTime FCreateTime
        {
            set { _fcreatetime = value; }
            get { return _fcreatetime; }
        }

        [FieldMap("FCreatorID", DbType.Int32)]
        public int FCreatorID { get; set; }

        [FieldMap("FIsAdmin", DbType.Int32)]
        public int FLastModifyBy { get; set; }

        [FieldMap("FLastModBy", DbType.Int32)]
        public int FLastModBy { get; set; }

        [FieldMap("FLastModDate", DbType.DateTime)]
        public DateTime FLastModDate { get; set; }
        #endregion Model

        public void Save()
        {
            //添加操作
            if (FItemID == 0)
            {
                //子类调用基类的属性
                FItemID = SqlCom.GetMaxNum("t_User");
                FDeleted = 0;
                FPwd = "123456";
                FCreateTime = DateTime.Now;
                FCreatorID = UserUtility.FUserID;
                this.add();
            }
            else
            {
                FLastModDate = DateTime.Now;
                FLastModBy = UserUtility.FUserID;
                this.update();
            }
        }

        public void Delete(int fitemid)
        {
            this.FItemID = fitemid;
            this.deleted(false);

        }

        public t_User[] LoadList(string cond)
        {
            string strSQL = string.Format("select * from t_User where {0}", cond);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_User>(strSQL);
            }
        }

        public t_User[] LoadEntities(string fname)
        {
            string str = string.Format("select * from t_user where  FName like '%{0}%'", fname);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_User>(str);
            }
        }

        public t_User LoadEntity(int fitemID)
        {
            string str = string.Format("select * from t_user where  FItemID={0}", fitemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_User>(str);
            }
        }

        public void ModifyPwd(string encryptionStr)
        {
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                db.ExecNoQuery("update t_User set FPwd=@FPwd where FItemID=@FItemID",
                    new SqlParameter("@FPwd",encryptionStr),
                    new SqlParameter("@FItemID", UserUtility.FUserID));
            }
        }
    }

     public interface IUser
     {
         t_User LoadEntity(int fitemID);

         t_User[] LoadEntities(string fname);

         void Save(t_User item);

         void Delete(int FItemID);

         t_User[] LoadList(string cond);

         void ModifyPwd(string encryptionStr);
     }
}
