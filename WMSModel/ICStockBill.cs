using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMSDAL.Entry;
using WMSDAL.Map;
using WMSDAL.Sql;

namespace WMSModel
{
    [TableMap("ICStockBill", "FInterID")]
    public class ICStockBill : EntryObject
    {
        [MapColumnsToGridViewAttribute("FInterID", "FInterID", "", 1, false)]
        [FieldMap("FInterID", DbType.Int32)]
        public int FInterID { get; set; }

        [MapColumnsToGridViewAttribute("FBillNo", "FBillNo", "入库单号", 2, true)]
        [FieldMap("FBillNo",DbType.String)]
        public string FBillNo { get; set; }

        [MapColumnsToGridViewAttribute("FDate", "FDate", "入库时间", 3, true)]
        [FieldMap("FDate", DbType.DateTime)]
        public DateTime FDate { get; set; }

        [MapColumnsToGridViewAttribute("FEmpID", "FEmpID", "", 12, false)]
        [FieldMap("FEmpID", DbType.Int32)]
        public int FEmpID { get; set; }

        [MapColumnsToGridViewAttribute("FEmp", "FEmp", "业务员", 13, true)]
        public string FEmp { get; set; }

        [MapColumnsToGridViewAttribute("FDeptID", "FDeptID", "", 14, false)]
        [FieldMap("FDeptID", DbType.Int32)]
        public int FDeptID { get; set; }

        [MapColumnsToGridViewAttribute("FDept", "FDept", "部门", 15, true)]
        public string FDept { get; set; }

        [MapColumnsToGridViewAttribute("FSupplyID", "FSupplyID", "", 16, false)]
        [FieldMap("FSupplyID", DbType.Int32)]
        public int FSupplyID { get; set; }

        [MapColumnsToGridViewAttribute("FSupplier", "FSupplier", "供应商", 17, true)]
        public string FSupplier { get; set; }

        //[FieldMap("FNote", DbType.String)]
        //public string FNote { get; set; }

        [FieldMap("FCreateTime", DbType.String)]
        public DateTime FCreateTime { get; set; }

        [FieldMap("FLastModDate", DbType.DateTime)]
        public DateTime FLastModDate { get; set; }

        [FieldMap("FModifyBy", DbType.Int32)]
        public int FModifyBy { get; set; }

        [SubObject(typeof(ICStockBillEntry), typeof(List<ICStockBillEntry>), "FinterID", "FinterID")]
        public List<ICStockBillEntry> ListEntity { get; set; }

        #region Function
        //public ICStockBill CreateInsance()
        //{
        //    return  new ICStockBill();
        //}
        public ICStockBill GetInstance(int FInterID)
        {
            try
            {
                using (DbSession db = Db.Get())
                {
                    db.OpenConnection();
                    ICStockBill instance = db.QueryObject<ICStockBill>(
                        "select * from V_ICStockBill where FInterID= @FInterID ",
                        new SqlParameter("@FInterID", FInterID));
                    return instance;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ICStockBillEntry> GetEntity(int FInterID)
        {
            try
            {
                using (DbSession dbSession = Db.Get())
                {
                    dbSession.OpenConnection();
                    List<ICStockBillEntry> listEntity = dbSession.QueryEntity<ICStockBillEntry>(
                        "select * from V_ICStockBillEntry where FInterID=@FInterID",
                        new SqlParameter("@FInterID", FInterID));
                    return listEntity;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadList(string cond)
        {
            string strSQL = string.Format("select * from V_ICStockBillList where {0}", cond);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.DataQuery(strSQL).Tables[0];
            }
        }

        public void Save()
        {
            if (FInterID == 0)
            {
                FInterID = SqlCom.GetMaxNum("ICStockBill");
                for (int i = 0; i < ListEntity.Count; i++)
                {
                    ListEntity[i].FInterID = FInterID;
                    ListEntity[i].FEntryID = i + 1;
                }
                this.add();
            }
            else
                this.update();
        }
        #endregion
    }

    [TableMap("ICStockBillEntry", "FinterID")]
    public class ICStockBillEntry
    {
        [MapColumnsToGridViewAttribute("FInterID", "FInterID", "",4, false)]
        [FieldMap("FInterID", DbType.Int32)]
        public int FInterID { get; set; }

        [FieldMap("FEntryID", DbType.Int32)]
        public int FEntryID { get; set; }

        [FieldRelation(FFieldName = "FItemName", FReturnName = "FItemID")]
        [MapColumnsToGridViewAttribute("FItemID", "FItemID", "", 5, false)]
        [FieldMap("FItemID", DbType.Int32)]
        public int FItemID { get; set; }

        [FieldRelation(FFieldName = "FItemName", FReturnName = "FNumber")]
        [MapColumnsToGridViewAttribute("FNumber", "FNumber", "代码", 6, true)]
        public string FNumber { get; set; }

        [FieldRelation(FFieldName = "FItemName", FReturnName = "FName")]
        [MapColumnsToGridViewAttribute("FItemName", "FItemName", "货品名称", 7, true)]
        public string FItemName { get; set; }

        [MapColumnsToGridViewAttribute("FDimension", "FDimension", "尺寸", 8, true)]
        public string FDimension { get; set; }

        [MapColumnsToGridViewAttribute("FOpenWay", "FOpenWay", "方向", 9, true)]
        public string FOpenWay { get; set; }

       [MapColumnsToGridViewAttribute("FUnit", "FUnit", "单位", 10, true)]
        public string FUnit { get; set; }

       [MapColumnsToGridViewAttribute("FQty", "FQty", "数量", 11, true)]
        [FieldMap("FQty", DbType.Int32)]
        public int FQty { get; set; }

       [MapColumnsToGridViewAttribute("FPrice", "FPrice", "价格", 12, true)]
        [FieldMap("FPrice", DbType.Decimal)]
        public decimal FPrice { get; set; }

       [MapColumnsToGridViewAttribute("FNote", "FNote", "备注", 18, true)]
        [FieldMap("FNote", DbType.String)]
        public string FNote { get; set; }
    }
    public interface IICStockBill
    {
        DataTable LoadList(string cond);

        ICStockBill GetInstance(int FInterID);

        List<ICStockBillEntry> GetEntity(int FInterID);

        void Save( ICStockBill entity);
    }
}
