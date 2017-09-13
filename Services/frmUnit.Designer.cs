namespace Services
{
    partial class frmUnit
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
            this.c_pnl.Controls.Add(this.FName);
            this.c_pnl.Controls.Add(this.FNumber);
            this.c_pnl.Size = new System.Drawing.Size(343, 283);
            // 
            // FName
            // 
            this.FName.BackColor = System.Drawing.Color.Transparent;
            this.FName.Caption = "名称*：";
            this.FName.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FName.Location = new System.Drawing.Point(41, 129);
            this.FName.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FName.MinimumSize = new System.Drawing.Size(50, 21);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(183, 21);
            this.FName.TabIndex = 15;
            // 
            // FNumber
            // 
            this.FNumber.BackColor = System.Drawing.Color.Transparent;
            this.FNumber.Caption = "编码*：";
            this.FNumber.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNumber.Location = new System.Drawing.Point(41, 67);
            this.FNumber.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNumber.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNumber.Name = "FNumber";
            this.FNumber.Size = new System.Drawing.Size(183, 21);
            this.FNumber.TabIndex = 14;
            // 
            // frmUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 335);
            this.Name = "frmUnit";
            this.Text = "frmUnit";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wingdell.Control.WDTextEdit FName;
        private Wingdell.Control.WDTextEdit FNumber;
    }
}