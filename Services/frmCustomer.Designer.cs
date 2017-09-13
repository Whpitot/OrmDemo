namespace Services
{
    partial class frmCustomer
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
            this.FNumber = new Wingdell.Control.WDTextEdit();
            this.FName = new Wingdell.Control.WDTextEdit();
            this.FFax = new Wingdell.Control.WDTextEdit();
            this.FPhone = new Wingdell.Control.WDTextEdit();
            this.FServer = new Wingdell.Control.WDTextEdit();
            this.FNote = new Wingdell.Control.WDTextEdit();
            this.FSupplierID = new Wingdell.Control.WDItemEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.FSupplierID);
            this.c_pnl.Controls.Add(this.FNote);
            this.c_pnl.Controls.Add(this.FServer);
            this.c_pnl.Controls.Add(this.FPhone);
            this.c_pnl.Controls.Add(this.FFax);
            this.c_pnl.Controls.Add(this.FName);
            this.c_pnl.Controls.Add(this.FNumber);
            this.c_pnl.Size = new System.Drawing.Size(563, 303);
            // 
            // FNumber
            // 
            this.FNumber.BackColor = System.Drawing.Color.Transparent;
            this.FNumber.Caption = "代  码*：";
            this.FNumber.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNumber.Location = new System.Drawing.Point(22, 27);
            this.FNumber.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNumber.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNumber.Name = "FNumber";
            this.FNumber.Size = new System.Drawing.Size(186, 21);
            this.FNumber.TabIndex = 0;
            // 
            // FName
            // 
            this.FName.BackColor = System.Drawing.Color.Transparent;
            this.FName.Caption = "名   称*：";
            this.FName.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FName.Location = new System.Drawing.Point(22, 89);
            this.FName.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FName.MinimumSize = new System.Drawing.Size(50, 21);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(186, 21);
            this.FName.TabIndex = 1;
            // 
            // FFax
            // 
            this.FFax.BackColor = System.Drawing.Color.Transparent;
            this.FFax.Caption = "传  真*：";
            this.FFax.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FFax.Location = new System.Drawing.Point(22, 220);
            this.FFax.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FFax.MinimumSize = new System.Drawing.Size(50, 21);
            this.FFax.Name = "FFax";
            this.FFax.Size = new System.Drawing.Size(186, 21);
            this.FFax.TabIndex = 2;
            // 
            // FPhone
            // 
            this.FPhone.BackColor = System.Drawing.Color.Transparent;
            this.FPhone.Caption = "电  话*：";
            this.FPhone.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FPhone.Location = new System.Drawing.Point(266, 27);
            this.FPhone.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FPhone.MinimumSize = new System.Drawing.Size(50, 21);
            this.FPhone.Name = "FPhone";
            this.FPhone.Size = new System.Drawing.Size(186, 21);
            this.FPhone.TabIndex = 3;
            // 
            // FServer
            // 
            this.FServer.BackColor = System.Drawing.Color.Transparent;
            this.FServer.Caption = "联系人*：";
            this.FServer.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FServer.Location = new System.Drawing.Point(266, 89);
            this.FServer.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FServer.MinimumSize = new System.Drawing.Size(50, 21);
            this.FServer.Name = "FServer";
            this.FServer.Size = new System.Drawing.Size(186, 21);
            this.FServer.TabIndex = 4;
            // 
            // FNote
            // 
            this.FNote.BackColor = System.Drawing.Color.Transparent;
            this.FNote.Caption = "备   注*：";
            this.FNote.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNote.Location = new System.Drawing.Point(266, 157);
            this.FNote.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNote.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNote.Name = "FNote";
            this.FNote.Size = new System.Drawing.Size(186, 21);
            this.FNote.TabIndex = 5;
            // 
            // FSupplierID
            // 
            this.FSupplierID.BackColor = System.Drawing.Color.Transparent;
            this.FSupplierID.Caption = "销售品牌*：";
            this.FSupplierID.Location = new System.Drawing.Point(9, 157);
            this.FSupplierID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FSupplierID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FSupplierID.Name = "FSupplierID";
            this.FSupplierID.SelectService = null;
            this.FSupplierID.Size = new System.Drawing.Size(199, 21);
            this.FSupplierID.TabIndex = 6;
            this.FSupplierID.Value = emptyItem1;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 364);
            this.Name = "frmCustomer";
            this.Text = "frmCustomerMng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wingdell.Control.WDTextEdit FFax;
        private Wingdell.Control.WDTextEdit FName;
        private Wingdell.Control.WDTextEdit FNumber;
        private Wingdell.Control.WDTextEdit FNote;
        private Wingdell.Control.WDTextEdit FServer;
        private Wingdell.Control.WDTextEdit FPhone;
        private Wingdell.Control.WDItemEdit FSupplierID;
    }
}