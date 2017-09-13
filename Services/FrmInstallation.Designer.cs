namespace Services
{
    partial class FrmInstallation
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
            WMSModel.EmptyItem emptyItem7 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem8 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem6 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem5 = new WMSModel.EmptyItem();
            this.FCustomerID = new Wingdell.Control.WDItemEdit();
            this.FRecordDate = new Wingdell.Control.WDDateEdit();
            this.FSalesmanID = new Wingdell.Control.WDItemEdit();
            this.FNote = new Wingdell.Control.WDTextEdit();
            this.FPhone = new Wingdell.Control.WDTextEdit();
            this.FBillNo = new Wingdell.Control.WDTextEdit();
            this.FInstallerID = new Wingdell.Control.WDItemEdit();
            this.FInstallDate = new Wingdell.Control.WDDateEdit();
            this.FItemID = new Wingdell.Control.WDItemEdit();
            this.FQty = new Wingdell.Control.WDTextEdit();
            this.FauxPrice = new Wingdell.Control.WDTextEdit();
            this.FSettleAmount = new Wingdell.Control.WDTextEdit();
            this.FAccount = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.FAddress);
            this.c_pnl.Controls.Add(this.label1);
            this.c_pnl.Controls.Add(this.FAccount);
            this.c_pnl.Controls.Add(this.FSettleAmount);
            this.c_pnl.Controls.Add(this.FauxPrice);
            this.c_pnl.Controls.Add(this.FQty);
            this.c_pnl.Controls.Add(this.FItemID);
            this.c_pnl.Controls.Add(this.FInstallDate);
            this.c_pnl.Controls.Add(this.FInstallerID);
            this.c_pnl.Controls.Add(this.FCustomerID);
            this.c_pnl.Controls.Add(this.FRecordDate);
            this.c_pnl.Controls.Add(this.FSalesmanID);
            this.c_pnl.Controls.Add(this.FNote);
            this.c_pnl.Controls.Add(this.FPhone);
            this.c_pnl.Controls.Add(this.FBillNo);
            this.c_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_pnl.Size = new System.Drawing.Size(797, 416);
            // 
            // FCustomerID
            // 
            this.FCustomerID.BackColor = System.Drawing.Color.Transparent;
            this.FCustomerID.Caption = "店铺名称*：";
            this.FCustomerID.Location = new System.Drawing.Point(78, 249);
            this.FCustomerID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FCustomerID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FCustomerID.Name = "FCustomerID";
            this.FCustomerID.SelectService = null;
            this.FCustomerID.Size = new System.Drawing.Size(239, 21);
            this.FCustomerID.TabIndex = 20;
            this.FCustomerID.Value = emptyItem7;
            // 
            // FRecordDate
            // 
            this.FRecordDate.BackColor = System.Drawing.Color.Transparent;
            this.FRecordDate.Caption = "报单日期*：";
            this.FRecordDate.Location = new System.Drawing.Point(443, 40);
            this.FRecordDate.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FRecordDate.MinimumSize = new System.Drawing.Size(50, 21);
            this.FRecordDate.Name = "FRecordDate";
            this.FRecordDate.Size = new System.Drawing.Size(201, 21);
            this.FRecordDate.TabIndex = 18;
            this.FRecordDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // FSalesmanID
            // 
            this.FSalesmanID.BackColor = System.Drawing.Color.Transparent;
            this.FSalesmanID.Caption = "业务员*：";
            this.FSalesmanID.Location = new System.Drawing.Point(91, 295);
            this.FSalesmanID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FSalesmanID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FSalesmanID.Name = "FSalesmanID";
            this.FSalesmanID.SelectService = null;
            this.FSalesmanID.Size = new System.Drawing.Size(226, 21);
            this.FSalesmanID.TabIndex = 17;
            this.FSalesmanID.Value = emptyItem8;
            // 
            // FNote
            // 
            this.FNote.BackColor = System.Drawing.Color.Transparent;
            this.FNote.Caption = "备注*：";
            this.FNote.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNote.Location = new System.Drawing.Point(462, 295);
            this.FNote.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNote.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNote.Name = "FNote";
            this.FNote.Size = new System.Drawing.Size(182, 21);
            this.FNote.TabIndex = 16;
            // 
            // FPhone
            // 
            this.FPhone.BackColor = System.Drawing.Color.Transparent;
            this.FPhone.Caption = "电话*：";
            this.FPhone.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FPhone.Location = new System.Drawing.Point(103, 135);
            this.FPhone.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FPhone.MinimumSize = new System.Drawing.Size(50, 21);
            this.FPhone.Name = "FPhone";
            this.FPhone.Size = new System.Drawing.Size(214, 21);
            this.FPhone.TabIndex = 15;
            // 
            // FBillNo
            // 
            this.FBillNo.BackColor = System.Drawing.Color.Transparent;
            this.FBillNo.Caption = "安装单号*：";
            this.FBillNo.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FBillNo.Location = new System.Drawing.Point(78, 40);
            this.FBillNo.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FBillNo.MinimumSize = new System.Drawing.Size(50, 21);
            this.FBillNo.Name = "FBillNo";
            this.FBillNo.Size = new System.Drawing.Size(239, 21);
            this.FBillNo.TabIndex = 13;
            // 
            // FInstallerID
            // 
            this.FInstallerID.BackColor = System.Drawing.Color.Transparent;
            this.FInstallerID.Caption = "安装员*：";
            this.FInstallerID.Location = new System.Drawing.Point(91, 337);
            this.FInstallerID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FInstallerID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FInstallerID.Name = "FInstallerID";
            this.FInstallerID.SelectService = null;
            this.FInstallerID.Size = new System.Drawing.Size(226, 21);
            this.FInstallerID.TabIndex = 21;
            this.FInstallerID.Value = emptyItem6;
            // 
            // FInstallDate
            // 
            this.FInstallDate.BackColor = System.Drawing.Color.Transparent;
            this.FInstallDate.Caption = "安装日期*：";
            this.FInstallDate.Location = new System.Drawing.Point(443, 88);
            this.FInstallDate.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FInstallDate.MinimumSize = new System.Drawing.Size(50, 21);
            this.FInstallDate.Name = "FInstallDate";
            this.FInstallDate.Size = new System.Drawing.Size(201, 21);
            this.FInstallDate.TabIndex = 22;
            this.FInstallDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // FItemID
            // 
            this.FItemID.BackColor = System.Drawing.Color.Transparent;
            this.FItemID.Caption = "货品名称*：";
            this.FItemID.Location = new System.Drawing.Point(78, 88);
            this.FItemID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FItemID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FItemID.Name = "FItemID";
            this.FItemID.SelectService = null;
            this.FItemID.Size = new System.Drawing.Size(239, 21);
            this.FItemID.TabIndex = 23;
            this.FItemID.Value = emptyItem5;
            // 
            // FQty
            // 
            this.FQty.BackColor = System.Drawing.Color.Transparent;
            this.FQty.Caption = "数量*：";
            this.FQty.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FQty.Location = new System.Drawing.Point(462, 135);
            this.FQty.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FQty.MinimumSize = new System.Drawing.Size(50, 21);
            this.FQty.Name = "FQty";
            this.FQty.Size = new System.Drawing.Size(180, 21);
            this.FQty.TabIndex = 24;
            // 
            // FauxPrice
            // 
            this.FauxPrice.BackColor = System.Drawing.Color.Transparent;
            this.FauxPrice.Caption = "应收金额*：";
            this.FauxPrice.EditFormat = Wingdell.Control.EditFormat.Number;
            this.FauxPrice.Location = new System.Drawing.Point(443, 249);
            this.FauxPrice.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FauxPrice.MinimumSize = new System.Drawing.Size(50, 21);
            this.FauxPrice.Name = "FauxPrice";
            this.FauxPrice.Size = new System.Drawing.Size(201, 21);
            this.FauxPrice.TabIndex = 25;
            // 
            // FSettleAmount
            // 
            this.FSettleAmount.BackColor = System.Drawing.Color.Transparent;
            this.FSettleAmount.Caption = "实收金额*：";
            this.FSettleAmount.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FSettleAmount.Location = new System.Drawing.Point(443, 194);
            this.FSettleAmount.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FSettleAmount.MinimumSize = new System.Drawing.Size(50, 21);
            this.FSettleAmount.Name = "FSettleAmount";
            this.FSettleAmount.Size = new System.Drawing.Size(201, 21);
            this.FSettleAmount.TabIndex = 26;
            // 
            // FAccount
            // 
            this.FAccount.AutoSize = true;
            this.FAccount.Location = new System.Drawing.Point(462, 340);
            this.FAccount.Name = "FAccount";
            this.FAccount.Size = new System.Drawing.Size(85, 18);
            this.FAccount.TabIndex = 27;
            this.FAccount.Text = "checkBox1";
            this.FAccount.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "地址*：";
            // 
            // FAddress
            // 
            this.FAddress.Location = new System.Drawing.Point(145, 170);
            this.FAddress.Multiline = true;
            this.FAddress.Name = "FAddress";
            this.FAddress.Size = new System.Drawing.Size(209, 62);
            this.FAddress.TabIndex = 29;
            // 
            // FrmInstallation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 472);
            this.Name = "FrmInstallation";
            this.Text = "frmInstallation";
            this.Load += new System.EventHandler(this.FrmInstallation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.c_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wingdell.Control.WDDateEdit FRecordDate;
        private Wingdell.Control.WDItemEdit FSalesmanID;
        private Wingdell.Control.WDTextEdit FNote;
        private Wingdell.Control.WDTextEdit FPhone;
        private Wingdell.Control.WDTextEdit FBillNo;
        private Wingdell.Control.WDItemEdit FCustomerID;
        private Wingdell.Control.WDItemEdit FInstallerID;
        private Wingdell.Control.WDTextEdit FSettleAmount;
        private Wingdell.Control.WDTextEdit FauxPrice;
        private Wingdell.Control.WDTextEdit FQty;
        private Wingdell.Control.WDItemEdit FItemID;
        private Wingdell.Control.WDDateEdit FInstallDate;
        private System.Windows.Forms.CheckBox FAccount;
        private System.Windows.Forms.TextBox FAddress;
        private System.Windows.Forms.Label label1;
    }
}