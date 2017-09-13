namespace Services
{
    partial class frmEmp
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
            this.FDeptID = new Wingdell.Control.WDItemEdit();
            this.FNote = new Wingdell.Control.WDTextEdit();
            this.FPhone = new Wingdell.Control.WDTextEdit();
            this.FName = new Wingdell.Control.WDTextEdit();
            this.FNumber = new Wingdell.Control.WDTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.FDeptID);
            this.c_pnl.Controls.Add(this.FNote);
            this.c_pnl.Controls.Add(this.FPhone);
            this.c_pnl.Controls.Add(this.FName);
            this.c_pnl.Controls.Add(this.FNumber);
            this.c_pnl.Location = new System.Drawing.Point(0, 37);
            this.c_pnl.Size = new System.Drawing.Size(755, 308);
            // 
            // FDeptID
            // 
            this.FDeptID.BackColor = System.Drawing.Color.Transparent;
            this.FDeptID.Caption = "部门*：";
            this.FDeptID.Location = new System.Drawing.Point(19, 103);
            this.FDeptID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FDeptID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FDeptID.Name = "FDeptID";
            this.FDeptID.SelectService = null;
            this.FDeptID.Size = new System.Drawing.Size(182, 21);
            this.FDeptID.TabIndex = 12;
            this.FDeptID.Value = emptyItem1;
            // 
            // FNote
            // 
            this.FNote.BackColor = System.Drawing.Color.Transparent;
            this.FNote.Caption = "备注*：";
            this.FNote.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNote.Location = new System.Drawing.Point(19, 186);
            this.FNote.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNote.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNote.Name = "FNote";
            this.FNote.Size = new System.Drawing.Size(182, 21);
            this.FNote.TabIndex = 11;
            // 
            // FPhone
            // 
            this.FPhone.BackColor = System.Drawing.Color.Transparent;
            this.FPhone.Caption = "电话*：";
            this.FPhone.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FPhone.Location = new System.Drawing.Point(19, 142);
            this.FPhone.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FPhone.MinimumSize = new System.Drawing.Size(50, 21);
            this.FPhone.Name = "FPhone";
            this.FPhone.Size = new System.Drawing.Size(182, 21);
            this.FPhone.TabIndex = 10;
            // 
            // FName
            // 
            this.FName.BackColor = System.Drawing.Color.Transparent;
            this.FName.Caption = "名称*：";
            this.FName.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FName.Location = new System.Drawing.Point(19, 59);
            this.FName.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FName.MinimumSize = new System.Drawing.Size(50, 21);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(182, 21);
            this.FName.TabIndex = 9;
            // 
            // FNumber
            // 
            this.FNumber.BackColor = System.Drawing.Color.Transparent;
            this.FNumber.Caption = "编号*：";
            this.FNumber.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNumber.Location = new System.Drawing.Point(19, 19);
            this.FNumber.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNumber.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNumber.Name = "FNumber";
            this.FNumber.Size = new System.Drawing.Size(182, 21);
            this.FNumber.TabIndex = 5;
            // 
            // frmEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 376);
            this.Name = "frmEmp";
            this.Text = "frmEmp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEmp_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Unicre.WMS.Controls.SRItemEdit FParentID;
        private Wingdell.Control.WDTextEdit FName;
        private Wingdell.Control.WDTextEdit FNumber;
        private Wingdell.Control.WDTextEdit FNote;
        private Wingdell.Control.WDTextEdit FPhone;
        private Wingdell.Control.WDItemEdit FDeptID;
    }
}