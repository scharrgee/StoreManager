namespace storeManager.UI.Controls
{
    partial class ucNewProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNewProduct));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pvNewPrduct = new Telerik.WinControls.UI.RadPageView();
            this.pvpBasic = new Telerik.WinControls.UI.RadPageViewPage();
            this.lblRemoveimg = new System.Windows.Forms.Label();
            this.btnDesc = new System.Windows.Forms.Button();
            this.lblQtyOnHand = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblLocDetail = new System.Windows.Forms.Label();
            this.dgvLocation = new System.Windows.Forms.DataGridView();
            this.colLocation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProfitMargin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProductPicture = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtCommission = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtReOrderLevel = new System.Windows.Forms.TextBox();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkOnSale = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrand = new System.Windows.Forms.Button();
            this.btnCalculateSellingPrice = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.btnCategory = new System.Windows.Forms.Button();
            this.pvpExtraInfo = new Telerik.WinControls.UI.RadPageViewPage();
            this.cmbMeasurement = new Telerik.WinControls.UI.RadDropDownList();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNew = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvNewPrduct)).BeginInit();
            this.pvNewPrduct.SuspendLayout();
            this.pvpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.pvpExtraInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMeasurement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.pvNewPrduct);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer1.Panel2.Controls.Add(this.btnNew);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(905, 590);
            this.splitContainer1.SplitterDistance = 539;
            this.splitContainer1.TabIndex = 0;
            // 
            // pvNewPrduct
            // 
            this.pvNewPrduct.Controls.Add(this.pvpBasic);
            this.pvNewPrduct.Controls.Add(this.pvpExtraInfo);
            this.pvNewPrduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvNewPrduct.Location = new System.Drawing.Point(0, 0);
            this.pvNewPrduct.Name = "pvNewPrduct";
            this.pvNewPrduct.SelectedPage = this.pvpBasic;
            this.pvNewPrduct.Size = new System.Drawing.Size(905, 539);
            this.pvNewPrduct.TabIndex = 1;
            this.pvNewPrduct.Text = "radPageView1";
            this.pvNewPrduct.ThemeName = "Breeze";
            // 
            // pvpBasic
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pvpBasic.Controls.Add(this.lblRemoveimg);
            this.pvpBasic.Controls.Add(this.btnDesc);
            this.pvpBasic.Controls.Add(this.lblQtyOnHand);
            this.pvpBasic.Controls.Add(this.lblQty);
            this.pvpBasic.Controls.Add(this.lblLocDetail);
            this.pvpBasic.Controls.Add(this.dgvLocation);
            this.pvpBasic.Controls.Add(this.txtBrand);
            this.pvpBasic.Controls.Add(this.label8);
            this.pvpBasic.Controls.Add(this.txtSupplier);
            this.pvpBasic.Controls.Add(this.label7);
            this.pvpBasic.Controls.Add(this.label6);
            this.pvpBasic.Controls.Add(this.txtProfitMargin);
            this.pvpBasic.Controls.Add(this.label5);
            this.pvpBasic.Controls.Add(this.dtpExpiryDate);
            this.pvpBasic.Controls.Add(this.label4);
            this.pvpBasic.Controls.Add(this.dtpManufactureDate);
            this.pvpBasic.Controls.Add(this.label3);
            this.pvpBasic.Controls.Add(this.lblProductPicture);
            this.pvpBasic.Controls.Add(this.lblDescription);
            this.pvpBasic.Controls.Add(this.txtDescription);
            this.pvpBasic.Controls.Add(this.txtCategory);
            this.pvpBasic.Controls.Add(this.label17);
            this.pvpBasic.Controls.Add(this.txtDiscount);
            this.pvpBasic.Controls.Add(this.txtCommission);
            this.pvpBasic.Controls.Add(this.label18);
            this.pvpBasic.Controls.Add(this.label15);
            this.pvpBasic.Controls.Add(this.txtReOrderLevel);
            this.pvpBasic.Controls.Add(this.txtSalePrice);
            this.pvpBasic.Controls.Add(this.label16);
            this.pvpBasic.Controls.Add(this.label13);
            this.pvpBasic.Controls.Add(this.txtPurchasePrice);
            this.pvpBasic.Controls.Add(this.txtBarCode);
            this.pvpBasic.Controls.Add(this.label14);
            this.pvpBasic.Controls.Add(this.label12);
            this.pvpBasic.Controls.Add(this.chkOnSale);
            this.pvpBasic.Controls.Add(this.label2);
            this.pvpBasic.Controls.Add(this.txtItemName);
            this.pvpBasic.Controls.Add(this.txtItemNumber);
            this.pvpBasic.Controls.Add(this.label1);
            this.pvpBasic.Controls.Add(this.btnBrand);
            this.pvpBasic.Controls.Add(this.btnCalculateSellingPrice);
            this.pvpBasic.Controls.Add(this.btnAddSupplier);
            this.pvpBasic.Controls.Add(this.pictureBoxProduct);
            this.pvpBasic.Controls.Add(this.btnCategory);
            this.pvpBasic.Location = new System.Drawing.Point(8, 33);
            this.pvpBasic.Name = "pvpBasic";
            this.pvpBasic.Size = new System.Drawing.Size(889, 498);
            this.pvpBasic.Text = "Basic";
            // 
            // lblRemoveimg
            // 
            this.lblRemoveimg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemoveimg.AutoSize = true;
            this.lblRemoveimg.BackColor = System.Drawing.Color.Transparent;
            this.lblRemoveimg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveimg.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoveimg.Location = new System.Drawing.Point(692, 21);
            this.lblRemoveimg.Name = "lblRemoveimg";
            this.lblRemoveimg.Size = new System.Drawing.Size(92, 14);
            this.lblRemoveimg.TabIndex = 93;
            this.lblRemoveimg.Text = "Remove Image";
            this.lblRemoveimg.Click += new System.EventHandler(this.lblRemoveimg_Click);
            // 
            // btnDesc
            // 
            this.btnDesc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDesc.BackgroundImage")));
            this.btnDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesc.FlatAppearance.BorderSize = 0;
            this.btnDesc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesc.Location = new System.Drawing.Point(544, 182);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(22, 20);
            this.btnDesc.TabIndex = 92;
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // lblQtyOnHand
            // 
            this.lblQtyOnHand.AutoSize = true;
            this.lblQtyOnHand.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyOnHand.Location = new System.Drawing.Point(315, 460);
            this.lblQtyOnHand.Name = "lblQtyOnHand";
            this.lblQtyOnHand.Size = new System.Drawing.Size(11, 14);
            this.lblQtyOnHand.TabIndex = 91;
            this.lblQtyOnHand.Text = "-";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Teal;
            this.lblQty.Location = new System.Drawing.Point(4, 464);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(116, 14);
            this.lblQty.TabIndex = 90;
            this.lblQty.Text = "Quantity On Hand";
            // 
            // lblLocDetail
            // 
            this.lblLocDetail.AutoSize = true;
            this.lblLocDetail.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocDetail.ForeColor = System.Drawing.Color.Teal;
            this.lblLocDetail.Location = new System.Drawing.Point(4, 280);
            this.lblLocDetail.Name = "lblLocDetail";
            this.lblLocDetail.Size = new System.Drawing.Size(98, 14);
            this.lblLocDetail.TabIndex = 89;
            this.lblLocDetail.Text = "Location Details";
            // 
            // dgvLocation
            // 
            this.dgvLocation.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocation,
            this.colQty});
            this.dgvLocation.Location = new System.Drawing.Point(7, 297);
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.RowHeadersWidth = 30;
            this.dgvLocation.Size = new System.Drawing.Size(334, 150);
            this.dgvLocation.TabIndex = 88;
            this.dgvLocation.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocation_CellEndEdit);
            this.dgvLocation.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvLocation_RowsAdded);
            this.dgvLocation.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLocation_RowsRemoved);
            // 
            // colLocation
            // 
            this.colLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLocation.Width = 200;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            // 
            // txtBrand
            // 
            this.txtBrand.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrand.Location = new System.Drawing.Point(98, 71);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(128, 20);
            this.txtBrand.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 85;
            this.label8.Text = "Brand :";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(98, 18);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(128, 20);
            this.txtSupplier.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 81;
            this.label7.Text = "Supplier :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(590, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 80;
            this.label6.Text = "Profit Margin :";
            // 
            // txtProfitMargin
            // 
            this.txtProfitMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfitMargin.Location = new System.Drawing.Point(691, 457);
            this.txtProfitMargin.Multiline = true;
            this.txtProfitMargin.Name = "txtProfitMargin";
            this.txtProfitMargin.ReadOnly = true;
            this.txtProfitMargin.Size = new System.Drawing.Size(194, 21);
            this.txtProfitMargin.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 78;
            this.label5.Text = "Expiry Date :";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(394, 137);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(101, 20);
            this.dtpExpiryDate.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 14);
            this.label4.TabIndex = 76;
            this.label4.Text = "Manufacture Date :";
            // 
            // dtpManufactureDate
            // 
            this.dtpManufactureDate.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpManufactureDate.Location = new System.Drawing.Point(394, 108);
            this.dtpManufactureDate.Name = "dtpManufactureDate";
            this.dtpManufactureDate.Size = new System.Drawing.Size(101, 20);
            this.dtpManufactureDate.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(622, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 74;
            this.label3.Text = "Picture :";
            // 
            // lblProductPicture
            // 
            this.lblProductPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductPicture.BackColor = System.Drawing.SystemColors.Control;
            this.lblProductPicture.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPicture.Location = new System.Drawing.Point(702, 71);
            this.lblProductPicture.Name = "lblProductPicture";
            this.lblProductPicture.Size = new System.Drawing.Size(163, 39);
            this.lblProductPicture.TabIndex = 73;
            this.lblProductPicture.Text = "DoubleClick This Area To Add A Picture";
            this.lblProductPicture.DoubleClick += new System.EventHandler(this.lblProductPicture_DoubleClick);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(301, 186);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 15);
            this.lblDescription.TabIndex = 72;
            this.lblDescription.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(394, 182);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(147, 20);
            this.txtDescription.TabIndex = 70;
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(98, 45);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(128, 20);
            this.txtCategory.TabIndex = 68;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(317, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 14);
            this.label17.TabIndex = 66;
            this.label17.Text = "Discount :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(394, 79);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(101, 20);
            this.txtDiscount.TabIndex = 65;
            // 
            // txtCommission
            // 
            this.txtCommission.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommission.Location = new System.Drawing.Point(104, 209);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Size = new System.Drawing.Size(139, 20);
            this.txtCommission.TabIndex = 64;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(19, 209);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 14);
            this.label18.TabIndex = 63;
            this.label18.Text = "Commission :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(285, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 14);
            this.label15.TabIndex = 62;
            this.label15.Text = "ReOrder Level :";
            // 
            // txtReOrderLevel
            // 
            this.txtReOrderLevel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReOrderLevel.Location = new System.Drawing.Point(394, 50);
            this.txtReOrderLevel.Name = "txtReOrderLevel";
            this.txtReOrderLevel.Size = new System.Drawing.Size(101, 20);
            this.txtReOrderLevel.TabIndex = 61;
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalePrice.Location = new System.Drawing.Point(394, 24);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(82, 20);
            this.txtSalePrice.TabIndex = 60;
            this.txtSalePrice.TextChanged += new System.EventHandler(this.txtSalePrice_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(311, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 59;
            this.label16.Text = "Sale Price :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 237);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 14);
            this.label13.TabIndex = 58;
            this.label13.Text = "Purchase Price :";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasePrice.Location = new System.Drawing.Point(104, 237);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(139, 20);
            this.txtPurchasePrice.TabIndex = 57;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCode.Location = new System.Drawing.Point(104, 181);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(139, 20);
            this.txtBarCode.TabIndex = 56;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(39, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 14);
            this.label14.TabIndex = 55;
            this.label14.Text = "Bar Code :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 52;
            this.label12.Text = "Category :";
            // 
            // chkOnSale
            // 
            this.chkOnSale.AutoSize = true;
            this.chkOnSale.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnSale.Location = new System.Drawing.Point(418, 225);
            this.chkOnSale.Name = "chkOnSale";
            this.chkOnSale.Size = new System.Drawing.Size(70, 18);
            this.chkOnSale.TabIndex = 51;
            this.chkOnSale.Text = "On Sale";
            this.chkOnSale.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 14);
            this.label2.TabIndex = 50;
            this.label2.Text = "Product Name :";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(98, 125);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(145, 20);
            this.txtItemName.TabIndex = 49;
            // 
            // txtItemNumber
            // 
            this.txtItemNumber.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNumber.Location = new System.Drawing.Point(98, 97);
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.Size = new System.Drawing.Size(145, 20);
            this.txtItemNumber.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 47;
            this.label1.Text = "Product Code :";
            // 
            // btnBrand
            // 
            this.btnBrand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrand.BackgroundImage")));
            this.btnBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrand.FlatAppearance.BorderSize = 0;
            this.btnBrand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrand.Location = new System.Drawing.Point(228, 71);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Size = new System.Drawing.Size(22, 20);
            this.btnBrand.TabIndex = 86;
            this.btnBrand.UseVisualStyleBackColor = true;
            this.btnBrand.Click += new System.EventHandler(this.btnBrand_Click);
            // 
            // btnCalculateSellingPrice
            // 
            this.btnCalculateSellingPrice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalculateSellingPrice.BackgroundImage")));
            this.btnCalculateSellingPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalculateSellingPrice.FlatAppearance.BorderSize = 0;
            this.btnCalculateSellingPrice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCalculateSellingPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculateSellingPrice.Location = new System.Drawing.Point(473, 24);
            this.btnCalculateSellingPrice.Name = "btnCalculateSellingPrice";
            this.btnCalculateSellingPrice.Size = new System.Drawing.Size(22, 20);
            this.btnCalculateSellingPrice.TabIndex = 84;
            this.btnCalculateSellingPrice.UseVisualStyleBackColor = true;
            this.btnCalculateSellingPrice.Click += new System.EventHandler(this.btnCalculateSellingPrice_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddSupplier.BackgroundImage")));
            this.btnAddSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddSupplier.FlatAppearance.BorderSize = 0;
            this.btnAddSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSupplier.Location = new System.Drawing.Point(228, 18);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(22, 20);
            this.btnAddSupplier.TabIndex = 82;
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxProduct.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxProduct.Location = new System.Drawing.Point(687, 15);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(194, 143);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 69;
            this.pictureBoxProduct.TabStop = false;
            this.pictureBoxProduct.DoubleClick += new System.EventHandler(this.lblProductPicture_DoubleClick);
            // 
            // btnCategory
            // 
            this.btnCategory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCategory.BackgroundImage")));
            this.btnCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Location = new System.Drawing.Point(228, 46);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(22, 20);
            this.btnCategory.TabIndex = 67;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // pvpExtraInfo
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pvpExtraInfo.Controls.Add(this.cmbMeasurement);
            this.pvpExtraInfo.Controls.Add(this.label9);
            this.pvpExtraInfo.Location = new System.Drawing.Point(8, 33);
            this.pvpExtraInfo.Name = "pvpExtraInfo";
            this.pvpExtraInfo.Size = new System.Drawing.Size(889, 498);
            this.pvpExtraInfo.Text = "Extra Info";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbMeasurement.Location = new System.Drawing.Point(97, 36);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(194, 18);
            this.cmbMeasurement.TabIndex = 1;
            this.cmbMeasurement.ThemeName = "Breeze";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Measurement";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(8, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 37);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.ThemeName = "Breeze";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(679, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "Breeze";
            this.btnSave.TextChanged += new System.EventHandler(this.btnSave_TextChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(795, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 37);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Close";
            this.btnCancel.ThemeName = "Breeze";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucNewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucNewProduct";
            this.Size = new System.Drawing.Size(905, 590);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvNewPrduct)).EndInit();
            this.pvNewPrduct.ResumeLayout(false);
            this.pvpBasic.ResumeLayout(false);
            this.pvpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.pvpExtraInfo.ResumeLayout(false);
            this.pvpExtraInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMeasurement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadPageView pvNewPrduct;
        private Telerik.WinControls.UI.RadPageViewPage pvpBasic;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Button btnBrand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCalculateSellingPrice;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProfitMargin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpManufactureDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProductPicture;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtCommission;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtReOrderLevel;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkOnSale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadPageViewPage pvpExtraInfo;
        private System.Windows.Forms.DataGridView dgvLocation;
        private System.Windows.Forms.Label lblLocDetail;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblQtyOnHand;
        private Telerik.WinControls.UI.RadButton btnNew;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.Button btnDesc;
        private System.Windows.Forms.Label lblRemoveimg;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private Telerik.WinControls.UI.RadDropDownList cmbMeasurement;
        private System.Windows.Forms.Label label9;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;

    }
}
