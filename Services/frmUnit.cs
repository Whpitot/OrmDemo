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

    public partial class frmUnit : BaseEditForm
    {
        public frmUnit()
        {
            InitializeComponent();
        }

        IUnit iUnit = new UnitSession();
        t_Unit Unit;
        public event Action Refresh;
            
        #region 方法重写

        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
            {
                Unit = iUnit.Create();
                SetBillStatus(BillStatus.Add);
            }
            else
            {
                Unit = iUnit.LoadEntity(FItemID);
                SetBillStatus(BillStatus.Edit);
            }

            DisplayData<t_Unit>(Unit, allControl);            
        }

        protected override void Save()
        {
              base.Save();
              if (!CheckData())
                  return;
              iUnit.Save(Unit);
              Msgbox.Info("保存成功");
              Refresh();
        }

        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Unit>(Unit, allControl);
            if (Unit.FNumber.Trim() == "" || Unit.FName.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (Unit.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }
            return true;
        }
        #endregion
    }
}
