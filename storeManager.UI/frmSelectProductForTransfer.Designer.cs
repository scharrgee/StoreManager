namespace storeManager.UI
{
    partial class frmSelectProductForTransfer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvProductList = new Telerik.WinControls.UI.RadGridView();
            this.btnSelect = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLocation = new Telerik.WinControls.UI.RadDropDownList();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvProductList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.radGroupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSelect);
            this.splitContainer1.Size = new System.Drawing.Size(446, 522);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvProductList
            // 
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(0, 0);
            // 
            // dgvProductList
            // 
            this.dgvProductList.MasterTemplate.AllowAddNewRow = false;
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.ReadOnly = true;
            this.dgvProductList.Size = new System.Drawing.Size(446, 352);
            this.dgvProductList.TabIndex = 0;
            this.dgvProductList.Text = "radGridView1";
            this.dgvProductList.ThemeName = "Breeze";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(232, 130);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(98, 24);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.ThemeName = "Breeze";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(336, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeName = "Breeze";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnSearch);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.cmbLocation);
            this.radGroupBox1.Controls.Add(this.txtProduct);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(440, 83);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.ThemeName = "Breeze";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbLocation.Location = new System.Drawing.Point(254, 8);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(177, 20);
            this.cmbLocation.TabIndex = 8;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(55, 8);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(136, 20);
            this.txtProduct.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Product";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(324, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 24);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.ThemeName = "Breeze";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmSelectProductForTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 522);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "frmSelectProductForTransfer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Product For Transfer";
            this.ThemeName = "Breeze";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadGridView dgvProductList;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSelect;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownList cmbLocation;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label1;
    }
}
