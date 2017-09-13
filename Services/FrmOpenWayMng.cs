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
    using ServiceLib;
    using WMSDAL.Entry;
    using WMSModel;
    public partial class FrmOpenWayMng : BaseEditMng
    {
        public FrmOpenWayMng()
        {
            InitializeComponent();
        }

        IOpenWay iProxy = new OpenWaySession();
        public OpenWay SelectedItem;
        

        protected override void InitControls()
        {
            base.InitControls();
            AutoHandleGridView.AutoBindColumnToGridView<Dimension>(gridView1);
            gridView1.OptionsBehavior.Editable = false;
        }

        private void QueryList()
        {
            string cond = " 1=1 ";

            if (txtFNumber.Text.Trim() != "")
            {
                cond += string.Format(" and FNumber like '%{0}%'", txtFNumber.Text.Trim());
            }
            if (txtFName.Text.Trim() != "")
            {
                cond += string.Format(" and FNumber like '%{0}%'", txtFName.Text.Trim());
            }
            cond += " order by FItemID";

            this.Cursor = Cursors.WaitCursor;
            gridControl1.DataSource = iProxy.LoadList(cond);
            this.Cursor = Cursors.Default;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            QueryList();
        }

        private void FrmDimensionMng_Load(object sender, EventArgs e)
        {
            QueryList();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)//作为实体集合来加载
        {
            //做到实时更新数据，用了模态模式就不用单例模式了，要不要这样用？
            if (SelectModel)
            {
                SelectedItem = gridView1.GetFocusedRow() as OpenWay;
                CloseForm(DialogResult.OK);
            }
            else
            {
                FrmOpenWay editForm = new FrmOpenWay();
                SelectedItem = gridView1.GetFocusedRow() as OpenWay;
                editForm.FItemID = SelectedItem.FItemID;
                editForm.ReLoadInstance += QueryList;
                editForm.BillMngGridService = this;
                editForm.ShowDialog();
            }
        }

        protected override void Add()
        {
            FrmOpenWay editForm = new FrmOpenWay();
            editForm.ReLoadInstance += QueryList;
            editForm.ShowDialog();
            editForm.BillMngGridService = this;
        }

        protected override void Delete()
        {
            if (MessageBox.Show("确定要删除吗？", "文迪软件", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SelectedItem = gridView1.GetFocusedRow() as OpenWay;
                int FItemID = SelectedItem.FItemID;
                iProxy.Delete(FItemID);
                QueryList();
            }
        }
    }
}
