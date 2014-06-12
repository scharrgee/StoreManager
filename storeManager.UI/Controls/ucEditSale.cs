using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

using storeManager.UI;
using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using System.Globalization;

using storeManager.UI.Controls;
using storeManager.ViewModel;
using System.Threading;
using System.Threading.Tasks;

namespace storeManager.UI.Controls
{
    public partial class ucManageSale : UserControl
    {
        private ICustomerService _customer;
        private ISaleDetailService _saleDetail;
        private ISaleService _sale;
        private IProductService _product;
        private ITaxService _tax;
        private IPaymentModeService _paymentMode;
        private Company company;
        IErrorService _logger;
        private List<AffectedProductsViewModel> _affectedProduts = new List<AffectedProductsViewModel>();

        //delegate void LoadGridAsync(string dfrom, string dto, int status, string invno);

        int _currentsaleID = 0;
        Sale _currentSale = null;
        string _productID = "";
        int _saleDetailID = 0;
        bool _saleConsistent = false;
        bool _dirty = false;
        decimal _taxRate = 0;
        //int _currentBalance = 0;

        public ucManageSale()
        {
            InitializeComponent();
            LoadDropDowns();
            Init();
        }

        private void Init()
        {
            _customer = new CustomerService();
            _sale = new SaleService();
            _saleDetail = new SaleDetailService();
            _product = new ProductService();
            _paymentMode = new PaymentModeService();
            _tax = new TaxService();
            company = new GenericService<Company>().GetAll().FirstOrDefault();
            _logger = new ErrorLogService();

            SuscribeToEvent();

            btnAddRow.Enabled = false;
            btnRemoveRow.Enabled = false;
            btnDone.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }

        void Hub_GenericInfo(object sender, EventHubAgs e)
        {
            int id = e.ID.ToInt();
            string[] data = e.Data.Split(',');

            string productName = data[0];
            string unitprice = data[1];

            AddProduct(productName, unitprice, id);

            UnSuscribeToEvent();
        }

        private void SuscribeToEvent()
        {
            Hub.GenericInfo += new EventHandler<EventHubAgs>(Hub_GenericInfo);
        }

        private void UnSuscribeToEvent()
        {
            Hub.GenericInfo -= new EventHandler<EventHubAgs>(Hub_GenericInfo);
        }

        private void AddProduct(string productName, string unitprice, int productID)
        {
            dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[0].Value = productName;
            dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[2].Value = unitprice;
            dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[1].Value = "0";
            dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[3].Value = "0.00";
            dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[4].Value = "0.00";
            dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[5].Value = productID;

            _affectedProduts.Add(new AffectedProductsViewModel { ProductID = productID, State = ProductState.Added });
        }

        private void LoadDropDowns()
        {
            List<SaleStatus> statuses = new List<SaleStatus>
            {
                new SaleStatus(){ Id = 0, Status = "All"}
            };

            statuses.AddRange(Helper.LoadSaleStatuses());

            cmbStatus.Load("id", "Status", statuses);
            cmbSalesRep.Load("EmployeeID", "FisrtName", Helper.LoadEmployees());
            cmbCustomer.Load("CustomerID", "CustomerName", Helper.LoadCustomers());
            cmbLocation.Load("id", "Name", Helper.LoadLocations());
            cmbLocation.SelectedIndex = 0;

            cmbTax.Load("TaxID", "TaxName", Helper.LoadTaxes());

            cmbPaymentMode.Load("PaymentModeID", "PayMode", Helper.LoadPaymentModes());
            cmbPaymentMode.Select("Cash");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //mnDeduct.PerformClick();
            //mnReceive.PerformClick();
        }

        private void mnDeduct_Click(object sender, EventArgs e)
        {
            int locationID = int.Parse(cmbLocation.SelectedValue.ToString());

            foreach (GridViewRowInfo dr in dgvOrderItems.Rows)
            {
                int qty = int.Parse(dr.Cells["colQuantity"].Value.ToString());
                int productID = dr.Cells["colID"].Value.ToInt();

                try
                {
                    _product.ReduceInventory(qty, productID, locationID);
                    SaveChangesToSale();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred", "ucEditSale", "mnDeduct_Click");

                    Helper.ShowMessage("Transaction was not completed, An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _currentSale.SaleStatusID = (int)SaleStatuses.Invoiced;
            _sale.Update(_currentSale, s => s.SaleID == _currentsaleID);

            UpdateUI(_currentSale.SaleStatusID);
            SetStatus();
        }

        private void mnReceive_Click(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text.ToDecimal() <= 0)
            {
                Helper.ShowMessage("Please specify payment amount", "Specify Payment Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAmountPaid.Focus();
                return;
            }

            try
            {
                if (_dirty)
                    SaveChangesToSale();

                CustomerPaymentHistory history = new CustomerPaymentHistory()
                {
                    Balance = txtBalanceDue.Text.ToDecimal(),
                    PayAmount = txtAmountPaid.Text.ToDecimal(),
                    PaymentDate = dtpOrderDate.Value,
                    SaleID = _currentsaleID
                };

                new GenericService<CustomerPaymentHistory>().Add(history);

                SetCurrentSaleBalance();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucEditSale", "mnReceive_Click");

                Helper.ShowMessage("Transaction was not completed, An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SaveChangesToSale()
        {
            _currentSale.CustBalance -= txtAmountPaid.Text.ToDecimal();
            _currentSale.AmountPaid = txtAmountPaid.Text.ToDecimal();
            _currentSale.SaleID = _currentsaleID;
            _currentSale.Amount = txtTotalAmt.Text.ToDecimal();
            _currentSale.SubTotal = txtSubTotal.Text.ToDecimal();
            _currentSale.Discount = txtSaleDiscount.Text.ToDecimal();

            if (!(txtAmountPaid.Text.ToDecimal() <= 0))
                _currentSale.SaleStatusID = _currentSale.CustBalance <= 0 ? (int)SaleStatuses.Closed : (int)SaleStatuses.Invoiced;

            _sale.Update(_currentSale, s => s.SaleID == _currentsaleID);
            _saleDetail.SaveChangesToAffectedProducts(_affectedProduts);

            _dirty = false;
            UpdateUI(_currentSale.SaleStatusID);
            _affectedProduts.Clear();

            Helper.ShowMessage("Changes has been committed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSalesListGrid();
        }

        private void LoadSalesListGrid()
        {
            btnAddRow.Enabled = false;

            dgvSalesList.DataSource = null; ;

            if (!dtFrom.CompareTo(dtTo))
            {
                Helper.ShowMessage("From date cannot be later than To date", "Date Not Valid",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            string dfrom = dtFrom.GetValue(true);
            string dto = dtTo.GetValue(false);
            int status = cmbStatus.SelectedValue.ToInt();
            string inv = txtInvNo.Text;

            Task<IEnumerable<EditSaleViewModel>> loadGridTask = Task.Factory.StartNew<IEnumerable<EditSaleViewModel>>(state =>
            {
                LoadSalesArgs loadSalesArgs = (LoadSalesArgs)state;

                return new StoredProcedureGatewayService()
                                                   .GetSaleList(loadSalesArgs.Dfrom, loadSalesArgs.Dto, loadSalesArgs.Status, loadSalesArgs.Invno)
                                                   .Select(s => new EditSaleViewModel { OrderNumber = s.InvoiceNumber ?? "", SaleID = s.SaleID.ToString() ?? "0" });
            }, new LoadSalesArgs(dfrom, dto, status, inv));


            loadGridTask.ContinueWith((ant) =>
            {

                dgvSalesList.DataSource = ant.Result;

                ConfigureGrid();

                Helper.DefaultCursor(this);
                lblStatus.Text = "Finished loading sales";
                btnAddRow.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            lblStatus.Text = "Loading sales...";

            Helper.WaitCursor(this);
        }

        //private void LoadGrid(object state)
        //{
        //    LoadSalesArgs args = (LoadSalesArgs)state;

        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new Action(() =>
        //        {
        //            LoadSales(new LoadSalesArgs(args.Dfrom, args.Dto, args.Status, args.Invno));
        //            Helper.DefaultCursor(this);

        //        }));
        //    }
        //    else
        //    {
        //        LoadSales(new LoadSalesArgs(args.Dfrom, args.Dto, args.Status, args.Invno));
        //        Helper.DefaultCursor(this);
        //    }


        //}

        private struct LoadSalesArgs
        {
            private string _Dfrom;
            private string _Dto;
            private int _Status;
            private string _Invno;
            /// <summary>
            /// Summary for LoadSalesArgs
            /// </summary>
            public LoadSalesArgs(string dfrom, string dto, int status, string invno)
            {
                _Dfrom = dfrom;
                _Dto = dto;
                _Status = status;
                _Invno = invno;
            }
            public string Dfrom
            {
                get
                {
                    return _Dfrom;
                }
            }
            public string Dto
            {
                get
                {
                    return _Dto;
                }
            }
            public int Status
            {
                get
                {
                    return _Status;
                }
            }
            public string Invno
            {
                get
                {
                    return _Invno;
                }
            }
        }

        //private void LoadSales(LoadSalesArgs loadSalesArgs)
        //{
        //    var saleList = new StoredProcedureGatewayService()
        //                                 .GetSaleList(loadSalesArgs.Dfrom, loadSalesArgs.Dto, loadSalesArgs.Status, loadSalesArgs.Invno)
        //                                 .Select(s => new EditSaleViewModel { OrderNumber = s.InvoiceNumber ?? "", SaleID = s.SaleID.ToString() ?? "0" });

        //    foreach (var item in saleList)
        //    {
        //        AddRowToGrid(item);
        //    }

        //    lblStatus.Text = "Finished loading sales";
        //}

        //private void AddRowToGrid(EditSaleViewModel item)
        //{
        //    string[] row = new string[2];

        //    row[0] = item.OrderNumber;
        //    row[1] = item.SaleID;

        //    dgvSalesList.Rows.Add(row);
        //}

        //void LoadGrid()
        //{
        //    LoadGrid(new LoadSalesArgs(dtFrom.GetValue(true), dtTo.GetValue(false), cmbStatus.SelectedValue.ToInt(), txtInvNo.Text));
        //}

        void ConfigureGrid()
        {
            if (dgvSalesList.Rows.Count == 0) return;

            dgvSalesList.Columns["OrderNumber"].HeaderText = "Invoice #";

            dgvSalesList.Columns["OrderNumber"].Width = 270;

            dgvSalesList.Columns["SaleID"].IsVisible = false;
        }

        private void dgvSalesList_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (_dirty)
            {
                if (DialogResult.Yes == Helper.ShowMessage("Your changes have not been saved yet. Do you want to save?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    SaveChangesToSale();
                }
            }

            _dirty = false;

            dgvOrderItems.Rows.Clear();

            List<SaleDetail> details = GetSaleDetails(e);

            SetStatus();
            CheckQuoteStatus(_currentSale.SaleStatusID);
            UpdateUI(_currentSale.SaleStatusID);
            SetCurrentSaleBalance();

            details.ForEach(d =>
            {
                Product product = _product.GetSingle(p => p.ProductID.ToString() == d.ProductID);
                object[] rows = new object[7];
                rows[0] = product.ProductName;
                rows[1] = d.Quantity;
                rows[2] = d.UnitPrice;
                rows[3] = d.Discount;
                rows[4] = d.LineTotal;
                rows[5] = d.ProductID;
                rows[6] = d.SalesDetailsID;

                dgvOrderItems.Rows.Add(rows);
            });
        }

        private void SetCurrentSaleBalance()
        {
            mnReceive.Enabled = _currentSale.CustBalance > 0;
            txtBalanceDue.Text = _currentSale.CustBalance.ToString();
        }

        private List<SaleDetail> GetSaleDetails(Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            _currentsaleID = e.Row.Cells["SaleID"].Value.ToInt();

            _currentSale = _sale.GetSingle(s => s.SaleID == _currentsaleID);
            int customerID = _currentSale.CustomerID.ToInt();
            Customer customer = _customer.GetSingle(c => c.CustomerID == customerID);

            cmbCustomer.SelectedValue = customer.CustomerID;
            txtContact.Text = customer.ContactPerson ?? "N/A";
            txtAddress.Text = customer.LocationAdress ?? customer.PostalAddress ?? "N/A";
            txtPhone.Text = customer.PhoneNumber1 ?? "N/A";
            cmbSalesRep.SelectedValue = _currentSale.EmployeeID;
            cmbLocation.SelectedValue = _currentSale.LocationID;
            txtOrderNo.Text = _currentSale.InvoiceNumber;

            txtSubTotal.Text = _currentSale.SubTotal.ToString();
            txtSaleDiscount.Text = _currentSale.Discount.ToString();
            txtTax.Text = _currentSale.Tax.ToString();
            txtTotalAmt.Text = _currentSale.Amount.ToString();
            txtAmountPaid.Text = _currentSale.AmountPaid.ToString();
            txtBalanceDue.Text = _currentSale.CustBalance.ToString();
            cmbPaymentMode.SelectedValue = _currentSale.PaymentModeID;
            dtpOrderDate.Value = _currentSale.InvoiceDate;

            List<SaleDetail> details = _saleDetail.Query(d => d.SaleID == _currentsaleID).ToList();
            return details;
        }

        private void SetStatus()
        {
            txtStatus.Text = Enum.GetName(typeof(SaleStatuses), _currentSale.SaleStatusID);
        }

        private void CheckQuoteStatus(int? statusID)
        {
            btnConvertToOrder.Visible = statusID.Value == (int)SaleStatuses.Quote;
            btnCancel.Visible = statusID.Value != (int)SaleStatuses.Quote;
            btnDone.Visible = statusID.Value != (int)SaleStatuses.Quote;

            UpdateUI(statusID);
        }

        private void btnConvertToOrder_Click(object sender, EventArgs e)
        {
            _currentSale.SaleStatusID = (int)SaleStatuses.Order;
            _currentSale.InvoiceNumber = Helper.GetInvoiceNo(Prefix.ORD.ToString());
            _sale.Update(_currentSale, s => s.SaleID == _currentsaleID);

            LoadSalesListGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            switch (btnCancel.Text)
            {
                case "Cancel Order":
                    _currentSale.SaleStatusID = (int)SaleStatuses.Cancelled;
                    _sale.Update(_currentSale, s => s.SaleID == _currentsaleID);

                    UpdateUI(_currentSale.SaleStatusID);

                    btnCancel.Text = "Re-Open Order";
                    break;
                case "Re-Open Order":

                    if (!(_currentSale.SaleStatusID == (int)SaleStatuses.Cancelled))
                    {
                        if (_currentSale.SaleStatusID == (int)SaleStatuses.Closed)
                        {
                            _currentSale.CustBalance = _currentSale.Amount;
                        }

                        _currentSale.SaleStatusID = (int)SaleStatuses.Open;
                        _sale.Update(_currentSale, s => s.SaleID == _currentsaleID);

                        _saleDetail.ReverseSale(_currentsaleID, false);
                        break;
                    }

                    _currentSale.SaleStatusID = (int)SaleStatuses.Open;
                    _sale.Update(_currentSale, s => s.SaleID == _currentsaleID);

                    break;
                default:
                    break;
            }

            UpdateUI(_currentSale.SaleStatusID);
            SetStatus();
            LoadSalesListGrid();
        }

        private void UpdateUI(int? status)
        {
            panSummary.Enabled = gbCustDetails.Enabled =
                dgvOrderItems.Enabled =
                status != (int)SaleStatuses.Cancelled;
            //gbCustDetails.Enabled = status != (int)SaleStatuses.Cancelled;
            //dgvOrderItems.Enabled = status != (int)SaleStatuses.Cancelled;

            btnDone.Enabled = status != (int)SaleStatuses.Closed;
            mnDeduct.Enabled = status != (int)SaleStatuses.Invoiced;
            btnCancel.Enabled = true;
            btnSave.Enabled = _dirty;

            btnAddRow.Enabled = btnRemoveRow.Enabled = 
                !(status == (int)SaleStatuses.Invoiced || status == (int)SaleStatuses.Closed || status == (int)SaleStatuses.Cancelled) 
                ? true : false;
            //btnRemoveRow.Enabled = !(status == (int)SaleStatuses.Invoiced || status == (int)SaleStatuses.Closed) ? true : false;

            btnCancel.Text = (status == (int)SaleStatuses.Cancelled || status == (int)SaleStatuses.Invoiced || status == (int)SaleStatuses.Closed) ? "Re-Open Order" : "Cancel Order";

            dgvOrderItems.ReadOnly = (status == (int)SaleStatuses.Invoiced || status == (int)SaleStatuses.Closed) ? true : false;

            cmbTax.Enabled = !(status == (int)SaleStatuses.Invoiced || status == (int)SaleStatuses.Closed) ? true : false;
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text == "")
            {
                txtBalanceDue.Text = _currentSale.CustBalance.Value.ToString();
                return;
            }

            decimal balance = _currentSale.CustBalance.Value - txtAmountPaid.Text.ToDecimal();

            txtBalanceDue.Text = Math.Round(balance, 2).ToString();
        }

        private void CalculateSaleCost()
        {
            try
            {
                decimal discount = 0;
                decimal subTotal = 0;
                decimal total = 0;
                decimal saleSubTotal = 0;
                int lineItemQty = 0;
                decimal lineItemPrice = 0;


                if (dgvOrderItems.Rows.Count > 0)
                {
                    foreach (GridViewRowInfo gr in dgvOrderItems.Rows)
                    {
                        lineItemQty = int.Parse(gr.Cells[1].Value.ToString());
                        lineItemPrice = decimal.Parse(gr.Cells[2].Value.ToString());

                        discount = gr.Cells[3].Value.ToString() == "" ? 0 : (decimal.Parse(gr.Cells[3].Value.ToString()));

                        _sale.CalculateLineTotal(lineItemQty, lineItemPrice, 0, discount, out subTotal, out total);

                        saleSubTotal += subTotal;
                    }
                }

                decimal discountamt = txtSaleDiscount.Text == "" ? 0 : txtSaleDiscount.Text.ToDecimal();
                decimal calculatedTax = Math.Round(_sale.CalculateTax((saleSubTotal), _taxRate), 2);

                decimal totalAmount = (saleSubTotal + calculatedTax) - discountamt;


                txtSubTotal.Text = Math.Round(saleSubTotal, 2).ToString();
                txtTax.Text = calculatedTax.ToString();
                txtTotalAmt.Text = totalAmount.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "CalculateItemsCost");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbTax_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTax.SelectedValue.ToString() == "0") return;

            int taxID = 0;
            try
            {
                if (!int.TryParse(cmbTax.SelectedValue.ToString(), out taxID)) return;
                if (txtSubTotal.Text == "") return;

                _taxRate = new GenericService<Tax>().GetSingle(t => t.TaxID == taxID).TaxRate;

                CalculateSaleCost();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucEditSale", "cmbTax_SelectedValueChanged");

                Helper.ShowMessage("Transaction was not completed, An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvOrderItems.Rows.Insert(dgvOrderItems.CurrentCell.RowIndex, null);
            dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[0].ReadOnly = false;
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            GridViewDataRowInfo dataRowInfo = this.dgvOrderItems.CurrentRow as GridViewDataRowInfo;
            if (dataRowInfo != null)
            {
                int productID = dataRowInfo.Cells[5].Value.ToInt();
                int saleDetailID = dataRowInfo.Cells[6].Value.ToInt();

                this.dgvOrderItems.Rows.Remove(dataRowInfo);
                _dirty = true;
                CalculateSaleCost();

                UpdateUI(_currentSale.SaleStatusID);

                _affectedProduts.Add(new AffectedProductsViewModel { ProductID = productID, State = ProductState.Deleted, SaleDetailID = saleDetailID });
            }
        }

        private void dgvOrderItems_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row.Cells[0].IsCurrent)
            {
                _productID = e.Row.Cells[5].Value == null ? "" : e.Row.Cells[5].Value.ToString();
                _saleDetailID = e.Row.Cells[6].Value == null ? 0 : e.Row.Cells[6].Value.ToInt();

                SuscribeToEvent();
                frmChooseItem frm = new frmChooseItem();
                frm.PositionForm(dgvOrderItems.Top - 40, 380);
                frm.ShowDialog();
            }
        }

        private bool CheckIfRowAlreadyContainedProduct(string productID)
        {
            return !string.IsNullOrEmpty(productID);
        }



        protected void dgvOrderItems_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.Cells[1].IsCurrent || e.Row.Cells[3].IsCurrent)
            {
                _dirty = true;

                int productID = dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[5].Value.ToInt();
                int saleDtailID = dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[6].Value
                    == null ? 0 : dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[6].Value.ToInt();

                int qty = dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[1].Value.ToInt();
                decimal unitPrice = dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[2].Value.ToDecimal();
                decimal discount = dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[3].Value.ToDecimal();
                decimal lineTotal = (qty * unitPrice) - discount;
                dgvOrderItems.Rows[dgvOrderItems.CurrentCell.RowIndex].Cells[4].Value = lineTotal;

                CalculateSaleCost();

                UpdateUI(_currentSale.SaleStatusID);

                if (!_affectedProduts.Contains(new AffectedProductsViewModel { ProductID = productID, State = ProductState.Added }, new AffectedProductsViewModel()))
                {
                    if (_affectedProduts.Contains(new AffectedProductsViewModel { ProductID = productID, State = ProductState.Modified }, new AffectedProductsViewModel()))
                    {
                        AffectedProductsViewModel product = _affectedProduts.Where(p => p.ProductID == productID && p.State == ProductState.Modified).FirstOrDefault();

                        product.LineDiscount = discount;
                        product.Quantity = qty;
                        product.LineTotal = lineTotal;
                    }
                    else
                    {
                        _affectedProduts.Add(new AffectedProductsViewModel
                        {
                            ProductID = productID,
                            State = ProductState.Modified,
                            LineDiscount = discount,
                            Quantity = qty,
                            SaleDetailID = saleDtailID,
                            LineTotal = lineTotal,
                            InvoiceNumber = txtOrderNo.Text,
                            SaleID = _currentsaleID
                        });
                    }

                }
                else
                {
                    AffectedProductsViewModel product = _affectedProduts.Where(p => p.ProductID == productID && p.State == ProductState.Added).FirstOrDefault();

                    product.SaleID = _currentsaleID;
                    product.LineDiscount = discount;
                    product.Quantity = qty;
                    product.LineTotal = lineTotal;
                    product.UnitPrice = unitPrice;
                    product.InvoiceNumber = txtOrderNo.Text;
                }
            }
        }

        private void dgvOrderItems_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.Cells[0].IsCurrent)
            {
                if (CheckIfRowAlreadyContainedProduct(_productID))
                {
                    _affectedProduts.Add(new AffectedProductsViewModel { ProductID = _productID.ToInt(), State = ProductState.Deleted, SaleDetailID = _saleDetailID });

                    _productID = "";
                    _saleDetailID = 0;
                }
            }
        }

        private void dgvOrderItems_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            string cellValue = e.CellElement.Value == null ? "??" : e.CellElement.Value.ToString();

            if (e.Column.Name == "colLineTotal" && (cellValue == "??" || cellValue == "0.00"))
            {
                SetBackColor(e);
            }
            else if (e.Column.Name == "colQuantity" && (cellValue == "??" || cellValue == "0"))
            {
                SetBackColor(e);
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, Telerik.WinControls.ValueResetFlags.Local);

                _saleConsistent = true;
            }

        }

        private void SetBackColor(CellFormattingEventArgs e)
        {
            e.CellElement.BackColor = Color.Red;
            e.CellElement.NumberOfColors = 1;
            e.CellElement.DrawFill = true;
            _saleConsistent = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_saleConsistent)
            {
                Helper.ShowMessage("Please correct errors", "Correct Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                SaveChangesToSale();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucEditSale", "btnSave_Click");

                Helper.ShowMessage("Transaction was not completed, An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalAmt_TextChanged(object sender, EventArgs e)
        {
            txtBalanceDue.Text = (txtTotalAmt.Text.ToDecimal() - txtAmountPaid.Text.ToDecimal()).ToString();
            _currentSale.CustBalance = txtBalanceDue.Text.ToDecimal();

            //_dirty = true;

            UpdateUI(_currentSale.SaleStatusID);
        }

        private void btnSaleDiscCal_Click(object sender, EventArgs e)
        {
            if (!Helper.ValidateTexBox(txtTotalAmt)) return;

            Hub.SetDiscountAmount += new EventHandler<EventHubAgs>(Hub_SetDiscountAmount);
            new frmCalculateDiscount(txtTotalAmt.Text.ToDecimal()).ShowDialog();

            Hub.SetDiscountAmount -= new EventHandler<EventHubAgs>(Hub_SetDiscountAmount);
        }

        void Hub_SetDiscountAmount(object sender, EventHubAgs e)
        {
            txtSaleDiscount.Text = e.Data;
        }

        private void txtSaleDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateSaleCost();
        }
    }
}
