namespace storeManager.UI.Controls
{
    partial class ucTransferStocks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChooseProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colFromLocation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColToLocation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnTransfer = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnAddByLoc = new Telerik.WinControls.UI.RadButton();
            this.btnAddRow = new Telerik.WinControls.UI.RadButton();
            this.btnRemoveRow = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddByLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveRow)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.Controls.Add(this.dgvProductList);
            this.radPanel1.Location = new System.Drawing.Point(0, 37);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(882, 429);
            this.radPanel1.TabIndex = 0;
            // 
            // dgvProductList
            // 
            this.dgvProductList.AllowUserToAddRows = false;
            this.dgvProductList.AllowUserToDeleteRows = false;
            this.dgvProductList.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.btnChooseProduct,
            this.colFromLocation,
            this.ColToLocation,
            this.ColQuantity,
            this.colCurrQty,
            this.colRemainingQuantity,
            this.colProductID,
            this.colLocationID});
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(0, 0);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowHeadersWidth = 20;
            this.dgvProductList.Size = new System.Drawing.Size(882, 429);
            this.dgvProductList.TabIndex = 0;
            this.dgvProductList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellContentClick);
            this.dgvProductList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellEndEdit);
            this.dgvProductList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProductList_RowsAdded);
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Product";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 300;
            // 
            // btnChooseProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChooseProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnChooseProduct.HeaderText = "";
            this.btnChooseProduct.Name = "btnChooseProduct";
            this.btnChooseProduct.Text = "Select";
            this.btnChooseProduct.Width = 20;
            // 
            // colFromLocation
            // 
            this.colFromLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colFromLocation.HeaderText = "From Location";
            this.colFromLocation.Name = "colFromLocation";
            this.colFromLocation.Width = 200;
            // 
            // ColToLocation
            // 
            this.ColToLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColToLocation.HeaderText = "To Location";
            this.ColToLocation.Name = "ColToLocation";
            this.ColToLocation.Width = 200;
            // 
            // ColQuantity
            // 
            this.ColQuantity.HeaderText = "Tranfer Quantity";
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.Width = 150;
            // 
            // colCurrQty
            // 
            this.colCurrQty.HeaderText = "Current Quantity";
            this.colCurrQty.Name = "colCurrQty";
            this.colCurrQty.ReadOnly = true;
            this.colCurrQty.Width = 150;
            // 
            // colRemainingQuantity
            // 
            this.colRemainingQuantity.HeaderText = "Remaining Quantity";
            this.colRemainingQuantity.Name = "colRemainingQuantity";
            this.colRemainingQuantity.ReadOnly = true;
            this.colRemainingQuantity.Width = 150;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // colLocationID
            // 
            this.colLocationID.HeaderText = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.ReadOnly = true;
            this.colLocationID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 550);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(51, 514);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(828, 83);
            this.txtRemarks.TabIndex = 8;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.Location = new System.Drawing.Point(654, 603);
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
            this.btnCancel.Location = new System.Drawing.Point(770, 603);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeName = "Breeze";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(3, 472);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(42, 24);
            this.btnAddRow.TabIndex = 8;
            this.btnAddRow.Text = "+";
            this.btnAddRow.ThemeName = "Breeze";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(49, 472);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(42, 24);
            this.btnRemoveRow.TabIndex = 9;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.ThemeName = "Breeze";
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // ucTransferStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.btnRemoveRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnAddByLoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radPanel1);
            this.Name = "ucTransferStocks";
            this.Size = new System.Drawing.Size(882, 643);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddByLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveRow)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewButtonColumn btnChooseProduct;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFromLocation;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColToLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemainingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationID;
        private Telerik.WinControls.UI.RadButton btnAddRow;
        private Telerik.WinControls.UI.RadButton btnRemoveRow;
    }
}
