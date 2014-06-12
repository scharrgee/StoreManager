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
using storeManager.ViewModel;
using Telerik.WinControls.UI;

namespace storeManager.UI.Controls
{
    public partial class ucTransferStock : UserControl
    {
        List<ViewModel.TransferStockViewModel> transferStock = new List<ViewModel.TransferStockViewModel>();
        IEnumerable<Location> locations;

        public ucTransferStock()
        {
            InitializeComponent();

            locations = new GenericService<Location>().GetAll();
            EventHub.Hub.TransferStaock += new EventHandler<EventHub.TransferStockEventArgs>(Hub_TransferStaock);

        }

        void Hub_TransferStaock(object sender, EventHub.TransferStockEventArgs e)
        {
            e.LocationID.ToList().ForEach(l => transferStock.AddRange(new StoredProcedureGatewayService().GetProductsAtLocation(l, e.ProductID, "")));
            AddProductsToGrid(transferStock);
        }

        private void AddProductsToGrid(List<TransferStockViewModel> transferStocks)
        {
            AddLocation();

            foreach (TransferStockViewModel stock in transferStocks)
            {
                //GridViewComboBoxColumn toLocation = AddLocation();
                dgvProductList.Rows.Add(stock.ProductName);
            }
        }

        private void AddLocation()
        {
            //dgvProductList.MasterTemplate.AutoGenerateColumns = false;
            GridViewComboBoxColumn toLocation = new GridViewComboBoxColumn();
            toLocation.DataSource = locations;
            toLocation.ValueMember = "id";
            toLocation.DisplayMember = "Name";
            toLocation.FieldName = "comFromlocation";
            toLocation.Width = 200;
            this.dgvProductList.Columns.Add(toLocation);
            //return toLocation;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

        }

        private void btnAddByLoc_Click(object sender, EventArgs e)
        {
            new frmLocations().ShowDialog();
        }
    }
}
