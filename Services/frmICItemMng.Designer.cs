namespace Services
{
    partial class frmICItemMng
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.srTextEdit1 = new Unicre.WMS.Controls.SRTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.srTextEdit2 = new Unicre.WMS.Controls.SRTextEdit();
            this.F_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.F_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FDimension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_grcMain = new DevExpress.XtraGrid.GridControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.FName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.FNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.c_grcTree = new DevExpress.XtraTreeList.TreeList();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.FOpenWay = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.splitContainerControl1);
            this.c_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_pnl.Size = new System.Drawing.Size(884, 412);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(440, 14);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(61, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "查询";
            // 
            // srTextEdit1
            // 
            this.srTextEdit1.BackColor = System.Drawing.Color.Transparent;
            this.srTextEdit1.Caption = "代码：";
            this.srTextEdit1.EditFormat = Unicre.WMS.Controls.EditFormat.Normal;
            this.srTextEdit1.Location = new System.Drawing.Point(20, 16);
            this.srTextEdit1.MaximumSize = new System.Drawing.Size(1000, 21);
            this.srTextEdit1.MinimumSize = new System.Drawing.Size(50, 21);
            this.srTextEdit1.Name = "srTextEdit1";
            this.srTextEdit1.Size = new System.Drawing.Size(187, 21);
            this.srTextEdit1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.srTextEdit2);
            this.panelControl1.Controls.Add(this.srTextEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(739, 52);
            this.panelControl1.TabIndex = 1;
            // 
            // srTextEdit2
            // 
            this.srTextEdit2.BackColor = System.Drawing.Color.Transparent;
            this.srTextEdit2.Caption = "名称：";
            this.srTextEdit2.EditFormat = Unicre.WMS.Controls.EditFormat.Normal;
            this.srTextEdit2.Location = new System.Drawing.Point(232, 16);
            this.srTextEdit2.MaximumSize = new System.Drawing.Size(1000, 21);
            this.srTextEdit2.MinimumSize = new System.Drawing.Size(50, 21);
            this.srTextEdit2.Name = "srTextEdit2";
            this.srTextEdit2.Size = new System.Drawing.Size(187, 21);
            this.srTextEdit2.TabIndex = 1;
            // 
            // F_Name
            // 
            this.F_Name.Caption = "名称";
            this.F_Name.FieldName = "FName";
            this.F_Name.Name = "F_Name";
            this.F_Name.Visible = true;
            this.F_Name.VisibleIndex = 1;
            this.F_Name.Width = 114;
            // 
            // F_Number
            // 
            this.F_Number.Caption = "代码";
            this.F_Number.FieldName = "FNumber";
            this.F_Number.Name = "F_Number";
            this.F_Number.Visible = true;
            this.F_Number.VisibleIndex = 0;
            this.F_Number.Width = 100;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.F_Number,
            this.F_Name,
            this.FSupplier,
            this.FLevel,
            this.FDimension,
            this.FOpenWay,
            this.FUnit,
            this.FPrice});
            this.gridView1.GridControl = this.c_grcMain;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FSupplier
            // 
            this.FSupplier.Caption = "供应商";
            this.FSupplier.FieldName = "FSupplier";
            this.FSupplier.Name = "FSupplier";
            this.FSupplier.Visible = true;
            this.FSupplier.VisibleIndex = 2;
            // 
            // FLevel
            // 
            this.FLevel.Caption = "等级";
            this.FLevel.FieldName = "FLevel";
            this.FLevel.Name = "FLevel";
            this.FLevel.Visible = true;
            this.FLevel.VisibleIndex = 3;
            // 
            // FDimension
            // 
            this.FDimension.Caption = "尺寸";
            this.FDimension.FieldName = "FDimension";
            this.FDimension.Name = "FDimension";
            this.FDimension.Visible = true;
            this.FDimension.VisibleIndex = 4;
            this.FDimension.Width = 120;
            // 
            // FUnit
            // 
            this.FUnit.Caption = "单位";
            this.FUnit.FieldName = "FUnit";
            this.FUnit.Name = "FUnit";
            this.FUnit.Visible = true;
            this.FUnit.VisibleIndex = 6;
            // 
            // FPrice
            // 
            this.FPrice.Caption = "单价";
            this.FPrice.FieldName = "FPrice";
            this.FPrice.Name = "FPrice";
            this.FPrice.Visible = true;
            this.FPrice.VisibleIndex = 7;
            // 
            // c_grcMain
            // 
            this.c_grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grcMain.Location = new System.Drawing.Point(2, 2);
            this.c_grcMain.MainView = this.gridView1;
            this.c_grcMain.Name = "c_grcMain";
            this.c_grcMain.Size = new System.Drawing.Size(735, 352);
            this.c_grcMain.TabIndex = 0;
            this.c_grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.c_grcMain.DoubleClick += new System.EventHandler(this.c_grcMain_DoubleClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.c_grcMain);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 52);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(739, 356);
            this.panelControl2.TabIndex = 2;
            // 
            // FName
            // 
            this.FName.Caption = "名称";
            this.FName.FieldName = "FName";
            this.FName.Name = "FName";
            this.FName.Visible = true;
            this.FName.VisibleIndex = 1;
            // 
            // FNumber
            // 
            this.FNumber.Caption = "代码";
            this.FNumber.FieldName = "FNumber";
            this.FNumber.Name = "FNumber";
            this.FNumber.Visible = true;
            this.FNumber.VisibleIndex = 0;
            // 
            // c_grcTree
            // 
            this.c_grcTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.FNumber,
            this.FName});
            this.c_grcTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grcTree.KeyFieldName = "FItemID";
            this.c_grcTree.Location = new System.Drawing.Point(0, 0);
            this.c_grcTree.Name = "c_grcTree";
            this.c_grcTree.OptionsBehavior.Editable = false;
            this.c_grcTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.c_grcTree.ParentFieldName = "FParentID";
            this.c_grcTree.Size = new System.Drawing.Size(136, 408);
            this.c_grcTree.TabIndex = 0;
            this.c_grcTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.c_grcTree_FocusedNodeChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.c_grcTree);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(880, 408);
            this.splitContainerControl1.SplitterPosition = 136;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // FOpenWay
            // 
            this.FOpenWay.Caption = "打开方式";
            this.FOpenWay.FieldName = "FOpenWay";
            this.FOpenWay.Name = "FOpenWay";
            this.FOpenWay.Visible = true;
            this.FOpenWay.VisibleIndex = 5;
            this.FOpenWay.Width = 80;
            // 
            // frmICItemMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 468);
            this.Name = "frmICItemMng";
            this.Text = "货品管理";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grcTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList c_grcTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn FNumber;
        private DevExpress.XtraTreeList.Columns.TreeListColumn FName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl c_grcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn F_Number;
        private DevExpress.XtraGrid.Columns.GridColumn F_Name;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private Unicre.WMS.Controls.SRTextEdit srTextEdit2;
        private Unicre.WMS.Controls.SRTextEdit srTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn FDimension;
        private DevExpress.XtraGrid.Columns.GridColumn FUnit;
        private DevExpress.XtraGrid.Columns.GridColumn FPrice;
        private DevExpress.XtraGrid.Columns.GridColumn FSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn FLevel;
        private DevExpress.XtraGrid.Columns.GridColumn FOpenWay;
    }
}