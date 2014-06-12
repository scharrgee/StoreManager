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
using Telerik.WinControls.UI;

namespace storeManager.UI.Controls
{
    public partial class ucCurrentStock : UserControl
    {
        int productID = 0;

        public ucCurrentStock()
        {
            InitializeComponent();
            LoadCategoryCmb();
            LoadLocationCmb();

            ctxProduct.Items[0].Click += new EventHandler(ucProductList_New_Click);
            ctxProduct.Items[2].Click += new EventHandler(ucProductList_Delete_Click);
            ctxProduct.Items[1].Click += new EventHandler(ucProductList_Update_Click);
        }

        void ucProductList_New_Click(object sender, EventArgs e)
        {
            frmMain main = Helper.CreateInstanceFor<frmMain>("frmMain");
            main.ShowNewProductWindow();
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
            dgvProducts.DataSource = new StoredProcedureGatewayService()
                .GetCurrentStock(txtProdName.Text, txtProdCode.Text, cmbCategory.SelectedValue.ToInt(),cmbLocation.SelectedValue.ToInt());

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

        void LoadLocationCmb()
        {
            IEnumerable<Location> location = new GenericService<Location>().GetAll();
            cmbLocation.DataSource = location;
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "id";
        }

        void ConfigureGrid()
        {
            dgvProducts.Columns["ProductID"].IsVisible = false;
            dgvProducts.Columns["LocationID"].IsVisible = false;
            dgvProducts.Columns["CategoryID"].IsVisible = false;

            dgvProducts.Columns["ProductName"].HeaderText = "Product Description";
            dgvProducts.Columns["Quantity"].HeaderText = "Quantity";
            dgvProducts.Columns["Location"].HeaderText = "Location";
            dgvProducts.Columns["CategoryName"].HeaderText = "Category";

            dgvProducts.Columns["ProductName"].Width = 400;
            dgvProducts.Columns["Quantity"].Width = 200;
            dgvProducts.Columns["Location"].Width = 300;
            dgvProducts.Columns["CategoryName"].Width = 300;

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
    }
}
