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

    public partial class frmEmpMng : BaseEditForm
    {
        public frmEmpMng()
        {
            InitializeComponent();
            LoadTree();
        }

        IDept dept = new DeptSession();
        IEmp iemp = new EmpSession();
        frmEmp frmemp;
        public t_Emp SelectedItem { get; set; }
        public bool SelectModel { get; set; }


        //使用参数的形式 FItemClassID=2 代表职员,但这里要去部门下面的职员部门的FItemClassID=1
        void LoadTree()
        {
            c_grcTree.DataSource = dept.LoadEntities();
            c_grcTree.ExpandAll();
        }

        //减少if else 的使用,用FParentID去检索数据,免去了FNumber引起的错误；
        void LoadGrid()
        {
            if (c_grcTree.FocusedNode != null)
            {
                int FItemID =Convert.ToInt32(GetInstanceByNode().FItemID);
                t_Emp[] emp = iemp.LoadEntities(FItemID);
                c_grcMain.DataSource = emp;
            }
        }

        private t_Dept GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_Dept;
        }

        private t_Emp GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_Emp;
        }
        protected override void Add()
        {
            frmemp = new frmEmp();
            frmemp.BillMngGridService = this;
            DialogResult result = frmemp.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTree();
            }
        }

        protected override void Delete()
        {
            MessageBox.Show("确定要删除吗？", "文迪软件", MessageBoxButtons.OK);
            iemp.Delete(GetFocusRow().FItemID);
            
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

        private void c_grcMain_DoubleClick(object sender, EventArgs e)
        {
            if (SelectModel)
            {
                SelectedItem = GetFocusRow();
                CloseForm(DialogResult.OK);
            }
            else
            {
                frmemp = new frmEmp();
                frmemp.FItemID = GetFocusRow().FItemID;
                frmemp.BillMngGridService = this;
                DialogResult result = frmemp.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadTree();
                }
            }
        }

    }
}
