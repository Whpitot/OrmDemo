namespace Services
{
    partial class FrmICStockBillMng
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
            this.chkOrder = new System.Windows.Forms.CheckBox();
            this.txtFBillNo = new Wingdell.Control.WDTextEdit();
            this.btn_Query = new DevExpress.XtraEditors.SimpleButton();
            this.FDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.FDateBegin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Controls.Add(this.chkOrder);
            this.c_pnl.Controls.Add(this.txtFBillNo);
            this.c_pnl.Controls.Add(this.FDateBegin);
            this.c_pnl.Controls.Add(this.label1);
            this.c_pnl.Controls.Add(this.FDateEnd);
            this.c_pnl.Controls.Add(this.btn_Query);
            this.c_pnl.Size = new System.Drawing.Size(924, 55);
            // 
            // gridView1
            // 
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 86);
            this.gridControl1.Size = new System.Drawing.Size(924, 356);
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // chkOrder
            // 
            this.chkOrder.AutoSize = true;
            this.chkOrder.Location = new System.Drawing.Point(209, 14);
            this.chkOrder.Name = "chkOrder";
            this.chkOrder.Size = new System.Drawing.Size(93, 18);
            this.chkOrder.TabIndex = 43;
            this.chkOrder.Text = "订单日期*：";
            this.chkOrder.UseVisualStyleBackColor = true;
            // 
            // txtFBillNo
            // 
            this.txtFBillNo.BackColor = System.Drawing.Color.Transparent;
            this.txtFBillNo.Caption = "安装单号*：";
            this.txtFBillNo.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.txtFBillNo.Location = new System.Drawing.Point(12, 11);
            this.txtFBillNo.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFBillNo.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFBillNo.Name = "txtFBillNo";
            this.txtFBillNo.Size = new System.Drawing.Size(169, 21);
            this.txtFBillNo.TabIndex = 38;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(582, 11);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 34;
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // FDateEnd
            // 
            this.FDateEnd.Location = new System.Drawing.Point(454, 11);
            this.FDateEnd.Name = "FDateEnd";
            this.FDateEnd.Size = new System.Drawing.Size(110, 22);
            this.FDateEnd.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "至";
            // 
            // FDateBegin
            // 
            this.FDateBegin.Location = new System.Drawing.Point(308, 11);
            this.FDateBegin.Name = "FDateBegin";
            this.FDateBegin.Size = new System.Drawing.Size(115, 22);
            this.FDateBegin.TabIndex = 31;
            // 
            // FrmICStockBillMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 467);
            this.Name = "FrmICStockBillMng";
            this.Text = "入库单管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmICStockBillMng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.c_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOrder;
        private Wingdell.Control.WDTextEdit txtFBillNo;
        private System.Windows.Forms.DateTimePicker FDateBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FDateEnd;
        private DevExpress.XtraEditors.SimpleButton btn_Query;
    }
}