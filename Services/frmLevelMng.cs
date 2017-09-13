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

    public partial class frmLevelMng : BaseEditForm
    {
        public frmLevelMng()
        {
            InitializeComponent();
            LoadTree();
        }

        ILevel iLevel = new LevelSession();
        frmLevel frmlevel;
        public t_Level SelectedItem;

        //使用参数的形式
        void LoadTree()
        {
            t_Level[] Levels = iLevel.LoadEntities();
            c_grcTree.DataSource = Levels;
            c_grcTree.ExpandAll();
        }

        //减少if else 的使用
        void LoadGrid()
        {
            if (c_grcTree.FocusedNode != null)
            {
                int FItemID = Convert.ToInt32(GetInstanceByNode().FItemID);
                //grid加载数据源必须要是以数组的形式加载才可以的
                t_Level[] Levels = iLevel.LoadEntities(FItemID);
                c_grcMain.DataSource = Levels;
            }
        }

        private t_Level GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_Level;
        }

        private t_Level GetFocusRow()
        {
            return gridView1.GetFocusedRow() as t_Level;
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
                frmlevel = new frmLevel();
                frmlevel.FItemID = GetFocusRow().FItemID;
                frmlevel.BillMngGridService = this;
                DialogResult result = frmlevel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadTree();
                }
            }
        }

        protected override void Add()
        {
            frmlevel = new frmLevel();
            frmlevel.BillMngGridService = this;
            DialogResult result = frmlevel.ShowDialog();
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
                iLevel.Delete(FItemID);
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
