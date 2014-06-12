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

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;

namespace storeManager.Reporting
{
    public partial class frmReportParameters : Form
    {
        private string repOption;
        DataSet dsReport;
        frmReportOutput repOutput = new frmReportOutput();
        //frmMessageDialog msg = new frmMessageDialog();
        ReportingClass repClass = new ReportingClass();

        private const int PARENT_NODE = 0;
        private int _saleTypeID;
        private const int DEFAULT_LOCALSTOREID = 1;

        public delegate DataSet GetReportData(int ReportMode);
       

        public frmReportParameters()
        {
            InitializeComponent();
            CenterToScreen();
            treeViewSalesReport.ExpandAll();
            treeViewPurchasesReport.ExpandAll();

            //PopulateCmb(); 
            ClearForm();
            btnCancel.Enabled = false;
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

        //private void PopulateCmb()
        //{
        //    SaleType[] sType = SaleType.Search();
        //    cmbSaleType.DataSource = sType;
        //    cmbSaleType.DisplayMember = "SaleTypeName";
        //    cmbSaleType.ValueMember = "SaleTypeID";

        //    try
        //    {
        //        cmbSaleType.SelectedIndex = 0;
        //    }
        //    catch (Exception)
        //    {

        //    }
           
            
        //}

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
                    //_saleTypeID = int.Parse(cmbSaleType.SelectedValue.ToString());
                    if (treeViewSalesReport.SelectedNode.Name == "CustomerSale" || treeViewSalesReport.SelectedNode.Name == "CustomerSaleDetails")
                    {
                        return;
                        if (chkCustUse.Checked)
                        {
                            if (!UtilityClass.ValidateTexBox(txtCustomer))
                                return;
                        }
                    }

                    if (chkUseStore.Checked)
                    {
                        if (!UtilityClass.ValidateTexBox(txtStore))
                            return;
                    }

                    repClass = new ReportingClass();
                    repOption = "";

                    //if (!treeViewSalesReport.Focus())
                    //{
                    //    return;
                    //}


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
                        case "":

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
                        case "AllItems":
                            repOption = "ProductListReport";
                            break;
                        case "OutOfStockItm":
                            repOption = "OutOfStockReport";
                            break;
                        case "ExpiryList":
                            if (!chkDateUse.Checked)
                            {
                                //new frmMessageDialog().ShowMessage("Please specify reporting dates", frmMessageDialog.IconType.Success);
                                return;
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
                    }
                }
            }
            catch (Exception)
            {
            }
           

            SetupStatusBar();
            bgwReportStatus.RunWorkerAsync();
        }

        //public void ReportParams(string repName)
        //{
        //    repOption = repName;

        //    switch (repOption)
        //    {
        //        case "InvoiceReport":
        //            this.Text = "Invoice report";
        //            break;
        //    }
        //}

        private void bgwReportStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwReportStatus.ReportProgress(0, "Working...");

            int _reportMode = 0;

            switch (repOption)
            {
                case "InvoiceReport":
                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }
                    if (chkSaleType.Checked) 
                    {
                        repClass.SaleTypeID = _saleTypeID;
                    }

                    if (chkUseStore.Checked)
                    {
                        repClass.StoreID = int.Parse(txtStore.Tag.ToString());
                    }
                    else
                        repClass.StoreID = DEFAULT_LOCALSTOREID;
                    _reportMode = 1;
                    break;
                case "InvoiceDetailsReport":
                    if (chkDateUse.Checked)
                    {
                        repClass.StartDate = dtpStartDate.Value.ToLongDateString();
                        repClass.EndDate = dtpEndDate.Value.ToLongDateString();
                    }

                    if (chkSaleType.Checked)
                    {
                        repClass.SaleTypeID = _saleTypeID;
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
                case "ProductListReport":
                case "StockSummaryReport":
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
            }

            GetReportData delGetReport = new GetReportData(repClass.GetReportDataSet);
            IAsyncResult result = delGetReport.BeginInvoke(_reportMode, null, null);

            while (result.IsCompleted == false)
            {
                if (bgwReportStatus.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }

            dsReport = delGetReport.EndInvoke(result);
            repOutput.RunReport(repOption, dsReport);

            bgwReportStatus.ReportProgress(100, "Completed");
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
                //msg.ShowMessage("Report is empty", frmMessageDialog.IconType.Success);
                btnCancel.Enabled = false;
                return;
            }

            repOutput.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            btnCancel.Enabled = false;
            repOutput.ShowDialog(this);         
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

        //private void btnAddCustomer_Click(object sender, EventArgs e)
        //{
        //    frmChooseCustomer cust = new frmChooseCustomer();

        //    DataTable dtCat = Customer.GetCustomer();

        //    UtilityClass.PopulateListviewWithDataTable(cust.lvCustomers, dtCat);
        //    cust.ShowDialog();

        //    if (cust.DialogResult == DialogResult.OK)
        //    {
        //        txtCustomer.Text = cust.lvCustomers.SelectedItems[0].SubItems[1].Text;
        //        txtCustomer.Tag = cust.lvCustomers.SelectedItems[0].SubItems[0].Text;
        //    }
        //}

        private void chkCustUse_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = chkCustUse.Checked;
        }

        private void treeViewReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
                //btnRunReport.Enabled = treeViewSalesReport.SelectedNode.Nodes.Count == 0;
        }

        //private void btnChooseStore_Click(object sender, EventArgs e)
        //{
        //    DataTable dtStore = new ExecuteStoredProc().fetchStoredProc("prc_Stores_Get");
        //    frmChooseStore store = new frmChooseStore();

        //    UtilityClass.PopulateListviewWithDataTable(store.lvStores, dtStore);
        //    store.ShowDialog();

        //    if (store.lvStores.SelectedIndices.Count == 0)
        //    {
        //        return;
        //    }

        //    if (store.DialogResult == DialogResult.OK)
        //    {
        //        txtStore.Text = store.lvStores.SelectedItems[0].SubItems[1].Text;
        //        txtStore.Tag = store.lvStores.SelectedItems[0].SubItems[0].Text;
        //    }
        //}

        //private void btnChooseBrand_Click(object sender, EventArgs e)
        //{
        //    DataTable dtBrand = new ExecuteStoredProc().fetchStoredProc("prc_Brand_Get");
        //    frmChooseBrand brand = new frmChooseBrand();
        //    frmChooseBrand frm = Application.OpenForms["frmChooseBrand"] as frmChooseBrand;

        //    if (frm != null)
        //    {
        //        frm.lvBrands.Items.Clear();
        //        UtilityClass.PopulateListviewWithDataTable(frm.lvBrands, dtBrand);
        //        frm.Activate();
        //    }
        //    else
        //    {
        //        brand = new frmChooseBrand();
        //        UtilityClass.PopulateListviewWithDataTable(brand.lvBrands, dtBrand);
        //        brand.ShowDialog();
        //    }         

        //    if (brand.DialogResult == DialogResult.OK)
        //    {
        //        txtBrand.Text = brand.lvBrands.SelectedItems[0].SubItems[1].Text;
        //        txtBrand.Tag = brand.lvBrands.SelectedItems[0].SubItems[0].Text;
        //    }
        //}

        //private void btnChooseCategory_Click(object sender, EventArgs e)
        //{
        //    DataTable dtCategory = new ExecuteStoredProc().fetchStoredProc("prc_Category_Get");
        //    frmChooseCategory category = new frmChooseCategory();
        //    frmChooseCategory frm = Application.OpenForms["frmChooseCategory"] as frmChooseCategory;

        //    if (frm != null)
        //    {
        //        frm.lvCategory.Items.Clear();
        //        UtilityClass.PopulateListviewWithDataTable(frm.lvCategory, dtCategory);
        //        frm.Activate();
        //    }
        //    else
        //    {
        //        category = new frmChooseCategory();
        //        UtilityClass.PopulateListviewWithDataTable(category.lvCategory, dtCategory);
        //        category.ShowDialog();
        //    }

        //    if (category.DialogResult == DialogResult.OK)
        //    {
        //        txtCategory.Text = category.lvCategory.SelectedItems[0].SubItems[1].Text;
        //        txtCategory.Tag = category.lvCategory.SelectedItems[0].SubItems[0].Text;
        //    }
        //}

        private void ClearForm()
        {
            chkCategory.Checked = false;
            chkCustUse.Checked = false;
            chkDateUse.Checked = false;
            chkSaleType.Checked = false;
            chkUseBrand.Checked = false;
            chkUseStore.Checked = false;
        }
    }
}
