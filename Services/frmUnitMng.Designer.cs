﻿namespace Services
{
    partial class frmUnitMng
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
            this.Name1 = new Wingdell.Control.WDTextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.FItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.F_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.F_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_grcMain = new DevExpress.XtraGrid.GridControl();
            this.Number = new Wingdell.Control.WDTextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.FNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.c_grcTree = new DevExpress.XtraTreeList.TreeList();
            this.FName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.splitContainerControl1);
            this.c_pnl.Size = new System.Drawing.Size(673, 380);
            // 
            // Name1
            // 
            this.Name1.BackColor = System.Drawing.Color.Transparent;
            this.Name1.Caption = "名称*：";
            this.Name1.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.Name1.Location = new System.Drawing.Point(180, 16);
            this.Name1.MaximumSize = new System.Drawing.Size(1000, 21);
            this.Name1.MinimumSize = new System.Drawing.Size(50, 21);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(169, 21);
            this.Name1.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(383, 16);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(61, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "查询";
            // 
            // FItemID
            // 
            this.FItemID.Caption = "gridColumn1";
            this.FItemID.FieldName = "FItemID";
            this.FItemID.Name = "FItemID";
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
            this.FItemID});
            this.gridView1.GridControl = this.c_grcMain;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // c_grcMain
            // 
            this.c_grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grcMain.Location = new System.Drawing.Point(2, 2);
            this.c_grcMain.MainView = this.gridView1;
            this.c_grcMain.Name = "c_grcMain";
            this.c_grcMain.Size = new System.Drawing.Size(456, 320);
            this.c_grcMain.TabIndex = 0;
            this.c_grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.c_grcMain.DoubleClick += new System.EventHandler(this.c_grcMain_DoubleClick);
            // 
            // Number
            // 
            this.Number.BackColor = System.Drawing.Color.Transparent;
            this.Number.Caption = "编码*：";
            this.Number.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.Number.Location = new System.Drawing.Point(5, 16);
            this.Number.MaximumSize = new System.Drawing.Size(1000, 21);
            this.Number.MinimumSize = new System.Drawing.Size(50, 21);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(169, 21);
            this.Number.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.c_grcMain);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 52);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(460, 324);
            this.panelControl2.TabIndex = 2;
            // 
            // FNumber
            // 
            this.FNumber.Caption = "代码";
            this.FNumber.FieldName = "FNumber";
            this.FNumber.Name = "FNumber";
            this.FNumber.Visible = true;
            this.FNumber.VisibleIndex = 0;
            this.FNumber.Width = 80;
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
            this.c_grcTree.OptionsBehavior.PopulateServiceColumns = true;
            this.c_grcTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.c_grcTree.OptionsView.AutoWidth = false;
            this.c_grcTree.ParentFieldName = "FParentID";
            this.c_grcTree.Size = new System.Drawing.Size(204, 376);
            this.c_grcTree.TabIndex = 0;
            this.c_grcTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.c_grcTree_FocusedNodeChanged);
            // 
            // FName
            // 
            this.FName.Caption = "名称";
            this.FName.FieldName = "FName";
            this.FName.Name = "FName";
            this.FName.Visible = true;
            this.FName.VisibleIndex = 1;
            this.FName.Width = 100;
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
            this.splitContainerControl1.Size = new System.Drawing.Size(669, 376);
            this.splitContainerControl1.SplitterPosition = 204;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Name1);
            this.panelControl1.Controls.Add(this.Number);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(460, 52);
            this.panelControl1.TabIndex = 1;
            // 
            // frmUnitMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 435);
            this.Name = "frmUnitMng";
            this.Text = "frmUnitMng";
            this.Load += new System.EventHandler(this.frmUnitMng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_grcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grcTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn FItemID;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Wingdell.Control.WDTextEdit Name1;
        private Wingdell.Control.WDTextEdit Number;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;

   }
}