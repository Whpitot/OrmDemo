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

    [TableMap("t_Fix", "FinterID")]
    public partial class t_Fix : EntryObject
    {
        public t_Fix()
        { }
        #region Model
        private int _finterid;
        private string _fbillno;
        private string _faddress;
        private string _fphone;
        private System.Int32 _ffixerID;
        private string _fnotes;

        [MapColumnsToGridViewAttribute("FInterID", "FInterID", "", 1, false)]
        [FieldMap("FInterID", DbType.Int32)]
        public int FinterID
        {
            set { _finterid = value; }
            get { return _finterid; }
        }
        [MapColumnsToGridViewAttribute("FBillNo", "FBillNo", "维修单号", 1, true)]
        [FieldMap("FBillNo", DbType.String)]
        public string FBillNo
        {
            set { _fbillno = value; }
            get { return _fbillno; }
        }

        [MapColumnsToGridViewAttribute("FRecordDate", "FRecordDate", "报单日期", 1, true)]
        [FieldMap("FRecordDate", DbType.DateTime)]
        public DateTime FRecordDate { get; set; }

        [MapColumnsToGridViewAttribute("FPhone", "FPhone", "电话", 1, true)]
        [FieldMap("FPhone", DbType.String)]
        public string FPhone
        {
            set { _fphone = value; }
            get { return _fphone; }
        }

        [MapColumnsToGridViewAttribute("FAddress", "FAddress", "地址", 1, true)]
        [FieldMap("FAddress", DbType.String)]
        public string FAddress
        {
            set { _faddress = value; }
            get { return _faddress; }
        }
        [MapColumnsToGridViewAttribute("FFixerID", "FFixerID", "", 1, false)]
        [FieldMap("FFixerID", DbType.Int32)]
        public System.Int32 FFixerID
        {
            set { _ffixerID = value; }
            get { return _ffixerID; }
        }
        [MapColumnsToGridViewAttribute("FFixer", "FFixer", "维修员", 1, true)]
        public string FFixer { get; set; }

        [MapColumnsToGridViewAttribute("FFixDate", "FFixDate", "", 1, false)]
        [FieldMap("FFixDate", DbType.DateTime)]
        public DateTime FFixDate { get; set; }

        [MapColumnsToGridViewAttribute("FRecorderID", "FRecorderID", "", 1, false)]
        [FieldMap("FRecorderID", DbType.Int32)]
        public int FRecordID { get; set; }

        [MapColumnsToGridViewAttribute("FRecorder", "FRecorder", "业务员", 1, true)]
        public string FRecorder { get; set; }

        [MapColumnsToGridViewAttribute("FNote", "FNote", "备注", 1, true)]
        [FieldMap("FNote", DbType.String)]
        public string FNote
        {
            set { _fnotes = value; }
            get { return _fnotes; }
        }

        [FieldMap("FCreateTime", DbType.DateTime)]
        public DateTime FCreateTime { get; set; }

        [FieldMap("FLastModDate", DbType.DateTime)]
        public DateTime FLastModDate { get; set; }

        [FieldMap("FModifyBy", DbType.DateTime)]
        public int FModifyBy { get; set; }

        #endregion Model

        #region Function
        public DataTable LoadList(string cond)
        {
            string selestr = string.Format(@"select * from V_t_FixList             
                                            where {0} ", cond);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.DataQuery(selestr).Tables[0];
            }
        }

        public t_Fix Create()
        {
            t_Fix _fbill = new t_Fix();
            return _fbill;
        }


        public t_Fix LoadEntity(int FInterID)
        {
            string selestr = string.Format(@" ", FInterID);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_Fix>("select * from t_Fix  where FInterID = @FInterID ORDER BY FInterID"
                    ,new SqlParameter("@FInterID",FInterID));
            }
        }

        public void Save()
        {
            //添加操作
            if (FinterID == 0)
            {
                FinterID = SqlCom.GetMaxNum("t_Fix");
                FCreateTime = DateTime.Now;
                this.add();
            }
            else
            {
                this.update();   
            }
        }
        #endregion
    }

    public interface IFix
    {
        DataTable LoadList(string cond);

        t_Fix LoadEntity(int fid);

        t_Fix Create();

        void Save(t_Fix _instance);
    }
}

   