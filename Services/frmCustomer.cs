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

    public partial class frmCustomer : BaseEditForm
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        ICustomer icustomer = new CustomerSession();
        t_Customer customer;

        private int DepID;
        public bool isAdd;
        DialogResult result = DialogResult.Cancel;

        #region 重写方法
        protected override void Save()
        {
            if (!CheckData())
                return;
            icustomer.Save(customer);
            Msgbox.Info("保存成功");
            result = DialogResult.OK;
        }
        //单据初始化
        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
                customer = icustomer.Create();
            else
            {
                //做一个条件为空的判断
                customer = icustomer.LoadEntity(FItemID);
            }
            FSupplierID.SelectService = new SupplierService();
            DisplayData<t_Customer>(customer, allControl);
        }

        //数据检查是否正确
        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Customer>(customer, allControl);

            if (customer.FNumber.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (customer.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }
            return true;
        }
        #endregion

        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }

    }
}
