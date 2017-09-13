namespace Services
{
    partial class FrmInstallationMng
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
            WMSModel.EmptyItem emptyItem1 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem2 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem3 = new WMSModel.EmptyItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOrder = new System.Windows.Forms.CheckBox();
            this.chkInstall = new System.Windows.Forms.CheckBox();
            this.txtFInstaller = new Wingdell.Control.WDItemEdit();
            this.txtFCustomer = new Wingdell.Control.WDItemEdit();
            this.txtFEmp = new Wingdell.Control.WDItemEdit();
            this.FBillNO = new Wingdell.Control.WDTextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.FAZDateEnd = new System.Windows.Forms.DateTimePicker();
            this.FAZDateBegin = new System.Windows.Forms.DateTimePicker();
            this.btn_Query = new DevExpress.XtraEditors.SimpleButton();
            this.FDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.FDateBegin = new System.Windows.Forms.DateTimePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.gridControl1);
            this.c_pnl.Controls.Add(this.panel1);
            this.c_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_pnl.Size = new System.Drawing.Size(813, 427);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOrder);
            this.panel1.Controls.Add(this.chkInstall);
            this.panel1.Controls.Add(this.txtFInstaller);
            this.panel1.Controls.Add(this.txtFCustomer);
            this.panel1.Controls.Add(this.txtFEmp);
            this.panel1.Controls.Add(this.FBillNO);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.FAZDateEnd);
            this.panel1.Controls.Add(this.FAZDateBegin);
            this.panel1.Controls.Add(this.btn_Query);
            this.panel1.Controls.Add(this.FDateEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.FDateBegin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 91);
            this.panel1.TabIndex = 0;
            // 
            // chkOrder
            // 
            this.chkOrder.AutoSize = true;
            this.chkOrder.Checked = true;
            this.chkOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrder.Location = new System.Drawing.Point(5, 57);
            this.chkOrder.Name = "chkOrder";
            this.chkOrder.Size = new System.Drawing.Size(93, 18);
            this.chkOrder.TabIndex = 43;
            this.chkOrder.Text = "报单日期*：";
            this.chkOrder.UseVisualStyleBackColor = true;
            // 
            // chkInstall
            // 
            this.chkInstall.AutoSize = true;
            this.chkInstall.Location = new System.Drawing.Point(370, 57);
            this.chkInstall.Name = "chkInstall";
            this.chkInstall.Size = new System.Drawing.Size(93, 18);
            this.chkInstall.TabIndex = 42;
            this.chkInstall.Text = "安装日期*：";
            this.chkInstall.UseVisualStyleBackColor = true;
            // 
            // txtFInstaller
            // 
            this.txtFInstaller.BackColor = System.Drawing.Color.Transparent;
            this.txtFInstaller.Caption = "安装工*：";
            this.txtFInstaller.Location = new System.Drawing.Point(599, 14);
            this.txtFInstaller.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFInstaller.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFInstaller.Name = "txtFInstaller";
            this.txtFInstaller.SelectService = null;
            this.txtFInstaller.Size = new System.Drawing.Size(179, 21);
            this.txtFInstaller.TabIndex = 41;
            this.txtFInstaller.Value = emptyItem1;
            // 
            // txtFCustomer
            // 
            this.txtFCustomer.BackColor = System.Drawing.Color.Transparent;
            this.txtFCustomer.Caption = "客户*：";
            this.txtFCustomer.Location = new System.Drawing.Point(415, 14);
            this.txtFCustomer.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFCustomer.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFCustomer.Name = "txtFCustomer";
            this.txtFCustomer.SelectService = null;
            this.txtFCustomer.Size = new System.Drawing.Size(162, 21);
            this.txtFCustomer.TabIndex = 40;
            this.txtFCustomer.Value = emptyItem2;
            // 
            // txtFEmp
            // 
            this.txtFEmp.BackColor = System.Drawing.Color.Transparent;
            this.txtFEmp.Caption = "业务员*：";
            this.txtFEmp.Location = new System.Drawing.Point(198, 14);
            this.txtFEmp.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFEmp.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFEmp.Name = "txtFEmp";
            this.txtFEmp.SelectService = null;
            this.txtFEmp.Size = new System.Drawing.Size(199, 21);
            this.txtFEmp.TabIndex = 39;
            this.txtFEmp.Value = emptyItem3;
            // 
            // FBillNO
            // 
            this.FBillNO.BackColor = System.Drawing.Color.Transparent;
            this.FBillNO.Caption = "安装单号*：";
            this.FBillNO.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FBillNO.Location = new System.Drawing.Point(10, 14);
            this.FBillNO.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FBillNO.MinimumSize = new System.Drawing.Size(50, 21);
            this.FBillNO.Name = "FBillNO";
            this.FBillNO.Size = new System.Drawing.Size(169, 21);
            this.FBillNO.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 14);
            this.label3.TabIndex = 37;
            this.label3.Text = "至";
            // 
            // FAZDateEnd
            // 
            this.FAZDateEnd.Location = new System.Drawing.Point(608, 53);
            this.FAZDateEnd.Name = "FAZDateEnd";
            this.FAZDateEnd.Size = new System.Drawing.Size(114, 22);
            this.FAZDateEnd.TabIndex = 36;
            // 
            // FAZDateBegin
            // 
            this.FAZDateBegin.Location = new System.Drawing.Point(461, 53);
            this.FAZDateBegin.Name = "FAZDateBegin";
            this.FAZDateBegin.Size = new System.Drawing.Size(116, 22);
            this.FAZDateBegin.TabIndex = 35;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(736, 49);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(63, 23);
            this.btn_Query.TabIndex = 34;
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // FDateEnd
            // 
            this.FDateEnd.Location = new System.Drawing.Point(242, 53);
            this.FDateEnd.Name = "FDateEnd";
            this.FDateEnd.Size = new System.Drawing.Size(110, 22);
            this.FDateEnd.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "至";
            // 
            // FDateBegin
            // 
            this.FDateBegin.Location = new System.Drawing.Point(96, 53);
            this.FDateBegin.Name = "FDateBegin";
            this.FDateBegin.Size = new System.Drawing.Size(115, 22);
            this.FDateBegin.TabIndex = 31;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 93);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(809, 332);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // FrmInstallationMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 483);
            this.Name = "FrmInstallationMng";
            this.Text = "安装管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkOrder;
        private System.Windows.Forms.CheckBox chkInstall;
        private Wingdell.Control.WDItemEdit txtFInstaller;
        private Wingdell.Control.WDItemEdit txtFCustomer;
        private Wingdell.Control.WDItemEdit txtFEmp;
        private Wingdell.Control.WDTextEdit FBillNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FAZDateEnd;
        private System.Windows.Forms.DateTimePicker FAZDateBegin;
        private DevExpress.XtraEditors.SimpleButton btn_Query;
        private System.Windows.Forms.DateTimePicker FDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FDateBegin;

    }
}