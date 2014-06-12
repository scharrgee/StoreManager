using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Runtime.Remoting.Messaging;

using System.Xml;
using System.Xml.Xsl;
using System.IO;

using System.Linq;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI;
using storeManager.UI.EventHub;

namespace storeManager.UI.Reporting
{
    public partial class frmReportParameters : Form
    {
        private string repOption;
        DataSet dsReport;
        frmReportOutput repOutput = new frmReportOutput();
        //frmMessageDialog msg = new frmMessageDialog();
        ReportingClass repClass = new ReportingClass();

        private const int PARENT_NODE = 0;
        //private int _saleTypeID;
        private const int DEFAULT_LOCALSTOREID = 1;

        public delegate DataSet GetReportData(int ReportMode);

        List<string> AllOptions = new List<string>();
        List<string> DateOptions = new List<string>();


        public frmReportParameters()
        {
            InitializeComponent();
            CenterToScreen();
            treeViewSalesReport.ExpandAll();
            //treeViewPurchasesReport.ExpandAll();
            treeViewIventoryReport.ExpandAll();

            PopulateSaleStatusCmb();
            ClearForm();
            btnCancel.Enabled = false;
            Hub.GenericInfo += new EventHandler<EventHubAgs>(Hub_GenericInfo);


        }


        void SetUpOptions()
        {
            AllOptions.Add("");
            AllOptions.Add("");
            AllOptions.Add("");
            AllOptions.Add("");
            AllOptions.Add("");
            AllOptions.Add("");
            AllOptions.Add("");
            AllOptions.Add("");
            AllOptions.Add("");

            DateOptions.Add("");
            DateOptions.Add("");
            DateOptions.Add("");
            DateOptions.Add("");
        }

        private void SetupStatusBar()
        {
            this.toolStripReportProgressBar.Maximum = 900;
            this.toolStripReportProgressBar.Minimum = 0;
            this.toolStripReportProgressBar.Step = 20;

            this.toolStripReportProgressBar.Visible = true;
            this.toolStripReportProgressBar.Value += 20;
            this.reportTimer.Start();
            //this.timer1.Enabled = true;
        }

        private void DisableStatusBar()
        {
            this.toolStripReportProgressBar.Visible = false;
            this.toolStripReportProgressBar.Value = 0;
            //this.statusStrip1.Visible = false;
            this.reportTimer.Enabled = false;

        }

        private void PopulateSaleStatusCmb()
        {
            cmbSaleType.DataSource = new GenericService<SaleStatus>().GetAll(); ;
            cmbSaleType.DisplayMember = "Status";
            cmbSaleType.ValueMember = "id";

            try
            {
                cmbSaleType.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }


        }

        private void DisplayProgress(bool barEnd)
        {
            if (barEnd == false)
            {
                if (this.toolStripReportProgressBar.Value >= 900)
                {
                    this.toolStripReportProgressBar.Value = 0;
                }
                else
                    this.toolStripReportProgressBar.Value += 20;
            }
            else
                this.toolStripReportProgressBar.Value = (this.toolStripReportProgressBar.Maximum);


            return;

        }

        private void reportTimer_Tick(object sender, EventArgs e)
        {
            if (this.toolStripReportProgressBar.Value >= 900)
            {
                this.toolStripReportProgressBar.Value = 0;
            }
            else
                this.toolStripReportProgressBar.Value += 20;

            return;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            dsReport = new DataSet();
            repClass = new ReportingClass();

            try
            {
                if (treeViewSalesReport.Focus())
                {

                    repClass = new ReportingClass();
                    repOption = "";

                    switch (treeViewSalesReport.SelectedNode.Name)
                    {
                        case "itmSales":
                            repOption = "InvoiceReport";
                            break;
                        case "itmSalesDetails":
                            repOption = "InvoiceDetailsReport";
                            break;
                        case "CustomerSale":
                            repOption = "CustomerSaleReport";
                            break;
                        case "SaleByProductSummary":
                            repOption = "SaleByProductSummaryReport";
                            break;
                        case "SaleByProductDetail":
                            repOption = "SaleByProductDetailReport";
                            break;
                        case "EndOfDay":
                            repOption = "EndOfDaySalesReport";
                            break;
                        case "EndOfDayProducts":
                            repOption = "EndOfDayProductsReport";
                            break;
                        case "EndOfDayProductsSummary":
                            repOption = "EndOfDayProductsSummaryReport";
                            break;
                        case "CustSaleSummary":
                            repOption = "CustSaleSummaryReport";
                            break;
                        case "CustSaleDetail":
                            repOption = "CustSaleDetailReport";
                            break;
                        case "VoidedSales":
                            repOption = "VoidedSalesReport";
                            break;
                    }
                }

                if (treeViewIventoryReport.Focus())
                {
                    switch (treeViewIventoryReport.SelectedNode.Name)
                    {
                        case "ReorderList":
                            repOption = "ReorderListReport";
                            break;
                        case "Location":
                            repOption = "ProductListReportByLocation";
                            break;
                        case "Category":
                            repOption = "ProductListReportByCategory";
                            break;
                        case "Supplier":
                            repOption = "ProductListReportBySupplier";
                            break;
                        case "Brand":
                            repOption = "ProductListReportByBrand";
                            break;
                        case "ProductPriceList":
                            repOption = "ProductPriceListReport";
                            break;
                        case "OutOfStockItm":
                            repOption = "OutOfStockReport";
                            break;
                        case "ExpiryList":
                            if (!chkDateUse.Checked)
                            {
                                //new frmMessageDialog().ShowMessage("Please specify reporting dates", frmMessageDialog.IconType.Success);
                                //return;
                            }
                            repOption = "ExpiryListReport";
                            break;
                        case "CountSheet":
                            repOption = "CountSheet";
                            break;
                        case "StockAdjustments":
                            repOption = "StockAjustmentsReport";
                            break;
                        case "StockSummary":
                            repOption = "StockSummaryReport";
                            break;
                        case "StockDetails":
                            repOption = "StockDetailsReport";
                            break;
                        case "EODStockDetails":
                            repOption = "EODStockDetailsReport";
                            break;
                        case "StockTransferHistory":
                            repOption = "StockTransferHistoryReport";
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }

            RunReport();

        }

        void RunReport()
        {
            int _reportMode = 0;

            switch (repOption)
            {
                case "InvoiceReport":
                case "VoidedSalesReport":
                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }
                    if (chkSaleType.Checked)
                    {
                        repClass.SaleTypeID = cmbSaleType.SelectedValue.ToInt();
                    }

                    if (chkUseStore.Checked)
                    {
                        repClass.StoreID = int.Parse(txtStore.Tag.ToString());
                    }
                    else
                        repClass.StoreID = DEFAULT_LOCALSTOREID;
                    repClass.VoidSale = repOption == "InvoiceReport" ? 0 : 1;

                    _reportMode = 1;
                    break;

                case "InvoiceDetailsReport":
                case "SaleByProductSummaryReport":
                case "SaleByProductDetailReport":
                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    if (chkSaleType.Checked)
                    {
                        repClass.SaleTypeID = cmbSaleType.SelectedValue.ToInt(); ;
                    }

                    if (chkUseStore.Checked)
                    {
                        repClass.StoreID = int.Parse(txtStore.Tag.ToString());
                    }
                    else
                        repClass.StoreID = DEFAULT_LOCALSTOREID;

                    _reportMode = 2;
                    break;
                case "CustomerSaleReport":

                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    if (chkCustUse.Checked)
                    {
                        repClass.CustomerID = txtCustomer.Tag.ToString();
                    }
                    _reportMode = 3;
                    break;
                case "ExpiryListReport":

                    if (chkDateUse.Checked)
                    {

                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    if (chkUseBrand.Checked)
                    {
                        repClass.BrandID = int.Parse(txtBrand.Tag.ToString());
                    }

                    if (chkCategory.Checked)
                    {
                        repClass.CategoryID = Convert.ToInt16(txtCategory.Tag);
                    }
                    _reportMode = 4;
                    break;
                case "OutOfStockReport":

                    if (chkUseBrand.Checked)
                    {
                        repClass.BrandID = int.Parse(txtBrand.Tag.ToString());
                    }

                    if (chkCategory.Checked)
                    {
                        repClass.CategoryID = Convert.ToInt16(txtCategory.Tag);
                    }
                    _reportMode = 5;
                    break;
                case "ProductListReportByLocation":
                case "StockSummaryReport":
                case "ProductListReportByCategory":
                case "ProductListReportBySupplier":
                case "ProductListReportByBrand":
                    if (chkUseBrand.Checked)
                    {
                        repClass.BrandID = int.Parse(txtBrand.Tag.ToString());
                    }

                    if (chkCategory.Checked)
                    {
                        repClass.CategoryID = Convert.ToInt16(txtCategory.Tag);
                    }
                    _reportMode = 6;
                    break;
                case "ProductPriceListReport":
                    if (chkUseBrand.Checked)
                    {
                        repClass.BrandID = int.Parse(txtBrand.Tag.ToString());
                    }

                    if (chkCategory.Checked)
                    {
                        repClass.CategoryID = Convert.ToInt16(txtCategory.Tag);
                    }
                    _reportMode = 11;
                    break;
                case "ReorderListReport":

                    if (chkUseBrand.Checked)
                    {
                        repClass.BrandID = int.Parse(txtBrand.Tag.ToString());
                    }

                    if (chkCategory.Checked)
                    {
                        repClass.CategoryID = Convert.ToInt16(txtCategory.Tag);
                    }
                    _reportMode = 7;
                    break;
                case "StockAjustmentsReport":

                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    _reportMode = 8;
                    break;
                case "CountSheet":

                    if (chkUseBrand.Checked)
                    {
                        repClass.BrandID = int.Parse(txtBrand.Tag.ToString());
                    }

                    if (chkCategory.Checked)
                    {
                        repClass.CategoryID = Convert.ToInt16(txtCategory.Tag);
                    }
                    _reportMode = 9;
                    break;
                case "EndOfDaySalesReport":

                    repClass.StartDate = DateTime.Now.ToLongDateString();
                    repClass.EndDate = DateTime.Now.ToLongDateString();

                    if (chkSaleType.Checked)
                    {
                        repClass.SaleTypeID = cmbSaleType.SelectedValue.ToInt();
                    }

                    if (chkUseStore.Checked)
                    {
                        repClass.StoreID = int.Parse(txtStore.Tag.ToString());
                    }
                    else
                        repClass.StoreID = DEFAULT_LOCALSTOREID;
                    _reportMode = 1;
                    break;
                case "EndOfDayProductsReport":
                case "EndOfDayProductsSummaryReport":
                    repClass.StartDate = DateTime.Now.ToLongDateString();
                    repClass.EndDate = DateTime.Now.ToLongDateString();

                    if (chkSaleType.Checked)
                    {
                        repClass.SaleTypeID = cmbSaleType.SelectedValue.ToInt();
                    }

                    if (chkUseStore.Checked)
                    {
                        repClass.StoreID = int.Parse(txtStore.Tag.ToString());
                    }
                    else
                        repClass.StoreID = DEFAULT_LOCALSTOREID;
                    _reportMode = 2;
                    break;
                case "StockDetailsReport":

                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    _reportMode = 12;
                    break;
                case "EODStockDetailsReport":

                    repClass.StartDate = DateTime.Now.ToLongDateString();
                    repClass.EndDate = DateTime.Now.ToLongDateString();

                    _reportMode = 12;
                    break;
                case "StockTransferHistoryReport":

                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    _reportMode = 13;
                    break;
                case "CustSaleSummaryReport":

                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }
                    if (chkSaleType.Checked)
                    {
                        repClass.SaleTypeID = cmbSaleType.SelectedValue.ToInt();
                    }
                    if (!Helper.ValidateTexBox(txtCustomer))
                        return;

                    repClass.CustomerID = txtCustomer.Tag.ToString();

                    _reportMode = 14;
                    break;
                case "CustSaleDetailReport":

                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    if (chkSaleType.Checked)
                    {
                        repClass.SaleTypeID = cmbSaleType.SelectedValue.ToInt();
                    }

                    if (!Helper.ValidateTexBox(txtCustomer))
                        return;

                    repClass.CustomerID = txtCustomer.Tag.ToString();

                    _reportMode = 15;
                    break;
            }

            dsReport = repClass.GetReportDataSet(_reportMode);
            repOutput.RunReport(repOption, dsReport);
            repOutput.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            btnCancel.Enabled = false;
            repOutput.ShowDialog(this);
        }



        private void bgwReportStatus_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripReportProgressBar.Value = e.ProgressPercentage;
            toolStripStatusLabelComplete.Text = e.UserState.ToString();
        }

        private void bgwReportStatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DisableStatusBar();

            if (e.Cancelled)
            {
                toolStripStatusLabelComplete.Text = "Cancelled";
                return;
            }

            if (repOutput.NoRows)
            {
                btnCancel.Enabled = false;
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            bgwReportStatus.CancelAsync();
        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = chkDateUse.Checked;
            dtpStartDate.Enabled = chkDateUse.Checked;
        }

        private void chkCustUse_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = chkCustUse.Checked;
        }

        private void treeViewReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewSalesReport.Focus())
            {
                switch (treeViewSalesReport.SelectedNode.Name)
                {
                    case "itmSales":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "itmSalesDetails":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "CustomerSale":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(true);
                        EnableDates(true);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                    case "SaleByProductSummary":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "SaleByProductDetail":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "EndOfDay":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "EndOfDayProducts":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "EndOfDayProductsSummary":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "CustSaleSummary":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(true);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(false);
                        break;
                    case "CustSaleDetail":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(true);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(false);
                        break;
                    case "VoidedSales":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                }
            }

            if (treeViewIventoryReport.Focus())
            {
                switch (treeViewIventoryReport.SelectedNode.Name)
                {
                    case "ReorderList":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "Location":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(true);
                        break;
                    case "Category":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(true);
                        break;
                    case "Supplier":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(true);
                        break;
                    case "Brand":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(true);
                        break;
                    case "ProductPriceList":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                    case "OutOfStockItm":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(true);
                        break;
                    case "ExpiryList":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                    case "CountSheet":
                        EnableBrand(true);
                        EnableCategory(true);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                    case "StockAdjustments":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                    case "StockSummary":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(true);
                        EnableStore(true);
                        break;
                    case "StockDetails":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                    case "EODStockDetails":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(false);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                    case "StockTransferHistory":
                        EnableBrand(false);
                        EnableCategory(false);
                        EnableCustomer(false);
                        EnableDates(true);
                        EnableSaleStatus(false);
                        EnableStore(false);
                        break;
                }
            }
        }



        private void ClearForm()
        {
            chkCategory.Checked = false;
            chkCustUse.Checked = false;
            chkDateUse.Checked = false;
            chkSaleType.Checked = false;
            chkUseBrand.Checked = false;
            chkUseStore.Checked = false;
        }

        private void btnChooseBrand_Click(object sender, EventArgs e)
        {
            new frmChooseBrand("txtBrand;chkUseBrand").Show();
        }

        void Hub_GenericInfo(object sender, EventHubAgs e)
        {
            string[] controls = e.ControlName.Split(';');


            TextBox txt = this.Controls.Find(controls[0], true).FirstOrDefault() as TextBox;

            if (controls.Length > 1)
            {
                CheckBox chk = this.Controls.Find(controls[1], true).FirstOrDefault() as CheckBox;
                chk.Checked = true;
            }

            if (txt == null) return;

            txt.Text = e.Data.ToString();
            txt.Tag = e.ID;


        }

        private void btnChooseCategory_Click(object sender, EventArgs e)
        {
            new frmChooseCategory("txtCategory;chkCategory").ShowDialog();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new frmChooseCustomer(false, "txtCustomer;chkCustUse").ShowDialog();
        }

        void EnableDates(bool status)
        {
            gbDates.Enabled = status;
        }

        void EnableSaleStatus(bool status)
        {
            cmbSaleType.Enabled = status;
            chkSaleType.Enabled = status;
        }

        void EnableCustomer(bool status)
        {
            txtCustomer.Enabled = status;
            btnAddCustomer.Enabled = status;
            chkCustUse.Enabled = status;
        }

        void EnableStore(bool status)
        {
            txtStore.Enabled = status;
            btnChooseStore.Enabled = status;
            chkUseStore.Enabled = status;
        }

        void EnableBrand(bool status)
        {
            txtBrand.Enabled = status;
            btnChooseBrand.Enabled = status;
            chkUseBrand.Enabled = status;
        }

        void EnableCategory(bool status)
        {
            txtCategory.Enabled = status;
            btnChooseCategory.Enabled = status;
            chkCategory.Enabled = status;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            chkDateUse.Checked = true;
        }

        private void btnChooseStore_Click(object sender, EventArgs e)
        {

        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            chkUseBrand.Checked = txtBrand.Text != "";
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            chkCategory.Checked = txtCategory.Text != "";
        }
    }
}
