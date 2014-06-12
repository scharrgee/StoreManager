namespace storeManager.UI.Controls
{
    partial class ucTransferStock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.dgvProductList = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnTransfer = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnAddByLoc = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddByLoc)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.Controls.Add(this.dgvProductList);
            this.radPanel1.Location = new System.Drawing.Point(0, 37);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(882, 450);
            this.radPanel1.TabIndex = 0;
            // 
            // dgvProductList
            // 
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(0, 0);
            // 
            // dgvProductList
            // 
            gridViewTextBoxColumn1.HeaderText = "Product Description";
            gridViewTextBoxColumn1.Name = "colItem";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 350;
            gridViewComboBoxColumn1.HeaderText = "From Location";
            gridViewComboBoxColumn1.Name = "comFromlocation";
            gridViewComboBoxColumn1.Width = 200;
            gridViewComboBoxColumn2.HeaderText = "To Location";
            gridViewComboBoxColumn2.Name = "colTolocation";
            gridViewComboBoxColumn2.Width = 200;
            gridViewTextBoxColumn2.HeaderText = "Quantity";
            gridViewTextBoxColumn2.Name = "colQty";
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.HeaderText = "ProductID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colProductID";
            gridViewTextBoxColumn4.HeaderText = "LocationID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colLocationID";
            this.dgvProductList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewComboBoxColumn1,
            gridViewComboBoxColumn2,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.ShowGroupPanel = false;
            this.dgvProductList.Size = new System.Drawing.Size(882, 450);
            this.dgvProductList.TabIndex = 0;
            this.dgvProductList.Text = "radGridView1";
            this.dgvProductList.ThemeName = "Breeze";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-4, 529);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(49, 493);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(830, 83);
            this.txtRemarks.TabIndex = 8;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.Location = new System.Drawing.Point(654, 583);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(110, 24);
            this.btnTransfer.TabIndex = 7;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.ThemeName = "Breeze";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(770, 583);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeName = "Breeze";
            // 
            // btnAddByLoc
            // 
            this.btnAddByLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddByLoc.Location = new System.Drawing.Point(769, 7);
            this.btnAddByLoc.Name = "btnAddByLoc";
            this.btnAddByLoc.Size = new System.Drawing.Size(110, 24);
            this.btnAddByLoc.TabIndex = 10;
            this.btnAddByLoc.Text = "Add By Location";
            this.btnAddByLoc.ThemeName = "Breeze";
            this.btnAddByLoc.Click += new System.EventHandler(this.btnAddByLoc_Click);
            // 
            // ucTransferStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.btnAddByLoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radPanel1);
            this.Name = "ucTransferStock";
            this.Size = new System.Drawing.Size(882, 623);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddByLoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private Telerik.WinControls.UI.RadButton btnTransfer;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnAddByLoc;
        private Telerik.WinControls.UI.RadGridView dgvProductList;
    }
}
