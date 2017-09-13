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
    using Controls;
    using Services.FormSelect;
    using ServiceLib;
    using WMSModel;
    using Services.InfoPrint;
    using WMSDAL.Entry;
    using DevExpress.DXCore.Controls.XtraGrid;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.Data;
    public partial class FrmInstallationMng : BaseEditForm
    {
        public FrmInstallationMng()
        {
            InitializeComponent();
        }

        IInstallation iIstallation = new InstallationSession();

        protected override void InitControls()
        {
            base.InitControls();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsNavigation.AutoFocusNewRow = true;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;

            gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Peru;
            gridView1.ColumnPanelRowHeight = 40;
            gridView1.IndicatorWidth = 40;

            txtFEmp.SelectService = new EmpService();
            txtFCustomer.SelectService = new CustomerService();
            txtFInstaller.SelectService = new EmpService();

            AutoHandleGridView.AutoBindColumnToGridView<t_Installation>(gridView1);
            AutoHandleGridView.CalculateSumOfColumns(gridView1, new string[] { "FQty" }, SummaryItemType.Sum);
            //不用手动去绑定CheckBox.
        }

        private void dd()
        {
            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "FauxPrice";
            //item.DisplayFormat = "（总计 = {0}）";  
            item.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.GroupSummary.Add(item);
        }
        private string BuiderCondition()
        {
            string cond = " 1=1 ";

            if (FBillNO.Text.Trim() != "")
            {
                cond += string.Format(" and FBillNO like '%{0}%'", FBillNO.Text.Trim());
            }
            if (txtFEmp.Text.Trim() != "")
            {
                cond += string.Format(" and FEmp like '%{0}%'", txtFEmp.Text.Trim());
            }
            if (txtFCustomer.Text.Trim() != "")
            {
                cond += string.Format(" and FCustomer like '%{0}%'", txtFCustomer.Text.Trim());
            }
            if (txtFInstaller.Text.Trim() != "")
            {
                cond += string.Format(" and FInstaller like '%{0}%'", txtFInstaller.Text.Trim());
            }
            if (chkOrder.Checked)
            {
                cond += string.Format(" and FRecordDate >='{0}' and FRecordDate<='{1}'", FDateBegin.Value.ToShortDateString(), FDateEnd.Value.ToShortDateString());
            }
            if (chkInstall.Checked)
            {
                cond += string.Format(" and FInstallDate >='{0}' and FInstallDate<='{1}'", FAZDateBegin.Value.ToShortDateString(), FAZDateEnd.Value.ToShortDateString());
            }
            cond += " order by FBillNO";
            return cond;
        }

        public void QueryDate()
        {
            string strQuery = BuiderCondition();
            if (strQuery != "")
            {
                this.Cursor = Cursors.WaitCursor;
                gridControl1.DataSource = iIstallation.LoadList(strQuery);
                this.Cursor = Cursors.Default;
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            QueryDate();
            this.Cursor = Cursors.Default;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetRow(e.RowHandle) != null)
            {
                bool state = Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, "FAccount"));
                if (state)
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
            }
        }

        private DataRowView GetFocusRow()
        {
            var data = gridView1.GetFocusedRow() as DataRowView;
            if (data == null)
            {
                throw new Exception("当前没有选择行");
            }
            return data;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmInstallation frminstallation = new FrmInstallation();
            frminstallation._id = Convert.ToInt32(GetFocusRow()["FInterID"]);
            frminstallation.BillMngGridService = this;
            frminstallation.ShowDialog();
        }

         protected override void Add()
        {
            FrmInstallation frminstallation = new FrmInstallation();
            frminstallation.ShowDialog();
        }

        protected override void Print()
        {
            BillPrintFunction("EveryMonthBill");
        }

        private void BillPrintFunction(string templatename)
        {
            if (string.IsNullOrEmpty(txtFCustomer.Text.Trim()))
            {
                Msgbox.Info("请先选择客户名称");
                return;
            }
            frmPrint frm = new frmPrint()
            { 
                FCustomer = txtFCustomer.Text.Trim(),
                BeginDate =Convert.ToDateTime(FAZDateBegin.Text),
                EndDate =Convert.ToDateTime(FAZDateEnd.Text),
                Template=templatename
            };
            frm.ShowDialog();
        }
    }
}
