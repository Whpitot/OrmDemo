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

    public partial class frmSupplierMng : BaseEditForm
    {       
      public frmSupplierMng()
        {
            InitializeComponent();
            LoadTree();
        }
        
        ISupplier isupplier = new SupplierSession();
        frmSupplier frmSupplier;
        public t_Supplier SelectedItem;

        //加载供应商的全部列表
        void LoadTree()
        {
            c_grcTree.DataSource = isupplier.LoadEntities();
            c_grcTree.ExpandAll();
        }

        //减少if else 的使用
        void LoadGrid()
        {
            if (c_grcTree.FocusedNode != null)
            {
                int FItemID = GetInstanceByNode().FItemID;

                t_Supplier[] supplier = isupplier.LoadEntities(FItemID);
                c_grcMain.DataSource = supplier;
            }
        }

        private t_Supplier GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_Supplier;
        }

        private t_Supplier GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_Supplier;
        }
        protected override void Add()
        {
            frmSupplier = new frmSupplier();
            frmSupplier.BillMngGridService = this;
            DialogResult result = frmSupplier.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTree();
            }
        }

        protected override void Delete()
        {
            if (DialogResult.Yes == MessageBox.Show("确定要删除吗？", "文迪科技", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                isupplier.Delete(GetFocusRow().FItemID);
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

        private void c_grcMain_DoubleClick(object sender, EventArgs e)
        {
            if (SelectModel)
            {
                SelectedItem = GetFocusRow();
                CloseForm(DialogResult.OK);
            }
            else
            {
                frmSupplier = new frmSupplier();
                frmSupplier.FItemID = GetFocusRow().FItemID;
                frmSupplier.BillMngGridService = this;
                DialogResult result = frmSupplier.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadTree();
                }
            }
        }
    }
}
