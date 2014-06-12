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
    public partial class ucTransferStocks : UserControl
    {
        List<TransferStockViewModel> transferStock = new List<TransferStockViewModel>();
        IEnumerable<Location> locations;
        List<TransferStockViewModel> selectedProducts = new List<TransferStockViewModel>();
        IProductService _productService;
        IErrorService _logger;

        bool UpdateRow = false;
        int _rowindex = 0;

        public ucTransferStocks()
        {
            InitializeComponent();

            locations = new GenericService<Location>().GetAll();
            _productService = new ProductService();
            _logger = new ErrorLogService();

            PopulateCombo();

            EventHub.Hub.TransferStaock += new EventHandler<EventHub.TransferStockEventArgs>(Hub_TransferStaock);
        }


        void Hub_TransferStaock(object sender, EventHub.TransferStockEventArgs e)
        {
            UpdateRow = e.ProductID > 0;

            e.LocationID.ToList().ForEach(l => transferStock.AddRange(new StoredProcedureGatewayService().GetProductsAtLocation(l, e.ProductID, "")));
            AddProductsToGrid(transferStock);
        }

        private void AddProductsToGrid(List<TransferStockViewModel> transferStocks)
        {
            int counter = 0;

            if (UpdateRow)
            {
                AddRecordToGrid(_rowindex, transferStocks.First());
                transferStocks.Clear();
                return;
            }

            foreach (TransferStockViewModel stock in transferStocks)
            {
                AddRecordToGrid(counter, stock);
            }

            transferStocks.Clear();
        }

        private void AddRecordToGrid(int counter, TransferStockViewModel stock)
        {
            if (selectedProducts.Contains(stock, new TranferStockComparer())) return;

            if (!UpdateRow)
                counter = dgvProductList.Rows.Count > 0 ? dgvProductList.Rows.Add(stock.ProductName) : dgvProductList.Rows.Add();

            dgvProductList.Rows[counter].Cells["colProductName"].Value = stock.ProductName;
            dgvProductList.Rows[counter].Cells["colQuantity"].Value = stock.Quantity;
            dgvProductList.Rows[counter].Cells["colCurrQty"].Value = stock.Quantity;
            dgvProductList.Rows[counter].Cells["colProductID"].Value = stock.ProductID;
            dgvProductList.Rows[counter].Cells["colLocationID"].Value = stock.LocationID;

            DataGridViewComboBoxCell combocell = (DataGridViewComboBoxCell)dgvProductList.Rows[counter].Cells[2];
            combocell.Value = stock.LocationID;
            combocell.ReadOnly = true;

            DataGridViewButtonCell buttoncell = (DataGridViewButtonCell)dgvProductList.Rows[counter].Cells[1];
            buttoncell.Value = "...";

            selectedProducts.Add(stock);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (dgvProductList.Rows.Count == 0)
                return;

            try
            {
                foreach (DataGridViewRow row in dgvProductList.Rows)
                {
                    string fromLoc = row.Cells["colFromLocation"] == null ? string.Empty : row.Cells["colFromLocation"].Value.ToString();
                    string toLoc = row.Cells["colToLocation"].Value == null ? string.Empty : row.Cells["colToLocation"].Value.ToString();


                    if (fromLoc == toLoc)
                    {
                        row.DefaultCellStyle.BackColor = Color.Tomato;
                        Helper.ShowMessage("Stock cannot be tranfered to the same location",
                            "Illegal Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                    if (string.IsNullOrEmpty(fromLoc) || string.IsNullOrEmpty(toLoc))
                    {
                        row.DefaultCellStyle.BackColor = Color.Tomato;
                        Helper.ShowMessage("Verify and set all locations involved in the current tranfer",
                           "Illegal Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                    if (row.Cells["colProductID"].Value == null)
                    {
                        row.DefaultCellStyle.BackColor = Color.Tomato;
                        Helper.ShowMessage("Make sure a valid product is selected",
                           "Illegal Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                    int oldqty = row.Cells["colCurrQty"].Value == null ? 0 : row.Cells["colCurrQty"].Value.ToInt();
                    int currentqty = row.Cells["colQuantity"].Value.ToInt();
                    int productID = row.Cells["colProductID"].Value.ToInt();

                    int newqty = oldqty - currentqty;

                    if (newqty < 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Tomato;
                        Helper.ShowMessage("Cannot transfer more stock than is currently at location",
                            "Illegal Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                    ProductLocation prodloc=new GenericService<ProductLocation>().GetSingle(p => p.LocationID == toLoc.ToInt() && p.ProductID == productID);

                    int fromLocQtyBeforeTransfer = new GenericService<ProductLocation>().GetSingle(p => p.LocationID == fromLoc.ToInt() && p.ProductID == productID).Quantity;
                    int ToLocQtyBeforeTransfer = prodloc == null ? 0 : prodloc.Quantity;

                    if (new GenericService<ProductLocation>()
                        .GetSingle(p => p.LocationID == toLoc.ToInt() && p.ProductID == productID) != null)
                    {
                        _productService.AddInventory(currentqty, productID, toLoc.ToInt());
                    }
                    else
                    {
                        new GenericService<ProductLocation>().Add(new ProductLocation
                        {
                            ProductID = productID,
                            LocationID = toLoc.ToInt(),
                            Quantity = currentqty
                        });
                    }

                    _productService.ReduceInventory(currentqty, productID, fromLoc.ToInt());
                   

                    new GenericService<StockTranfer>().Add(new StockTranfer
                    {
                        FromLocationID = fromLoc.ToInt(),
                        FromLocationQtyAfterTransfer = (fromLocQtyBeforeTransfer - currentqty),
                        FromLocationQtyBeforeTranfer = fromLocQtyBeforeTransfer,
                        ProductID = productID,
                        ToLocationAfterTranfer = (ToLocQtyBeforeTransfer + currentqty),
                        ToLocationBeforeTransfer = ToLocQtyBeforeTransfer,
                        ToLocationID = toLoc.ToInt(),
                        TransferDate = DateTime.Now,
                        TransferQty = currentqty,
                        UserID = 0
                    });
                }

                Helper.ShowMessage("Stock tranfer was completed succesfully ", "Tranfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateRow = false;
                dgvProductList.Rows.Clear();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucTransferStock", "btnTransfer_Click");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnAddByLoc_Click(object sender, EventArgs e)
        {
            new frmLocations().ShowDialog();
        }

        private DataGridViewComboBoxCell FillCombo(int idx, int cell)
        {
            DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)(dgvProductList.Rows[idx].Cells[cell]);

            comboCell.DataSource = locations;
            comboCell.DisplayMember = "Name";
            comboCell.ValueMember = "ID";

            return comboCell;
        }

        DataGridViewRow AddRow(int qty, int currqty, int productid, int locationid)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvProductList);

            row.Cells[3].Value = qty;
            row.Cells[4].Value = currqty;
            row.Cells[5].Value = productid;
            row.Cells[6].Value = locationid;

            return row;
        }

        private void dgvProductList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            FillCombo(e.RowIndex);

            DataGridViewButtonCell buttoncell = (DataGridViewButtonCell)dgvProductList.Rows[e.RowIndex].Cells[1];
            buttoncell.Value = "...";
        }

        void InsertColumn()
        {
            DataGridViewComboBoxColumn comboFromLoc = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn comboToLoc = new DataGridViewComboBoxColumn();

            comboFromLoc.HeaderText = "From Location";
            comboFromLoc.Width = 200;
            comboFromLoc.DataSource = locations;
            comboFromLoc.DisplayMember = "Name";
            comboFromLoc.ValueMember = "ID";
            comboFromLoc.ReadOnly = true;

            comboToLoc.HeaderText = "To Location";
            comboToLoc.Width = 200;
            comboToLoc.DataSource = locations;
            comboToLoc.DisplayMember = "Name";
            comboToLoc.ValueMember = "ID";

            dgvProductList.Columns.Insert(1, comboFromLoc);
            dgvProductList.Columns.Insert(2, comboToLoc);
        }

        DataGridViewTextBoxColumn CreateColumn(string headetext, int witdh, string value, string name)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = headetext;
            column.Width = witdh;
            column.CellTemplate.Value = value;
            column.Name = name;

            return column;
        }

        private void FillCombo(int idx)
        {
            try
            {
                DataGridViewComboBoxCell colFromLoc = (DataGridViewComboBoxCell)(dgvProductList.Rows[idx].Cells["colFromLocation"]);
                DataGridViewComboBoxCell colToLoc = (DataGridViewComboBoxCell)(dgvProductList.Rows[idx].Cells["colToLocation"]);

                colFromLoc.DataSource = locations;
                colFromLoc.DisplayMember = "Name";
                colFromLoc.ValueMember = "ID";

                colToLoc.DataSource = locations;
                colToLoc.DisplayMember = "Name";
                colToLoc.ValueMember = "ID";
            }
            catch
            {

            }

        }

        private void dgvProductList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    int transferqty = dgvProductList.Rows[e.RowIndex].Cells["colQuantity"].Value.ToInt();
                    int currqty = dgvProductList.Rows[e.RowIndex].Cells["colCurrQty"].Value.ToInt();
                    dgvProductList.Rows[e.RowIndex].Cells["colRemainingQuantity"].Value = currqty - transferqty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucTransferStock", "dgvProductList_CellEndEdit");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
            {
                _rowindex = e.RowIndex;
                new frmSelectProductForTransfer().ShowDialog();
            }
        }

        private void PopulateCombo()
        {
            //FillCombo(0);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvProductList.Rows.Add();
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductList.SelectedCells.Count == 0) return;

                if (dgvProductList.SelectedCells[0].Value == null)
                {
                    dgvProductList.Rows.RemoveAt(dgvProductList.CurrentCell.RowIndex);
                    return;
                }

                int productID = dgvProductList.Rows[dgvProductList.CurrentCell.RowIndex].Cells[7].Value.ToInt();
                int locationID = dgvProductList.Rows[dgvProductList.CurrentCell.RowIndex].Cells[8].Value.ToInt();

                selectedProducts.Remove(selectedProducts.Find(p => p.LocationID == locationID && p.ProductID == productID));

                dgvProductList.Rows.RemoveAt(dgvProductList.CurrentCell.RowIndex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucTransferStock", "btnRemoveRow_Click");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
        }
    }

    class TranferStockComparer : IEqualityComparer<TransferStockViewModel>
    {
        public bool Equals(TransferStockViewModel x, TransferStockViewModel y)
        {
            return (x.LocationID == y.LocationID) && (x.ProductID == y.ProductID);
        }

        public int GetHashCode(TransferStockViewModel obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
