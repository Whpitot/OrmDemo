using Controls;
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

    public partial class frmUnitMng : BaseEditForm
    {
        public frmUnitMng()
        {
            InitializeComponent();
        }

        IUnit iunit = new UnitSession();
        frmUnit frmunit;
        public t_Unit SelectedItem;

        void LoadTree()
        {
            t_Unit[] Units = iunit.LoadEntities();
            c_grcTree.DataSource = Units;
            c_grcTree.ExpandAll();
        }

        void LoadGrid()
        {
            if (c_grcTree.FocusedNode != null)
            {
                int FItemID =Convert.ToInt32(GetInstanceByNode().FItemID);
                //grid加载数据源必须要是以数组的形式加载才可以的
                t_Unit[] Units = iunit.LoadEntities(FItemID);
                c_grcMain.DataSource = Units;
            }
        }

        private t_Unit GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_Unit; 
        }

        private t_Unit GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_Unit;
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
                frmunit = new frmUnit();
                frmunit.FItemID = GetFocusRow().FItemID;
                frmunit.BillMngGridService = this;
                frmunit.Refresh += LoadTree;
                frmunit.ShowDialog();
            }
        }

        protected override void Add()
        {
            frmunit = new frmUnit();
            frmunit.BillMngGridService = this;
            frmunit.Refresh += LoadTree;
            frmunit.ShowDialog();
        }

        protected override void Delete()
        {
            if (MessageBox.Show("确定要删除吗？", "文迪软件", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int FItemID = GetInstanceByNode().FItemID;
                iunit.Delete(FItemID);
                LoadTree();
            }
        }

        public override int MoveNextRow()
        {
             gridView1.MoveNext();

            return GetFocusRow().FItemID;
        }

        public override int MovePrevRow()
        {
            gridView1.MovePrev();
            return GetFocusRow().FItemID;
        }

        private void c_grcTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            LoadGrid();
        }

        private void frmUnitMng_Load(object sender, EventArgs e)
        {
            this.Name = "单位管理";            
            LoadTree();
        }
    }
}
