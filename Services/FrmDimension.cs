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

    public partial class FrmDimension : BaseEditForm
    {
        public FrmDimension()
        {
            InitializeComponent();
        }

        IDimension iProxy = new DimensionSession();
        Dimension instance;
        public event Action ReLoadInstance;

        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
            {
                instance = new Dimension();
                SetBillStatus(BillStatus.Add);
            }
            else
            {
                instance=iProxy.LoadEntity(FItemID);
                SetBillStatus(BillStatus.Add);
            }
            DisplayData<Dimension>(instance, allControl);
        }

        protected override void Save()
        {
            base.Save();
            if (!CheckData())
                return;
            iProxy.Save(instance);
            ReLoadInstance();
            Msgbox.Info("保存成功");
        }

        protected override bool CheckData()//可以写框架交给
        {
            //数据加载
            AddEntity<Dimension>(instance, allControl);
            if (instance.FNumber.Trim() == "" || instance.FName.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (instance.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }
            return true;
        }
    }
}
