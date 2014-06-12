using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.ViewModel;
using Telerik.WinControls.UI;

namespace storeManager.UI.Controls
{
    public partial class ucProductList : UserControl
    {
        int productID = 0;

        public ucProductList()
        {
            InitializeComponent();
            LoadCategoryCmb();

            ctxProduct.Items[0].Click += new EventHandler(ucProductList_New_Click);
            ctxProduct.Items[2].Click += new EventHandler(ucProductList_Delete_Click);
            ctxProduct.Items[1].Click += new EventHandler(ucProductList_Update_Click);
        }

        void ucProductList_New_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void ucProductList_Delete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void ucProductList_Update_Click(object sender, EventArgs e)
        {
            frmMain frmMain = Helper.CreateInstanceFor<frmMain>("frmMain");
            frmMain.PrepareFormForProductUpdate();

            EventHub.Hub.OnProductUpdate(productID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = new StoredProcedureGatewayService().GetProducts(txtProdName.Text, txtProdCode.Text, cmbCategory.SelectedValue.ToInt());

            //AddGridViewRow(new StoredProcedureGatewayService().GetProducts(txtProdName.Text, txtProdCode.Text, cmbCategory.SelectedValue.ToInt()));

            ConfigureGrid();

            SetStatus(dgvProducts.Rows.Count);
        }

        private void SetStatus(int count)
        {
            lblStatus.Text = "Number of products currently showing : " + count;
        }

        void LoadCategoryCmb()
        {
            cmbCategory.DataSource = new CategoryService().GetAll();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DetermineSelectedIndex();
        }

        void ConfigureGrid()
        {
            dgvProducts.Columns["ProductID"].IsVisible = false;
            dgvProducts.Columns["SupplierID"].IsVisible = false;
            dgvProducts.Columns["CategoryID"].IsVisible = false;

            dgvProducts.Columns["ProductName"].HeaderText = "Product Description";
            dgvProducts.Columns["UnitPrice"].HeaderText = "Unit Price";
            dgvProducts.Columns["SupplierName"].HeaderText = "Supplier";
            dgvProducts.Columns["CategoryName"].HeaderText = "Category";
            dgvProducts.Columns["DaysBeforeExpiry"].HeaderText = "Days Before Expiry";

            dgvProducts.Columns["ProductName"].Width = 400;
            dgvProducts.Columns["UnitPrice"].Width = 150;
            dgvProducts.Columns["SupplierName"].Width = 400;
            dgvProducts.Columns["CategoryName"].Width = 150;
            dgvProducts.Columns["DaysBeforeExpiry"].Width = 150;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = null;
            txtProdCode.Text = "";
            txtProdName.Text = "";
            //cmbCategory.SelectedIndex = -1;

            SetStatus(0);
        }

        private void dgvProducts_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
            GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;

            productID = cell.RowInfo.Cells["ProductID"].Value.ToInt();
        }

        private void ctxProduct_DropDownOpening(object sender, CancelEventArgs e)
        {
            if (dgvProducts.Rows.Count == 0)
            {
                //ctxProduct.Items[0].Enabled = false;
                ctxProduct.Items[1].Enabled = false;
                ctxProduct.Items[2].Enabled = false;
                return;
            }

            ctxProduct.Items[1].Enabled = true;
            ctxProduct.Items[2].Enabled = true;
        }

        private void dgvProducts_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

        }

        void AddGridViewRow(IEnumerable<ProductSearchViewModel> products)
        {
            foreach (var item in products)
            {
                object[] rows = new object[9];
                rows[0] = item.DaysBeforeExpiry < 0 ? Properties.Resources.red : Properties.Resources.green;
                rows[1] = item.ProductID;
                rows[2] = item.SupplierID;
                rows[3] = item.CategoryID;
                rows[4] = item.ProductName;
                rows[5] = item.UnitPrice;
                rows[6] = item.SupplierName;
                rows[7] = item.CategoryName;
                rows[8] = item.DaysBeforeExpiry;

                dgvProducts.Rows.Add(rows);
            }
        }
    }
}
