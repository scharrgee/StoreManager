namespace storeManager.UI.Controls
{
    partial class ucCurrentStock
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvProducts = new Telerik.WinControls.UI.RadGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ctxProduct = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.mnNewProduct = new Telerik.WinControls.UI.RadMenuItem();
            this.mnUpdate = new Telerik.WinControls.UI.RadMenuItem();
            this.mnDeativate = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(862, 654);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 0;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.cmbLocation);
            this.radPanel1.Controls.Add(this.label5);
            this.radPanel1.Controls.Add(this.btnSearch);
            this.radPanel1.Controls.Add(this.btnRefresh);
            this.radPanel1.Controls.Add(this.cmbCategory);
            this.radPanel1.Controls.Add(this.label4);
            this.radPanel1.Controls.Add(this.txtProdName);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Controls.Add(this.label2);
            this.radPanel1.Controls.Add(this.txtProdCode);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(862, 182);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.ThemeName = "Breeze";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(641, 132);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.ThemeName = "Breeze";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(750, 132);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 24);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.ThemeName = "Breeze";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(111, 102);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(514, 21);
            this.cmbCategory.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Category";
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(111, 74);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(742, 20);
            this.txtProdName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(26, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search";
            // 
            // txtProdCode
            // 
            this.txtProdCode.Location = new System.Drawing.Point(111, 48);
            this.txtProdCode.Name = "txtProdCode";
            this.txtProdCode.Size = new System.Drawing.Size(742, 20);
            this.txtProdCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Code";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvProducts);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer2.Panel2.Controls.Add(this.lblStatus);
            this.splitContainer2.Size = new System.Drawing.Size(862, 468);
            this.splitContainer2.SplitterDistance = 430;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvProducts
            // 
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            // 
            // dgvProducts
            // 
            this.dgvProducts.MasterTemplate.AllowAddNewRow = false;
            this.dgvProducts.Name = "dgvProducts";
            this.radContextMenuManager1.SetRadContextMenu(this.dgvProducts, this.ctxProduct);
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.Size = new System.Drawing.Size(862, 430);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.Text = "radGridView1";
            this.dgvProducts.ThemeName = "Breeze";
            this.dgvProducts.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            this.dgvProducts.ContextMenuOpening += new Telerik.WinControls.UI.ContextMenuOpeningEventHandler(this.dgvProducts_ContextMenuOpening);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(8, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(11, 14);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "-";
            // 
            // ctxProduct
            // 
            this.ctxProduct.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnNewProduct,
            this.mnUpdate,
            this.mnDeativate});
            this.ctxProduct.DropDownOpening += new System.ComponentModel.CancelEventHandler(this.ctxProduct_DropDownOpening);
            // 
            // mnNewProduct
            // 
            this.mnNewProduct.AccessibleDescription = "New Product";
            this.mnNewProduct.AccessibleName = "New Product";
            this.mnNewProduct.Name = "mnNewProduct";
            this.mnNewProduct.Text = "New Product";
            this.mnNewProduct.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mnUpdate
            // 
            this.mnUpdate.AccessibleDescription = "Update Product";
            this.mnUpdate.AccessibleName = "Update Product";
            this.mnUpdate.Name = "mnUpdate";
            this.mnUpdate.Text = "Update Product";
            this.mnUpdate.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mnDeativate
            // 
            this.mnDeativate.AccessibleDescription = "Deactivate Product";
            this.mnDeativate.AccessibleName = "Deactivate Product";
            this.mnDeativate.Name = "mnDeativate";
            this.mnDeativate.Text = "Deactivate Product";
            this.mnDeativate.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(111, 135);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(514, 21);
            this.cmbLocation.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Location";
            // 
            // ucCurrentStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucCurrentStock";
            this.Size = new System.Drawing.Size(862, 654);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Telerik.WinControls.UI.RadGridView dgvProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblStatus;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadContextMenu ctxProduct;
        private Telerik.WinControls.UI.RadMenuItem mnNewProduct;
        private Telerik.WinControls.UI.RadMenuItem mnUpdate;
        private Telerik.WinControls.UI.RadMenuItem mnDeativate;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label5;

    }
}
