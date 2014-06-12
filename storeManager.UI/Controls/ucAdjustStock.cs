using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;

namespace storeManager.UI.Controls
{
    public partial class ucAdjustStock : UserControl
    {
        List<Product> products;
        IErrorService _logger;

        private const string DEFAULT_SALESPERSON = "Default Sales Person";
        private const int DEFAULT_SALESPERSONID = 99999;

        public ucAdjustStock()
        {
            InitializeComponent();
            Hub.ProductListAdded += new EventHandler<ProductListAddedEventArgs>(Hub_ProductListAdded);
            _logger = new ErrorLogService();
        }

        void Hub_ProductListAdded(object sender, ProductListAddedEventArgs e)
        {
            products = new List<Product>();

            e.AddedRows.ToList().ForEach(p => products.Add(new ProductService().GetSingle(x => x.ProductID == p.ProductID.ToInt())));
            AddProductsToGrid(products);
        }

        void AddProductsToGrid(List<Product> products)
        {
            try
            {
                IProductLocationService service = new ProductLocationService();
                Product product;
                Location location = new Location();
                //ProductLocation prodLoc;

                foreach (Product item in products)
                {
                    IEnumerable<ProductLocation> locations = service.Query(p => p.ProductID == item.ProductID);

                    if (locations.Count() > 1)
                    {
                        foreach (var itm in locations)
                        {
                            product = new Product();
                            product = new ProductService().GetSingle(p => p.ProductID == itm.ProductID);
                            location = new GenericService<Location>().GetSingle(l => l.Id == itm.LocationID);

                            dgvProducts1.Rows.Add(product.ProductName, location.Name, itm.Quantity, 0, 0, product.ProductID, location.Id, itm.Id);
                        }

                        continue;
                    }

                    int locationID = locations.First().LocationID;
                    string locationName = new GenericService<Location>().GetSingle(l => l.Id == locationID).Name;
                    string quantity = locations.First().Quantity.ToString();

                    dgvProducts1.Rows.Add(item.ProductName, locationName, quantity, 0, 0, item.ProductID, locationID, locations.First().Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucAdjustStock", "AddProductsToGrid");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmSelectProduct selProduct = new frmSelectProduct();
            selProduct.ShowDialog();
        }

        private void dgvProducts_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name != "colNewQty") return;

                for (int i = 0; i < dgvProducts1.Rows.Count; i++)
                {
                    dgvProducts1.Rows[i].Cells["colDifference"].Value = (dgvProducts1.Rows[i].Cells["colNewQty"].Value.ToInt() -
                        dgvProducts1.Rows[i].Cells["colCurrentQty"].Value.ToInt());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucAdjustStock", "dgvProducts");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            if (dgvProducts1.Rows.Count == 0) return;

            IProductLocationService locService = new ProductLocationService();
            IProductAdjustmentService adjustServcie = new ProductAdjustmentService();
            ProductLocation productLocation;
            ProductAdjustment productAdjustment;

            try
            {
                for (int i = 0; i < dgvProducts1.Rows.Count; i++)
                {
                    productAdjustment = new ProductAdjustment();
                    productLocation = new ProductLocation();

                    int prodLocID = dgvProducts1.Rows[i].Cells["colProdLocID"].Value.ToInt();
                    int newqty = dgvProducts1.Rows[i].Cells["colNewQty"].Value.ToInt();
                    int productID = dgvProducts1.Rows[i].Cells["colProductID"].Value.ToInt();
                    int locationID = dgvProducts1.Rows[i].Cells["colLocationID"].Value.ToInt();
                    int currqty = dgvProducts1.Rows[i].Cells["colCurrentQty"].Value.ToInt();
                    int diff = dgvProducts1.Rows[i].Cells["colDifference"].Value.ToInt();

                    diff = diff < 0 ? diff * -1 : diff;

                    productLocation = locService.GetSingle(l => l.Id == prodLocID);
                    productLocation.Quantity = newqty;

                    locService.Update(productLocation, p => p.Id == productLocation.Id);

                    adjustServcie.Add(new ProductAdjustment
                    {
                        ProductLocationID = prodLocID,
                        NewQty = newqty,
                        ProductID = productID,
                        LocationID = locationID,
                        CurrentQty = currqty,
                        Difference = diff,
                        Remarks = txtRemarks.Text,
                        AdjustmentDate = DateTime.Now,
                        EmployeeID = CurrentUser.User.EmployeeID
                    });
                }

                Helper.ShowMessage("Operation completed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvProducts1.Rows.Clear();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucAdjustStock", "btnAdjustStock");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
