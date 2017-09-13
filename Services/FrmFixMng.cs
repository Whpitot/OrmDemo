using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    using WMSDAL.Sql;
    using WMSModel;
    using ServiceLib;
    using Controls;
    using Main;
    using WMSDAL.Entry;
    using Services.FormSelect;

    public partial class FrmFixMng : BaseEditMng
    {
        public FrmFixMng()
        {
            InitializeComponent();
        }

        IFix ifix = new FixSession();

        protected override void InitControls()
        {
            base.InitControls();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsNavigation.AutoFocusNewRow = true;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;

            txtFFixer.SelectService = new EmpService();

            AutoHandleGridView.AutoBindColumnToGridView<t_Fix>(gridView1);

            //GridGroupSummaryItem item = new GridGroupSummaryItem();
            //item.FieldName = "FauxPrice";
            //item.DisplayFormat = "（总计 = {0}）";
            //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //item.ShowInGroupColumnFooter = FauxPrice;
            ////item.ShowInGroupColumnFooter=
            //gridView1.GroupSummary.Add(item);
            //gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "FauxPrice", FauxPrice, "（总计 = {0}）");
            //gridView1.GroupSummary.s


            QueryDate();


        }
        private string BuiderCondition()
        {
            string cond = " 1=1 ";

            if (txtFBillNo.Text.Trim() != "")
            {
                cond += string.Format(" and FBillNO like '%{0}%'", txtFBillNo.Text.Trim());
            }
        
            if (txtFFixer.Text.Trim() != "")
            {
                cond += string.Format(" and FFixer like '%{0}%'", txtFFixer.Text.Trim());
            }
            if (cboDate.Checked)
            {
                cond += string.Format(" and FReocrdDate >='{0}' and FReocrdDate<='{1}'", FDateBegin.Value.ToShortDateString(), FDateEnd.Value.ToShortDateString());
            }
            cond += " order by FInterID";
            return cond;
        }

        public void QueryDate()
        {
            string strQuery = BuiderCondition();
            if (strQuery != "")
            {
                this.Cursor = Cursors.WaitCursor;
                gridControl1.DataSource = ifix.LoadList(strQuery);
                this.Cursor = Cursors.Default;
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            QueryDate();
            this.Cursor = Cursors.Default;
        }
              
        private void c_grcMain_DoubleClick(object sender, EventArgs e)
        {
            FrmFix frmModify = new FrmFix();
            frmModify._id = Convert.ToInt32(GetFocusRow()["FInterID"]);
            frmModify.BillMngGridService = this;
            frmModify.ShowDialog();
        }

        protected override void Add()
        {
            FrmFix frmModify = new FrmFix();
            frmModify.ShowDialog();
        }
    }
}
