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

    public partial class frmCustomerMng : BaseEditForm
    {
        public frmCustomerMng()
        {
            InitializeComponent();
            LoadTree();
        }
        ISupplier iProxy = new SupplierSession();
        ICustomer icustomer = new CustomerSession();
        frmCustomer frmcustomer;
        public t_Customer SelectedItem { get; set; }
        public bool SelectModel { get; set; }


        //使用参数的形式
        void LoadTree()
        {
            c_grcTree.DataSource = iProxy.LoadEntities();
            c_grcTree.ExpandAll();
        }

        //减少if else 的使用
        void LoadGrid()
        {
            if (c_grcTree.FocusedNode != null)
            {
                if (GetInstanceByNode() != null)
                {
                    int FItemID = GetInstanceByNode().FItemID;
                    t_Customer[] customers = icustomer.LoadEntities(FItemID);
                    c_grcMain.DataSource = customers;
                }
            }
        }

        private t_Supplier GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_Supplier; 
        }

        private t_Customer GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_Customer;
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
                frmcustomer = new frmCustomer();
                frmcustomer.FItemID = GetFocusRow().FItemID;
                frmcustomer.BillMngGridService = this;
                DialogResult result = frmcustomer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadTree();
                }
            }
        }

        protected override void Add()
        {
            frmcustomer = new frmCustomer();
            frmcustomer.BillMngGridService = this;
            DialogResult result = frmcustomer.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTree();
            }
        }

        protected override void Delete()
        {
            if (DialogResult.Yes== MessageBox.Show("确定要删除吗？", "文迪么么", MessageBoxButtons.YesNo))
            {
                icustomer.Delete(GetFocusRow().FItemID);
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
