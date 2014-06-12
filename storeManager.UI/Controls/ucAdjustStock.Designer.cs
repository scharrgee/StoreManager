namespace storeManager.UI.Controls
{
    partial class ucAdjustStock
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn25 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn26 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn27 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn28 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn29 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn30 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn31 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn32 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProducts1 = new Telerik.WinControls.UI.RadGridView();
            this.btnAddProduct = new Telerik.WinControls.UI.RadButton();
            this.btnAdjust = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProducts = new Telerik.WinControls.UI.MasterGridViewTemplate();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.Controls.Add(this.groupBox1);
            this.radPanel1.Controls.Add(this.btnAddProduct);
            this.radPanel1.Location = new System.Drawing.Point(0, 3);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(888, 400);
            this.radPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvProducts1);
            this.groupBox1.Location = new System.Drawing.Point(3, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 340);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dgvProducts1
            // 
            this.dgvProducts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts1.Location = new System.Drawing.Point(3, 18);
            // 
            // dgvProducts1
            // 
            this.dgvProducts1.MasterTemplate.AllowAddNewRow = false;
            this.dgvProducts1.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn17.HeaderText = "ProductName";
            gridViewTextBoxColumn17.Name = "colItem";
            gridViewTextBoxColumn17.ReadOnly = true;
            gridViewTextBoxColumn17.Width = 400;
            gridViewTextBoxColumn18.HeaderText = "Location";
            gridViewTextBoxColumn18.Name = "colLocation";
            gridViewTextBoxColumn18.ReadOnly = true;
            gridViewTextBoxColumn18.Width = 300;
            gridViewTextBoxColumn19.HeaderText = "Current Quantity";
            gridViewTextBoxColumn19.Name = "colCurrentQty";
            gridViewTextBoxColumn19.ReadOnly = true;
            gridViewTextBoxColumn19.Width = 150;
            gridViewTextBoxColumn20.HeaderText = "New Quantity";
            gridViewTextBoxColumn20.Name = "colNewQty";
            gridViewTextBoxColumn20.Width = 100;
            gridViewTextBoxColumn21.HeaderText = "Difference";
            gridViewTextBoxColumn21.Name = "colDifference";
            gridViewTextBoxColumn21.ReadOnly = true;
            gridViewTextBoxColumn21.Width = 100;
            gridViewTextBoxColumn22.HeaderText = "ProductID";
            gridViewTextBoxColumn22.IsVisible = false;
            gridViewTextBoxColumn22.Name = "colProductID";
            gridViewTextBoxColumn23.HeaderText = "LocationID";
            gridViewTextBoxColumn23.IsVisible = false;
            gridViewTextBoxColumn23.Name = "colLocationID";
            gridViewTextBoxColumn24.HeaderText = "ProdLocID";
            gridViewTextBoxColumn24.IsVisible = false;
            gridViewTextBoxColumn24.Name = "colProdLocID";
            this.dgvProducts1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24});
            this.dgvProducts1.Name = "dgvProducts1";
            this.dgvProducts1.ShowGroupPanel = false;
            this.dgvProducts1.Size = new System.Drawing.Size(871, 319);
            this.dgvProducts1.TabIndex = 6;
            this.dgvProducts1.Text = "radGridView1";
            this.dgvProducts1.ThemeName = "Breeze";
            this.dgvProducts1.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvProducts_CellValueChanged);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProduct.Location = new System.Drawing.Point(724, 10);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(156, 24);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "Add Products";
            this.btnAddProduct.ThemeName = "Breeze";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAdjust
            // 
            this.btnAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdjust.Location = new System.Drawing.Point(659, 518);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(110, 24);
            this.btnAdjust.TabIndex = 3;
            this.btnAdjust.Text = "Adjust";
            this.btnAdjust.ThemeName = "Breeze";
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(775, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            this.btnCancel.ThemeName = "Breeze";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(52, 409);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(833, 83);
            this.txtRemarks.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Remarks";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowAddNewRow = false;
            this.dgvProducts.AllowColumnReorder = false;
            gridViewTextBoxColumn25.HeaderText = "ProductName";
            gridViewTextBoxColumn25.Name = "colItem";
            gridViewTextBoxColumn25.ReadOnly = true;
            gridViewTextBoxColumn25.Width = 450;
            gridViewTextBoxColumn26.HeaderText = "Location";
            gridViewTextBoxColumn26.Name = "colLocation";
            gridViewTextBoxColumn26.ReadOnly = true;
            gridViewTextBoxColumn26.Width = 350;
            gridViewTextBoxColumn27.HeaderText = "Current Quantity";
            gridViewTextBoxColumn27.Name = "colCurrentQty";
            gridViewTextBoxColumn27.ReadOnly = true;
            gridViewTextBoxColumn27.Width = 120;
            gridViewTextBoxColumn28.HeaderText = "New Quantity";
            gridViewTextBoxColumn28.Name = "colNewQty";
            gridViewTextBoxColumn28.Width = 100;
            gridViewTextBoxColumn29.HeaderText = "Difference";
            gridViewTextBoxColumn29.Name = "colDifference";
            gridViewTextBoxColumn29.ReadOnly = true;
            gridViewTextBoxColumn29.Width = 100;
            gridViewTextBoxColumn30.HeaderText = "ProductID";
            gridViewTextBoxColumn30.IsVisible = false;
            gridViewTextBoxColumn30.Name = "colProductID";
            gridViewTextBoxColumn31.HeaderText = "LocationID";
            gridViewTextBoxColumn31.IsVisible = false;
            gridViewTextBoxColumn31.Name = "colLocationID";
            gridViewTextBoxColumn32.HeaderText = "ProdLocID";
            gridViewTextBoxColumn32.IsVisible = false;
            gridViewTextBoxColumn32.Name = "colProdLocID";
            this.dgvProducts.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn25,
            gridViewTextBoxColumn26,
            gridViewTextBoxColumn27,
            gridViewTextBoxColumn28,
            gridViewTextBoxColumn29,
            gridViewTextBoxColumn30,
            gridViewTextBoxColumn31,
            gridViewTextBoxColumn32});
            // 
            // ucAdjustStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnAdjust);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radPanel1);
            this.Name = "ucAdjustStock";
            this.Size = new System.Drawing.Size(888, 551);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnAdjust;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnAddProduct;
        private Telerik.WinControls.UI.MasterGridViewTemplate dgvProducts;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView dgvProducts1;
    }
}
