using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controls;
using WMSModel;
using ServiceLib;
using WMSDAL;
using WMSDAL.Entry;

namespace Services
{
    public partial class FrmICStockBillMng : BaseEditMng
    {
        public FrmICStockBillMng()
        {
            InitializeComponent();
        }

        IICStockBill iICStockBill = new ICStockBillSession();
        protected override void InitControls()
        {
            base.InitControls();
            AutoHandleGridView.AutoBindColumnToGridView<ICStockBill>(gridView1);
            AutoHandleGridView.AutoBindColumnToGridView<ICStockBillEntry>(gridView1);
        }

        private void QueryList()
        {
            string cond = " 1=1 ";

            if (txtFBillNo.Text.Trim() != "")
            {
                cond += string.Format(" and FBillNO like '%{0}%'", txtFBillNo.Text.Trim());
            }
            if (chkOrder.Checked)
            {
                cond += string.Format(" and FDate >='{0}' and FDate<='{1}'", FDateBegin.Value.ToShortDateString(), FDateEnd.Value.ToShortDateString());
            }
            cond += " order by FInterID";

            gridControl1.DataSource = iICStockBill.LoadList(cond);
        }


        private void btn_Query_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            QueryList();
            this.Cursor = Cursors.Default;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmICStockBill frmICStockBill = new FrmICStockBill();
            frmICStockBill._id = Convert.ToInt32(GetFocusRow()["FInterID"]);
            frmICStockBill.BillMngGridService = this;
            frmICStockBill.ShowDialog();
        }

        protected override void Add()
        {
            FrmICStockBill frmICStockBill = new FrmICStockBill();
            frmICStockBill.ShowDialog();
        }

        private void FrmICStockBillMng_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            QueryList();
            this.Cursor = Cursors.Default;
        }
    }
}
