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
    public partial class FrmUserMng : BaseEditMng
    {
        public FrmUserMng()
        {
            InitializeComponent();
        }

        IUser iProxy = new UserSession();
        t_User SelectedItem;
       
        protected override void InitControls()
        {
            base.InitControls();
            AutoHandleGridView.AutoBindColumnToGridView<t_User>(gridView1);
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
                cond += string.Format(" and FName like '%{0}%'", txtFName.Text.Trim());
            }
            cond += " and FDeleted=0 order by FItemID";

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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //做到实时更新数据，用了模态模式就不用单例模式了，要不要这样用？
                FrmUser editForm = new FrmUser();
                SelectedItem = gridView1.GetFocusedRow() as t_User;
                editForm.FItemID = SelectedItem.FItemID;
                editForm.ReLoadInstance += QueryList;
                editForm.ShowDialog();
                editForm.BillMngGridService = this;
        }

        protected override void Add()
        {
            FrmUser editForm = new FrmUser();
            editForm.ReLoadInstance += QueryList;
            editForm.ShowDialog();
            editForm.BillMngGridService = this;
        }

        protected override void Delete()
        {
            if (MessageBox.Show("确定要删除吗？", "文迪软件", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SelectedItem = gridView1.GetFocusedRow() as t_User;
                int FItemID = SelectedItem.FItemID;
                iProxy.Delete(FItemID);
                QueryList();
            }
        }
    }
}
