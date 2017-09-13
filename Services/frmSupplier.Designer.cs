namespace Services
{
    partial class frmSupplier
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
            this.FServer = new Wingdell.Control.WDTextEdit();
            this.FFax = new Wingdell.Control.WDTextEdit();
            this.FName = new Wingdell.Control.WDTextEdit();
            this.FNumber = new Wingdell.Control.WDTextEdit();
            this.FPhone = new Wingdell.Control.WDTextEdit();
            this.FNote = new Wingdell.Control.WDTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Controls.Add(this.FNote);
            this.c_pnl.Controls.Add(this.FServer);
            this.c_pnl.Controls.Add(this.FNumber);
            this.c_pnl.Controls.Add(this.FFax);
            this.c_pnl.Controls.Add(this.FName);
            this.c_pnl.Controls.Add(this.FPhone);
            this.c_pnl.Size = new System.Drawing.Size(651, 300);
            // 
            // FServer
            // 
            this.FServer.BackColor = System.Drawing.Color.Transparent;
            this.FServer.Caption = "联系人*：";
            this.FServer.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FServer.Location = new System.Drawing.Point(336, 102);
            this.FServer.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FServer.MinimumSize = new System.Drawing.Size(50, 21);
            this.FServer.Name = "FServer";
            this.FServer.Size = new System.Drawing.Size(178, 21);
            this.FServer.TabIndex = 15;
            // 
            // FFax
            // 
            this.FFax.BackColor = System.Drawing.Color.Transparent;
            this.FFax.Caption = "传真*：";
            this.FFax.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FFax.Location = new System.Drawing.Point(347, 52);
            this.FFax.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FFax.MinimumSize = new System.Drawing.Size(50, 21);
            this.FFax.Name = "FFax";
            this.FFax.Size = new System.Drawing.Size(167, 21);
            this.FFax.TabIndex = 14;
            // 
            // FName
            // 
            this.FName.BackColor = System.Drawing.Color.Transparent;
            this.FName.Caption = "名称*：";
            this.FName.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FName.Location = new System.Drawing.Point(71, 102);
            this.FName.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FName.MinimumSize = new System.Drawing.Size(50, 21);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(169, 21);
            this.FName.TabIndex = 11;
            // 
            // FNumber
            // 
            this.FNumber.BackColor = System.Drawing.Color.Transparent;
            this.FNumber.Caption = "编号*：";
            this.FNumber.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNumber.Location = new System.Drawing.Point(71, 52);
            this.FNumber.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNumber.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNumber.Name = "FNumber";
            this.FNumber.Size = new System.Drawing.Size(169, 21);
            this.FNumber.TabIndex = 10;
            // 
            // FPhone
            // 
            this.FPhone.BackColor = System.Drawing.Color.Transparent;
            this.FPhone.Caption = "电话*：";
            this.FPhone.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FPhone.Location = new System.Drawing.Point(71, 154);
            this.FPhone.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FPhone.MinimumSize = new System.Drawing.Size(50, 21);
            this.FPhone.Name = "FPhone";
            this.FPhone.Size = new System.Drawing.Size(169, 21);
            this.FPhone.TabIndex = 16;
            // 
            // FNote
            // 
            this.FNote.BackColor = System.Drawing.Color.Transparent;
            this.FNote.Caption = "备注*：";
            this.FNote.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNote.Location = new System.Drawing.Point(345, 154);
            this.FNote.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNote.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNote.Name = "FNote";
            this.FNote.Size = new System.Drawing.Size(169, 21);
            this.FNote.TabIndex = 17;
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 362);
            this.Name = "frmSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSupplier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSupplier_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Wingdell.Control.WDTextEdit FName;
        private Wingdell.Control.WDTextEdit FNumber;
        private Wingdell.Control.WDTextEdit FServer;
        private Wingdell.Control.WDTextEdit FFax;
        private Wingdell.Control.WDTextEdit FPhone;
        private Wingdell.Control.WDTextEdit FNote;
    }
}