using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BusinessLayer;
using storeManager.Entities;

using storeManager.UI.Controls;

namespace storeManager.UI
{
    public partial class frmChooseItem : Form
    {
        IEnumerable<Product> products;

        delegate IEnumerable<Product> LoadProductsAsync();

        public frmChooseItem()
        {
            InitializeComponent();
            //LoadListView();
        }

        public frmChooseItem(string item)
        {
            InitializeComponent();
            LoadListView();

            txtLookForProduct.Text = item;
        }

        public void SetText(string value)
        {
            txtLookForProduct.Text = value;
        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count == 0) return;

            EventHub.Hub.OnGenericInfoCall(lvItems.SelectedItems[0].SubItems[0].Text,
                lvItems.SelectedItems[0].SubItems[1].Text + "," + lvItems.SelectedItems[0].SubItems[2].Text + "," + lvItems.SelectedItems[0].SubItems[3].Text, "txtItemName");

            this.Hide();
        }

        private void txtLookForProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtLookForProduct.Text == "") return;

            Helper.WaitCursor(this);

            LoadProductsAsync loadProducts = new LoadProductsAsync(LoadProducts);

            loadProducts.BeginInvoke((res) =>
            {
                LoadProductsAsync loadProductsres = res.AsyncState as LoadProductsAsync;
                IEnumerable<Product> foundproducts = loadProductsres.EndInvoke(res);

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        lvItems.PopulateListView(foundproducts);

                        Helper.DefaultCursor(this);
                    }));
                }

            }, loadProducts);
        }

        private IEnumerable<Product> LoadProducts()
        {
            IEnumerable<Product> foundproducts = new ProductService().Query(p => p.ProductName.ToLower().Contains(txtLookForProduct.Text.ToLower()));
            return foundproducts;
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.ucNewProduct)) return;

            frmControlHost host = new frmControlHost();
            ucNewProduct product = new ucNewProduct();
            this.TopMost = false;
            this.Close();

            product.Dock = DockStyle.Fill;

            host.Controls.Add(product);

            host.ShowDialog();
        }

        private void LoadListView()
        {
            Helper.WaitCursor(this);
            products = new ProductService().GetAll();

            lvItems.PopulateListView(products);
            Helper.DefaultCursor(this);
        }

        public void PositionForm(int top, int left)
        {
            this.Top = top + 200;
            this.Left = left + 200;
            this.TopMost = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChooseItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();
        }
    }
}
