using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace storeManager.Reporting
{
    public partial class frmReportOutput : Form
    {
        public bool NoRows { get; set; }

        public frmReportOutput()
        {
            InitializeComponent();
        }

        public void RunReport(string repName, DataSet dsReport)
        {
            Cursor.Current = Cursors.WaitCursor;
            NoRows = false;

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(()=>
                {

                }));
            }

            switch (repName)
            {
                case "InvoiceReport":
                    rptInvoiceReport invoiceRep = new rptInvoiceReport();
                    invoiceRep.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = invoiceRep;
                    break;
                case "InvoiceDetailsReport":
                    rptSaleDetailsReport invoiceDetails = new rptSaleDetailsReport();
                    invoiceDetails.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = invoiceDetails;
                    break;
                case "CustomerSaleReport":
                    rptCustomerSalesReport customerDetails = new rptCustomerSalesReport();
                    customerDetails.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = customerDetails;
                    break;
                case "ExpiryListReport":
                    rptExpiryList expiryList = new rptExpiryList();
                    expiryList.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = expiryList;
                    break;
                case "OutOfStockReport":
                    rptOutOfStock outOfStock = new rptOutOfStock();
                    outOfStock.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = outOfStock;
                    break;
                case "ProductListReport":
                    rptProductList productList = new rptProductList();
                    productList.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = productList;
                    break;
                case "ReorderListReport":
                    rptReorderList reorderList = new rptReorderList();
                    reorderList.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = reorderList;
                    break;
                case "StockAjustmentsReport":
                    rptStockAdjustments stockAdjustment = new rptStockAdjustments();
                    stockAdjustment.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = stockAdjustment;
                    break;
                case "CountSheet":
                    rptCountSheet countSheet = new rptCountSheet();
                    countSheet.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = countSheet;
                    break;
                case "StockSummaryReport":
                    rptStockSummary stockSummary = new rptStockSummary();
                    stockSummary.SetDataSource(dsReport.Tables[0]);
                    crystalReportViewerRep.ReportSource = stockSummary;
                    break;
                default:
                    NoRows = true;
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
