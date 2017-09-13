using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMSDAL.Map;
using WMSDAL.Sql;
using WMSDAL.Entry;
using Common;

namespace WMSModel
{
    [TableMap("t_Installation", "FInterID")]
    public class t_Installation : EntryObject
    {
        #region Model
        private System.Int32 _finterid;
        private System.Int32 _fitemid;
        private string _faddress;
        private System.Int32 _fqty;
        private string _fphone;
        private System.Int32 _fcustomer;
        private System.Int32 _finstaller;
        private System.Decimal _fauxprice;
        private string _fnote;
        private System.Int32 _fprice;
        /// <summary>
        /// 
        /// </summary>
        [MapColumnsToGridViewAttribute("FInterID","FInterID","",1,false)]
        [FieldMap("FInterID", DbType.Int32)]
        public System.Int32 FInterID
        {
            set { _finterid = value; }
            get { return _finterid; }
        }
        [MapColumnsToGridViewAttribute("FBillNo", "FBillNo", "安装单号", 2, true)]
        [FieldMap("FBillNo", DbType.Int32)]
        public string FBillNo { get; set; }

        [MapColumnsToGridViewAttribute("FRecordDate", "FRecordDate", "报单日期", 3, true)]
        [FieldMap("FRecordDate", DbType.DateTime)]
        public DateTime FRecordDate { get; set; }

        [MapColumnsToGridViewAttribute("FItemID", "FItemID", "", 4, false)]
        [FieldMap("FItemID", DbType.Int32)]
        public System.Int32 FItemID
        {
            set { _fitemid = value; }
            get { return _fitemid; }
        }
        [MapColumnsToGridViewAttribute("FNumber", "FNumber", "代码", 5, true)]
        public string FNumber { get; set; }

        [MapColumnsToGridViewAttribute("FItemName", "FItemName", "货品名称", 6, true)]
        public string FItemName { get; set; }

        //[FieldMap("FDimensionID", DbType.Int32)]
        //public string FDimensionID { get; set; }

        [MapColumnsToGridViewAttribute("FDimension", "FDimension", "尺寸", 8, true)]
        public string FDimension { get; set; }

        //[FieldMap("FOpenWayID", DbType.Int32)]
        //public string FOpenWayID { get; set; }

        [MapColumnsToGridViewAttribute("FOpenWay", "FOpenWay", "方向", 9, true)]
        public string FOpenWay { get; set; }

        [MapColumnsToGridViewAttribute("FUnit", "FUnit", "单位", 8, true)]
        public string FUnit { get; set; }

        [MapColumnsToGridViewAttribute("FPhone", "FPhone", "电话", 9, true)]
        [FieldMap("FPhone", DbType.String)]
        public string FPhone
        {
            set { _fphone = value; }
            get { return _fphone; }
        }

        [MapColumnsToGridViewAttribute("FAddress", "FAddress", "地址", 10, true)]
        [FieldMap("FAddress", DbType.String)]
        public string FAddress
        {
            set { _faddress = value; }
            get { return _faddress; }
        }

        [MapColumnsToGridViewAttribute("FInstallDate", "FInstallDate", "安装日期", 11, true)]
        [FieldMap("FInstallDate", DbType.DateTime)]
        public DateTime FInstallDate { get; set; }

        [MapColumnsToGridViewAttribute("FQty", "FQty", "数量", 12, true)]
        [FieldMap("FQty", DbType.Int32)]
        public System.Int32 FQty
        {
            set { _fqty = value; }
            get { return _fqty; }
        }
        [MapColumnsToGridViewAttribute("FCustomerID", "FCustomerID", "", 13, false)]
        [FieldMap("FCustomerID", DbType.Int32)]
        public System.Int32 FCustomerID
        {
            set { _fcustomer = value; }
            get { return _fcustomer; }
        }

        [MapColumnsToGridViewAttribute("FCustomer", "FCustomer", "店铺名称", 14, true)]
        public string FCustomer { get; set; }

        [MapColumnsToGridViewAttribute("FInstallerID", "FInstallerID", "", 15, false)]
        [FieldMap("FInstallerID", DbType.Int32)]
        public System.Int32 FInstallerID
        {
            set { _finstaller = value; }
            get { return _finstaller; }
        }

        [MapColumnsToGridViewAttribute("FInstaller", "FInstaller", "安装员", 16, true)]
        public string FInstaller { get; set; }

        [MapColumnsToGridViewAttribute("FSalesmanID", "FSalesmanID", "", 17, false)]
        [FieldMap("FSalesmanID", DbType.Int32)]
        public int FSalesmanID { get; set; }

        [MapColumnsToGridViewAttribute("FSalesman", "FSalesman", "业务员", 18, true)]
        public string FSalesman { get; set; }

        [MapColumnsToGridViewAttribute("Fprice", "Fprice", "价格", 19, true)]
        [FieldMap("Fprice", DbType.Int32)]
        public System.Int32 Fprice
        {
            set { _fprice = value; }
            get { return _fprice; }
        }

        [MapColumnsToGridViewAttribute("FSettleAmount", "FSettleAmount", "实收金额", 19, true)]
        [FieldMap("FSettleAmount", DbType.Decimal)]
        public decimal FSettleAmount { get; set; }
        /// <summary>
        /// 
        [MapColumnsToGridViewAttribute("FauxPrice", "FauxPrice", "应收金额", 19, true)]       
        [FieldMap("FauxPrice", DbType.Decimal)]
        public System.Decimal FauxPrice
        {
            set { _fauxprice = value; }
            get { return _fauxprice; }
        }

        [MapColumnsToGridViewAttribute("FAccount", "FAccount", "是否结账", 19, true)]
        [FieldMap("FAccount", DbType.Boolean)]
        public bool FAccount { get; set; }

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

        [MapColumnsToGridViewAttribute("FNote", "FNote", "备注", 20, true)]
        [FieldMap("FNote", DbType.String)]
        public string FNote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }
        #endregion Model

        public void Delete()
        {
            this.deleted(false);
        }

        public void Save()
        {
            if (FInterID == 0)
            {
                FInterID = SqlCom.GetMaxNum("t_Installation");
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

        public t_Installation Create()
        {
            t_Installation item = new t_Installation();
            return item;
        }
        #region 把表格数据加载传给实体

        public t_Installation LoadEntity(int FInterID)
        {
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_Installation>("select * from t_Installation where FInterID =@FInterID  order by FBillNo",
                   new SqlParameter("@FInterID", FInterID));
            }
        }

        public DataTable LoadList(string cond)
        {
            string selestr = string.Format(@"select * from V_t_Installation             
                                            where {0} ", cond);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.DataQuery(selestr).Tables[0];
            }
        }
        #endregion
    }
    public interface IInstallation
    {
        t_Installation LoadEntity(int fitemID);

        void Save(t_Installation item);

        t_Installation Create();

        void Delete(int FItemID);

        DataTable LoadList(string cond);
    }
}
