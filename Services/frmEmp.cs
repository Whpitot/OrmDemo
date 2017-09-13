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
    using Services.FormSelect;

    public partial class frmEmp : BaseEditForm
    {
        IEmp iemp = new EmpSession();
        t_Emp emp;

        private int DepID;
        public bool isAdd;
        DialogResult result = DialogResult.Cancel;

        public frmEmp()
        {
            InitializeComponent();
        }

        #region 重写方法
        protected override void Save()//通用的实体保存类方法
        {           
                if (!CheckData())
                    return;
                iemp.Save(emp);
                 Msgbox.Info("保存成功");
                 result = DialogResult.OK;
        }

        //单据初始化
        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
                emp = iemp.Create();
            else
            {
                emp = iemp.LoadEntity(FItemID);
            }
            FDeptID.SelectService = new DeptService();            
            DisplayData<t_Emp>(emp, allControl);            
        }

        //数据检查是否正确
        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Emp>(emp, allControl);

            if (emp.FNumber.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (emp.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }
            ////FParentID的数据验证
            //int pin = emp.GetParentIdByFNumber(emp.FNumber.Trim(), 3);
            //if (pin == -2)
            //{
            //    MessageBox.Show("编号输入有误，请检查！");
            //    return false;
            //}
            //if (pin == -1)
            //{
            //    MessageBox.Show("编号已存在，请检查！");
            //    return false;
            //}
            //emp.FParentID = pin;
            return true;
        }
        #endregion
        private void frmEmp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
