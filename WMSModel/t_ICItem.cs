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
    using Common;

    [TableMap("t_ICItem", "FItemID")]
    public partial class t_ICItem : EntryObject, IItemInfo
    {
        public t_ICItem()
        { }
        #region Model
        private int _fitemid;
        private int _fdimensionid;
        private string _fname;
        private string _fnumber;
        private System.Int32 _fsupplierid;
        private decimal _fprice;
        private string _fsaleunit;
        private DateTime _flastmoddate;
        private string _fnote;
        /// <summary>
        /// 
        /// </summary>
       [FieldMap("FItemID", DbType.Int32)]
        public int FItemID
        {
            set { _fitemid = value; }
            get { return _fitemid; }
        }
        /// <summary>
        /// 
        /// </summary>
      [FieldMap("FDimensionID", DbType.String)]
        public int FDimensionID
        {
            set { _fdimensionid = value; }
            get { return _fdimensionid; }
        }

      public string FDimension { get; set; }

      [FieldMap("FOpenWayID", DbType.String)]
      public int FOpenWayID { get; set; }

      public string FOpenWay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FName", DbType.String)]
        public string FName
        {
            set { _fname = value; }
            get { return _fname; }
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
        [FieldMap("FNumber", DbType.String)]
        public string FNumber
        {
            set { _fnumber = value; }
            get { return _fnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FSupplierID", DbType.Int32)]
        public System.Int32 FSupplierID
        {
            set { _fsupplierid = value; }
            get { return _fsupplierid; }
        }
        public string FSupplier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FUnitID", DbType.Int32)]
        public int FUnitID { get; set; }

        public string FUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FPrice", DbType.Decimal)]
        public decimal FPrice
        {
            set { _fprice = value; }
            get { return _fprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FSaleUnit", DbType.String)]
        public string FSaleUnit
        {
            set { _fsaleunit = value; }
            get { return _fsaleunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FLastModDate", DbType.DateTime)]
        public DateTime FLastModDate
        {
            set { _flastmoddate = value; }
            get { return _flastmoddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FNote", DbType.String)]
        public string FNote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }

        [FieldMap("FLevelID", DbType.Int32)]
        public int FLevelID { get; set; }
        public string FLevel { get; set; }

        [FieldMap("FCreateDate", DbType.DateTime)]
        public DateTime FCreateDate { get; set; }

        [FieldMap("FModifyBy", DbType.Int32)]
        public int FModifyBy { get; set; }

        #endregion Model


        #region Function
        public t_ICItem Create()
        {
            t_ICItem item = new t_ICItem();
            return item;
        }


        //如果要显示出来要给字段加东西才可以的，，，
        public t_ICItem[] LoadEntities(int FItemID)
        {          
            //参数里面设置模糊查询
            string str = "select * from V_IcitemList where FSupplierID = @FItemID  order by FNumber";
            SqlParameter pars = new SqlParameter("@FItemID", FItemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_ICItem>(str, pars);
            }
        }

        public t_ICItem[] LoadEntities()
        {
            //参数里面设置模糊查询
            string str = "select * from t_ICItem where FDeleted=0 order by FNumber";
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_ICItem>(str);
            }
        }

        public t_ICItem LoadEntity(int fitemID)
        {
            string str = string.Format("select * from t_icitem  where FItemID={0} and FDeleted=0", fitemID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_ICItem>(str);
            }
        }

        public void Save(t_ICItem icitem)
        {
            //添加操作
            if (FItemID == 0)
            {
                //子类调用基类的属性
                FItemID = SqlCom.GetMaxNum("t_icitem");
                FCreateDate = DateTime.Now;
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

        public void Delete()
        {
            this.deleted(true);
        }
        #endregion
    }
    public interface IICItem
    {
        t_ICItem[] LoadEntities(int FItemID);

        t_ICItem[] LoadEntities();

        t_ICItem Create();

        t_ICItem LoadEntity(int fitemID);

        void Save(t_ICItem icitem);

        void Delete(int fitemid);
    }
}
