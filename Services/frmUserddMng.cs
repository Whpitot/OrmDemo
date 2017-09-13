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
    using WMSModel;
    using ServiceLib;

    public partial class frmUserddMng : Form
    {
        public frmUserddMng()
        {
            InitializeComponent();
            LoadGrid();
        }

        IUser iuser = new UserSession();
        frmUser frmuser;

        //减少if else 的使用
        void LoadGrid()
        {
            string FNumber = "";
            t_User[] user = iuser.LoadEntities(FNumber);
            c_grcMain.DataSource = user;
        }

        private t_User GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_User;
        }
        protected override void Add()
        {
            frmuser = new frmUser();
            frmuser.BillMngGridService = this;
            DialogResult result = frmuser.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadGrid();
            }
        }

        protected override void Delete()
        {
            if (MessageBox.Show("确定要删除该记录？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            iuser.Delete(GetFocusRow().FUserID);
            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK);
            LoadGrid();
        }

        public override int MoveNextRow()
        {
            gridView1.MoveNext();

            return GetFocusRow().FUserID;
        }

        public override int MovePrevRow()
        {
            gridView1.MovePrev();
            return GetFocusRow().FUserID;
        }

        private void c_grcTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            LoadGrid();
        }

        private void c_grcMain_DoubleClick(object sender, EventArgs e)
        {
            frmuser = new frmUser();
            frmuser.FUserID = GetFocusRow().FUserID;
            int A = 33;
            frmuser.BillMngGridService = this;
            DialogResult result = frmuser.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadGrid();
            }
        }
    }
}
