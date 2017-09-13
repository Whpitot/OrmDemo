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
    using System.Data;
using System.Data.SqlClient;

    [TableMap("Dimension", "FItemID")]
    public class Dimension:EntryObject,IItemInfo
    {
        private System.Int32 _fitemid;
        [MapColumnsToGridView("FItemID","FItemID","",1,false)]
        [FieldMap("FItemID", DbType.Int32)]
        public System.Int32 FItemID
        {
            get { return _fitemid; }
            set { _fitemid = value; }
        }


        private System.String _fnumber;
        [MapColumnsToGridView("FNumber","FNumber","代码",1,true)]
        [FieldMap("FNumber", DbType.String)]
        public System.String FNumber
        {
            get { return _fnumber; }
            set { _fnumber = value; }
        }
        private System.String _fname;
        [MapColumnsToGridView("FName","FName","名称",1,true)]
        [FieldMap("FName", DbType.String)]
        public System.String FName
        {
            get { return _fname; }
            set { _fname = value; }
        }

        private System.Boolean _fdeleted;
        [FieldMap("FDeleted", DbType.Boolean)]
        public System.Boolean FDeleted
        {
            get { return _fdeleted; }
            set { _fdeleted = value; }
        }

        private System.String _fnote;
        [MapColumnsToGridView("FNote","FNote","备注",1,true)]
        [FieldMap("FNote", DbType.String)]
        public System.String FNote
        {
            get { return _fnote; }
            set { _fnote = value; }
        }

        [FieldMap("FCreatorID", DbType.Int32)]
        public int FCreatorID { get; set; }

        [FieldMap("FCreateTime", DbType.DateTime)]
        public DateTime FCreateTime { get; set; }

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
                FItemID = SqlCom.GetMaxNum("Dimension");
                FCreateTime = DateTime.Now;
                FCreatorID = UserUtility.FUserID;
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
            this.deleted(true);
        }

        public Dimension[] LoadList(string cond)
        {
            string strSQL = string.Format("select * from Dimension where {0}", cond);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<Dimension>(strSQL);
            }
        }

        public Dimension LoadEntity(int FItemID)
        {
            //参数里面设置模糊查询
            string strSql = "";
            SqlParameter pars = null;
            strSql = "select * from Dimension where FItemID =@FItemID and FDeleted=0 order by FNumber";
            pars = new SqlParameter("@FItemID", FItemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<Dimension>(strSql, pars);
            }
        }
    }



    public interface IDimension
    {
        Dimension LoadEntity(int FItemID);

        Dimension[] LoadList(string cond);

        void Save(Dimension instance);

        void Delete(int FItemID);
    }
}
