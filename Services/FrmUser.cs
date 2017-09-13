using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Collections;
using System.Reflection;

namespace Services
{
    using WMSDAL.Sql;
    using WMSModel;
    using ServiceLib;
    using Controls;

    public partial class FrmUser :BaseEditForm
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        public event Action ReLoadInstance;
        IUser iProxy = new UserSession();
        t_User instance;
             
        #region 方法重写

        protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
            {
                instance = new t_User();
                SetBillStatus(BillStatus.Add);
            }
            else
            {
                instance = iProxy.LoadEntity(FItemID);
                SetBillStatus(BillStatus.Edit);
            }

            DisplayData<t_User>(instance, allControl);            
        }

        protected override void Save()
        {
              base.Save();
              if (!CheckData())
                  return;
              iProxy.Save(instance);
              Msgbox.Info("保存成功");
              ReLoadInstance();
        }

        protected override bool CheckData()
        {
            AddEntity<t_User>(instance, allControl);
            if (instance.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }
            return true;
        }
        #endregion

    }
}
