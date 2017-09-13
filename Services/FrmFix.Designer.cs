namespace Services
{
    partial class FrmFix
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
            this.FBillNo = new Wingdell.Control.WDTextEdit();
            this.FRecordDate = new Wingdell.Control.WDDateEdit();
            this.FFixDate = new Wingdell.Control.WDDateEdit();
            this.FModifierID = new Wingdell.Control.WDItemEdit();
            this.FPhone = new Wingdell.Control.WDTextEdit();
            this.FAddress = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.textBox1);
            this.c_pnl.Controls.Add(this.labelControl2);
            this.c_pnl.Controls.Add(this.labelControl1);
            this.c_pnl.Controls.Add(this.FAddress);
            this.c_pnl.Controls.Add(this.FPhone);
            this.c_pnl.Controls.Add(this.FModifierID);
            this.c_pnl.Controls.Add(this.FFixDate);
            this.c_pnl.Controls.Add(this.FRecordDate);
            this.c_pnl.Controls.Add(this.FBillNo);
            this.c_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_pnl.Size = new System.Drawing.Size(764, 361);
            // 
            // FBillNo
            // 
            this.FBillNo.BackColor = System.Drawing.Color.Transparent;
            this.FBillNo.Caption = "维修单号*：";
            this.FBillNo.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FBillNo.Location = new System.Drawing.Point(42, 25);
            this.FBillNo.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FBillNo.MinimumSize = new System.Drawing.Size(50, 21);
            this.FBillNo.Name = "FBillNo";
            this.FBillNo.Size = new System.Drawing.Size(244, 21);
            this.FBillNo.TabIndex = 0;
            // 
            // FRecordDate
            // 
            this.FRecordDate.BackColor = System.Drawing.Color.Transparent;
            this.FRecordDate.Caption = "报单日期*：";
            this.FRecordDate.Location = new System.Drawing.Point(42, 142);
            this.FRecordDate.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FRecordDate.MinimumSize = new System.Drawing.Size(50, 21);
            this.FRecordDate.Name = "FRecordDate";
            this.FRecordDate.Size = new System.Drawing.Size(244, 21);
            this.FRecordDate.TabIndex = 1;
            this.FRecordDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // FFixDate
            // 
            this.FFixDate.BackColor = System.Drawing.Color.Transparent;
            this.FFixDate.Caption = "维修日期*：";
            this.FFixDate.Location = new System.Drawing.Point(42, 264);
            this.FFixDate.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FFixDate.MinimumSize = new System.Drawing.Size(50, 21);
            this.FFixDate.Name = "FFixDate";
            this.FFixDate.Size = new System.Drawing.Size(244, 21);
            this.FFixDate.TabIndex = 2;
            this.FFixDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // FModifierID
            // 
            this.FModifierID.BackColor = System.Drawing.Color.Transparent;
            this.FModifierID.Caption = "维修员*：";
            this.FModifierID.Location = new System.Drawing.Point(54, 200);
            this.FModifierID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FModifierID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FModifierID.Name = "FModifierID";
            this.FModifierID.SelectService = null;
            this.FModifierID.Size = new System.Drawing.Size(232, 21);
            this.FModifierID.TabIndex = 3;
            this.FModifierID.Value = emptyItem2;
            // 
            // FPhone
            // 
            this.FPhone.BackColor = System.Drawing.Color.Transparent;
            this.FPhone.Caption = "电话*：";
            this.FPhone.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FPhone.Location = new System.Drawing.Point(67, 83);
            this.FPhone.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FPhone.MinimumSize = new System.Drawing.Size(50, 21);
            this.FPhone.Name = "FPhone";
            this.FPhone.Size = new System.Drawing.Size(219, 21);
            this.FPhone.TabIndex = 4;
            // 
            // FAddress
            // 
            this.FAddress.Location = new System.Drawing.Point(374, 52);
            this.FAddress.Multiline = true;
            this.FAddress.Name = "FAddress";
            this.FAddress.Size = new System.Drawing.Size(237, 56);
            this.FAddress.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(374, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "地址*：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(374, 125);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "备注*：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(374, 145);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 52);
            this.textBox1.TabIndex = 10;
            // 
            // FrmFix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 417);
            this.Name = "FrmFix";
            this.Text = "frmModify";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.c_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wingdell.Control.WDTextEdit FBillNo;
        private System.Windows.Forms.TextBox FAddress;
        private Wingdell.Control.WDTextEdit FPhone;
        private Wingdell.Control.WDItemEdit FModifierID;
        private Wingdell.Control.WDDateEdit FFixDate;
        private Wingdell.Control.WDDateEdit FRecordDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}