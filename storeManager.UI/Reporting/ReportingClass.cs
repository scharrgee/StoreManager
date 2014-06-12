using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace storeManager.UI.Reporting
{
    public class ReportingClass
    {
        DataSet dsReport = new DataSet();
        private string _connString;
        private string _startDate;

        public object LocationID { get; set; }

        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        private string _endDate;

        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        private string _invoiceNo;

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set { _invoiceNo = value; }
        }

        private string _invoiceState;

        public string InvoiceState
        {
            get { return _invoiceState; }
            set { _invoiceState = value; }
        }

        private int _saleTypeID;

        public int SaleTypeID
        {
            get { return _saleTypeID; }
            set { _saleTypeID = value; }
        }

        private string _customerID;

        public string CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        private int _storeID;

        public int StoreID
        {
            get { return _storeID; }
            set { _storeID = value; }
        }

        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        private int _BrandID;

        public int BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
        }

        public int VoidSale { get; set; }

        //ConnectToDb connString;

        public ReportingClass()
        {
            //connString = new ConnectToDb();
            this._connString = ConfigurationHelper.DbConnectionString;
        }

        public DataSet GetReportDataSet(int reportMode)
        {
            switch (reportMode)
            {
                case 1:
                    InvoiceReport();
                    break;
                case 2:
                    InvoiceDetailsReport();
                    break;
                case 3:
                     CustomerSaleReport();
                    break;
                case 4:
                    ExpiryListReport();
                    break;
                case 5:
                    OutOfStockReport();
                    break;
                case 6:
                   ProductListReport();
                    break;
                case 7:
                    ReorderListReport();
                    break;
                case 8:
                     StockAjustmentsReport();
                    break;
                case 9:
                    CountSheet();
                    break;
                case 10:
                    StockSummaryReport();
                    break;
                case 11:
                    ProductListPriceReport();
                    break;
                case 12:
                    StockDetailsReport();
                    break;
                case 13:
                    StockTransferHistoryReport();
                    break;
                case 14:
                    CustomerSaleSummaryReport();
                    break;
                case 15:
                    CustomerSaleDetailReport();
                    break;
            }

            return dsReport;
        }

        private void CustomerSaleDetailReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_CustomerDetail_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SalesStartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@SaleEndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = SaleTypeID;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;


            DataTable dt = new DataTable("CustomerSaleDetailsReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        private void CustomerSaleSummaryReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_Customer_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SalesStartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@SaleEndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = SaleTypeID;
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;


            DataTable dt = new DataTable("CustomerSaleReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        private void StockTransferHistoryReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_StockTransfers_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;


            DataTable dt = new DataTable("StockTranferHistory");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        private void ProductListPriceReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_ProductPriceList_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;


            DataTable dt = new DataTable("ProductListReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void InvoiceReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_Invoice_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SalesStartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@SaleEndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = SaleTypeID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = StoreID;
            cmd.Parameters.Add("@VoidSale", SqlDbType.Int).Value = VoidSale;


            DataTable dt = new DataTable("SalesReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }


        public void InvoiceDetailsReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_InvoiceDetails_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SalesStartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@SaleEndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = SaleTypeID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = StoreID;



            DataTable dt = new DataTable("SaleDetailsReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void CustomerSaleReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_CustomerSales_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID;
            cmd.Parameters.Add("@SaleTypeID", SqlDbType.Int).Value = SaleTypeID;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;


            DataTable dt = new DataTable("CustomerSaleReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void ExpiryListReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_ExpiryList_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;


            DataTable dt = new DataTable("ExpiryListReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void OutOfStockReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_OutOfStock_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;


            DataTable dt = new DataTable("OutOfStockReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void ProductListReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_ProductList_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;


            DataTable dt = new DataTable("ProductListReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void StockDetailsReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_StcokDetails_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SalesStartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@SaleEndDate", SqlDbType.DateTime).Value = EndDate;


            DataTable dt = new DataTable("StockDetailsReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void ReorderListReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_ReorderList_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;
            cmd.Parameters.Add("@LocationID", SqlDbType.Int).Value = LocationID;


            DataTable dt = new DataTable("ReorderListReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();
        }

        public void StockAjustmentsReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_StockAjustments_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;


            DataTable dt = new DataTable("ProductListReport");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dsReport.Tables.Add(dt);
            GetCompanyDetails();

            //return dt;
        }

        public void CountSheet()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_CountSheet";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;

            DataTable dt = new DataTable("CountSheet");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            dsReport.Tables.Add(dt);
            GetCompanyDetails();

            //return dt;
        }

        public void StockSummaryReport()
        {
            ProductListReport();
        }

        public void GetCompanyDetails()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT TOP(1) * FROM Companies";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("CompanyDetail");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            dsReport.Tables.Add(dt);
        }



      
    }
}
