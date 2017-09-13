using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Services
{
    using WMSDAL.Sql;
    using WMSModel;
    using ServiceLib;
    using Controls;
    using Main;
    using Services.FormSelect;
    using System.Reflection;
    using WMSDAL.Map;
    using WMSDAL.Entry;

    public partial class frmAssembly : BaseEditForm
    {
        public frmAssembly()
        {
            InitializeComponent();
        }

        public event Action Refresh;
        IAssembly iassemble = new AssemblySession();
        t_Assemble _instance;
        List<t_AssembleEntry> entrys = new List<t_AssembleEntry>();

        protected override void InitControls()
        {
            base.InitControls();
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsNavigation.AutoFocusNewRow = true;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;

            gridView1.OptionsSelection.MultiSelect = false;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.KeyDown +=gridView1_KeyDown;
           
            FEmp.SelectService = new EmpService();
            FManager.SelectService = new EmpService();

            loadItemData();
        }

        #region gridView1_KeyDown 单据体按键事件的处理（主要包含F7事件）
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                EntryLookUpData();
            }
            if (e.KeyCode == Keys.F6)
            {
                //CopyColumnData();
            }
        }
        #endregion

        private void EntryLookUpData()
        {
            IItemInfo items = null;
             if (gridView1.FocusedRowHandle < 0)
            {
                //if (gridView1.RowCount > 1)
                //    //if (gridView1.GetRow(gridView1.RowCount - 2) == null || (gridView1.GetRow(gridView1.RowCount - 2) as t_AssembleEntry).FInterID <= 0)
                //    //    return;
            }
            string columnTag =Convert.ToString(gridView1.FocusedColumn.Tag);//拿到标题列,当为空时会抛异常
            string columnName = gridView1.FocusedColumn.FieldName;
            if (string.IsNullOrEmpty(columnTag))
                return;
            t_AssembleEntry selmodel = gridView1.GetFocusedRow() as t_AssembleEntry;
            if (selmodel == null)
            {
                selmodel = new t_AssembleEntry();
                selmodel.FInterID = this._id;
                entrys.Add(selmodel);
                ResetEntryID();     
            }
            if (items == null)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();                
                Form baseinfo = assembly.CreateInstance(columnTag.ToString()) as Form;
                PropertyInfo selectedItem = baseinfo.GetType().GetProperty("SelectedItem");
                PropertyInfo selectModel = baseinfo.GetType().GetProperty("SelectModel");
                selectModel.SetValue(baseinfo, true, null);
                baseinfo.ShowDialog();
                items = selectedItem.GetValue(baseinfo, null) as IItemInfo;
            }

            IItemInfo returnitem = items;
            Dictionary<string, string> list =AttrubuteHelper.FindFieldRelationAttribute<t_AssembleEntry>(columnName);
            if (list.Count == 0) return;
            foreach (var item in list)
            {
                AttrubuteHelper.SetValue(selmodel,item.Key,AttrubuteHelper.GetValue(returnitem,item.Value));
            }
            BindEntrySpecialProperty(columnName, selmodel, returnitem);
            GridViewRefresh();
        }
        #region BindEntrySpecialProperty 单据体特殊字段赋值
        //目前字段的自动绑定功能很弱，表头表体间关联以及字段的非名称和编号属性等自动赋值先做特殊化处理
        private void BindEntrySpecialProperty(string columnName, t_AssembleEntry selmodel, IItemInfo returnitem)
        {
            if (columnName == "FItemName")
            {
                string sql = string.Format("select FModel,FUnit,FPrice from t_icitem  where fitemid={0}", returnitem.FItemID);
                using (DbSession db = Db.Get())
                {
                    db.OpenConnection();
                    DataTable dt = db.DataQuery(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        selmodel.FModel = dt.Rows[0]["FModel"].ToString();
                        selmodel.FUnit = dt.Rows[0]["FUnit"].ToString();
                        selmodel.Fprice = Convert.ToInt32(dt.Rows[0]["FPrice"]);
                    }
                }               
            }
        }
        #endregion

        private void ResetEntryID()
        {
            int _entryid = 1;
            foreach (var item in entrys)
            {
                item.FEntryID = _entryid;
                _entryid++;
            }        
        }

        #region GridViewRefresh 表体数据刷新
        private void GridViewRefresh()
        {
            int fcocusedrow = this.gridView1.FocusedRowHandle >= 0 ? this.gridView1.FocusedRowHandle : this.gridView1.RowCount - 2;
            this.c_grcMain.RefreshDataSource();
            this.gridView1.FocusedRowHandle = fcocusedrow;
        }
        #endregion


        #region loadItemData 单据对应实体和单据呈现（一般不改动此处代码，下次重构放底层）
        private void loadItemData()
        {
            if (_id > 0)
            {
                _instance = iassemble.SetInstance(_id);
                SetBillStatus(BillStatus.Edit);
            }          
            else
            {
                _instance = iassemble.Create();
                _instance.FBillNO = iassemble.GetRandNum("1");
                _instance.FEmpID = UserUtility.FUserID;
                _instance.FDate = DateTime.Now;          
                SetBillStatus(BillStatus.Add);
            }

            BindEntryList();
            DisplayData<t_Assemble>(_instance,allControl);
            
        }
        #endregion


        #region BindEntryList 绑定单据体
        void BindEntryList()
        {
            if (_id > 0) //加载单据
            {
                entrys.Clear();
                t_AssembleEntry[] mod = iassemble.GetEntrys(_id);
                foreach (t_AssembleEntry mo in mod)
                {                    
                    entrys.Add(mo);
                }
            }
            if (_id == 0)//新增单据
            {
                entrys.Clear();
                entrys.Add(new t_AssembleEntry());
                ResetEntryID();
            }
            c_grcMain.DataSource = entrys;
            c_grcMain.RefreshDataSource();
        }
        #endregion

        #region 获取当前表体对应的实体  （下次记得放在底层）
        private t_AssembleEntry GetSelectData(GridView gridview)
        {
            t_AssembleEntry assem = gridview.GetFocusedRow() as t_AssembleEntry;
            if(assem==null)
            {
                Msgbox.Info("没有选中行！");
            }
            return assem;
        }
        #endregion

        #region 删除行
        protected override void DelRow()
        {
            try
            {
                if (gridView1.OptionsBehavior.ReadOnly == true) return;
                t_AssembleEntry assem = GetSelectData(gridView1);
                if (assem != null)
                {
                    entrys.Remove(assem);
                    ResetEntryID();
                    c_grcMain.RefreshDataSource();
                }
            }
            catch(Exception ex)
            {
                Msgbox.Info(ex.Message);
            }       
        }
        #endregion

        #region DataCheck 单据保存前数据数据校对,系统完成之后这里需要做修改
        protected override bool CheckData()
        {
            //gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            _instance.EntryList = this.entrys;
            //数据加载
            AddEntity<t_Assemble>(_instance, allControl);

            if (_instance.FBillNO.Trim() == "")
            {
                MessageBox.Show("编号必须填写，请检查！");
                return false;
            }
            return true;
        }
        #endregion

        #region 单据保存
        protected override void Save()
        {
            if (!CheckData())
                return;

            iassemble.Save(_instance);    
            Msgbox.Info("保存成功");
            DisplayData();
        }
        #endregion       
    }
}
