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

    public partial class frmICItemMng : BaseEditForm
    {
        ISupplier iSupplier = new SupplierSession();
        IICItem iicitem = new ICItemSession();
        frmICItem frmicitem;
        public t_ICItem SelectedItem { get; set; }
        public bool SelectModel { get; set; }

        public frmICItemMng()
        {
            InitializeComponent();
            LoadTree();
        }

        #region 初始化
        private void LoadTree()
        {

            c_grcTree.DataSource = iSupplier.LoadEntities();
            c_grcTree.ExpandAll();
        }

        private void LoadGrid()
        {
            if (c_grcTree.FocusedNode != null)
            {
                int FItemID = GetInstanceByNode().FItemID;
                t_ICItem[] emp = iicitem.LoadEntities(FItemID);
                c_grcMain.DataSource = emp;
            }

        }

        private t_Supplier GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_Supplier;
        }

        private void c_grcTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            LoadGrid();
        }

        private t_ICItem GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_ICItem;
        }
        #endregion

        #region 方法重写
        protected override void Add()
        {
            frmicitem = new frmICItem();
            frmicitem.BillMngGridService = this;
            DialogResult result = frmicitem.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTree();
            }
        }
        #endregion

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
                frmicitem = new frmICItem();
                frmicitem.FItemID = GetFocusRow().FItemID;
                frmicitem.BillMngGridService = this;
                DialogResult result = frmicitem.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadTree();
                }
            }
        }

        protected override void Delete()
        {
            if (MessageBox.Show("确定要删除吗？", "文迪软件", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SelectedItem = GetFocusRow();
                int FItemID = SelectedItem.FItemID;
                iicitem.Delete(FItemID);
                LoadTree();
            }
        }
        //下一个
        public override int MoveNextRow()
        {
            gridView1.MoveNext();

            return GetFocusRow().FItemID;
        }
        // previous
        public override int MovePrevRow()
        {
            gridView1.MovePrev();
            return GetFocusRow().FItemID;
        }
    }
}
