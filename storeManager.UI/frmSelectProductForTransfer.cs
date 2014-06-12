using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using storeManager.UI;
using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;

namespace storeManager.UI
{
    public partial class frmSelectProductForTransfer : Telerik.WinControls.UI.RadForm
    {
        public frmSelectProductForTransfer()
        {
            InitializeComponent();

            LoadLocationCmb();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProductList.DataSource = new StoredProcedureGatewayService()
                .GetProductsAtLocation(cmbLocation.SelectedValue.ToInt(), 0, txtProduct.Text);

            dgvProductList.Columns["ProductName"].HeaderText = "Product Name";
            dgvProductList.Columns["ProductName"].Width = 300;

            dgvProductList.Columns["Quantity"].Width = 100;

            dgvProductList.Columns["LocationID"].IsVisible = false;
            dgvProductList.Columns["ProductID"].IsVisible = false;

            
        }

        void LoadLocationCmb()
        {
            IEnumerable<Location> location = new GenericService<Location>().GetAll();
            cmbLocation.DataSource = location;
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvProductList.SelectedRows.Count == 0) return;

            List<int> locationid = new List<int>();

            locationid.Add(dgvProductList.SelectedRows[0].Cells["LocationID"].Value.ToInt());
            int productid = dgvProductList.SelectedRows[0].Cells["ProductID"].Value.ToInt();

            Hub.OnProductTransfer(locationid, productid);

            this.Close();
        }
    }
}
