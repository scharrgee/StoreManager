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
    public partial class ucProductPricing : UserControl
    {
        List<Product> products;

        public ucProductPricing()
        {
            InitializeComponent();
            Hub.ProductListAdded += new EventHandler<ProductListAddedEventArgs>(Hub_ProductListAdded);
        }

        void Hub_ProductListAdded(object sender, ProductListAddedEventArgs e)
        {
            products = new List<Product>();

            e.AddedRows.ToList().ForEach(p => products.Add(new ProductService().GetSingle(x => x.ProductID == p.ProductID.ToInt())));
            AddProductsToGrid(products);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmSelectProduct selProduct = new frmSelectProduct();
            selProduct.ShowDialog();
        }

        void AddProductsToGrid(List<Product> products)
        {
            foreach (Product item in products)
            {
                dgvProducts.Rows.Add(item.ProductName, item.UnitPrice, item.PurchasePrice, 0.0, item.ProductID);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            IProductService service;

            try
            {
                for (int i = 0; i < dgvProducts.Rows.Count; i++)
                {
                    service = new ProductService();

                    decimal newCost = dgvProducts.Rows[i].Cells["colNewPrice"].Value.ToDecimal();
                    int productID = dgvProducts.Rows[i].Cells["colProductID"].Value.ToInt();

                    Product prod = products.Where(p => p.ProductID == productID).FirstOrDefault();
                    prod.UnitPrice = newCost;
                    prod.ProductID = productID;

                    service.Update(prod, p => p.ProductID == prod.ProductID);
                }

                Helper.ShowMessage("Operation completed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvProducts.Rows.Clear();
            }
            catch (Exception ex)
            {

                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
