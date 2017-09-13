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

    [Serializable]

    [TableMap("t_Assemble", "FinterID")]
    public partial class t_Assemble:EntryObject
    {
        public t_Assemble()
        { }
        #region Model
        private int _finterid;
        private string _fbillno;
        private DateTime _fdate;
        private int _fempid;
        private string _fmanagerid;
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FInterID", DbType.Int32)]
        public int FinterID
        {
            set { _finterid = value; }
            get { return _finterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FBillNO", DbType.String)]
        public string FBillNO
        {
            set { _fbillno = value; }
            get { return _fbillno; }
        }
        /// <summary>
        /// 
        /// </summary>
         [FieldMap("FDate", DbType.Date)]
        public DateTime FDate
        {
            set { _fdate = value; }
            get { return _fdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FEmpID", DbType.Int32)]
        public int FEmpID
        {
            set { _fempid = value; }
            get { return _fempid; }
        }
        //[FieldMap("FEmp", DbType.String)]
        [FieldRelation(FFieldName = "FEmp", FReturnName = "FName")]
        public string FEmp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldRelation(FFieldName = "FManager", FReturnName = "FItemID")]
        [FieldMap("FManagerID", DbType.Int32)]
        public string FManagerID
        {
            set { _fmanagerid = value; }
            get { return _fmanagerid; }
        }

        [FieldRelation(FFieldName = "FManager", FReturnName = "FName")]
        public string FManager { get; set; }

        [SubObject(typeof(t_AssembleEntry),typeof(List<t_AssembleEntry>),"FinterID","FinterID")]
        public List<t_AssembleEntry> EntryList { get; set; }
        #endregion Model

        #region Function
        public DataTable GetData(string sql)
        {
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.DataQuery(sql).Tables[0];
            }
        }

        public t_Assemble SetInstance(int FInterID)
        {
            try
            {
                using (DbSession db = Db.Get())
                {
                    db.OpenConnection();
                    t_Assemble assmeble = db.QueryObject<t_Assemble>("select * from V_t_assemble where FInterID= @FInterID ",
                        new SqlParameter("@FInterID", FInterID));
                    return assmeble;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //create a instance
        public t_Assemble Create()
        {
            t_Assemble _fbill = new t_Assemble();
            return _fbill;
        }

        //Get a rand number of t_assemble as sign
        public string GetRandNum(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new Exception(" 必须指定类型代码！");
            }
            string curno = string.Empty;
            string flag = string.Empty;
            string fbillno;
            string sqlstr = string.Format(@"Update ICBillNo Set FCurNo=FCurNo+1 where FBillID= {0} ;
                                          Select FPreLetter,FCurNo,FFormat From ICBillNo where FBillID = {0}", type);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                using (IDataReader reader = db.QueryReader(sqlstr))
                {
                    reader.Read();
                    fbillno = reader["FPreLetter"].ToString() + reader["FFormat"].ToString();
                    String curno2 = reader["FCurNo"].ToString();
                    fbillno = fbillno.Substring(0, fbillno.Length - curno2.Length) + curno2;
                    reader.Close();
                }
            }
            return fbillno;
        }

        public t_AssembleEntry[] GetEntrys(int fid)
        {
            string selestr = string.Format(@"select * from V_t_AssembleEntry             
                                            where FInterID = {0} ORDER BY FInterID ", fid);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_AssembleEntry>(selestr);
            }
        }

        public DataTable LoadList(string cond)
        {
            string selestr = string.Format(@"select * from V_t_assembleList             
                                            where {0} ", cond);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.DataQuery(selestr).Tables[0];
            }
        }

        public void Save()
        {
            //添加操作
            if (FinterID == 0)
            {
                FinterID = SqlCom.GetMaxNum("t_Assemble");
                for (int i = 0; i < EntryList.Count; i++)
                {
                    EntryList[i].FInterID = FinterID;
                    EntryList[i].FEntryID = i + 1;
                }
                this.add();
            }
            else
            {
                this.update();
            }
        }
        #endregion
    }

    [Serializable]
    [TableMap("t_AssembleEntry", "FinterID")]
    public partial class t_AssembleEntry
    {
        public t_AssembleEntry()
        { }
        #region Model
        private System.Int32 _finterid;
        private System.Int32 _fentryid;
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
        [FieldMap("FInterID", DbType.Int32)]        
        public System.Int32 FInterID
        {
            set { _finterid = value; }
            get { return _finterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FEntryID", DbType.Int32)]
        public System.Int32 FEntryID
        {
            set { _fentryid = value; }
            get { return _fentryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldRelation(FFieldName = "FItemName", FReturnName = "FItemID")]
        [FieldMap("FItemID", DbType.Int32)]
        public System.Int32 FItemID
        {
            set { _fitemid = value; }
            get { return _fitemid; }
        }
        [FieldRelation(FFieldName = "FItemName", FReturnName = "FName")]
        public string FItemName { get; set; }

        [FieldRelation(FFieldName = "FItemName", FReturnName = "FNumber")]
        public string FNumber { get; set; }

        [FieldRelation(FFieldName = "FItemName", FReturnName = "FUnit")]
        public string FUnit { get; set; }

        [FieldRelation(FFieldName = "FItemName", FReturnName = "FModel")]
        public string FModel { get; set; }

        [FieldMap("FInstallDate", DbType.DateTime)]
        public DateTime FInstallDate { get; set; }  
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FPhone", DbType.String)]
        public string FPhone
        {
            set { _fphone = value; }
            get { return _fphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FAddress", DbType.String)]
        public string FAddress
        {
            set { _faddress = value; }
            get { return _faddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FQty", DbType.Int32)]
        public System.Int32 FQty
        {
            set { _fqty = value; }
            get { return _fqty; }
        }

        /// <summary>
        /// 
        /// </summary>
        [FieldRelation(FFieldName = "FCustomer", FReturnName = "FItemID")]
        [FieldMap("FCustomerID", DbType.Int32)]
        public System.Int32 FCustomerID
        {
            set { _fcustomer = value; }
            get { return _fcustomer; }
        }
        [FieldRelation(FFieldName = "FCustomer", FReturnName = "FName")]
        public string FCustomer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldRelation(FFieldName = "FInstaller", FReturnName = "FItemID")]
        [FieldMap("FInstallerID", DbType.Int32)]
        public System.Int32 FInstallerID
        {
            set { _finstaller = value; }
            get { return _finstaller; }
        }

        [FieldRelation(FFieldName = "FInstaller", FReturnName = "FName")]
        public string FInstaller { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("Fprice", DbType.Int32)]
        public System.Int32 Fprice
        {
            set { _fprice = value; }
            get { return _fprice; }
        }

        [FieldMap("FSettleAmount", DbType.Decimal)]
        public decimal FSettleAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FauxPrice", DbType.Decimal)]
        public System.Decimal FauxPrice
        {
            set { _fauxprice = value; }
            get { return _fauxprice; }
        }

        [FieldMap("FAccount", DbType.Boolean)]
        public bool FAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FNote", DbType.String)]
        public string FNote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }                      
        #endregion Model
    }
    public interface IAssembly
    {
        DataTable GetData(string sql);

        t_Assemble SetInstance(int fid);

        t_Assemble Create();

        string GetRandNum(string type);

        t_AssembleEntry[] GetEntrys(int fid);

        DataTable LoadList(string cond);

        void Save(t_Assemble _instance);
    }

}
