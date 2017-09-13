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

    public partial class frmLevel : BaseEditForm
    {
        public frmLevel()
        {
            InitializeComponent();
        }

        DialogResult result = DialogResult.Cancel;
        ILevel iLevel = new LevelSession();
        t_Level Level;
        bool isAdd;

         protected override void InitControls()
        {
            base.InitControls();
            if (FItemID == 0)
            {
                Level = iLevel.Create();
                SetBillStatus(BillStatus.Add);
            }
            else
            {
                Level = iLevel.LoadEntities(FItemID)[0];
                SetBillStatus(BillStatus.Edit);
            }

            DisplayData<t_Level>(Level, allControl);            
        }

        protected override void Save()
        {
              base.Save();
              if (!CheckData())
                  return;
              iLevel.Save(Level);
              Msgbox.Info("保存成功");
              result = DialogResult.OK;
        }

        protected override bool CheckData()
        {
            //数据加载
            AddEntity<t_Level>(Level, allControl);
            if (Level.FNumber.Trim() == "" || Level.FName.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            if (Level.FName.Trim() == "")
            {
                MessageBox.Show("名称必须填写，请检查！");
                return false;
            }
            return true;
        }

        private void frmLevel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
