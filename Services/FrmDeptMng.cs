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

    //不含分类项的情况
    public partial class FrmDeptMng : BaseEditForm
    {
        IDept idept = new DeptSession();
        frmDept frmdept;
        public t_Dept SelectedItem;

        public FrmDeptMng()
        {
            InitializeComponent();
            LoadTree();
        }

        //使用参数的形式
        void LoadTree()
        {
            t_Dept[] depts = idept.LoadEntities();
            c_grcTree.DataSource = depts;
            c_grcTree.ExpandAll();
        }

        //减少if else 的使用
        void LoadGrid()
        {
            if (c_grcTree.FocusedNode != null)
            {
                int FItemID =Convert.ToInt32(GetInstanceByNode().FItemID);
                //grid加载数据源必须要是以数组的形式加载才可以的
                t_Dept[] depts = idept.LoadEntities(FItemID);
                c_grcMain.DataSource = depts;
            }
        }

        private t_Dept GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_Dept; 
        }

        private t_Dept GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_Dept;
        }


        private void c_grcMain_DoubleClick(object sender, EventArgs e)
        {
            //做到实时更新数据，用了模态模式就不用单例模式了，要不要这样用？
            if (SelectModel)
            {
                SelectedItem = GetFocusRow();
                CloseForm(DialogResult.OK);
            }
            else
            {
                frmdept = new frmDept();
                frmdept.FItemID = GetFocusRow().FItemID;
                frmdept.BillMngGridService = this;
                DialogResult result = frmdept.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadTree();
                }
            }
        }

        protected override void Add()
        {
            frmdept = new frmDept();
            frmdept.BillMngGridService = this;
            DialogResult result = frmdept.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTree();
            }
        }

        protected override void Delete()
        {
            if (MessageBox.Show("确定要删除吗？", "文迪软件", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int FItemID = GetInstanceByNode().FItemID;
                idept.Delete(FItemID);
                LoadTree();
            }
        }
          //下一个
        public override int MoveNextRow()
        {
             gridView1.MoveNext();

            return GetFocusRow().FItemID;
        }
        //上一个
        public override int MovePrevRow()
        {
            gridView1.MovePrev();
            return GetFocusRow().FItemID;
        }

        private void c_grcTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            LoadGrid();
        }

    }
}
