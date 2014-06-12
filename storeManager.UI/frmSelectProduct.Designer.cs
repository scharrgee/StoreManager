namespace storeManager.UI
{
    partial class frmSelectProduct
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSelect = new Telerik.WinControls.UI.RadButton();
            this.btnAddOne = new Telerik.WinControls.UI.RadButton();
            this.btnRemoveOne = new Telerik.WinControls.UI.RadButton();
            this.btnRemoveAll = new Telerik.WinControls.UI.RadButton();
            this.btnAddAll = new Telerik.WinControls.UI.RadButton();
            this.dgvSelectedProd = new Telerik.WinControls.UI.RadGridView();
            this.dgvProductList = new Telerik.WinControls.UI.RadGridView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProd.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnCancel);
            this.radGroupBox1.Controls.Add(this.btnSelect);
            this.radGroupBox1.Controls.Add(this.btnAddOne);
            this.radGroupBox1.Controls.Add(this.btnRemoveOne);
            this.radGroupBox1.Controls.Add(this.btnRemoveAll);
            this.radGroupBox1.Controls.Add(this.btnAddAll);
            this.radGroupBox1.Controls.Add(this.dgvSelectedProd);
            this.radGroupBox1.Controls.Add(this.dgvProductList);
            this.radGroupBox1.HeaderText = "Product Selection";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(742, 344);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Product Selection";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(542, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Close";
            this.btnCancel.ThemeName = "Breeze";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(426, 313);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 24);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "Select";
            this.btnSelect.ThemeName = "Breeze";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnAddOne
            // 
            this.btnAddOne.Location = new System.Drawing.Point(332, 147);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(77, 24);
            this.btnAddOne.TabIndex = 11;
            this.btnAddOne.Text = ">";
            this.btnAddOne.ThemeName = "Breeze";
            this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.Location = new System.Drawing.Point(332, 177);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(77, 24);
            this.btnRemoveOne.TabIndex = 10;
            this.btnRemoveOne.Text = "<";
            this.btnRemoveOne.ThemeName = "Breeze";
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(332, 207);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(77, 24);
            this.btnRemoveAll.TabIndex = 9;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.ThemeName = "Breeze";
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(332, 117);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(77, 24);
            this.btnAddAll.TabIndex = 8;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.ThemeName = "Breeze";
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // dgvSelectedProd
            // 
            this.dgvSelectedProd.Location = new System.Drawing.Point(426, 37);
            // 
            // dgvSelectedProd
            // 
            this.dgvSelectedProd.MasterTemplate.AllowAddNewRow = false;
            this.dgvSelectedProd.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.HeaderText = "Product Name";
            gridViewTextBoxColumn1.Name = "colName";
            gridViewTextBoxColumn1.Width = 200;
            gridViewTextBoxColumn2.HeaderText = "Category";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.HeaderText = "ProductID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colProductID";
            gridViewTextBoxColumn4.HeaderText = "CategoryID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colCategoryID";
            this.dgvSelectedProd.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgvSelectedProd.MasterTemplate.EnableGrouping = false;
            this.dgvSelectedProd.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgvSelectedProd.Name = "dgvSelectedProd";
            this.dgvSelectedProd.ReadOnly = true;
            this.dgvSelectedProd.Size = new System.Drawing.Size(311, 268);
            this.dgvSelectedProd.TabIndex = 7;
            this.dgvSelectedProd.Text = "radGridView2";
            this.dgvSelectedProd.ThemeName = "Breeze";
            // 
            // dgvProductList
            // 
            this.dgvProductList.Location = new System.Drawing.Point(5, 37);
            // 
            // dgvProductList
            // 
            this.dgvProductList.MasterTemplate.AllowAddNewRow = false;
            this.dgvProductList.MasterTemplate.AllowColumnReorder = false;
            this.dgvProductList.MasterTemplate.EnableGrouping = false;
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.ReadOnly = true;
            this.dgvProductList.Size = new System.Drawing.Size(311, 268);
            this.dgvProductList.TabIndex = 6;
            this.dgvProductList.Text = "radGridView1";
            this.dgvProductList.ThemeName = "Breeze";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(561, 455);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 24);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.ThemeName = "Breeze";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(98, 458);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(230, 21);
            this.cmbCategory.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Category";
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(98, 430);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(230, 20);
            this.txtProdName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(13, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search";
            // 
            // txtProdCode
            // 
            this.txtProdCode.Location = new System.Drawing.Point(98, 404);
            this.txtProdCode.Name = "txtProdCode";
            this.txtProdCode.Size = new System.Drawing.Size(230, 20);
            this.txtProdCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Product Code";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(434, 401);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(230, 21);
            this.cmbLocation.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Location";
            // 
            // frmSelectProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 527);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProdCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radGroupBox1);
            this.MaximizeBox = false;
            this.Name = "frmSelectProduct";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Product";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.frmSelectProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProd.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnAddOne;
        private Telerik.WinControls.UI.RadButton btnRemoveOne;
        private Telerik.WinControls.UI.RadButton btnRemoveAll;
        private Telerik.WinControls.UI.RadButton btnAddAll;
        private Telerik.WinControls.UI.RadGridView dgvSelectedProd;
        private Telerik.WinControls.UI.RadGridView dgvProductList;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSelect;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label5;

    }
}
