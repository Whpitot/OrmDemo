using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WMSModel
{
    using WMSDAL.Map;
    using WMSDAL.Sql;
    using WMSDAL.Entry;
    using Common;
    using System.Data;


    [TableMap("t_Dept", "FItemID")]
    public class t_Dept : EntryObject, IItemInfo
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

        //保存修改者的FItemID
        private System.Int32 _fmodifyBy; 
        [FieldMap("FModifyBy", DbType.Int32)]
        public System.Int32 FModifyBy
        {
            get { return _fmodifyBy; }
            set { _fmodifyBy = value; }
        }

        private System.DateTime  _flastModDate;
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
                FItemID = SqlCom.GetMaxNum("t_Dept");
                  this.add();
            }
            else
            {
                FLastModDate = DateTime.Now;
                FModifyBy = UserUtility.FUserID;
                this.update();
            }
        }

        public void Delete()
        {
            this.deleted(false);
        }

        public t_Dept Create()
        {
            t_Dept item = new t_Dept();
            return item;
        }

        #region 把表格数据加载传给实体
        public t_Dept[] LoadEntities(int FItemID)
        {
            //参数里面设置模糊查询
            string strSql = "";
            SqlParameter pars = null;
            strSql = "select * from t_Dept where FItemID =@FItemID and FDeleted=0 order by FNumber";
            pars = new SqlParameter("@FItemID", FItemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Dept>(strSql, pars);
            }
        }

        public t_Dept[] LoadEntities()
        {
            //参数里面设置模糊查询
            string strSql = "";
            strSql = "select * from t_Dept where  FDeleted=0 order by FNumber";
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_Dept>(strSql);
            }
        }
        #endregion
    }



    public interface IDept
    {
        t_Dept[] LoadEntities(int FItemID);

        t_Dept[] LoadEntities();

        void Save(t_Dept item);

        t_Dept Create();

        void Delete(int FItemID);
    }
}
