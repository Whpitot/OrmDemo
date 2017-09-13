namespace Services
{
    partial class frmICItem
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
            WMSModel.EmptyItem emptyItem5 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem4 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem3 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem2 = new WMSModel.EmptyItem();
            WMSModel.EmptyItem emptyItem1 = new WMSModel.EmptyItem();
            this.FNumber = new Wingdell.Control.WDTextEdit();
            this.FName = new Wingdell.Control.WDTextEdit();
            this.FSupplierID = new Wingdell.Control.WDItemEdit();
            this.FLevelID = new Wingdell.Control.WDItemEdit();
            this.FPrice = new Wingdell.Control.WDTextEdit();
            this.FNote = new Wingdell.Control.WDTextEdit();
            this.FUnitID = new Wingdell.Control.WDItemEdit();
            this.FDimensionID = new Wingdell.Control.WDItemEdit();
            this.FOpenWayID = new Wingdell.Control.WDItemEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).BeginInit();
            this.c_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnl
            // 
            this.c_pnl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_pnl.Appearance.Options.UseBackColor = true;
            this.c_pnl.Controls.Add(this.FOpenWayID);
            this.c_pnl.Controls.Add(this.FDimensionID);
            this.c_pnl.Controls.Add(this.FNote);
            this.c_pnl.Controls.Add(this.FPrice);
            this.c_pnl.Controls.Add(this.FUnitID);
            this.c_pnl.Controls.Add(this.FLevelID);
            this.c_pnl.Controls.Add(this.FSupplierID);
            this.c_pnl.Controls.Add(this.FName);
            this.c_pnl.Controls.Add(this.FNumber);
            // 
            // FNumber
            // 
            this.FNumber.BackColor = System.Drawing.Color.Transparent;
            this.FNumber.Caption = "编   号*：";
            this.FNumber.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNumber.Location = new System.Drawing.Point(27, 18);
            this.FNumber.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNumber.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNumber.Name = "FNumber";
            this.FNumber.Size = new System.Drawing.Size(183, 21);
            this.FNumber.TabIndex = 0;
            // 
            // FName
            // 
            this.FName.BackColor = System.Drawing.Color.Transparent;
            this.FName.Caption = "名   称*：";
            this.FName.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FName.Location = new System.Drawing.Point(27, 62);
            this.FName.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FName.MinimumSize = new System.Drawing.Size(50, 21);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(183, 21);
            this.FName.TabIndex = 1;
            // 
            // FSupplierID
            // 
            this.FSupplierID.BackColor = System.Drawing.Color.Transparent;
            this.FSupplierID.Caption = "供应商*：";
            this.FSupplierID.Location = new System.Drawing.Point(302, 18);
            this.FSupplierID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FSupplierID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FSupplierID.Name = "FSupplierID";
            this.FSupplierID.SelectService = null;
            this.FSupplierID.Size = new System.Drawing.Size(199, 21);
            this.FSupplierID.TabIndex = 3;
            this.FSupplierID.Value = emptyItem5;
            // 
            // FLevelID
            // 
            this.FLevelID.BackColor = System.Drawing.Color.Transparent;
            this.FLevelID.Caption = "等   级*：";
            this.FLevelID.Location = new System.Drawing.Point(302, 62);
            this.FLevelID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FLevelID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FLevelID.Name = "FLevelID";
            this.FLevelID.SelectService = null;
            this.FLevelID.Size = new System.Drawing.Size(199, 21);
            this.FLevelID.TabIndex = 4;
            this.FLevelID.Value = emptyItem4;
            // 
            // FPrice
            // 
            this.FPrice.BackColor = System.Drawing.Color.Transparent;
            this.FPrice.Caption = "价   格*：";
            this.FPrice.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FPrice.Location = new System.Drawing.Point(27, 201);
            this.FPrice.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FPrice.MinimumSize = new System.Drawing.Size(50, 21);
            this.FPrice.Name = "FPrice";
            this.FPrice.Size = new System.Drawing.Size(183, 21);
            this.FPrice.TabIndex = 6;
            // 
            // FNote
            // 
            this.FNote.BackColor = System.Drawing.Color.Transparent;
            this.FNote.Caption = "备   注*：";
            this.FNote.EditFormat = Wingdell.Control.EditFormat.Normal;
            this.FNote.Location = new System.Drawing.Point(302, 155);
            this.FNote.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FNote.MinimumSize = new System.Drawing.Size(50, 21);
            this.FNote.Name = "FNote";
            this.FNote.Size = new System.Drawing.Size(199, 21);
            this.FNote.TabIndex = 7;
            // 
            // FUnitID
            // 
            this.FUnitID.BackColor = System.Drawing.Color.Transparent;
            this.FUnitID.Caption = "单   位*：";
            this.FUnitID.Location = new System.Drawing.Point(302, 107);
            this.FUnitID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FUnitID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FUnitID.Name = "FUnitID";
            this.FUnitID.SelectService = null;
            this.FUnitID.Size = new System.Drawing.Size(199, 21);
            this.FUnitID.TabIndex = 5;
            this.FUnitID.Value = emptyItem3;
            // 
            // FDimensionID
            // 
            this.FDimensionID.BackColor = System.Drawing.Color.Transparent;
            this.FDimensionID.Caption = "尺   寸*：";
            this.FDimensionID.Location = new System.Drawing.Point(27, 107);
            this.FDimensionID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FDimensionID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FDimensionID.Name = "FDimensionID";
            this.FDimensionID.SelectService = null;
            this.FDimensionID.Size = new System.Drawing.Size(183, 21);
            this.FDimensionID.TabIndex = 8;
            this.FDimensionID.Value = emptyItem2;
            // 
            // FOpenWayID
            // 
            this.FOpenWayID.BackColor = System.Drawing.Color.Transparent;
            this.FOpenWayID.Caption = "方   向*：";
            this.FOpenWayID.Location = new System.Drawing.Point(27, 155);
            this.FOpenWayID.MaximumSize = new System.Drawing.Size(1000, 21);
            this.FOpenWayID.MinimumSize = new System.Drawing.Size(50, 21);
            this.FOpenWayID.Name = "FOpenWayID";
            this.FOpenWayID.SelectService = null;
            this.FOpenWayID.Size = new System.Drawing.Size(183, 21);
            this.FOpenWayID.TabIndex = 9;
            this.FOpenWayID.Value = emptyItem1;
            // 
            // frmICItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 361);
            this.Name = "frmICItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmICItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmICItem_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnl)).EndInit();
            this.c_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wingdell.Control.WDTextEdit FNote;
        private Wingdell.Control.WDTextEdit FPrice;
        private Wingdell.Control.WDItemEdit FLevelID;
        private Wingdell.Control.WDItemEdit FSupplierID;
        private Wingdell.Control.WDTextEdit FName;
        private Wingdell.Control.WDTextEdit FNumber;
        private Wingdell.Control.WDItemEdit FUnitID;
        private Wingdell.Control.WDItemEdit FOpenWayID;
        private Wingdell.Control.WDItemEdit FDimensionID;

    }
}