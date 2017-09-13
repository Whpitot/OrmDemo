namespace Services
{
    partial class FrmFixMng
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
            this.btn_Query = new DevExpress.XtraEditors.SimpleButton();
            this.FDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.FDateBegin = new System.Windows.Forms.DateTimePicker();
            this.FInterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtFBillNo = new Wingdell.Control.WDItemEdit();
            this.txtFFixer = new Wingdell.Control.WDItemEdit();
            this.cboDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Controls.Add(this.cboDate);
            this.c_pnl.Controls.Add(this.txtFFixer);
            this.c_pnl.Controls.Add(this.txtFBillNo);
            this.c_pnl.Controls.Add(this.btn_Query);
            this.c_pnl.Controls.Add(this.FDateEnd);
            this.c_pnl.Controls.Add(this.label1);
            this.c_pnl.Controls.Add(this.FDateBegin);
            this.c_pnl.Size = new System.Drawing.Size(887, 53);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FInterID});
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 84);
            this.gridControl1.Size = new System.Drawing.Size(887, 437);
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(803, 14);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 33;
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // FDateEnd
            // 
            this.FDateEnd.Location = new System.Drawing.Point(687, 15);
            this.FDateEnd.Name = "FDateEnd";
            this.FDateEnd.Size = new System.Drawing.Size(110, 22);
            this.FDateEnd.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(652, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "至";
            // 
            // FDateBegin
            // 
            this.FDateBegin.Location = new System.Drawing.Point(531, 15);
            this.FDateBegin.Name = "FDateBegin";
            this.FDateBegin.Size = new System.Drawing.Size(115, 22);
            this.FDateBegin.TabIndex = 30;
            // 
            // FInterID
            // 
            this.FInterID.Caption = "gridColumn1";
            this.FInterID.FieldName = "FInterID";
            this.FInterID.Name = "FInterID";
            // 
            // txtFBillNo
            // 
            this.txtFBillNo.BackColor = System.Drawing.Color.Transparent;
            this.txtFBillNo.Caption = "维修单号*：";
            this.txtFBillNo.Location = new System.Drawing.Point(12, 16);
            this.txtFBillNo.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFBillNo.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFBillNo.Name = "txtFBillNo";
            this.txtFBillNo.SelectService = null;
            this.txtFBillNo.Size = new System.Drawing.Size(199, 21);
            this.txtFBillNo.TabIndex = 40;
            this.txtFBillNo.Value = emptyItem2;
            // 
            // txtFFixer
            // 
            this.txtFFixer.BackColor = System.Drawing.Color.Transparent;
            this.txtFFixer.Caption = "维修员*：";
            this.txtFFixer.Location = new System.Drawing.Point(217, 16);
            this.txtFFixer.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFFixer.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFFixer.Name = "txtFFixer";
            this.txtFFixer.SelectService = null;
            this.txtFFixer.Size = new System.Drawing.Size(199, 21);
            this.txtFFixer.TabIndex = 41;
            this.txtFFixer.Value = emptyItem1;
            // 
            // cboDate
            // 
            this.cboDate.AutoSize = true;
            this.cboDate.Location = new System.Drawing.Point(444, 19);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(81, 18);
            this.cboDate.TabIndex = 42;
            this.cboDate.Text = "*报单日期";
            this.cboDate.UseVisualStyleBackColor = true;
            // 
            // FrmFixMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 546);
            this.Name = "FrmFixMng";
            this.Text = "维修管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.c_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Query;
        private System.Windows.Forms.DateTimePicker FDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FDateBegin;
        private DevExpress.XtraGrid.Columns.GridColumn FInterID;
        private System.Windows.Forms.CheckBox cboDate;
        private Wingdell.Control.WDItemEdit txtFFixer;
        private Wingdell.Control.WDItemEdit txtFBillNo;
    }
}