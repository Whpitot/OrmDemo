namespace Services
{
    partial class frmAssembly
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WMSModel.EmptyItem emptyItem2 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem1 = new WMSModel.EmptyItem();
            this.c_grcMain = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FInterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FEntryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FInstallDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.FAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FInstaller = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FSettleAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FauxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.FNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FEntityID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FInstallerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FBillNO = new Wingdell.Control.WDTextEdit();
            this.FEmp = new Wingdell.Control.WDItemEdit();
            this.FManager = new Wingdell.Control.WDItemEdit();
            this.FDate = new Wingdell.Control.WDDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Controls.Add(this.FDate);
            this.c_pnl.Controls.Add(this.FManager);
            this.c_pnl.Controls.Add(this.FEmp);
            this.c_pnl.Controls.Add(this.FBillNO);
            this.c_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.c_pnl.Size = new System.Drawing.Size(956, 61);
            // 
            // c_grcMain
            // 
            this.c_grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grcMain.Location = new System.Drawing.Point(0, 92);
            this.c_grcMain.MainView = this.gridView1;
            this.c_grcMain.Name = "c_grcMain";
            this.c_grcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemDateEdit1});
            this.c_grcMain.Size = new System.Drawing.Size(956, 387);
            this.c_grcMain.TabIndex = 10;
            this.c_grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FInterID,
            this.FEntryID,
            this.FItemID,
            this.FItemName,
            this.FNumber,
            this.FUnit,
            this.FModel,
            this.FInstallDate,
            this.FAddress,
            this.FQty,
            this.FPhone,
            this.FCustomer,
            this.FInstaller,
            this.Fprice,
            this.FSettleAmount,
            this.FauxPrice,
            this.FAccount,
            this.FNote,
            this.FEntityID,
            this.FCustomerID,
            this.FInstallerID});
            this.gridView1.GridControl = this.c_grcMain;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, null, null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FInterID
            // 
            this.FInterID.Caption = "gridColumn1";
            this.FInterID.FieldName = "FInterID";
            this.FInterID.Name = "FInterID";
            // 
            // FEntryID
            // 
            this.FEntryID.Caption = "行号";
            this.FEntryID.FieldName = "FEntryID";
            this.FEntryID.Name = "FEntryID";
            this.FEntryID.Visible = true;
            this.FEntryID.VisibleIndex = 0;
            this.FEntryID.Width = 39;
            // 
            // FItemID
            // 
            this.FItemID.Caption = "gridColumn1";
            this.FItemID.FieldName = "FItemID";
            this.FItemID.Name = "FItemID";
            // 
            // FItemName
            // 
            this.FItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.FItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FItemName.Caption = "名称";
            this.FItemName.FieldName = "FItemName";
            this.FItemName.Name = "FItemName";
            this.FItemName.Tag = "Services.frmICItemMng";
            this.FItemName.Visible = true;
            this.FItemName.VisibleIndex = 2;
            // 
            // FNumber
            // 
            this.FNumber.Caption = "代码";
            this.FNumber.FieldName = "FNumber";
            this.FNumber.Name = "FNumber";
            this.FNumber.Visible = true;
            this.FNumber.VisibleIndex = 1;
            // 
            // FUnit
            // 
            this.FUnit.Caption = "单位";
            this.FUnit.FieldName = "FUnit";
            this.FUnit.Name = "FUnit";
            this.FUnit.Visible = true;
            this.FUnit.VisibleIndex = 5;
            this.FUnit.Width = 51;
            // 
            // FModel
            // 
            this.FModel.Caption = "型号";
            this.FModel.FieldName = "FModel";
            this.FModel.Name = "FModel";
            this.FModel.Visible = true;
            this.FModel.VisibleIndex = 3;
            // 
            // FInstallDate
            // 
            this.FInstallDate.Caption = "安装时间";
            this.FInstallDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.FInstallDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.FInstallDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.FInstallDate.FieldName = "FInstallDate";
            this.FInstallDate.Name = "FInstallDate";
            this.FInstallDate.Visible = true;
            this.FInstallDate.VisibleIndex = 6;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // FAddress
            // 
            this.FAddress.Caption = "地址";
            this.FAddress.FieldName = "FAddress";
            this.FAddress.Name = "FAddress";
            this.FAddress.Visible = true;
            this.FAddress.VisibleIndex = 7;
            this.FAddress.Width = 99;
            // 
            // FQty
            // 
            this.FQty.Caption = "数量";
            this.FQty.FieldName = "FQty";
            this.FQty.Name = "FQty";
            this.FQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.FQty.Visible = true;
            this.FQty.VisibleIndex = 4;
            this.FQty.Width = 42;
            // 
            // FPhone
            // 
            this.FPhone.Caption = "电话";
            this.FPhone.FieldName = "FPhone";
            this.FPhone.Name = "FPhone";
            this.FPhone.Visible = true;
            this.FPhone.VisibleIndex = 8;
            this.FPhone.Width = 62;
            // 
            // FCustomer
            // 
            this.FCustomer.Caption = "客户";
            this.FCustomer.FieldName = "FCustomer";
            this.FCustomer.Name = "FCustomer";
            this.FCustomer.Tag = "Services.frmCustomerMng";
            this.FCustomer.Visible = true;
            this.FCustomer.VisibleIndex = 9;
            this.FCustomer.Width = 77;
            // 
            // FInstaller
            // 
            this.FInstaller.Caption = "安装员";
            this.FInstaller.FieldName = "FInstaller";
            this.FInstaller.Name = "FInstaller";
            this.FInstaller.Tag = "Services.frmEmpMng";
            this.FInstaller.Visible = true;
            this.FInstaller.VisibleIndex = 10;
            this.FInstaller.Width = 51;
            // 
            // Fprice
            // 
            this.Fprice.Caption = "价格";
            this.Fprice.DisplayFormat.FormatString = "F2";
            this.Fprice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Fprice.FieldName = "Fprice";
            this.Fprice.Name = "Fprice";
            this.Fprice.Visible = true;
            this.Fprice.VisibleIndex = 11;
            this.Fprice.Width = 73;
            // 
            // FSettleAmount
            // 
            this.FSettleAmount.Caption = "实收金额";
            this.FSettleAmount.DisplayFormat.FormatString = "F2";
            this.FSettleAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.FSettleAmount.FieldName = "FSettleAmount";
            this.FSettleAmount.Name = "FSettleAmount";
            this.FSettleAmount.Visible = true;
            this.FSettleAmount.VisibleIndex = 12;
            // 
            // FauxPrice
            // 
            this.FauxPrice.Caption = "应收金额";
            this.FauxPrice.DisplayFormat.FormatString = "F2";
            this.FauxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.FauxPrice.FieldName = "FauxPrice";
            this.FauxPrice.Name = "FauxPrice";
            this.FauxPrice.Visible = true;
            this.FauxPrice.VisibleIndex = 13;
            this.FauxPrice.Width = 58;
            // 
            // FAccount
            // 
            this.FAccount.Caption = "是否结账";
            this.FAccount.ColumnEdit = this.repositoryItemCheckEdit1;
            this.FAccount.FieldName = "FAccount";
            this.FAccount.Name = "FAccount";
            this.FAccount.Visible = true;
            this.FAccount.VisibleIndex = 14;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // FNote
            // 
            this.FNote.Caption = "备注";
            this.FNote.FieldName = "FNote";
            this.FNote.Name = "FNote";
            this.FNote.Visible = true;
            this.FNote.VisibleIndex = 15;
            this.FNote.Width = 106;
            // 
            // FEntityID
            // 
            this.FEntityID.Caption = "gridColumn1";
            this.FEntityID.Name = "FEntityID";
            // 
            // FCustomerID
            // 
            this.FCustomerID.FieldName = "FCustomerID";
            this.FCustomerID.Name = "FCustomerID";
            // 
            // FInstallerID
            // 
            this.FInstallerID.Caption = "gridColumn1";
            this.FInstallerID.FieldName = "FInstallerID";
            this.FInstallerID.Name = "FInstallerID";
            // 
            // FBillNO
            // 
            this.FBillNO.BackColor = System.Drawing.Color.Transparent;
            this.FBillNO.Caption = "安装单号*：";
            this.FBillNO.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FBillNO.Location = new System.Drawing.Point(24, 19);
            this.FBillNO.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FBillNO.MinimumSize = new System.Drawing.Size(50, 21);
            this.FBillNO.Name = "FBillNO";
            this.FBillNO.Size = new System.Drawing.Size(169, 21);
            this.FBillNO.TabIndex = 4;
            // 
            // FEmp
            // 
            this.FEmp.BackColor = System.Drawing.Color.Transparent;
            this.FEmp.Caption = "业务员*：";
            this.FEmp.Location = new System.Drawing.Point(383, 19);
            this.FEmp.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FEmp.MinimumSize = new System.Drawing.Size(50, 21);
            this.FEmp.Name = "FEmp";
            this.FEmp.SelectService = null;
            this.FEmp.Size = new System.Drawing.Size(199, 21);
            this.FEmp.TabIndex = 6;
            this.FEmp.Value = emptyItem2;
            // 
            // FManager
            // 
            this.FManager.BackColor = System.Drawing.Color.Transparent;
            this.FManager.Caption = "审核 人*：";
            this.FManager.Location = new System.Drawing.Point(620, 19);
            this.FManager.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FManager.MinimumSize = new System.Drawing.Size(50, 21);
            this.FManager.Name = "FManager";
            this.FManager.SelectService = null;
            this.FManager.Size = new System.Drawing.Size(199, 21);
            this.FManager.TabIndex = 7;
            this.FManager.Value = emptyItem1;
            // 
            // FDate
            // 
            this.FDate.BackColor = System.Drawing.Color.Transparent;
            this.FDate.Caption = "日  期*：";
            this.FDate.Location = new System.Drawing.Point(208, 19);
            this.FDate.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FDate.MinimumSize = new System.Drawing.Size(50, 21);
            this.FDate.Name = "FDate";
            this.FDate.Size = new System.Drawing.Size(169, 21);
            this.FDate.TabIndex = 8;
            this.FDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // frmAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 504);
            this.Controls.Add(this.c_grcMain);
            this.Name = "frmAssembly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAssembly";
            this.Controls.SetChildIndex(this.c_pnl, 0);
            this.Controls.SetChildIndex(this.c_grcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl c_grcMain;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn FInterID;
        private DevExpress.XtraGrid.Columns.GridColumn FEntryID;
        private DevExpress.XtraGrid.Columns.GridColumn FItemID;
        private DevExpress.XtraGrid.Columns.GridColumn FAddress;
        private DevExpress.XtraGrid.Columns.GridColumn FQty;
        private DevExpress.XtraGrid.Columns.GridColumn FPhone;
        private DevExpress.XtraGrid.Columns.GridColumn FCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn FInstaller;
        private DevExpress.XtraGrid.Columns.GridColumn Fprice;
        private DevExpress.XtraGrid.Columns.GridColumn FauxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn FNote;
        private DevExpress.XtraGrid.Columns.GridColumn FItemName;
        private DevExpress.XtraGrid.Columns.GridColumn FNumber;
        private DevExpress.XtraGrid.Columns.GridColumn FUnit;
        private DevExpress.XtraGrid.Columns.GridColumn FModel;
        private DevExpress.XtraGrid.Columns.GridColumn FEntityID;
        private DevExpress.XtraGrid.Columns.GridColumn FCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn FInstallerID;
        private Wingdell.Control.WDItemEdit FManager;
        private Wingdell.Control.WDItemEdit FEmp;
        private Wingdell.Control.WDTextEdit FBillNO;
        private Wingdell.Control.WDDateEdit FDate;
        private DevExpress.XtraGrid.Columns.GridColumn FInstallDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn FAccount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn FSettleAmount;
    }
}