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
    using Services.FormSelect;
    using Services.InfoPrint;

    public partial class frmAssemblyMng : BaseEditForm
    {
        public frmAssemblyMng()
        {
            InitializeComponent();
        }

        IAssembly iassemble = new AssemblySession();
        t_Assemble _instance;

        protected override void InitControls()
        {
            base.InitControls();
            gridView1.IndicatorWidth = 40;//指示器。标志            
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            txtFEmp.SelectService = new EmpService();
            txtFInstaller.SelectService = new EmpService();
            txtFCustomer.SelectService = new CustomerService();
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
                cond += string.Format(" and FDate >='{0}' and FDate<='{1}'", FDateBegin.Value.ToShortDateString(), FDateEnd.Value.ToShortDateString());
            }
            if (chkInstall.Checked)
            {
                cond += string.Format(" and FInstallDate >='{0}' and FInstallDate<='{1}'", FAZDateBegin.Value.ToShortDateString(), FAZDateEnd.Value.ToShortDateString());
            }
            cond += " order by FInterID,FDate,FBillNO";
            return cond;
        }

         #region RefreshGrid 请求数据
        /// <summary>
        /// 请求数据
        /// </summary>
        /// <param name="quicklySearchMode">是否快捷过滤方式</param>
        /// <param name="isRefreash">是否是刷新导致的请求数据</param>
        private void RefreshGrid()
        {
            string strQuery = BuiderCondition();
            if (strQuery != "")
            {
                this.Cursor = Cursors.WaitCursor;
                c_grcMain.DataSource = iassemble.LoadList(strQuery);             
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        private void btn_Query_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RefreshGrid();
            this.Cursor = Cursors.Default;
        }

        #region 自动行号
        /// <summary>
        /// 自动行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion

        private DataRowView GetFocusRow()
        {
            var data = gridView1.GetFocusedRow() as DataRowView;
            if (data == null)
            {
                throw new Exception("当前没有选择行");
            }
            return data;
        }

        private void c_grcMain_DoubleClick(object sender, EventArgs e)
        {
            frmAssembly frmassembly = new frmAssembly();
            frmassembly._id = Convert.ToInt32(GetFocusRow()["FInterID"]);
            frmassembly.BillMngGridService = this;
            frmassembly.ShowDialog();
        }

        #region Add 新增单据，基类方法扩展
        protected override void Add()
        {
            frmAssembly frm = new frmAssembly();
            frm.ShowDialog();
            base.Add();
        }

        protected override void Print()
        {
            BillPrintFunction("EveryMonthBill");
        }
        #endregion

        #region BillPrintFunction  单据打印
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
        #endregion
    }
}