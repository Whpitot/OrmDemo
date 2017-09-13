using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WMSModel
{
    using WMSDAL.Map;
    using WMSDAL.Sql;
    using WMSDAL.Entry;
    using System.Data.SqlClient;
    using Common;


    [TableMap("t_Unit", "FItemID")]
    public class t_Unit : EntryObject,IItemInfo
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

        private System.Int32 _fdeleted;
        [FieldMap("FDeleted", DbType.Int32)]
        public System.Int32 FDeleted
        {
            get { return _fdeleted; }
            set { _fdeleted = value; }
        }

        private System.DateTime _fcreatetime;
        [FieldMap("FCreateTime", DbType.DateTime)]
        public System.DateTime FCreateTime
        {
            get { return _fcreatetime; }
            set { _fcreatetime = value; }
        }

        [FieldMap("FCreator", DbType.Int32)]
        public int FCreator { get; set; }

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
                FItemID = SqlCom.GetMaxNum("t_Unit");
                FCreateTime = DateTime.Now;
                FCreator = UserUtility.FUserID;
                this.add();
            }
            else
            {
                FModifyBy = UserUtility.FUserID;
                FLastModDate = DateTime.Now;
                this.update();
            }
        }

        public void Delete(int fitemid)
        {
            //int intt = this.FItemID;
            this.FItemID = fitemid;
            this.deleted(false);
        }

        public t_Unit Create()
        {
            t_Unit item = new t_Unit();
            return item;
        }


        #region 把表格数据加载传给实体
        public t_Unit LoadEntity(int fitemID)
        {
            string str = string.Format("select * from t_Unit where FItemID={0} and FDeleted=0", fitemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_Unit>(str);
            }        
        }

        public t_Unit[] LoadEntities()
        {
            //参数里面设置模糊查询
            string strSql = "";
            strSql = "select * from t_Unit where  FDeleted=0 order by FNumber";
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Unit>(strSql);
            }
        }

        public t_Unit[] LoadEntities(int fitemID)
        {
            string str = string.Format("select * from t_Unit where FItemID={0} and FDeleted=0", fitemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Unit>(str);
            }
        }
        #endregion
    }



    public interface IUnit
    {
        t_Unit LoadEntity(int fitemID);

        t_Unit[] LoadEntities();

        t_Unit[] LoadEntities(int fitemID);

        void Save(t_Unit item);

        t_Unit Create();

        void Delete(int FItemID);
    }
}
