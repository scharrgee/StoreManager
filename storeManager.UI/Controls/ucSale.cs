using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.PointOfService;

using storeManager.UI;
using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using System.Globalization;

namespace storeManager.UI.Controls
{
    public partial class ucSale : UserControl
    {

        private const string DEFAULT_CUSTOMER = "CASH CUSTOMER";
        private const string DEFAULT_CUSTID = "99999";
        private const string DEFAULT_SALESPERSON = "DEFAULT SALES PERSON";
        private const string DEFAULT_SALESPERSONID = "99999";
        private const int DEFAULT_LOCALSTOREID = 1;
        private const string ESC = "\u001b|";
        decimal _saletax = 0;
        string invoicePrintDate = "";
        int _voidSaleID = 0;
        bool _fromBarCode = false;

        private ICustomerService _customer;
        private ISaleDetailService _saleDetail;
        private ISaleService _sale;
        private IProductService _product;
        private ITaxService _tax;
        private IPaymentModeService _paymentMode;
        private Company _company;
        PosPrinter _printer = null;
        Scanner _scanner = null;
        IErrorService _logger;

        frmChooseItem frmchooseItem = null;
        delegate void productSearch();

        public ucSale()
        {
            InitializeComponent();
            Init();
            SetUpSaleScreenDefaults();
            GetInvoiceNo();
            LoadPaymentModeCmb();
            LoadLocationCmb();

            Hub.EditSale += new EventHandler<EditSaleEventArgs>(Hub_EditSale);
            this.Disposed += new EventHandler(ucSale_Disposed);

            txtItemName.Focus();
        }

        void ucSale_Disposed(object sender, EventArgs e)
        {
            if (frmchooseItem != null) frmchooseItem.Close();
        }

        void _sanner_DataEvent(object sender, DataEventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            try
            {
                // Display the ASCII encoded label text
                txtBarCode.Text = encoder.GetString(_scanner.ScanDataLabel);
                // Display the encoding type
                _scanner.DataEventEnabled = true;

                _fromBarCode = true;

                txtBarCode.Focus();
                txtBarCode_KeyDown(this, new KeyEventArgs(Keys.Enter));
                txtQty.Focus();

                _fromBarCode = false;
            }
            catch (PosControlException ex)
            {
                // Log any errors
                _logger.LogError(ex, "An error occurred", "ucSale", "_sanner_DataEvent");
            }
        }

        public PosPrinter ReceiptPrinter
        {
            get { return _printer; }
            set { _printer = value; }
        }

        public Scanner BarCodeSanner
        {
            get { return _scanner; }
            set { _scanner = value; }
        }

        void Hub_EditSale(object sender, EditSaleEventArgs e)
        {
            try
            {
                _voidSaleID = e.SaleID;

                Sale sale = _sale.GetSingle(s => s.SaleID == e.SaleID);
                Customer customer = _customer.GetSingle(c => c.CustomerID == int.Parse(sale.CustomerID));
                User user = new GenericService<User>().GetSingle(s => s.EmployeeID == int.Parse(sale.EmployeeID));
                string time = sale.InvoiceDate.ToShortTimeString();

                cmbLocation.SelectedValue = new GenericService<Company>().GetAll().FirstOrDefault().DefaultLocation;
                txtCustomer.Text = customer == null ? "" : customer.CustomerName;
                txtCustomer.Tag = sale.CustomerID;
                txtSalesPerson.Text = user == null ? "" : user.UserName;
                txtInvoiceNo.Text = sale.InvoiceNumber;
                txtSubTotal.Text = sale.SubTotal.ToString();
                txtSalTax.Text = sale.Tax.ToString();
                txtSaleDiscount.Text = sale.Discount.ToString();
                txtTotalAmt.Text = sale.Amount.ToString();
                txtAmountPaid.Text = sale.AmountPaid.ToString();
                txtBalanceDue.Text = sale.Balance.ToString();
                lblBalanceBig.Text = sale.Balance.ToString();
                invoicePrintDate = String.Format("{0} {1}", sale.InvoiceDate.ToShortDateString(), time.Substring(0, time.Length - 3));

                GetSaleDetails(e.SaleID);

                ConfigureFormAsReadOnly();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "Hub_EditSale");
                //UtilityClass.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ConfigureFormAsReadOnly()
        {
            Helper.MakeReadOnly(this);

            btnAddCustomer.Enabled = false;
            btnSaleDiscCal.Enabled = false;
            btnCancel.Enabled = false;
            btnChooseProduct.Enabled = false;
            btnChooseSalePerson.Enabled = false;
            btnSaleTax.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = false;
            btnNew.Enabled = false;
            btnSaleDiscCal.Enabled = false;

            gridViewItemLayout.Enabled = false;

            btnRecord.Text = "Reprint Receipt";
            btnVoidSale.Visible = true;
        }

        private void GetSaleDetails(int saleid)
        {
            try
            {
                List<SaleDetail> saledetails = _saleDetail.Query(s => s.SaleID == saleid).ToList();

                foreach (var item in saledetails)
                {
                    object[] rows = new object[7];
                    rows[0] = item.Quantity;
                    rows[1] = "";
                    rows[2] = _product.GetSingle(p => p.ProductID == int.Parse(item.ProductID)).ProductName;
                    rows[3] = item.UnitPrice;
                    rows[4] = item.Discount;
                    rows[5] = item.Tax;
                    rows[6] = item.LineTotal;

                    gridViewItemLayout.Rows.Add(rows);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "GetSaleDetails");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Hub_GenericInfo(object sender, EventHubAgs e)
        {
            TextBox txtProductName = this.Controls.Find(e.ControlName, true).FirstOrDefault() as TextBox;

            if (txtProductName == null) return;

            string productName = e.Data.Split(",".ToArray())[0];

            txtProductName.Text = productName;

            if (e.Data.Split(",".ToArray()).Count() > 1)
            {
                string[] data = e.Data.Split(",".ToArray());
                string productPrice = data[1];
                txtUnitPrice.Text = productPrice;
                lblMeasurement.Text = data[2];

                txtQty.Focus();
            }

            txtProductName.Tag = e.ID;

        }

        void SetUpSaleScreenDefaults()
        {
            txtCustomer.Text = DEFAULT_CUSTOMER;
            txtCustomer.Tag = DEFAULT_CUSTID;

            txtSalesPerson.Text = CurrentUser.User == null ? DEFAULT_SALESPERSON : CurrentUser.User.UserName.ToUpper();
            txtSalesPerson.Tag = CurrentUser.User == null ? DEFAULT_SALESPERSONID : CurrentUser.User.EmployeeID.ToString();

            Helper.SetControlName("ucSale");
        }

        private void Init()
        {
            _customer = new CustomerService();
            _sale = new SaleService();
            _saleDetail = new SaleDetailService();
            _product = new ProductService();
            _paymentMode = new PaymentModeService();
            _tax = new TaxService();
            _company = new GenericService<Company>().GetAll().FirstOrDefault();
            _logger = new ErrorLogService();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Helper.ValidateTexBox(txtItemName))
                    return;
                if (!Helper.ValidateTexBox(txtQty))
                    return;

                lblStatus.Text = "";

                int productID = txtItemName.Tag.ToInt();
                int locationID = cmbLocation.SelectedValue.ToInt();

                if (!Helper.HaveEnoughProductQuantityToFulfillSale(productID, locationID, txtQty.Text.ToInt(), gridViewItemLayout, txtItemName.Text)) return;

                PopulateGrid();
                ClearFields();

                txtItemName.Focus();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "btnInsert_Click");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearFields()
        {
            txtItemName.Clear();
            txtItemNo.Clear();
            txtQty.Clear();
            txtUnitPrice.Clear();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewItemLayout.Rows.Count == 0)
                return;

            gridViewItemLayout.Rows.RemoveAt(gridViewItemLayout.CurrentCell.RowIndex);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Helper.ClearForm(this);
            GetInvoiceNo();
        }

        private void GetInvoiceNo()
        {
            txtInvoiceNo.Text = Helper.GetInvoiceNo(Prefix.INV.ToString());
        }

        private void PopulateGrid()
        {
            try
            {
                decimal subTotal = 0;

                object[] row = new object[7];
                row[0] = txtQty.Text;
                row[1] = txtItemName.Tag;
                row[2] = txtItemName.Text;
                row[3] = txtUnitPrice.Text;

                subTotal = int.Parse(txtQty.Text) * decimal.Parse(txtUnitPrice.Text);

                row[4] = "0.00";
                row[5] = "0.00";
                row[6] = Math.Round(subTotal, 2);

                gridViewItemLayout.Rows.Add(row);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "PopulateGrid");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CalculateItemsCost()
        {
            try
            {
                decimal discount = 0;
                decimal subTotal = 0;
                decimal total = 0;
                decimal saleSubTotal = 0;
                int lineItemQty = 0;
                decimal lineItemPrice = 0;


                if (gridViewItemLayout.Rows.Count > 0)
                {
                    foreach (DataGridViewRow gr in gridViewItemLayout.Rows)
                    {
                        lineItemQty = int.Parse(gr.Cells[0].Value.ToString());
                        lineItemPrice = decimal.Parse(gr.Cells[3].Value.ToString());

                        discount = gr.Cells[4].Value.ToString() == "" ? 0 : (decimal.Parse(gr.Cells[4].Value.ToString()));

                        _sale.CalculateLineTotal(lineItemQty, lineItemPrice, 0, discount, out subTotal, out total);

                        saleSubTotal += subTotal;
                    }
                }

                decimal taxAmt = txtSalTax.Text == "" ? 0 : txtSalTax.Text.ToDecimal();
                decimal discountamt = txtSaleDiscount.Text == "" ? 0 : txtSaleDiscount.Text.ToDecimal();

                txtSubTotal.Text = Math.Round(saleSubTotal, 2).ToString();
                txtTotalAmt.Text = (Math.Round(CalculateTax((saleSubTotal - discountamt), taxAmt), 2)).ToString();

                lblSaleTotalBig.Text = txtTotalAmt.Text.ToDecimal().ToString("0.00");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "CalculateItemsCost");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private decimal CalculateTax(decimal totalSaleSubTotal, decimal taxAmt)
        {
            return Math.Round(totalSaleSubTotal, 2) + _sale.CalculateTax(totalSaleSubTotal, taxAmt);
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (CurrentUser.User.IsAdmin.Value)
            {
                Helper.ShowMessage("An Administrator cannot make sales, Please log on as a different user with sales rights ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (btnRecord.Text == "Reprint Receipt")
                {
                    if (_printer.Claimed)
                        PrintReceipt();

                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured", "ucSale", "Reprint Receipt");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (gridViewItemLayout.Rows.Count == 0)
            {
                Helper.ShowMessage("Sale must contain at least one product",
                    "Sale Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbPaymentMode.Text == "Cash")
            {
                if (!Helper.ValidateTexBox(txtAmountPaid))
                    return;
            }

            try
            {
                Sale sales;

                string InvoiceNo = txtInvoiceNo.Text;
                string AmountPaid = txtAmountPaid.Text;
                string subTotalAmt = txtSubTotal.Text;
                DateTime? SaleDate = dtpSaleDate.Value;
                decimal tax = txtSalTax.Text.ToDecimal();
                int locationID = cmbLocation.SelectedValue.ToInt();
                _saletax = _sale.CalculateTax(subTotalAmt.ToDecimal(), tax);
                decimal totalAmount = txtTotalAmt.Text.ToDecimal();
                decimal balance = txtBalanceDue.Text == "" ? 0 : decimal.Parse(txtBalanceDue.Text);

                sales = RecordSale(InvoiceNo, AmountPaid, subTotalAmt, SaleDate, totalAmount, balance);
                RecordSaleDetails(sales, InvoiceNo, locationID);
                PrintSaleReceipt();
                ResetFormFields();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "btnRecord");
                Helper.ShowMessage("An error occured sale has been cancelled \n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ResetFormFields()
        {
            txtInvoiceNo.Tag = false;

            txtSubTotal.Tag = null;
            txtTotalAmt.Tag = null;
            lblBalanceBig.Text = "0.00";

            Helper.ClearForm(this);
            gridViewItemLayout.Rows.Clear();

            lblStatus.Text = "Sale recorded successfully";

            GetInvoiceNo();
        }

        private void PrintSaleReceipt()
        {
            try
            {
                if (_printer.Claimed)
                    PrintReceipt();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "btnRecord");
            }
        }

        private void RecordSaleDetails(Sale sales, string InvoiceNo, int locationID)
        {
            Product product;
            SaleDetail salesDetails;

            foreach (DataGridViewRow dr in gridViewItemLayout.Rows)
            {
                if (dr.Cells[0].Value == null)
                {
                    throw new Exception("Value cannot be null");
                }

                salesDetails = new SaleDetail();
                product = new Product();

                salesDetails.SaleID = sales.SaleID;
                salesDetails.Quantity = int.Parse(dr.Cells["ColQty"].Value.ToString());
                salesDetails.ProductID = dr.Cells["ColItmNumber"].Value.ToString();
                salesDetails.UnitPrice = decimal.Parse(dr.Cells["ColPrice"].Value.ToString());
                salesDetails.Discount = decimal.Parse(dr.Cells["ColDiscount"].Value.ToString());
                salesDetails.Tax = decimal.Parse(dr.Cells["ColTax"].Value.ToString());
                salesDetails.InvoiceNumber = InvoiceNo;
                salesDetails.LineTotal = decimal.Parse(dr.Cells["ColTotal"].Value.ToString());
                salesDetails.LocationID = cmbLocation.SelectedValue.ToInt();

                try
                {
                    _saleDetail.Add(salesDetails);
                }
                catch (Exception ex)
                {
                    _sale.RollBackSaleTransaction(InvoiceNo);
                    _logger.LogError(ex, "An error occurred", "ucSale", "");
                    Helper.ShowMessage("Transaction was not completed, An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int qty = int.Parse(dr.Cells["ColQty"].Value.ToString());
                int productID = dr.Cells["ColItmNumber"].Value.ToInt();

                try
                {
                    _product.ReduceInventory(qty, productID, locationID);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred", "ucSale", "");
                    _sale.RollBackSaleTransaction(InvoiceNo);

                    Helper.ShowMessage("Transaction was not completed, An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Sale RecordSale(string InvoiceNo, string AmountPaid, string subTotalAmt, DateTime? SaleDate, decimal totalAmount, decimal balance)
        {
            Sale sales = new Sale();
            sales.CustomerID = txtCustomer.Tag.ToString();
            sales.Amount = totalAmount;
            sales.SubTotal = decimal.Parse(subTotalAmt);
            sales.InvoiceDate = SaleDate.Value;
            sales.InvoiceNumber = InvoiceNo;
            sales.StoreID = DEFAULT_LOCALSTOREID; //arbituary value, to bo replaced
            sales.Tax = Math.Round(_saletax, 2);
            sales.PaymentModeID = int.Parse(cmbPaymentMode.SelectedValue.ToString());

            //sales.Discount = txtSaleDiscount.Text == "" ? 0 : txtSaleDiscount.Text.ToDecimal();
            sales.AmountPaid = decimal.Parse(AmountPaid);
            sales.Balance = balance;
            sales.DateClosed = decimal.Parse(AmountPaid) >= decimal.Parse(subTotalAmt) ? SaleDate : null;
            //sales.SaleTypeID = (int)SaleStatus.Invoice;

            //sales.SaleTypeID = int.Parse(TypeOfSale.Order.ToString());
            sales.SaleStatusID = _sale.GetSaleStatus(totalAmount, AmountPaid.ToDecimal());
            sales.EmployeeID = txtSalesPerson.Tag == null ? DEFAULT_SALESPERSONID : txtSalesPerson.Tag.ToString();
            sales.Discount = txtSaleDiscount.Text == "" ? 0 : decimal.Parse(txtSaleDiscount.Text);
            sales.VoidSale = false;
            sales.LocationID = cmbLocation.SelectedValue.ToInt();

            try
            {
                sales = _sale.Add(sales);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucSale", "btnRecord");
            }
            return sales;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            SuscribeToEvent();
            new frmChooseCustomer(true, "txtCustomer").ShowDialog();
            UnsuscribeEvent();
        }

        private void btnChooseProduct_Click(object sender, EventArgs e)
        {
            SuscribeToEvent();
            frmchooseItem = new frmChooseItem();
            frmchooseItem.PositionForm(txtItemName.Top, txtItemName.Left);
            frmchooseItem.Show();
            //UnsuscribeEvent();

            txtQty.Focus();
        }

        void LoadPaymentModeCmb()
        {
            cmbPaymentMode.DataSource = new GenericService<PaymentMode>().GetAll();
            cmbPaymentMode.DisplayMember = "PayMode";
            cmbPaymentMode.ValueMember = "PaymentModeID";

            cmbPaymentMode.Select("Cash");
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPaymentMode.Text)
            {
                case "Cash":
                    txtBalanceDue.Enabled = true;
                    break;
                case "Cheque":
                    txtBalanceDue.Enabled = false;
                    break;
                case "Voucher":
                    txtBalanceDue.Enabled = false;
                    break;
            }
        }

        void UnsuscribeEvent()
        {
            Hub.GenericInfo -= new EventHandler<EventHubAgs>(Hub_GenericInfo);
            Hub.TaxInfo -= new EventHandler<EventHubAgs>(Hub_TaxInfo);
        }

        void SuscribeToEvent()
        {
            Hub.GenericInfo += new EventHandler<EventHubAgs>(Hub_GenericInfo);
            Hub.TaxInfo += new EventHandler<EventHubAgs>(Hub_TaxInfo);
        }

        void Hub_TaxInfo(object sender, EventHubAgs e)
        {
            TextBox txtTax = this.Controls.Find(e.ControlName, true).FirstOrDefault() as TextBox;

            if (txtTax == null) return;

            string taxName = e.Data.Split(",".ToArray())[0];
            string taxrate = e.Data.Split(",".ToArray())[1];

            txtTax.Text = Math.Round(taxrate.ToDecimal(), 2).ToString();
            lblSaleTax.Text = taxName;

            txtTax.Tag = e.ID;
        }

        void LoadLocationCmb()
        {
            IEnumerable<Location> location = new GenericService<Location>().GetAll().Where(l => l.Id == _company.DefaultLocation).ToList();
            cmbLocation.DataSource = location;
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "id";

            cmbLocation.Enabled = false;
        }

        private void gridViewItemLayout_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateItemsCost();
        }

        private void gridViewItemLayout_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateItemsCost();
        }

        private void txtPaidToday_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text == "")
            {
                txtBalanceDue.Text = "";
                return;
            }

            if (txtAmountPaid.Text.ToDecimal() > txtTotalAmt.Text.ToDecimal())
            {
                txtBalanceDue.Text = Math.Round((txtAmountPaid.Text.ToDecimal() - txtTotalAmt.Text.ToDecimal()), 2).ToString();
                lblBalanceBig.Text = txtBalanceDue.Text;
            }
        }

        private void btnSaleTax_Click(object sender, EventArgs e)
        {
            SuscribeToEvent();
            new frmChooseTax().ShowDialog();
            UnsuscribeEvent();
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

        private void txtSalTax_TextChanged(object sender, EventArgs e)
        {
            CalculateItemsCost();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!(char.IsControl(c) || char.IsNumber(c) || char.IsDigit(c) || c == '.'))
            {
                e.Handled = true;
                return;
            }
        }

        private void gridViewItemLayout_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTotalAmt.Text == "") return;

            if (e.ColumnIndex == 0 || e.ColumnIndex == 4)
            {
                CalculateItemsCost();

                int qty = gridViewItemLayout.Rows[e.RowIndex].Cells[0].Value.ToInt();
                decimal discount = gridViewItemLayout.Rows[e.RowIndex].Cells[4].Value.ToDecimal();
                decimal unitprice = gridViewItemLayout.Rows[e.RowIndex].Cells[3].Value.ToDecimal();
                decimal lineTotal = qty * unitprice;

                gridViewItemLayout.Rows[e.RowIndex].Cells[4].Value = Math.Round(discount, 2);
                gridViewItemLayout.Rows[e.RowIndex].Cells[6].Value = (lineTotal - discount);
            }
        }

        private void ucSale_Load(object sender, EventArgs e)
        {
            Helper.CreateInstanceFor<frmMain>("frmMain").Text = "New Sale";

            if (_scanner != null)
                _scanner.DataEvent += new DataEventHandler(_sanner_DataEvent);
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            SuscribeToEvent();
            new frmChooseItem(txtItemName.Text).ShowDialog();
            UnsuscribeEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            //DisposePrinter();

            this.Dispose();
        }

        void PrintReceipt()
        {
            string companyName = _company.CompanyName;
            string companyAddress = _company.Address1;
            string companyTel = _company.PhoneLine1;

            string invoiceNo = txtInvoiceNo.Text;
            string customer = txtCustomer.Text;

            string tax = _saletax.ToString();
            string discount = txtSaleDiscount.Text == "" ? "0.0" : txtSaleDiscount.Text;
            string total = txtTotalAmt.Text;
            string amtPaid = txtAmountPaid.Text == "" ? "0.0" : txtAmountPaid.Text;
            string subTotal = txtSubTotal.Text;
            string balance = txtBalanceDue.Text == "" ? "0.0" : txtBalanceDue.Text;

            //<<<step2>>>--Start
            //Initialization
            DateTime nowDate = DateTime.Now;							//System date
            DateTimeFormatInfo dateFormat = new DateTimeFormatInfo();	//Date Format
            dateFormat.MonthDayPattern = "MMMM";
            string currinvoiceDate = String.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            string strDate = invoicePrintDate == "" ? "Transaction Date - " + currinvoiceDate.Substring(0, currinvoiceDate.Length - 3) : "Transaction Date - " + invoicePrintDate;

            int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
            long lRecLineCharsCount;

            try
            {
                //<<<step3>>>--Start GH₵
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "1B");
                //<<<step3>>>--End

                _printer.PrintNormal(PrinterStation.Receipt, ESC + "1C"
                    + companyName + "\n");
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "N"
                    + companyAddress + "\n");
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "N"
                   + companyTel + "\n");

                _printer.PrintNormal(PrinterStation.Receipt, ESC + "200uF");

                invoiceNo = MakePrintString(_printer.RecLineChars, "Receipt #: " + ESC + "N" + invoiceNo, "");
                _printer.PrintNormal(PrinterStation.Receipt, invoiceNo + "\n");

                customer = MakePrintString(_printer.RecLineChars, "Customer : " + ESC + "N" + customer, "");
                _printer.PrintNormal(PrinterStation.Receipt, customer + "\n");

                //<<<step5>>--Start
                //Make 2mm speces
                //ESC|#uF = Line Feed
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "200uF");
                //<<<step5>>>-End

                lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
                if (lRecLineCharsCount >= 2)
                {
                    _printer.RecLineChars = RecLineChars[1];
                    _printer.PrintNormal(PrinterStation.Receipt, ESC + "cA" + strDate + "\n");
                    _printer.RecLineChars = RecLineChars[0];
                }
                else
                {
                    _printer.PrintNormal(PrinterStation.Receipt, ESC + "cA" + strDate + "\n");
                }
                _printer.PrintNormal(PrinterStation.Receipt, "================================================\n");
                //<<<step5>>>--Start
                //Make 5mm speces
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "500uF");

                _printer.PrintNormal(PrinterStation.Receipt, "Item Description          Qty  Unit Price  Total\n");
                _printer.PrintNormal(PrinterStation.Receipt, "------------------------------------------------\n");
                string strPrintData = "";

                foreach (DataGridViewRow row in gridViewItemLayout.Rows)
                {
                    string desc = TruncText(row.Cells["ColDecscription"].Value.ToString(), 26);
                    string qty = row.Cells["ColQty"].Value.ToString();
                    string price = row.Cells["ColPrice"].Value.ToString();
                    string linetotal = (int.Parse(qty) * decimal.Parse(price)).ToString();

                    strPrintData = desc + AddSpace(desc, 26) + qty + AddSpace(qty, 6) + "GHC "
                        + price + AddSpace(price, 6) + linetotal;

                    _printer.PrintNormal(PrinterStation.Receipt, strPrintData + "\n");
                }

                _printer.PrintNormal(PrinterStation.Receipt, "------------------------------------------------\n");

                //Make 2mm speces
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "200uF");

                //Print the total cost
                strPrintData = MakePrintString(_printer.RecLineChars, "Sub Total"
                    , "GHC " + subTotal);

                _printer.PrintNormal(PrinterStation.Receipt, ESC + "bC" + strPrintData + "\n");

                strPrintData = MakePrintString(_printer.RecLineChars, "Tax", "GHC  "
                    + tax);

                _printer.PrintNormal(PrinterStation.Receipt, strPrintData + "\n");

                strPrintData = MakePrintString(_printer.RecLineChars, "Discount", "GHC "
                    + discount);

                _printer.PrintNormal(PrinterStation.Receipt, strPrintData + "\n");


                strPrintData = MakePrintString(_printer.RecLineChars / 2, "Total", "GHC "
                    + total);

                _printer.PrintNormal(PrinterStation.Receipt, ESC + "bC" + ESC + "2C"
                    + strPrintData + "\n");

                strPrintData = MakePrintString(_printer.RecLineChars, "Customer's payment"
                    , "GHC " + amtPaid);

                _printer.PrintNormal(PrinterStation.Receipt
                    , strPrintData + "\n");

                strPrintData = MakePrintString(_printer.RecLineChars, "Change", "GHC "
                    + balance);

                _printer.PrintNormal(PrinterStation.Receipt, strPrintData + "\n");
                _printer.PrintNormal(PrinterStation.Receipt, "Payment Type : " + ESC + "bC" + cmbPaymentMode.Text + "\n");

                _printer.PrintNormal(PrinterStation.Receipt, ESC + "200uF");
                strPrintData = MakePrintString(_printer.RecLineChars, "Sales Person", DEFAULT_SALESPERSON);

                _printer.PrintNormal(PrinterStation.Receipt, strPrintData + "\n");

                //Make 5mm speces
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "500uF");

                _printer.PrintNormal(PrinterStation.Receipt, ESC + "cA" + Properties.Settings.Default.DefaultReceiptFooter.ToUpper() + "\n");
                //_printer.PrintNormal(PrinterStation.Receipt, ESC + "cA" + "PLEASE CHECK GOODS, RECEIPT AND CHANGE" + "\n");
                //_printer.PrintNormal(PrinterStation.Receipt, ESC + "cA" + "GOOD ARE NOT RETURNABLE" + "\n");
                //<<<step4>>>--End
                //<<<step5>>>--End
                _printer.PrintNormal(PrinterStation.Receipt, ESC + "500uF");

                _printer.PrintNormal(PrinterStation.Receipt, ESC + "fP");
                //<<<step2>>>--End
            }
            catch (PosControlException ex)
            {
                _logger.LogError(ex, "The application received an error when receipt was being printed", "ucSale", "PrintReceipt");
                Helper.ShowMessage("The application received an error when receipt was being printed \n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private long GetRecLineChars(ref int[] RecLineChars)
        {
            long lRecLineChars = 0;
            long lCount = _printer.RecLineCharsList.GetLength(0);
            int i;

            // Calculate the element count.

            if (lCount == 0)
            {
                lRecLineChars = 0;
            }
            else
            {
                if (lCount > MAX_LINE_WIDTHS)
                {
                    lCount = MAX_LINE_WIDTHS;
                }

                for (i = 0; i < lCount; i++)
                {
                    RecLineChars[i] = _printer.RecLineCharsList[i];
                }

                lRecLineChars = lCount;
            }

            return lRecLineChars;
        }

        // A maximum of 2 line widths will be considered
        const int MAX_LINE_WIDTHS = 2;

        /// <summary>
        /// PosPrinter object.
        /// </summary>


        /// <summary>
        /// An appropriate interval is converted into the length of
        /// the tab about two texts. And make a printing data.
        /// </summary>
        /// <param name="iLineChars">
        /// The width of the territory which it prints on is converted into the number of
        /// characters, and that value is specified.
        /// </param>
        /// <param name="strBuf">
        /// It is necessary as an information for deciding the interval of the text.
        /// </param>
        /// <param name="strPrice">
        /// It is necessary as an information for deciding the interval of the text, too.
        /// </param>
        /// <returns>printing data.
        /// </returns>
        public String MakePrintString(int iLineChars, String strBuf, String strPrice)
        {
            int iSpaces = 0;
            String tab = "";
            try
            {
                iSpaces = iLineChars - (strBuf.Length + strPrice.Length);
                for (int j = 0; j < iSpaces; j++)
                {
                    tab += " ";
                }
            }
            catch (Exception)
            {
            }
            return strBuf + tab + strPrice;
        }

        public String MakePrintString(int iLineChars, String strIttem, String qty, String strPrice)
        {
            int iSpaces = 0;
            String tab = "";
            try
            {
                iSpaces = iLineChars - (strIttem.Length + strPrice.Length + qty.Length);
                for (int j = 0; j < iSpaces - 5; j++)
                {
                    tab += " ";
                }
            }
            catch (Exception)
            {
            }
            return strIttem + tab + qty + "   " + strPrice;
        }

        string AddSpace(string data, int spaces)
        {
            //int iSpaces = 0;
            int dataSpace = 0;
            String tab = "";

            //iSpaces = iLineChars - data.Length;
            dataSpace = spaces - data.Length;

            for (int j = 0; j < dataSpace; j++)
            {
                tab += " ";
            }

            return tab;
        }

        string TruncText(string text, int length)
        {
            if (text.Length > length)
                return text.Substring(0, length);

            return text;
        }

        private void txtItemName_TextChanged_1(object sender, EventArgs e)
        {
            if (_fromBarCode) return;

            if (txtItemName.Text == "") return;

            frmchooseItem = Helper.CreateInstanceFor<frmChooseItem>("frmChooseItem");

            if (frmchooseItem == null)
            {
                SuscribeToEvent();
                frmchooseItem = new frmChooseItem();
                frmchooseItem.PositionForm(txtItemName.Top, txtItemName.Left);
                frmchooseItem.Show();
            }

            frmchooseItem.Visible = true;
            frmchooseItem.SetText(txtItemName.Text);
            txtItemName.Focus();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Focused)
                {
                    Product product = _product.GetSingle(p => p.Barcode == txtBarCode.Text);

                    if (product == null) return;

                    txtItemName.Text = product.ProductName;
                    txtItemName.Tag = product.ProductID;

                    txtUnitPrice.Text = product.UnitPrice.ToString();
                }
            }
        }

        private void btnVoidSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to reverse this sale?", "Void Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _saleDetail.ReverseSale(_voidSaleID, true);

                    btnVoidSale.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured", "Void Sale", "ucSale");
                Helper.ShowMessage("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
