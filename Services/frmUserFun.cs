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
    using DevExpress.XtraTreeList.Nodes;
    using System.Collections;

    public partial class frmUserFun : BaseEditForm//运用的什么设计原理和机制
    {
        public frmUserFun()
        {
            InitializeComponent();
        }

        IUser iProxyUser = new UserSession();
        IUserRight iuserright = new UserRightSession();
        It_TreeMenu itreemenu = new t_TreeMenuSession();
        t_UserRight _userright=new t_UserRight();
        t_TreeMenu _treemenu = new t_TreeMenu();

        protected override void InitControls()
        {
            base.InitControls();
            LoadTree();
            LoadGrid();
        }

        private void LoadTree()
        {
            t_User[] tree = iProxyUser.LoadList("1 = 1");
            c_grcTree.DataSource = tree;    //是以数据表形式传递进来的
        }

        private void c_grcTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            int fuserid = int.Parse(GetInstanceByNode().FItemID.ToString());
            ClearCheck();
            string[] _rights = _userright.GetRightByUser(fuserid);
            SetCheck(_rights);
        }

        void ClearCheck()
        {
            rightTree.BeginUpdate();
            List<TreeListNode> _treelistNode = GetCheckNode();
            for (int i = 0; i < _treelistNode.Count; i++)
            {
                _treelistNode[i].CheckState = CheckState.Unchecked;
            }
            rightTree.EndUpdate();
        }

        //加载以选中的节点
        List<TreeListNode> GetCheckNode()
        {
            List<TreeListNode> _nodelist = new List<TreeListNode>();
            for (int i = 0; i < rightTree.Nodes.Count; i++)
            {
                if (rightTree.Nodes[i].Checked)
                {
                    _nodelist.Add(rightTree.Nodes[i]);
                    FindAllLoad(_nodelist, (rightTree.Nodes[i]));
                }
            }
            return _nodelist;
        }

        //递归加载以选中的节点
        void FindAllLoad(List<TreeListNode> _list, TreeListNode tn)
        {
            for (int i = 0; i < tn.Nodes.Count; i++)
            {
                if (tn.Nodes[i].Checked)
                {
                    _list.Add(tn.Nodes[i]);
                    FindAllLoad(_list, tn.Nodes[i]);
                }
            }
        }

        //对父节点做循环
        void SetCheck(string[] _values)
        {
            rightTree.BeginUpdate();
            Hashtable _rights = new Hashtable();
            for (int i = 0; i < _values.Length; i++)
            {
                if (!_rights.Contains(_values[i].ToString()))
                {
                    _rights.Add(_values[i].ToString(), _values[i].ToString());
                }
            }
            for (int i = 0; i < rightTree.Nodes.Count; i++)
            {
                t_TreeMenu tf = rightTree.GetDataRecordByNode(rightTree.Nodes[i]) as t_TreeMenu;
                if (_rights.Contains(tf.FuncID.ToString()))
                {
                    rightTree.Nodes[i].CheckState = CheckState.Checked;
                    SetCheck(_rights, rightTree.Nodes[i]);
                }
            }
            rightTree.EndUpdate();
        }

        //对子节点做循环
        void SetCheck(Hashtable ht, TreeListNode tn)
        {
            for (int i = 0; i < tn.Nodes.Count; i++)
            {
                t_TreeMenu tf = rightTree.GetDataRecordByNode(tn.Nodes[i]) as t_TreeMenu;
                if (ht.Contains(tf.FuncID.ToString()))
                {
                    tn.Nodes[i].CheckState = CheckState.Checked;
                    SetCheck(ht, tn.Nodes[i]);
                }

            }
        }

        private void LoadGrid()
        {
            rightTree.DataSource = itreemenu.LoadList("");
            rightTree.ExpandAll();
        }

        private t_User GetInstanceByNode()
        {
            return c_grcTree.GetDataRecordByNode(c_grcTree.FocusedNode) as t_User;
        }
  
        #region 方法重写
        protected override void Add()
        {
            base.Add();
            string fuserid = GetInstanceByNode().FItemID.ToString();
            StringBuilder sb = new StringBuilder();
            if (fuserid != null)
            {
                List<TreeListNode> list = GetCheckNode();
                for (int i = 0; i < list.Count; i++)
                {
                    t_TreeMenu tm = rightTree.GetDataRecordByNode(list[i]) as t_TreeMenu;
                    if (sb.ToString() != "")
                    {
                        sb.Append("|");
                    }
                    sb.Append(tm.FuncID.ToString());
                }
            }
            else
            {
                MessageBox.Show("请先选择要添加的用户！");
                return;
            }
            iuserright.Save(fuserid,sb.ToString());
        }

        #endregion
    }
}
