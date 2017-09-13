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

    [TableMap("t_Customer", "FItemID")]
    public class t_Customer : EntryObject, IItemInfo //只能继承一个基类
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

        [FieldMap("FSupplierID", DbType.Int32)]
        public int FSupplierID { get; set; }

        public string FSupplier { get; set; }

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
                FItemID = SqlCom.GetMaxNum("t_Customer");
                FLastModDate = DateTime.Now;
                FModifyBy = UserUtility.FUserID;
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
            this.FItemID = fitemid;
            this.deleted(false);
        }

        public t_Customer Create()
        {
            t_Customer item = new t_Customer();
            return item;
        }

        #region 把表格数据加载传给实体
        public t_Customer LoadEntity(int fitemID)
        {
            string str = string.Format("select * from t_Customer where FItemID={0}", fitemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_Customer>(str);
            }
        }


        public t_Customer[] LoadEntities(int FSupplierID)
        {
            //参数里面设置模糊查询
            string str = "select * from t_Customer where FSupplierID=@FSupplierID and FDeleted=0 order by FNumber";
            SqlParameter pars = new SqlParameter("@FSupplierID", FSupplierID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Customer>(str, pars);
            }
        }

        public t_Customer[] LoadEntities()
        {
            //参数里面设置模糊查询
            string str = "select * from t_Customer where FDeleted=0 order by FNumber";
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Customer>(str);
            }
        }
        #endregion
    }

    public interface ICustomer
    {
        t_Customer[] LoadEntities(int FItemID);

        t_Customer[] LoadEntities();

        t_Customer LoadEntity(int fitemID);

        //用orm框架
        void Save(t_Customer item);

        t_Customer Create();

        void Delete(int FItemID);

    }
}
