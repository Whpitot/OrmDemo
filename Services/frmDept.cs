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
    using WMSDAL.Sql;
    using WMSModel;
    using ServiceLib;
    using Controls;

    public partial class frmDept : BaseEditForm
    {
              
        DialogResult result = DialogResult.Cancel;
        IDept idept = new DeptSession();
        t_Dept dept;


        public frmDept()
        {
            InitializeComponent();
        }               
        #region 方法重写

        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
            {
                dept = idept.Create();
                SetBillStatus(BillStatus.Add);
            }
            else
            {
                dept = idept.LoadEntities(FItemID)[0];
                SetBillStatus(BillStatus.Edit);
            }

            DisplayData<t_Dept>(dept, allControl);            
        }

        protected override void Save()
        {
              base.Save();
              if (!CheckData())
                  return;
              idept.Save(dept);
              Msgbox.Info("保存成功");
              result = DialogResult.OK;
        }

        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Dept>(dept, allControl);
            if (dept.FNumber.Trim() == "" || dept.FName.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (dept.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }
            return true;
        }
        #endregion

        private void frmDept_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }

    }
}
