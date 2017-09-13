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

    [TableMap("t_Emp", "FItemID")]
    public class t_Emp : EntryObject,IItemInfo
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

        private System.Int32 _fparentid;
        [FieldMap("FDeptID", DbType.Int32)]
        public System.Int32 FDeptID
        {
            get { return _fparentid; }
            set { _fparentid = value; }
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

        private System.String _fnote;
        [FieldMap("FNote", DbType.String)]
        public System.String FNote
        {
            get { return _fnote; }
            set { _fnote = value; }
        }

        private System.DateTime _fcreatetime;
        [FieldMap("FCreateTime", DbType.DateTime)]
        public System.DateTime FCreateTime
        {
            get { return _fcreatetime; }
            set { _fcreatetime = value; }
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
                FItemID = SqlCom.GetMaxNum("t_Emp");
                FCreateTime = DateTime.Now;
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

        public t_Emp Create()
        {
            t_Emp item = new t_Emp();
            return item;
        }


        #region 把表格数据加载传给实体
        public t_Emp LoadEntity(int fitemID)
        {
            string str = string.Format("select * from t_Emp where FItemID={0} and FDeleted=0", fitemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_Emp>(str);
            }        
        }

        //根据部门ID加载职员
        public t_Emp[] LoadEntities(int FItemID)
        {
            //参数里面设置模糊查询
            string str = "select * from t_Emp where FDeptID = @FItemID and FDeleted=0 order by FNumber";
            SqlParameter pars = new SqlParameter("@FItemID", FItemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Emp>(str,pars);
            }
        }
        #endregion
    }



    public interface IEmp
    {
        t_Emp LoadEntity(int fitemID);

        t_Emp[] LoadEntities(int FItemID);

        void Save(t_Emp item);

        t_Emp Create();

        void Delete(int FItemID);
    }
}
