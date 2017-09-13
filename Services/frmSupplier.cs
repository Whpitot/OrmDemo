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

    public partial class frmSupplier : BaseEditForm
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        ISupplier isupplier = new SupplierSession();
        t_Supplier supplier;

        private int DepID;
        public bool isAdd;
        DialogResult result = DialogResult.Cancel;

        #region 重写方法
        protected override void Save()
        {
            if (!CheckData())
                return;
            isupplier.Save(supplier);
            Msgbox.Info("保存成功");
            result = DialogResult.OK;
        }

        //单据初始化
        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
                supplier = isupplier.Create();
            else
            {
                //做一个条件为空的判断
                supplier = isupplier.LoadEntity(FItemID);
            }
            DisplayData<t_Supplier>(supplier, allControl);
        }

        //数据检查是否正确
        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Supplier>(supplier, allControl);

            if (supplier.FNumber.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (supplier.FName.Trim() == "")
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

        private void frmSupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
