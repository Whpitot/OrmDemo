namespace Services
{
    partial class frmUserFun
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.rightTree = new DevExpress.XtraTreeList.TreeList();
            this.F_Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.FName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.FNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.c_grcTree = new DevExpress.XtraTreeList.TreeList();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightTree)).BeginInit();
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
            this.c_pnl.Size = new System.Drawing.Size(790, 512);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.rightTree);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(515, 508);
            this.panelControl2.TabIndex = 2;
            // 
            // rightTree
            // 
            this.rightTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.F_Name});
            this.rightTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTree.KeyFieldName = "FuncID";
            this.rightTree.Location = new System.Drawing.Point(2, 2);
            this.rightTree.Name = "rightTree";
            this.rightTree.OptionsBehavior.Editable = false;
            this.rightTree.OptionsView.ShowCheckBoxes = true;
            this.rightTree.ParentFieldName = "FParentID";
            this.rightTree.Size = new System.Drawing.Size(511, 504);
            this.rightTree.TabIndex = 0;
            // 
            // F_Name
            // 
            this.F_Name.Caption = "权限名称";
            this.F_Name.FieldName = "FName";
            this.F_Name.MinWidth = 32;
            this.F_Name.Name = "F_Name";
            this.F_Name.Visible = true;
            this.F_Name.VisibleIndex = 0;
            this.F_Name.Width = 91;
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
            this.c_grcTree.ParentFieldName = "FParentID";
            this.c_grcTree.Size = new System.Drawing.Size(266, 508);
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
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(786, 508);
            this.splitContainerControl1.SplitterPosition = 266;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmUserFun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Name = "frmUserFun";
            this.Text = "用户权限设置";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightTree)).EndInit();
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
        private DevExpress.XtraTreeList.TreeList rightTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn F_Name;
    }
}