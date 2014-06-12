using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using storeManager.UI.EventHub;

namespace storeManager.UI
{
    public partial class frmSelectProduct : Telerik.WinControls.UI.RadForm
    {
        public frmSelectProduct()
        {
            InitializeComponent();
            LoadCategoryCmb();
            LoadLocationCmb();
        }

        List<AddedRowViewModel> addedrows = new List<AddedRowViewModel>();

        private void frmSelectProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvProductList.DataSource = new StoredProcedureGatewayService()
                .GetProductList(txtProdName.Text, txtProdCode.Text, cmbCategory.SelectedValue.ToInt(),cmbLocation.SelectedValue.ToInt());

            ConfigureGrid();
        }

        void LoadCategoryCmb()
        {
            cmbCategory.DataSource = new CategoryService().GetAll();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DetermineSelectedIndex();
        }

        void LoadLocationCmb()
        {
            cmbLocation.DataSource = new GenericService<Location>().GetAll();
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "id";
            cmbLocation.DetermineSelectedIndex();
        }

        void ConfigureGrid()
        {
            dgvProductList.Columns["ProductID"].IsVisible = false;
            dgvProductList.Columns["CategoryID"].IsVisible = false;

            dgvProductList.Columns["ProductName"].HeaderText = "Product Name";
            dgvProductList.Columns["CategoryName"].HeaderText = "Category Name";

            dgvProductList.Columns["ProductName"].Width = 200;
            dgvProductList.Columns["CategoryName"].Width = 120;

        }

        private void btnAddOne_Click(object sender, EventArgs e)
        {
            if (dgvProductList.SelectedRows.Count == 0)
                return;

            AddProductsToGrid(0, true);
        }

        private void AddProductsToGrid(int idx, bool useSel)
        {
            string productID = GetCellData(dgvProductList, "ProductID", idx, useSel);
            string categoryID = GetCellData(dgvProductList, "CategoryID", idx, useSel);
            string productName = GetCellData(dgvProductList, "ProductName", idx, useSel);
            string categoryName = GetCellData(dgvProductList, "CategoryName", idx, useSel);

            if (addedrows.Count(c => c.ProductID == productID && c.CategoryID == categoryID) > 0)
                return;

            AddRow(productID, categoryID);

            dgvSelectedProd.Rows.Add(productName, categoryName,
               productID, categoryID);
        }

        void AddRow(string productID, string categoryID)
        {
            if (addedrows.Count(c => c.ProductID == productID && c.CategoryID == categoryID) == 0)
            {
                addedrows.Add(new AddedRowViewModel { CategoryID = categoryID, ProductID = productID });
            }
        }

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            if (dgvSelectedProd.SelectedRows.Count == 0)
                return;

            string productID = GetCellData(dgvSelectedProd, "colProductID", 0, true);
            string categoryID = GetCellData(dgvSelectedProd, "colCategoryID", 0, true);

            dgvSelectedProd.Rows.RemoveAt(dgvSelectedProd.SelectedRows[0].Index);

            addedrows.RemoveAll(p => p.CategoryID == categoryID && p.ProductID == productID);
        }

        string GetCellData(RadGridView grid, string cell, int idx, bool useSel)
        {
            if (useSel)
                return grid.SelectedRows[idx].Cells[cell].Value.ToString();
            else
                return grid.Rows[idx].Cells[cell].Value.ToString();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (dgvSelectedProd.SelectedRows.Count == 0)
                return;

            dgvSelectedProd.Rows.Clear();
            addedrows.Clear();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvProductList.Rows.Count; i++)
            {
                AddProductsToGrid(i, false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Hub.OnProductListAdded(addedrows);

            this.Close();
        }
    }
}
