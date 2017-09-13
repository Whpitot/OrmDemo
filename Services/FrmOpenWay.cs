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

    public partial class FrmOpenWay : BaseEditForm
    {
        public FrmOpenWay()
        {
            InitializeComponent();
        }

        IOpenWay iProxy = new OpenWaySession();
        OpenWay instance;
        public event Action ReLoadInstance;

        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
            {
                instance = new OpenWay();
                SetBillStatus(BillStatus.Add);
            }
            else
            {
                instance=iProxy.LoadEntity(FItemID);
                SetBillStatus(BillStatus.Add);
            }
            DisplayData<OpenWay>(instance, allControl);
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
            AddEntity<OpenWay>(instance, allControl);
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
