namespace Services
{
    partial class FrmICStockBill
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
            WMSModel.EmptyItem emptyItem3 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem2 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem1 = new WMSModel.EmptyItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FBillNo = new Wingdell.Control.WDTextEdit();
            this.FDate = new Wingdell.Control.WDDateEdit();
            this.FEmpID = new Wingdell.Control.WDItemEdit();
            this.FSupplyID = new Wingdell.Control.WDItemEdit();
            this.FDeptID = new Wingdell.Control.WDItemEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.FDeptID);
            this.c_pnl.Controls.Add(this.FSupplyID);
            this.c_pnl.Controls.Add(this.FEmpID);
            this.c_pnl.Controls.Add(this.FDate);
            this.c_pnl.Controls.Add(this.FBillNo);
            this.c_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.c_pnl.Size = new System.Drawing.Size(833, 99);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 130);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(833, 304);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // FBillNo
            // 
            this.FBillNo.BackColor = System.Drawing.Color.Transparent;
            this.FBillNo.Caption = "维修单号*：";
            this.FBillNo.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FBillNo.Location = new System.Drawing.Point(22, 23);
            this.FBillNo.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FBillNo.MinimumSize = new System.Drawing.Size(50, 21);
            this.FBillNo.Name = "FBillNo";
            this.FBillNo.Size = new System.Drawing.Size(183, 21);
            this.FBillNo.TabIndex = 11;
            // 
            // FDate
            // 
            this.FDate.BackColor = System.Drawing.Color.Transparent;
            this.FDate.Caption = "报单日期*：";
            this.FDate.Location = new System.Drawing.Point(229, 23);
            this.FDate.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FDate.MinimumSize = new System.Drawing.Size(50, 21);
            this.FDate.Name = "FDate";
            this.FDate.Size = new System.Drawing.Size(190, 21);
            this.FDate.TabIndex = 12;
            this.FDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // FEmpID
            // 
            this.FEmpID.BackColor = System.Drawing.Color.Transparent;
            this.FEmpID.Caption = "业务员*：";
            this.FEmpID.Location = new System.Drawing.Point(33, 60);
            this.FEmpID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FEmpID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FEmpID.Name = "FEmpID";
            this.FEmpID.SelectService = null;
            this.FEmpID.Size = new System.Drawing.Size(172, 21);
            this.FEmpID.TabIndex = 13;
            this.FEmpID.Value = emptyItem3;
            // 
            // FSupplyID
            // 
            this.FSupplyID.BackColor = System.Drawing.Color.Transparent;
            this.FSupplyID.Caption = "供应商*：";
            this.FSupplyID.Location = new System.Drawing.Point(452, 23);
            this.FSupplyID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FSupplyID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FSupplyID.Name = "FSupplyID";
            this.FSupplyID.SelectService = null;
            this.FSupplyID.Size = new System.Drawing.Size(199, 21);
            this.FSupplyID.TabIndex = 14;
            this.FSupplyID.Value = emptyItem2;
            // 
            // FDeptID
            // 
            this.FDeptID.BackColor = System.Drawing.Color.Transparent;
            this.FDeptID.Caption = "部门*：";
            this.FDeptID.Location = new System.Drawing.Point(249, 60);
            this.FDeptID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FDeptID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FDeptID.Name = "FDeptID";
            this.FDeptID.SelectService = null;
            this.FDeptID.Size = new System.Drawing.Size(170, 21);
            this.FDeptID.TabIndex = 15;
            this.FDeptID.Value = emptyItem1;
            // 
            // FrmICStockBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 459);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmICStockBill";
            this.Text = "FrmICStockBill";
            this.Controls.SetChildIndex(this.c_pnl, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Wingdell.Control.WDDateEdit FDate;
        private Wingdell.Control.WDTextEdit FBillNo;
        private Wingdell.Control.WDItemEdit FDeptID;
        private Wingdell.Control.WDItemEdit FSupplyID;
        private Wingdell.Control.WDItemEdit FEmpID;
    }
}