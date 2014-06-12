using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using storeManager.UI;
using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;

namespace storeManager.UI.Controls
{
    public partial class ucQuote : UserControl
    {

        private readonly string DEFAULT_CUSTOMER = "CASH CUSTOMER";
        private readonly string DEFAULT_CUSTID = "99999";
        private readonly string DEFAULT_SALESPERSON = "DEFAULT SALES PERSON";
        private readonly string DEFAULT_SALESPERSONID = "99999";
        private readonly int DEFAULT_LOCALSTOREID = 1;
        private bool _fromBarCode = false;

        private ICustomerService _customer;
        private ISaleDetailService _saleDetail;
        private ISaleService _sale;
        private IProductService _product;
        private ITaxService _tax;
        private IPaymentModeService _paymentMode;
        private IErrorService _logger;
        private Company company;
        private frmChooseItem frmchooseItem = null;

        public SaleStatuses Status { get; set; }
        public Prefix SalePrefix { get; set; }

        Prefix _prefix = Prefix.QUO;

        public ucQuote(Prefix prefix)
        {
            InitializeComponent();
            Init();

            _prefix = prefix;

            SetUpDefaults();
            GetInvoiceNo();
            LoadPaymentModeCmb();
            LoadLocationCmb();

            Hub.EditSale += new EventHandler<EditSaleEventArgs>(Hub_EditSale);
        }

        void Hub_EditSale(object sender, EditSaleEventArgs e)
        {
            Sale sale = _sale.GetSingle(s => s.SaleID == e.SaleID);

            cmbLocation.SelectedValue = new GenericService<Company>().GetAll().FirstOrDefault().DefaultLocation;
            txtCustomer.Text = _customer.GetSingle(c => c.CustomerID == int.Parse(sale.CustomerID)).CustomerName;
            txtCustomer.Tag = sale.CustomerID;
            txtSalesPerson.Text = new GenericService<User>().GetSingle(s => s.EmployeeID == int.Parse(sale.EmployeeID)).UserName;
            txtInvoiceNo.Text = sale.InvoiceNumber;
            txtSubTotal.Text = sale.SubTotal.ToString();
            //txtTax.Text = sale.Tax.ToString();
            //txtDiscount.Text = sale.Discount.ToString();
            txtTotalAmt.Text = sale.Amount.ToString();
            txtAmountPaid.Text = sale.AmountPaid.ToString();
            txtBalanceDue.Text = sale.Balance.ToString();

            GetSaleDetails(e.SaleID);

            ConfigureFormAsReadOnly();
        }

        private void ConfigureFormAsReadOnly()
        {
            Helper.MakeReadOnly(this);

            btnAddCustomer.Enabled = false;
            //btnCalculateDiscount.Enabled = false;
            btnCancel.Enabled = false;
            btnChooseProduct.Enabled = false;
            btnChooseSalePerson.Enabled = false;
            //btnChooseTax.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = false;
            btnNew.Enabled = false;
            btnSaleDiscCal.Enabled = false;
            btnSaleTax.Enabled = false;

            btnRecord.Text = "OK";
        }

        private void GetSaleDetails(int saleid)
        {
            List<SaleDetail> saledetails = _saleDetail.Query(s => s.SaleID == saleid).ToList();

            try
            {
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
            catch
            {
            }


        }

        void Hub_GenericInfo(object sender, EventHubAgs e)
        {
            TextBox txt = this.Controls.Find(e.ControlName, true).FirstOrDefault() as TextBox;

            if (txt == null) return;

            string name = e.Data.Split(",".ToArray())[0];

            txt.Text = name;

            if (e.Data.Split(",".ToArray()).Count() > 1)
            {
                string[] data = e.Data.Split(",".ToArray());
                string productPrice = data[1];
                txtUnitPrice.Text = productPrice;
                lblMeasurement.Text = data[2];

                txtQty.Focus();
            }

            txt.Tag = e.ID;
        }

        void SetUpDefaults()
        {
            txtCustomer.Text = DEFAULT_CUSTOMER;
            txtCustomer.Tag = DEFAULT_CUSTID;

            txtSalesPerson.Text = DEFAULT_SALESPERSON;
            txtSalesPerson.Tag = DEFAULT_SALESPERSONID;

            Helper.SetControlName("ucQuote");
        }

        private void Init()
        {
            _customer = new CustomerService();
            _sale = new SaleService();
            _saleDetail = new SaleDetailService();
            _product = new ProductService();
            _paymentMode = new PaymentModeService();
            _tax = new TaxService();
            _logger = new ErrorLogService();

            company = new GenericService<Company>().GetAll().FirstOrDefault();
        }

        private void btnInsert_Click(object sender, EventArgs e)
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
            txtInvoiceNo.Text = Helper.GetInvoiceNo(_prefix.ToString());
        }

        private void PopulateGrid()
        {
            decimal discount = 0;
            decimal tax = 0;
            decimal subTotal = 0;

            object[] rows = new object[7];
            rows[0] = txtQty.Text;
            rows[1] = txtItemName.Tag;
            rows[2] = txtItemName.Text;
            rows[3] = txtUnitPrice.Text;

            //discount = txtSaleDiscount.Text == "" ? 0 : decimal.Parse(txtDiscount.Text) / 100;
            //tax = txtTax.Text == "" ? 0 : decimal.Parse(txtTax.Text) / 100;

            subTotal = int.Parse(txtQty.Text) * decimal.Parse(txtUnitPrice.Text);

            rows[4] = Math.Round(discount * subTotal, 2);
            rows[5] = Math.Round(tax * subTotal, 2);
            rows[6] = Math.Round(subTotal - (discount * subTotal) + (tax * subTotal), 2);

            gridViewItemLayout.Rows.Add(rows);
        }

        private void CalculateItemsCost()
        {
            decimal discount = 0;
            decimal subTotal = 0;
            decimal total = 0;
            decimal tax = 0;
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

                    tax = gr.Cells[5].Value.ToString() == "" ? 0 : decimal.Parse(gr.Cells[5].Value.ToString());

                    _sale.CalculateLineTotal(lineItemQty, lineItemPrice, tax, discount, out subTotal, out total);

                    saleSubTotal += subTotal;
                }
            }

            decimal taxAmt = txtSalTax.Text == "" ? 0 : txtSalTax.Text.ToDecimal();
            decimal discountamt = txtSaleDiscount.Text == "" ? 0 : txtSaleDiscount.Text.ToDecimal();

            txtSubTotal.Text = Math.Round(saleSubTotal, 2).ToString();
            txtTotalAmt.Text = (CalculateTax((saleSubTotal - discountamt), taxAmt)).ToString();
        }

        private decimal CalculateTax(decimal totalSaleSubTotal, decimal taxAmt)
        {
            return Math.Round(totalSaleSubTotal, 2) + _sale.CalculateTax(totalSaleSubTotal, taxAmt);
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (btnRecord.Text == "OK")
            {
                ((frmControlHost)this.Parent).Close();
                return;
            }

            if (gridViewItemLayout.Rows.Count == 0)
            {
                Helper.ShowMessage("Sale must contain at least one product",
                    "Sale Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Product product;
                SaleDetail salesDetails;
                Sale sales = new Sale();

                string InvoiceNo = txtInvoiceNo.Text;
                string AmountPaid = txtAmountPaid.Text;
                string subTotalAmt = txtSubTotal.Text;
                DateTime? SaleDate = dtpSaleDate.Value;
                decimal tax = txtSalTax.Text.ToDecimal();
                int locationID = cmbLocation.SelectedValue.ToInt();
                decimal saletax = _sale.CalculateTax(subTotalAmt.ToDecimal(), tax);
                decimal totalAmount = txtTotalAmt.Text.ToDecimal();

                sales.CustomerID = txtCustomer.Tag.ToString();
                sales.Amount = totalAmount;
                sales.CustBalance = totalAmount;
                sales.SubTotal = decimal.Parse(subTotalAmt);
                sales.InvoiceDate = SaleDate.Value;
                sales.InvoiceNumber = InvoiceNo;
                sales.StoreID = DEFAULT_LOCALSTOREID; //arbituary value, to bo replaced
                sales.Tax = Math.Round(saletax, 2);
                sales.PaymentModeID = int.Parse(cmbPaymentMode.SelectedValue.ToString());

                sales.AmountPaid = 0;
                sales.Balance = 0;
                sales.DateClosed = null;

                sales.SaleStatusID = (int)Status;//_sale.GetSaleStatus(totalAmount, AmountPaid.ToDecimal());
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
                    _logger.LogError(ex, "An error occurred", "ucQuote", "btnRecord");
                    Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (DataGridViewRow dr in gridViewItemLayout.Rows)
                {
                    if (dr.Cells[0].Value == null)
                    {
                        return;
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

                    try
                    {
                        _saleDetail.Add(salesDetails);
                    }
                    catch(Exception ex)
                    {
                        _sale.RollBackSaleTransaction(InvoiceNo);
                        _logger.LogError(ex, "An error occurred", "ucQuote", "btnRecord");
                        Helper.ShowMessage("Transaction was not completed, An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                txtInvoiceNo.Tag = false;

                txtSubTotal.Tag = null;
                txtTotalAmt.Tag = null;

                Helper.ClearForm(this);
                gridViewItemLayout.Rows.Clear();

                lblStatus.Text = "Quote recorded successfully";

                GetInvoiceNo();
            }
            catch (Exception ex)
            {

                Helper.ShowMessage("An error occured sale has been cancelled \n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        }

        void LoadPaymentModeCmb()
        {
            cmbPaymentMode.DataSource = new GenericService<PaymentMode>().GetAll();
            cmbPaymentMode.DisplayMember = "PayMode";
            cmbPaymentMode.ValueMember = "PaymentModeID";
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

        private void btnChooseTax_Click(object sender, EventArgs e)
        {
            SuscribeToEvent();
            new frmChooseTax().ShowDialog();
            UnsuscribeEvent();
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
            TextBox txt = this.Controls.Find(e.ControlName, true).FirstOrDefault() as TextBox;

            if (txt == null) return;

            string name = e.Data.Split(",".ToArray())[0];
            string taxrate = e.Data.Split(",".ToArray())[1];

            txt.Text = Math.Round(taxrate.ToDecimal(), 2).ToString();
            lblSaleTax.Text = name;

            txt.Tag = e.ID;
        }

        void LoadLocationCmb()
        {
            IEnumerable<Location> location = new GenericService<Location>().GetAll().Where(l => l.Id == company.DefaultLocation).ToList();
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
            if (gridViewItemLayout.Rows.Count == 0) return;

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

        private void ucQuote_Load(object sender, EventArgs e)
        {
            Helper.CreateInstanceFor<frmMain>("frmMain").Text = "New Quote";
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
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

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
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
    }
}
