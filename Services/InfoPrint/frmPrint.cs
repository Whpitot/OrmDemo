using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using WMSDAL.Sql;
using grproLib;

namespace Services.InfoPrint
{
    public partial class frmPrint : Form
    {
        //定义Grid++Report报表主对象
        protected GridppReport rptMain = new GridppReport();
        AxgrproLib.AxGRPrintViewer axGRPrintViewer1;
        public string FCustomer { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Template { get; set; }

        public frmPrint()
        {
            InitializeComponent();
        }

        #region 向G++控件赋值
        private void InitGridPrinter()
        {
            if (axGRPrintViewer1 != null)
            {
                axGRPrintViewer1.Stop();
            }

            axGRPrintViewer1 = new AxgrproLib.AxGRPrintViewer();
            axGRPrintViewer1.Name = "axGRPrintViewer1";
            axGRPrintViewer1.Left = 200;
            axGRPrintViewer1.Top = 200;
            axGRPrintViewer1.Width = 500;
            axGRPrintViewer1.Height = 800;

            if (Controls.Find("axGRPrintViewer1", true).Length <= 0)
                this.Controls.Add(this.axGRPrintViewer1);

            axGRPrintViewer1.Dock = DockStyle.Fill;
            this.axGRPrintViewer1.BringToFront();

            //载入报表模板数据
            string Path = Application.StartupPath;
            rptMain.LoadFromFile(Path + @"\grf\" + Template + ".grf");

            rptMain.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportBGFetchRecord);

            //导出前事件
            rptMain.ExportBegin += new _IGridppReportEvents_ExportBeginEventHandler(ExportBegin);
            rptMain.Title = FCustomer+EndDate;//设置导出时的文件名
            rptMain.PrintPreview(true);
            this.Close();
        }
        #endregion

        private void ReportBGFetchRecord()
        {
            string sql = "exec pro_EveryMonthBill @beginDate,@endDate,@customer";
            SqlParameter[] paras ={
                                     new SqlParameter("@beginDate",BeginDate),
                                     new SqlParameter("@endDate",EndDate),
                                     new SqlParameter("@customer",FCustomer)
                                 };
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                DataTable dt = db.DataQuery(sql,paras).Tables[0];
                GridppReportDemo.Utility.FillRecordToReport(rptMain, dt);
            }   
        }

        #region ExportBegin 导出前参数设置
        private void ExportBegin(IGRExportOption ExportOption)
        {
            ExportOption.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            ExportOption.AsE2XLSOption.OnlyExportDetailGrid = false;

            //AsE2XLSOption:获取将本对象转换为导出Excel文件选项对象的接口引用
            ExportOption.AsE2XLSOption.SupressEmptyLines = false;
        }
        #endregion

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            rptMain.Print(true);
            axGRPrintViewer1.Refresh();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            InitGridPrinter();
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            rptMain.PrintPreview(true);
            axGRPrintViewer1.Refresh();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCheck_Click(object sender, EventArgs e)
        {
            axGRPrintViewer1.Refresh();
        }
    }
}
