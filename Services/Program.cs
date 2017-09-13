using Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    using DevExpress.XtraNavBar;
    using Main;
    using Configuration;
    using ServiceLib;
    using System.Reflection;
    using WMSModel;

    static class Program
    {       
        static FrmTreeMenu frmMain;
        static It_TreeMenu it_treemenu = new t_TreeMenuSession();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool bCreate=false;
             
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "SINGILE_INSTANCE_MUTEX", out bCreate);
            if (bCreate)
            {
                //111
                var login = new FrmLogIn();
                login.ShowDialog();
                if (!FrmLogIn.blCanLogin) return;
                FrmLogIn.blCanLogin = false;
                frmMain = new FrmTreeMenu();
                SetMainForm(frmMain);
                //22
                Application.Run(frmMain);                 
            }
            else
            {
                Msgbox.Info("程序已经启动");
                Application.Exit();            
            }
        }

        static void SetMainForm(FrmTreeMenu _frmMain)
        {
            Dictionary<int, object> _dictionary = new Dictionary<int, object>();
            t_TreeMenu[] tm = it_treemenu.LoadList("");
            foreach (t_TreeMenu f in tm)
            {
                if (f.FParentID == 0)
                {
                    DevExpress.XtraTab.XtraTabPage _page = new DevExpress.XtraTab.XtraTabPage();
                    _page.Name = f.FuncID.ToString();
                    _page.Text = f.FName;

                    DevExpress.XtraNavBar.NavBarControl _control = new DevExpress.XtraNavBar.NavBarControl();
                    _control.Text = f.FuncID.ToString() + f.FName;
                    _control.Name = f.FuncID.ToString() + f.FName;
                    _control.Dock = DockStyle.Fill;

                    _page.Controls.Add(_control);
                    _frmMain.xtraTabControl1.TabPages.Add(_page);

                    if (!_dictionary.ContainsKey(f.FuncID))
                    {
                        _dictionary.Add(f.FuncID, _control);
                    }
                }
                else
                {
                    if (f.Url == "group")
                    {
                        DevExpress.XtraNavBar.NavBarGroup _group = new DevExpress.XtraNavBar.NavBarGroup();
                        _group.Name = f.FuncID.ToString();
                        _group.Caption = f.FName;
                        _group.Expanded = true;
                        (_dictionary[f.FParentID] as DevExpress.XtraNavBar.NavBarControl).Groups.Add(_group);
                        _dictionary.Add(f.FuncID, _group);
                    }
                    if (f.Url == "item")
                    {
                        DevExpress.XtraNavBar.NavBarItem _item = new DevExpress.XtraNavBar.NavBarItem();
                        _item.Name = f.FuncID.ToString();
                        _item.Caption = f.FName;
                        _item.Tag = f;

                        _item.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(_item_LinkClicked);
                        (_dictionary[f.FParentID] as DevExpress.XtraNavBar.NavBarGroup).ItemLinks.Add(_item);
                        _dictionary.Add(f.FuncID, _item);
                    }
                }
            }
        }

        static void _item_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Assembly assembly=null;
            NavBarItem _item = sender as NavBarItem;
            t_TreeMenu _funlist = _item.Tag as t_TreeMenu;

            Type tt = Type.GetType(_funlist.FClassItem);//必须要在同意程序集下面，得到类名
            if (tt != null)
            {
                assembly = Assembly.GetExecutingAssembly();
            }
            int _begin = _funlist.FClassItem.LastIndexOf(".") + 1;
            int _end = _funlist.FClassItem.Length - _begin;
            string FName = _funlist.FClassItem.Substring(_begin, _end);

            if (!frmMain.SetActiveForm(FName))
            {
                frmMain.SetMainBackGround(false);
                Form _dx = assembly.CreateInstance(_funlist.FClassItem) as Form;
                _dx.Name = FName;
                _dx.MdiParent = frmMain;
                _dx.Visible = true;
                _dx.Show();
            }
        }
    }
}
