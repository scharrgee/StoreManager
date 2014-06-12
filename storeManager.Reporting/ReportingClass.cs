using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace storeManager.Reporting
{
  public class ReportingClass
    {
      private string _connString;
        private string _startDate;

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

        //ConnectToDb connString;

        public ReportingClass()
        {
            //connString = new ConnectToDb();
            this._connString = ConfigurationHelper.DbConnectionString;
        }

        public DataSet GetReportDataSet(int reportMode)
        {
            DataSet dsReport = new DataSet();

            switch (reportMode)
            { 
                case 1:
                    dsReport = InvoiceReport();
                    break;
                case 2:
                    dsReport = InvoiceDetailsReport();
                    break;
                case 3:
                    dsReport = CustomerSaleReport();
                    break;
                case 4:
                    dsReport = ExpiryListReport();
                    break;
                case 5:
                    dsReport = OutOfStockReport();
                    break;
                case 6:
                    dsReport = ProductListReport();
                    break;
                case 7:
                    dsReport = ReorderListReport();
                    break;
                case 8:
                    dsReport = StockAjustmentsReport();
                    break;
                case 9:
                    dsReport = CountSheet();
                    break;
                case 10:
                    dsReport = StockSummaryReport();
                    break;
            }

            return dsReport;
        }

        public DataSet InvoiceReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_Invoice_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SalesStartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@SaleEndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@SaleTypeID", SqlDbType.Int).Value = SaleTypeID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = StoreID;
            
            
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet InvoiceDetailsReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_InvoiceDetails_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SalesStartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@SaleEndDate", SqlDbType.DateTime).Value = EndDate;
            cmd.Parameters.Add("@SaleTypeID", SqlDbType.Int).Value = SaleTypeID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = StoreID;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet CustomerSaleReport()
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
           

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet ExpiryListReport()
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


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet OutOfStockReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_OutOfStock_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet ProductListReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_ProductList_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet ReorderListReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_ReorderList_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet StockAjustmentsReport()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_StockAjustments_Report";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet CountSheet()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this._connString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "prc_CountSheet";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
            cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public DataSet StockSummaryReport()
        {
           return ProductListReport();
        }
    }
}
