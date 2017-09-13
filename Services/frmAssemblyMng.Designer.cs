namespace Services
{
    partial class frmAssemblyMng
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            WMSModel.EmptyItem emptyItem3 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem2 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem1 = new WMSModel.EmptyItem();
            this.c_grcMain = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.F_BillNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.F_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.F_Installer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.F_Customer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FInterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.FDateEnd = new System.Windows.Forms.DateTimePicker();
            this.btn_Query = new DevExpress.XtraEditors.SimpleButton();
            this.FAZDateBegin = new System.Windows.Forms.DateTimePicker();
            this.FAZDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FBillNO = new Wingdell.Control.WDTextEdit();
            this.txtFEmp = new Wingdell.Control.WDItemEdit();
            this.txtFCustomer = new Wingdell.Control.WDItemEdit();
            this.txtFInstaller = new Wingdell.Control.WDItemEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.chkInstall = new System.Windows.Forms.CheckBox();
            this.chkOrder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.chkOrder);
            this.c_pnl.Controls.Add(this.chkInstall);
            this.c_pnl.Controls.Add(this.txtFInstaller);
            this.c_pnl.Controls.Add(this.txtFCustomer);
            this.c_pnl.Controls.Add(this.txtFEmp);
            this.c_pnl.Controls.Add(this.FBillNO);
            this.c_pnl.Controls.Add(this.label3);
            this.c_pnl.Controls.Add(this.FAZDateEnd);
            this.c_pnl.Controls.Add(this.FAZDateBegin);
            this.c_pnl.Controls.Add(this.btn_Query);
            this.c_pnl.Controls.Add(this.FDateEnd);
            this.c_pnl.Controls.Add(this.label1);
            this.c_pnl.Controls.Add(this.FDateBegin);
            this.c_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.c_pnl.Size = new System.Drawing.Size(1002, 96);
            // 
            // c_grcMain
            // 
            this.c_grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grcMain.Location = new System.Drawing.Point(0, 127);
            this.c_grcMain.MainView = this.gridView1;
            this.c_grcMain.Name = "c_grcMain";
            this.c_grcMain.Size = new System.Drawing.Size(1002, 307);
            this.c_grcMain.TabIndex = 10;
            this.c_grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.c_grcMain.DoubleClick += new System.EventHandler(this.c_grcMain_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.F_BillNO,
            this.FPhone,
            this.FDetail,
            this.FAddress,
            this.F_Number,
            this.fMaterial,
            this.FModel,
            this.FUnit,
            this.FPrice,
            this.FEmp,
            this.F_Installer,
            this.F_Customer,
            this.FInterID,
            this.FAccount});
            styleFormatCondition1.ApplyToRow = true;
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.c_grcMain;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // F_BillNO
            // 
            this.F_BillNO.Caption = "安装单号";
            this.F_BillNO.FieldName = "FBillNO";
            this.F_BillNO.Name = "F_BillNO";
            this.F_BillNO.Visible = true;
            this.F_BillNO.VisibleIndex = 1;
            // 
            // FPhone
            // 
            this.FPhone.Caption = "电话";
            this.FPhone.FieldName = "FPhone";
            this.FPhone.Name = "FPhone";
            this.FPhone.Visible = true;
            this.FPhone.VisibleIndex = 3;
            // 
            // FDetail
            // 
            this.FDetail.Caption = "备注";
            this.FDetail.FieldName = "FDetail";
            this.FDetail.Name = "FDetail";
            this.FDetail.Visible = true;
            this.FDetail.VisibleIndex = 12;
            // 
            // FAddress
            // 
            this.FAddress.Caption = "地址";
            this.FAddress.FieldName = "FAddress";
            this.FAddress.Name = "FAddress";
            this.FAddress.Visible = true;
            this.FAddress.VisibleIndex = 2;
            // 
            // F_Number
            // 
            this.F_Number.Caption = "代码";
            this.F_Number.FieldName = "FNumber";
            this.F_Number.Name = "F_Number";
            this.F_Number.Visible = true;
            this.F_Number.VisibleIndex = 4;
            this.F_Number.Width = 100;
            // 
            // fMaterial
            // 
            this.fMaterial.Caption = "商品名称";
            this.fMaterial.FieldName = "FItemName";
            this.fMaterial.Name = "fMaterial";
            this.fMaterial.Visible = true;
            this.fMaterial.VisibleIndex = 5;
            // 
            // FModel
            // 
            this.FModel.Caption = "型号";
            this.FModel.FieldName = "FModel";
            this.FModel.Name = "FModel";
            this.FModel.Visible = true;
            this.FModel.VisibleIndex = 6;
            // 
            // FUnit
            // 
            this.FUnit.Caption = "单位";
            this.FUnit.FieldName = "FUnit";
            this.FUnit.Name = "FUnit";
            this.FUnit.Visible = true;
            this.FUnit.VisibleIndex = 7;
            // 
            // FPrice
            // 
            this.FPrice.Caption = "价格";
            this.FPrice.FieldName = "FPrice";
            this.FPrice.Name = "FPrice";
            this.FPrice.Visible = true;
            this.FPrice.VisibleIndex = 8;
            // 
            // FEmp
            // 
            this.FEmp.Caption = "业务员";
            this.FEmp.FieldName = "FEmp";
            this.FEmp.Name = "FEmp";
            this.FEmp.Visible = true;
            this.FEmp.VisibleIndex = 9;
            // 
            // F_Installer
            // 
            this.F_Installer.Caption = "安装人";
            this.F_Installer.FieldName = "FInstaller";
            this.F_Installer.Name = "F_Installer";
            this.F_Installer.Visible = true;
            this.F_Installer.VisibleIndex = 11;
            // 
            // F_Customer
            // 
            this.F_Customer.Caption = "客户";
            this.F_Customer.FieldName = "FCustomer";
            this.F_Customer.Name = "F_Customer";
            this.F_Customer.Visible = true;
            this.F_Customer.VisibleIndex = 10;
            // 
            // FInterID
            // 
            this.FInterID.Caption = "gridColumn1";
            this.FInterID.FieldName = "FInterID";
            this.FInterID.Name = "FInterID";
            // 
            // FAccount
            // 
            this.FAccount.Caption = "是否结账";
            this.FAccount.FieldName = "FAccount";
            this.FAccount.Name = "FAccount";
            this.FAccount.Visible = true;
            this.FAccount.VisibleIndex = 0;
            // 
            // FDateBegin
            // 
            this.FDateBegin.Location = new System.Drawing.Point(96, 54);
            this.FDateBegin.Name = "FDateBegin";
            this.FDateBegin.Size = new System.Drawing.Size(115, 22);
            this.FDateBegin.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "至";
            // 
            // FDateEnd
            // 
            this.FDateEnd.Location = new System.Drawing.Point(242, 54);
            this.FDateEnd.Name = "FDateEnd";
            this.FDateEnd.Size = new System.Drawing.Size(110, 22);
            this.FDateEnd.TabIndex = 17;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(770, 50);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 18;
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // FAZDateBegin
            // 
            this.FAZDateBegin.Location = new System.Drawing.Point(461, 54);
            this.FAZDateBegin.Name = "FAZDateBegin";
            this.FAZDateBegin.Size = new System.Drawing.Size(116, 22);
            this.FAZDateBegin.TabIndex = 21;
            // 
            // FAZDateEnd
            // 
            this.FAZDateEnd.Location = new System.Drawing.Point(608, 54);
            this.FAZDateEnd.Name = "FAZDateEnd";
            this.FAZDateEnd.Size = new System.Drawing.Size(114, 22);
            this.FAZDateEnd.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "至";
            // 
            // FBillNO
            // 
            this.FBillNO.BackColor = System.Drawing.Color.Transparent;
            this.FBillNO.Caption = "安装单号*：";
            this.FBillNO.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FBillNO.Location = new System.Drawing.Point(23, 15);
            this.FBillNO.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FBillNO.MinimumSize = new System.Drawing.Size(50, 21);
            this.FBillNO.Name = "FBillNO";
            this.FBillNO.Size = new System.Drawing.Size(169, 21);
            this.FBillNO.TabIndex = 25;
            // 
            // txtFEmp
            // 
            this.txtFEmp.BackColor = System.Drawing.Color.Transparent;
            this.txtFEmp.Caption = "业务员*：";
            this.txtFEmp.Location = new System.Drawing.Point(208, 15);
            this.txtFEmp.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFEmp.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFEmp.Name = "txtFEmp";
            this.txtFEmp.SelectService = null;
            this.txtFEmp.Size = new System.Drawing.Size(199, 21);
            this.txtFEmp.TabIndex = 26;
            this.txtFEmp.Value = emptyItem3;
            // 
            // txtFCustomer
            // 
            this.txtFCustomer.BackColor = System.Drawing.Color.Transparent;
            this.txtFCustomer.Caption = "客户*：";
            this.txtFCustomer.Location = new System.Drawing.Point(428, 15);
            this.txtFCustomer.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFCustomer.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFCustomer.Name = "txtFCustomer";
            this.txtFCustomer.SelectService = null;
            this.txtFCustomer.Size = new System.Drawing.Size(199, 21);
            this.txtFCustomer.TabIndex = 27;
            this.txtFCustomer.Value = emptyItem2;
            // 
            // txtFInstaller
            // 
            this.txtFInstaller.BackColor = System.Drawing.Color.Transparent;
            this.txtFInstaller.Caption = "安装工*：";
            this.txtFInstaller.Location = new System.Drawing.Point(646, 15);
            this.txtFInstaller.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFInstaller.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFInstaller.Name = "txtFInstaller";
            this.txtFInstaller.SelectService = null;
            this.txtFInstaller.Size = new System.Drawing.Size(199, 21);
            this.txtFInstaller.TabIndex = 28;
            this.txtFInstaller.Value = emptyItem1;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(1002, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 459);
            this.barDockControl2.Size = new System.Drawing.Size(1002, 23);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 459);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1002, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 459);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "自定义打印";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // chkInstall
            // 
            this.chkInstall.AutoSize = true;
            this.chkInstall.Location = new System.Drawing.Point(370, 58);
            this.chkInstall.Name = "chkInstall";
            this.chkInstall.Size = new System.Drawing.Size(93, 18);
            this.chkInstall.TabIndex = 29;
            this.chkInstall.Text = "安装日期*：";
            this.chkInstall.UseVisualStyleBackColor = true;
            // 
            // chkOrder
            // 
            this.chkOrder.AutoSize = true;
            this.chkOrder.Location = new System.Drawing.Point(5, 54);
            this.chkOrder.Name = "chkOrder";
            this.chkOrder.Size = new System.Drawing.Size(93, 18);
            this.chkOrder.TabIndex = 30;
            this.chkOrder.Text = "订单日期*：";
            this.chkOrder.UseVisualStyleBackColor = true;
            // 
            // frmAssemblyMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 482);
            this.Controls.Add(this.c_grcMain);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "frmAssemblyMng";
            this.Text = "frmAssemblyMng";
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.c_pnl, 0);
            this.Controls.SetChildIndex(this.c_grcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.c_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl c_grcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn F_Number;
        private DevExpress.XtraGrid.Columns.GridColumn FPhone;
        private DevExpress.XtraGrid.Columns.GridColumn FDetail;
        private DevExpress.XtraGrid.Columns.GridColumn FAddress;
        private DevExpress.XtraGrid.Columns.GridColumn fMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn FUnit;
        private DevExpress.XtraGrid.Columns.GridColumn FPrice;
        private DevExpress.XtraGrid.Columns.GridColumn FEmp;
        private DevExpress.XtraEditors.SimpleButton btn_Query;
        private System.Windows.Forms.DateTimePicker FDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FDateBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FAZDateEnd;
        private System.Windows.Forms.DateTimePicker FAZDateBegin;
        private DevExpress.XtraGrid.Columns.GridColumn FInterID;
        private DevExpress.XtraGrid.Columns.GridColumn FModel;
        private Wingdell.Control.WDItemEdit txtFInstaller;
        private Wingdell.Control.WDItemEdit txtFCustomer;
        private Wingdell.Control.WDItemEdit txtFEmp;
        private Wingdell.Control.WDTextEdit FBillNO;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.CheckBox chkOrder;
        private System.Windows.Forms.CheckBox chkInstall;
        private DevExpress.XtraGrid.Columns.GridColumn FAccount;
        private DevExpress.XtraGrid.Columns.GridColumn F_BillNO;
        private DevExpress.XtraGrid.Columns.GridColumn F_Installer;
        private DevExpress.XtraGrid.Columns.GridColumn F_Customer;

    }
}