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
    using ServiceLib;
    using Services.FormSelect;
    using WMSDAL.Sql;
    using WMSModel;
    public partial class FrmInstallation : BaseEditForm
    {
        public FrmInstallation()
        {
            InitializeComponent();
        }

        IInstallation iIstallation = new InstallationSession();
        t_Installation installation;

        protected override void Save()
        {
            if (!CheckData())
                return;
            iIstallation.Save(installation);
            Msgbox.Info("保存成功");
        }

        //单据初始化
        protected override void InitControls()
        {
            base.InitControls();
            if (_id == 0)
            {
                installation = iIstallation.Create();
                installation.FBillNo = SqlCom.GetRandNum("1");
                installation.FInstallDate = DateTime.Now;
                installation.FRecordDate = DateTime.Now;
                installation.FSalesmanID = UserUtility.FUserID;
            }
            else
            {
                installation = iIstallation.LoadEntity(_id);
            }
            FCustomerID.SelectService = new CustomerService();
            FSalesmanID.SelectService = new EmpService();
            FInstallerID.SelectService = new EmpService();
            FItemID.SelectService = new IcItemService();
            DisplayData<t_Installation>(installation, allControl);
        }

        //数据检查是否正确
        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Installation>(installation, allControl);

            //if (installation.FItemName=="")
            //{
            //    MessageBox.Show("货品名称必须填写，请检查！");
            //    return false;
            //}
            //if (installation.FCustomer.Trim()=="")
            //{
            //    MessageBox.Show("店铺名称必须填写，请检查！");
            //    return false;
            //}
            return true;
        }

        private void FrmInstallation_Load(object sender, EventArgs e)
        {
            FAccount.Text = "是否结账";
        }
    }
}
