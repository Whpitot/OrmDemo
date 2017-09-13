using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSModel
{
    using WMSDAL.Map;
    using WMSDAL.Sql;
    using WMSDAL.Entry;
    using System.Data.SqlClient;
    using System.Data;
    using Common;

    [TableMap("t_Supplier", "FItemID")]
    public class t_Supplier:EntryObject,IItemInfo
    {
        private System.Int32 _fitemid;
        [FieldMap("FItemID", DbType.Int32)]
        public System.Int32 FItemID
        {
            get { return _fitemid; }
            set { _fitemid = value; }
        }
        private System.String _fnumber;
        [FieldMap("FNumber", DbType.String)]
        public System.String FNumber
        {
            get { return _fnumber; }
            set { _fnumber = value; }
        }
        private System.String _fname;
        [FieldMap("FName", DbType.String)]
        public System.String FName
        {
            get { return _fname; }
            set { _fname = value; }
        }

        private System.Int32 _ffax;
        [FieldMap("FFax", DbType.Int32)]
        public System.Int32 FFax
        {
            get { return _ffax; }
            set { _ffax = value; }
        }

        private System.Int32 _fdeleted;
        [FieldMap("FDeleted", DbType.Int32)]
        public System.Int32 FDeleted
        {
            get { return _fdeleted; }
            set { _fdeleted = value; }
        }

        private System.String _fphone;
        [FieldMap("FPhone", DbType.String)]
        public System.String FPhone
        {
            get { return _fphone; }
            set { _fphone = value; }
        }

        private System.String _fserver;
        [FieldMap("FServer", DbType.String)]
        public System.String FServer
        {
            get { return _fserver; }
            set { _fserver = value; }
        }

        private System.String _fnote;
        [FieldMap("FNote", DbType.String)]
        public System.String FNote
        {
            get { return _fnote; }
            set { _fnote = value; }
        }

        private System.Int32 _fmodifyBy;
        [FieldMap("FModifyBy", DbType.Int32)]
        public System.Int32 FModifyBy
        {
            get { return _fmodifyBy; }
            set { _fmodifyBy = value; }
        }

        private System.DateTime _flastModDate;
        [FieldMap("FLastModDate", DbType.DateTime)]
        public System.DateTime FLastModDate
        {
            get { return _flastModDate; }
            set { _flastModDate = value; }
        }

        public void Save()
        {
            //添加操作
            if (FItemID == 0)
            {
                //子类调用基类的属性
                FItemID = SqlCom.GetMaxNum("t_Supplier");
                this.add();
            }
            else
            {
                FLastModDate = DateTime.Now;
                FModifyBy = UserUtility.FUserID;

                this.update();
            }
        }

        public void Delete(int fitemid)
        {
            //int intt = this.FItemID;
            this.FItemID = fitemid;
            this.deleted(false);

        }

        public t_Supplier Create()
        {
            t_Supplier item = new t_Supplier();
            return item;
        }

        #region 把表格数据加载传给实体
        public t_Supplier LoadEntity(int FItemID)
        {
            string str = "select * from t_Supplier where FItemID=@FItemID and FDeleted=0 order by FNumber";
            SqlParameter pars = new SqlParameter("@FItemID", FItemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_Supplier>(str,pars);
            }
        }

        public t_Supplier[] LoadEntities()
        {
            //参数里面设置模糊查询
            string str = "select * from t_Supplier where FDeleted=0 order by FNumber";
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Supplier>(str);
            }
        }

        //以数组形式给Grid
        public t_Supplier[] LoadEntities(int FItemID)
        {
            string str = "select * from t_Supplier where FItemID=@FItemID and FDeleted=0 order by FNumber";
            SqlParameter pars = new SqlParameter("@FItemID", FItemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Supplier>(str, pars);
            }
        }
        #endregion
    }

    public interface ISupplier
    {

        t_Supplier[] LoadEntities();

        t_Supplier[] LoadEntities(int FItemID);

        t_Supplier LoadEntity(int fitemID);


        //用orm框架
        void Save(t_Supplier item);

        t_Supplier Create();

        void Delete(int FItemID);

    }
}
