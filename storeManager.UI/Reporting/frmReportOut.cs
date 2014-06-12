using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace storeManager.UI.Reporting
{
    public partial class frmReportOutput : Form
    {
        public bool NoRows { get; set; }
        bool _barcodeprinting = false;
        DataTable _barCodes;

        public frmReportOutput()
        {
            InitializeComponent();

            AttachPrintHandler();
        }

        public frmReportOutput(bool barcodeprinting,DataTable barcodes)
        {
            InitializeComponent();

            AttachPrintHandler();
            _barcodeprinting = barcodeprinting;
            _barCodes = barcodes;
        }

        private void AttachPrintHandler()
        {
            foreach (ToolStrip ts in crystalReportViewerRep.Controls.OfType<ToolStrip>())
            {
                foreach (ToolStripButton tsb in ts.Items.OfType<ToolStripButton>())
                {
                    //hacky but should work. you can probably figure out a better method
                    if (tsb.ToolTipText.ToLower().Contains("print"))
                    {
                        //Adding a handler for our propose
                        tsb.Click += new EventHandler(printButton_Click);
                    }
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Printed");
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
                    rptSalesReport invoiceRep = new rptSalesReport();
                    invoiceRep.SetDataSource(dsReport);
                    invoiceRep.Subreports[0].SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = invoiceRep;
                    break;
                case "EndOfDaySalesReport":
                    rptEndOfDayInvoiceReport endofdayRep = new rptEndOfDayInvoiceReport();
                    endofdayRep.SetDataSource(dsReport);
                    endofdayRep.Subreports[0].SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = endofdayRep;
                    break;
                case "InvoiceDetailsReport":
                    rptSaleDetailsReport invoiceDetails = new rptSaleDetailsReport();
                    invoiceDetails.SetDataSource(dsReport);
                    invoiceDetails.Subreports[0].SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = invoiceDetails;
                    break;
                case "EndOfDayProductsReport":
                    rptEODSaleByProductDetailsReport endofdayProdRep = new rptEODSaleByProductDetailsReport();
                    endofdayProdRep.SetDataSource(dsReport);
                    endofdayProdRep.Subreports[0].SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = endofdayProdRep;
                    break;
                case "EndOfDayProductsSummaryReport":
                    rptEODSaleByProductSummaryReport endofdayProdSumRep = new rptEODSaleByProductSummaryReport();
                    endofdayProdSumRep.SetDataSource(dsReport);
                    endofdayProdSumRep.Subreports[0].SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = endofdayProdSumRep;
                    break;
                case "CustomerSaleReport":
                    rptCustomerSalesReport customerDetails = new rptCustomerSalesReport();
                    customerDetails.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = customerDetails;
                    break;
                case "SaleByProductSummaryReport":
                    rptSaleByProductSummaryReport saleByProductSummary = new rptSaleByProductSummaryReport();
                    saleByProductSummary.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = saleByProductSummary;
                    break;
                case "SaleByProductDetailReport":
                    rptSaleByProductDetailsReport saleByProductDetail = new rptSaleByProductDetailsReport();
                    saleByProductDetail.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = saleByProductDetail;
                    break;
                case "ExpiryListReport":
                    rptExpiryList expiryList = new rptExpiryList();
                    expiryList.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = expiryList;
                    break;
                case "OutOfStockReport":
                    rptOutOfStock outOfStock = new rptOutOfStock();
                    outOfStock.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = outOfStock;
                    break;
                case "ProductListReportByLocation":
                    rptProductListByLocation productListbyloc = new rptProductListByLocation();
                    productListbyloc.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = productListbyloc;
                    break;
                case "ProductListReportByCategory":
                    rptProductListByCategory productListbycat = new rptProductListByCategory();
                    productListbycat.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = productListbycat;
                    break;
                case "ProductListReportBySupplier":
                    rptProductListBySupplier productListbysup = new rptProductListBySupplier();
                    productListbysup.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = productListbysup;
                    break;
                case "ProductListReportByBrand":
                    rptProductListByBrand productListbybrand = new rptProductListByBrand();
                    productListbybrand.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = productListbybrand;
                    break;
                case "ProductPriceListReport":
                    rptProductPriceList producPricetList = new rptProductPriceList();
                    producPricetList.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = producPricetList;
                    break;
                case "ReorderListReport":
                    rptReorderList reorderList = new rptReorderList();
                    reorderList.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = reorderList;
                    break;
                case "StockAjustmentsReport":
                    rptStockAdjustments stockAdjustment = new rptStockAdjustments();
                    stockAdjustment.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = stockAdjustment;
                    break;
                case "CountSheet":
                    rptCountSheet countSheet = new rptCountSheet();
                    countSheet.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = countSheet;
                    break;
                case "StockSummaryReport":
                    rptStockSummary stockSummary = new rptStockSummary();
                    stockSummary.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = stockSummary;
                    break;
                case "StockDetailsReport":
                    rptStockDetails stockDetail = new rptStockDetails();
                    stockDetail.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = stockDetail;
                    break;
                case "EODStockDetailsReport":
                    rptEODStockDetails EODstockDetail = new rptEODStockDetails();
                    EODstockDetail.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = EODstockDetail;
                    break;
                case "StockTransferHistoryReport":
                    rptStockTranfers stockTransferHistory = new rptStockTranfers();
                    stockTransferHistory.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = stockTransferHistory;
                    break;
                case "BarCodePrintingReport":
                    rptBarcodes barcodes = new rptBarcodes();
                    barcodes.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = barcodes;
                    break;
                case "CustSaleSummaryReport":
                    rptCustomerSalesReport custsummsary = new rptCustomerSalesReport();
                    custsummsary.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = custsummsary;
                    break;
                case "CustSaleDetailReport":
                    rptCustomerSalesDetailReport custDetail = new rptCustomerSalesDetailReport();
                    custDetail.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = custDetail;
                    break;
                case "VoidedSalesReport":
                    rptVoidInvoiceReport voidsale = new rptVoidInvoiceReport();
                    voidsale.SetDataSource(dsReport);
                    crystalReportViewerRep.ReportSource = voidsale;
                    break;
                default:
                    NoRows = true;
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
