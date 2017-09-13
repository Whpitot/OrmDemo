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

    public partial class frmICItem : BaseEditForm
    {
        public frmICItem()
        {
            InitializeComponent();
        }
        DialogResult result = DialogResult.Cancel;
        IICItem iicitem = new ICItemSession();
        t_ICItem icitem;

        #region 方法重写  1、初始化，2、数据检查 3、添加修改
        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
            {
              icitem= iicitem.Create();
              SetBillStatus(BillStatus.Add);
            }
            else
            {
                icitem = iicitem.LoadEntity(FItemID);
                SetBillStatus(BillStatus.Edit);
            }
            FLevelID.SelectService = new LevelService();
            FSupplierID.SelectService=new SupplierService();
            FDimensionID.SelectService = new DimensionService();
            FOpenWayID.SelectService = new OpenWayService();
            FUnitID.SelectService = new UnitService();
            DisplayData<t_ICItem>(icitem, allControl);
        }

        protected override void Save()
        {
            if (!CheckData())
                return;
                icitem.Save(icitem);
                Msgbox.Info("保存成功");
                result = DialogResult.OK;
        }

        protected override bool CheckData()
        {            
            AddEntity<t_ICItem>(icitem, allControl);//这个到时候放到后台去处理 mustInput

            if (icitem.FNumber.Trim() == "")
            { 
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (icitem.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }

            if (icitem.FSupplierID<=0)
            {
                MessageBox.Show("供应商必须填写，请检查！");
                return false;
            }
            return true;
        }
        #endregion

        private void frmICItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }

       
    }
}
