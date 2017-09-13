using Controls;
using ServiceLib;
using Services.FormSelect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMSDAL.Sql;
using WMSModel;

namespace Services
{
    public partial class FrmFix : BaseEditForm
    {
        public FrmFix()
        {
            InitializeComponent();
        }

        IFix ifix = new FixSession();
        t_Fix instance;

        protected override void InitControls()
        {
            base.InitControls();
            if (_id == 0)
            {
                instance = ifix.Create();
                instance.FBillNo = SqlCom.GetRandNum("2");
                instance.FRecordDate = DateTime.Now;
                instance.FFixDate = DateTime.Now;
            }
            else
            {
                instance = ifix.LoadEntity(_id);
            }
            FModifierID.SelectService = new EmpService();
            DisplayData<t_Fix>(instance, allControl);
        }

        protected override void Save()
        {
            if (!CheckData())
                return;
            ifix.Save(instance);
            Msgbox.Info("保存成功");
        }

        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Fix>(instance, allControl);

            //if (instance.FItemName=="")
            //{
            //    MessageBox.Show("货品名称必须填写，请检查！");
            //    return false;
            //}
            //if (instance.FCustomer.Trim()=="")
            //{
            //    MessageBox.Show("店铺名称必须填写，请检查！");
            //    return false;
            //}
            return true;
        }
    }
}
