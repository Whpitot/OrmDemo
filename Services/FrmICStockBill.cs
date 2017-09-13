using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controls;
using WMSModel;
using ServiceLib;
using WMSDAL.Entry;
using Services.FormSelect;
using WMSDAL.Sql;
using System.Reflection;
using WMSDAL.Map;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Services
{
    public partial class FrmICStockBill : BaseEditForm
    {
        public FrmICStockBill()
        {
            InitializeComponent();
        }
        IICStockBill iICStockBill = new ICStockBillSession();
        ICStockBill instance = new ICStockBill();
        List<ICStockBillEntry> listEntity = new List<ICStockBillEntry>();

        protected override void InitControls()
        {
            base.InitControls();

            gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowGroupedColumns = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            gridView1.OptionsNavigation.AutoFocusNewRow = true;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;

            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;

            gridView1.KeyDown+=gridView1_KeyDown;

            AutoHandleGridView.AutoBindColumnToGridView<ICStockBillEntry>(gridView1);
            AutoHandleGridView.CalculateSumOfColumns(gridView1, new string[] { "FQty"}, SummaryItemType.Sum);

            GridColumn FItemName = gridView1.Columns.ColumnByFieldName("FItemName");
            FItemName.Tag = "Services.frmICItemMng";

            FEmpID.SelectService = new EmpService();
            FSupplyID.SelectService = new SupplierService();
            FDeptID.SelectService = new DeptService();

            GetInstance();
        }

        private void GetInstance()
        {
            if (_id == 0)
            {
                instance = new ICStockBill();
                instance.FBillNo = SqlCom.GetRandNum("3");
                instance.FEmpID = UserUtility.FUserID;
                instance.FDate = DateTime.Now;
                SetBillStatus(BillStatus.Add);
            }
            else
            {
                instance = iICStockBill.GetInstance(_id);
                SetBillStatus(BillStatus.Edit);
            }

            GetEntity();
            DisplayData<ICStockBill>(instance, allControl);
        }

        private void GetEntity()
        {
            if (_id == 0)
                listEntity.Add(new ICStockBillEntry());
            else
                listEntity = iICStockBill.GetEntity(_id);
            gridControl1.DataSource = listEntity;        
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                LookUpEntity();
            }
            if (e.KeyCode == Keys.F6)
            {
                //CopyColumnData();
            }
        }

        void LookUpEntity()
        {
            IItemInfo items = null;
            try
            {
                if (gridView1.FocusedRowHandle < 0)
                {
                    if (gridView1.RowCount > 1)
                        if (gridView1.GetRow(gridView1.RowCount - 2) == null)
                            return;
                }
                string columnTag = Convert.ToString(gridView1.FocusedColumn.Tag);//拿到标题列,当为空时会抛异常
                string columnName = gridView1.FocusedColumn.FieldName;
                if (string.IsNullOrEmpty(columnTag))
                    return;
                ICStockBillEntry focusEntity = gridView1.GetFocusedRow() as ICStockBillEntry;
                if (focusEntity == null)
                {
                    focusEntity = new ICStockBillEntry();
                    focusEntity.FInterID = this._id;
                    listEntity.Add(focusEntity);
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
                Dictionary<string, string> list = AttrubuteHelper.FindFieldRelationAttribute<ICStockBillEntry>(columnName);
                if (list.Count == 0) return;
                foreach (var item in list)
                {
                    AttrubuteHelper.SetValue(focusEntity, item.Key, AttrubuteHelper.GetValue(returnitem, item.Value));
                }
                BindEntitySpecialProperty(columnName, focusEntity, returnitem);
                GridViewRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }
        }

        private void BindEntitySpecialProperty(string columnName, ICStockBillEntry selmodel, IItemInfo returnitem)
        {
            if (columnName == "FItemName")
            {
                string sql = string.Format(@"select t1.FPrice,t2.FName as FUnit ,t3.FName as FDimension,t4.FName as FOpenWay
                          FROM t_ICItem t1 left join t_Unit t2 on t1.FUnitID=t2.FItemID
                          left join Dimension t3 on t1.FDimensionID=t3.FItemID
                          left join OpenWay t4 on t1.FOpenWayID=t4.FItemID where t1.FItemID={0}", returnitem.FItemID);
                using (DbSession db = Db.Get())
                {
                    db.OpenConnection();
                    DataTable dt = db.DataQuery(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        selmodel.FDimension = dt.Rows[0]["FDimension"].ToString();
                        selmodel.FOpenWay = dt.Rows[0]["FOpenWay"].ToString();
                        selmodel.FUnit = dt.Rows[0]["FUnit"].ToString();
                        selmodel.FPrice = Convert.ToInt32(dt.Rows[0]["FPrice"]);
                    }
                }
            }
        }

        private void GridViewRefresh()
        {
            int fcocusedrow = this.gridView1.FocusedRowHandle >= 0 ? this.gridView1.FocusedRowHandle : this.gridView1.RowCount - 2;
            this.gridControl1.RefreshDataSource();
            this.gridView1.FocusedRowHandle = fcocusedrow;
        }

        protected override void Save()
        {
            gridView1.UpdateCurrentRow();
            instance.ListEntity = this.listEntity;
            AddEntity<ICStockBill>(instance, allControl);
            iICStockBill.Save(instance);
            Msgbox.Info("保存成功");
            DisplayData();
        }
    }
}
