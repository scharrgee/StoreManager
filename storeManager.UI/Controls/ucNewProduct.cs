using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using storeManager.UI.Controls;
using storeManager.UI.EventHub;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;


namespace storeManager.UI.Controls
{
    public partial class ucNewProduct : UserControl
    {
        //private IBrandService _brand;
        //private ICategoryService _category;
        private ISupplierService _supplier;
        private IProductService _pruduct;
        private IProductLocationService _prodLoc;
        IErrorService _logger;

        private const int DEFAULT_BRANDID = 9999;
        private const int DEFAULT_CATEGORYID = 9999;
        private const int DEFAULT_SUPPLIERID = 9999;

        private const string DEFAULT_SUPPLIERNAME = "DEFAULT SUPPLIER";
        private const string DEFAULT_CATEGORYNAME = "DEFAULT CATEGORY";
        private const string DEFAULT_BRANDNAME = "DEFAULT BRAND";

        List<string> _locations = new List<string>();
        int _counter = 0;

        string _state = "";


        public enum ProductState
        {
            New = 1, Dirty = 2
        }

        IEnumerable<Location> location = new GenericService<Location>().GetAll();

        public ucNewProduct()
        {
            InitializeComponent();
            InitEvents();

            PopulateCombo();
            LoadMeasurementCmb();

            _pruduct = new ProductService();
            _prodLoc = new ProductLocationService();
            _supplier = new SupplierService();
            _logger = new ErrorLogService();

            lblRemoveimg.Visible = false;

            SetUpDefaults();
        }

        private void SetUpDefaults()
        {
            txtSupplier.Text = DEFAULT_SUPPLIERNAME;
            txtBrand.Text = DEFAULT_BRANDNAME;
            txtCategory.Text = DEFAULT_CATEGORYNAME;

            cmbMeasurement.SelectedIndex = 0;
        }

        private ProductState _productState = ProductState.New;

        public ProductState GetProductState
        {
            get { return _productState; }
            set { _productState = value; }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            new frmChooseSupplier(true).ShowDialog();
        }

        void InitEvents()
        {
            Hub.GenericInfo += new EventHandler<EventHubAgs>(Hub_GenericInfo);
            Hub.UpdateProduct += new EventHandler<ProductUpdateEventArgs>(Hub_UpdateProduct);
        }

        void Hub_UpdateProduct(object sender, ProductUpdateEventArgs e)
        {
            try
            {
                Product product = _pruduct.GetSingle(p => p.ProductID == e.ProductID);

                txtSupplier.Tag = product.SupplierID;
                txtSupplier.Text = _supplier.GetSingle(s => s.SupplierID == product.SupplierID).Name;

                txtCategory.Tag = product.CategoryID;
                txtCategory.Text = new GenericService<Category>().GetSingle(c => c.CategoryID == product.CategoryID).Name;

                txtBrand.Tag = product.BrandID;
                txtBrand.Text = new GenericService<Brand>().GetSingle(b => b.BrandID == product.BrandID).BrandName;

                txtItemName.Text = product.ProductName;
                txtItemName.Tag = product.ProductID;

                txtBarCode.Text = product.Barcode;
                txtCommission.Text = product.Commission.ToString();
                txtPurchasePrice.Text = product.PurchasePrice.ToString();
                txtSalePrice.Text = product.SellingPrice.ToString();
                txtReOrderLevel.Text = product.ReorderLevel.ToString();
                txtDiscount.Text = product.Discount.ToString();
                //txtProfitMargin.Text=product.

                dtpManufactureDate.Value = product.ManufactureDate.HasValue ? product.ManufactureDate.Value : DateTime.Now;
                dtpExpiryDate.Value = product.ExpiryDate.HasValue ? product.ExpiryDate.Value : DateTime.Now;

                txtDescription.Text = product.Description;

                chkOnSale.Checked = product.OnSale.HasValue ? product.OnSale.Value : false;

                pictureBoxProduct.Image = product.ProductImage != null ? Helper.ByteArrayToImage(product.ProductImage) : null;
                lblProductPicture.Visible = product.ProductImage == null;
                lblRemoveimg.Visible = product.ProductImage != null;

                cmbMeasurement.SelectedValue = product.MeasurementID;

                //LoadProductLocation(product.ProductID);

                ConfigureForm("Update");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, OperationStatus.FAILURE, "ucNewProduct", "Hub_UpdateProduct");
                Helper.ShowMessage(OperationStatus.FAILURE + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void LoadProductLocation(int productID)
        {
            List<ProductLocation> products = _prodLoc.Queryable(l => l.ProductID == productID).ToList();

            for (int i = 0; i < products.Count() - 1; i++)
            {
                DataGridViewComboBoxColumn ComboColumn = new DataGridViewComboBoxColumn();

                ComboColumn.DataSource = location;
                ComboColumn.DisplayMember = "Name";
                ComboColumn.ValueMember = "ID";
                ComboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;


                //ComboColumn.Value = products[i].LocationID;
                //FillCombo(i);

                int qty = (int)products[i].Quantity;
                dgvLocation.Rows[i].Cells[1].Value = qty;
                //dgvLocation.Rows[i].Cells[0] = ComboColumn;
                //dgvLocation.Columns.Add(ComboColumn);
                //ComboColumn.Value = products[i].LocationID;
                //dgvLocation.Rows.Add(ComboColumn, qty);
            }
        }

        void Hub_GenericInfo(object sender, EventHubAgs e)
        {
            TextBox txt = this.Controls.Find(e.ControlName, true).FirstOrDefault() as TextBox;

            if (txt == null) return;

            txt.Text = e.Data.ToString();
            txt.Tag = e.ID;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            new frmChooseCategory().ShowDialog();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            new frmChooseBrand().Show();
        }

        private void btnDesc_Click(object sender, EventArgs e)
        {
            new frmDescription("txtDescription", txtDescription.Text).ShowDialog();
        }

        private void btnCalculateSellingPrice_Click(object sender, EventArgs e)
        {
            if (!txtPurchasePrice.ValidateTexBox("Purchase price cannot be blank")) return;

            new frmSellingPriceCalculate(decimal.Parse(txtPurchasePrice.Text)).ShowDialog();
        }

        private void lblProductPicture_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "jpeg(*.jpeg)|*.jpeg|jpg(*.jpg)|*.jpg|gif(*.gif)|*.gif| png(*.png)|*.png|bmp(*.bmp)|*.bmp";
            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.JPEG)|*.BMP;*.JPG;*.GIF;*.JPEG";
            dlg.CheckFileExists = true;
            dlg.InitialDirectory = Application.StartupPath;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduct.Image = Image.FromFile(dlg.FileName);
                lblProductPicture.Visible = false;
                lblRemoveimg.Visible = true;
            }
        }

        private void lblRemoveimg_Click(object sender, EventArgs e)
        {
            ResetPicture();
        }

        private void ResetPicture()
        {
            pictureBoxProduct.Image = null;
            lblProductPicture.Visible = true;
            lblRemoveimg.Visible = false;
        }

        private void PopulateCombo()
        {
            FillCombo(0);
        }

        private void dgvLocation_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            FillCombo(e.RowIndex);
            ResetParameters();
        }

        private void FillCombo(int idx)
        {
            DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)(dgvLocation.Rows[idx].Cells[0]);

            ComboColumn.DataSource = location;
            ComboColumn.DisplayMember = "Name";
            ComboColumn.ValueMember = "ID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_counter >= 1)
            {
                MessageBox.Show("cannot have more than one of the same location selected");
                return;
            }

            if (GetProductState == ProductState.New)
            {
                if (dgvLocation.Rows[0].Cells[0].Value == null || lblQty.Text == "")
                {
                    Helper.ShowMessage("Select product location or enter the quanty of the product at the selected location",
                        "Error in location or product quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (cmbMeasurement.SelectedIndex == -1)
            {
                Helper.ShowMessage("Please select product measurement",
                       "Select Product Measurement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!Helper.ValidateTexBox(txtSupplier))
                return;
            if (!Helper.ValidateTexBox(txtCategory))
                return;
            if (!Helper.ValidateTexBox(txtItemName))
                return;
            //if (!UtilityClass.ValidateTexBox(txtPurchasePrice))
            //    return;
            if (!Helper.ValidateTexBox(txtSalePrice))
                return;
            //if (!UtilityClass.ValidateTexBox(txtSalePrice))
            //    return;

            Product product = new Product();

            product.SupplierID = txtSupplier.Tag == null ? DEFAULT_SUPPLIERID : txtSupplier.Tag.ToString().ToInt();
            product.CategoryID = txtCategory.Tag == null ? DEFAULT_CATEGORYID : int.Parse(txtCategory.Tag.ToString());
            product.ProductNum = txtItemNumber.Text;
            product.ProductName = txtItemName.Text;
            product.Barcode = txtBarCode.Text;
            product.Commission = txtCommission.Text == "" ? 0 : decimal.Parse(txtCommission.Text);
            product.PurchasePrice = txtPurchasePrice.Text == "" ? 0 : decimal.Parse(txtPurchasePrice.Text);
            product.SellingPrice = decimal.Parse(txtSalePrice.Text);
            product.ExpiryDate = DateTime.Parse(dtpExpiryDate.Value.ToLongDateString());
            product.ManufactureDate = DateTime.Parse(dtpManufactureDate.Value.ToLongDateString());
            product.OnSale = chkOnSale.Checked;
            product.ManufactureDate = dtpManufactureDate.Value;
            product.ExpiryDate = dtpExpiryDate.Value;
            product.ProductImage = pictureBoxProduct.Image == null ? null : Helper.ImageToByteArray(pictureBoxProduct.Image);
            product.Discount = txtDiscount.Text == "" ? 0 : decimal.Parse(txtDiscount.Text);
            product.ReorderLevel = txtReOrderLevel.Text == "" ? 0 : int.Parse(txtReOrderLevel.Text);
            product.BrandID = txtBrand.Tag == null ? DEFAULT_BRANDID : int.Parse(txtBrand.Tag.ToString());
            product.Description = txtDescription.Text;
            product.UnitPrice = decimal.Parse(txtSalePrice.Text);
            product.DateAdded = DateTime.Now;
            product.MeasurementID = cmbMeasurement.SelectedValue.ToInt();

            try
            {
                switch (GetProductState)
                {
                    case ProductState.New:
                        product = _pruduct.Add(product);
                        SaveLocationQuantity(product.ProductID);
                        Helper.ShowMessage("Product was added successfully", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case ProductState.Dirty:
                        product.ProductID = txtItemName.Tag.ToInt();
                        _pruduct.Update(product, p => p.ProductID == product.ProductID);
                        Helper.ShowMessage("Product was updated successfully", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ConfigureForm("Save");

                        break;
                }

                Helper.ClearForm(this);
                ResetPicture();
                SetUpDefaults();
                dgvLocation.Rows.Clear();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, OperationStatus.FAILURE, "ucNewProduct", "btnSave");
                Helper.ShowMessage(OperationStatus.FAILURE + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SaveLocationQuantity(int productID)
        {
            try
            {
                foreach (DataGridViewRow row in dgvLocation.Rows)
                {
                    if (row.IsNewRow) continue;

                    int locID = ((DataGridViewComboBoxCell)row.Cells[0]).Value.ToInt();
                    int qty = row.Cells[1].Value.ToInt();

                    _prodLoc.Add(new ProductLocation { LocationID = locID, ProductID = productID, Quantity = qty });
                }
            }
             catch (Exception ex)
            {
                _logger.LogError(ex, OperationStatus.FAILURE, "ucNewProduct", "SaveLocationQuantity");
                Helper.ShowMessage(OperationStatus.FAILURE + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {
            //if (!txtPurchasePrice.ValidateTexBox("Purchase price cannot be blank")) return;
            if (txtPurchasePrice.Text == "")
            {
                txtProfitMargin.Text = "0.0";
                return;
            }

            txtProfitMargin.Text = (txtSalePrice.Text.ToDecimal() - txtPurchasePrice.Text.ToDecimal()).ToString();
        }

        private void btnSave_TextChanged(object sender, EventArgs e)
        {
            switch (_state)
            {
                case "Save":
                    GetProductState = ProductState.New;
                    txtItemName.Tag = null;
                    txtProfitMargin.Text = "0.0";
                    chkOnSale.Checked = false;
                    EnableControls(true);
                    break;
                case "Update":
                    GetProductState = ProductState.Dirty;
                    EnableControls(false);
                    break;
            }
        }

        private void EnableControls(bool status)
        {
            dgvLocation.Visible = status;
            lblLocDetail.Visible = status;
            lblQty.Visible = status;
            lblQtyOnHand.Visible = status;
        }

        public void ConfigureForm(string state)
        {
            _state = state;
            btnSave.Text = state;
        }

        private int CalculateProductQuantity()
        {
            int total = 0;
            string location = "";

            try
            {
                foreach (DataGridViewRow row in dgvLocation.Rows)
                {
                    if (row.Cells[1].Value == null) return total;

                    total += row.Cells[1].Value.ToInt();
                    location = (row.Cells[0] as DataGridViewCell).FormattedValue.ToString();

                    if (_locations.Contains(location))
                        _counter++;

                    _locations.Add(location);
                }

               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucNewProduct", "CalculateProductQuantity");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return total;
        }

        private void dgvLocation_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ResetParameters();
        }

        private void ResetParameters()
        {
            _counter = 0;
            _locations.Clear();

            lblQtyOnHand.Text = CalculateProductQuantity().ToString();
        }

        private void dgvLocation_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ResetParameters();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ConfigureForm("Save");

            Helper.ClearForm(this);
            ResetPicture();
            SetUpDefaults();
            dgvLocation.Rows.Clear();
        }

        void LoadMeasurementCmb()
        {
            cmbMeasurement.DataSource = new GenericService<Measurement>().GetAll();
            cmbMeasurement.DisplayMember = "Name";
            cmbMeasurement.ValueMember = "id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ((frmControlHost)this.Parent).Close();
            }
            catch
            {
                this.Visible = false;
                this.Dispose();
            }
           
        }
    }
}
