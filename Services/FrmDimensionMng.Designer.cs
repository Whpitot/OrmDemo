namespace Services
{
    partial class FrmDimensionMng
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
            this.txtFName = new Wingdell.Control.WDTextEdit();
            this.txtFNumber = new Wingdell.Control.WDTextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Controls.Add(this.txtFName);
            this.c_pnl.Controls.Add(this.txtFNumber);
            this.c_pnl.Controls.Add(this.simpleButton1);
            this.c_pnl.Size = new System.Drawing.Size(690, 49);
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
            this.gridControl1.Location = new System.Drawing.Point(0, 80);
            this.gridControl1.Size = new System.Drawing.Size(690, 363);
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.Transparent;
            this.txtFName.Caption = "名称*：";
            this.txtFName.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.txtFName.Location = new System.Drawing.Point(232, 18);
            this.txtFName.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFName.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(169, 21);
            this.txtFName.TabIndex = 7;
            // 
            // txtFNumber
            // 
            this.txtFNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtFNumber.Caption = "编码*：";
            this.txtFNumber.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.txtFNumber.Location = new System.Drawing.Point(30, 16);
            this.txtFNumber.MaximumSize = new System.Drawing.Size(1000, 21);
            this.txtFNumber.MinimumSize = new System.Drawing.Size(50, 21);
            this.txtFNumber.Name = "txtFNumber";
            this.txtFNumber.Size = new System.Drawing.Size(169, 21);
            this.txtFNumber.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(451, 18);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(61, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "查询";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmDimensionMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 468);
            this.Name = "FrmDimensionMng";
            this.Text = "尺寸管理";
            this.Load += new System.EventHandler(this.FrmDimensionMng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wingdell.Control.WDTextEdit txtFName;
        private Wingdell.Control.WDTextEdit txtFNumber;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}