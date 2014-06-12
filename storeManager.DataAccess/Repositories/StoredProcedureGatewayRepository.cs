using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Data.Objects;
using storeManager.ViewModel;
using System.Data.Common;
using System.Data.SqlClient;

using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
  public  class StoredProcedureGatewayRepository
    {
       Connection conn;
       IErrorLogRepository _logger;

       public StoredProcedureGatewayRepository()
        {
            conn = new Connection();
            _logger = new ErrorLogRepository();
        }

       public IEnumerable<ProductSearchViewModel> GetProducts(string productName,string productCode,int categoryID)
       {
           try
           {
               var param = new DbParameter[] { new SqlParameter { ParameterName = "@ProductName", Value = productName }, 
               new SqlParameter { ParameterName = "@ProductCode", Value = productCode },
               new SqlParameter { ParameterName = "@CategoryID", Value = categoryID }};

               return conn.GetContext().
                   ExecuteStoreQuery<ProductSearchViewModel>("Exec prc_GetProducts @ProductName,@ProductCode,@CategoryID", param).ToList();
           }
           catch (Exception ex)
           {
               _logger.LogError(ex, "An error occurred", "", "");
               throw;
           }
           
       }

       public IEnumerable<ProductPricingViewModel> GetProductList(string productName, string productCode, int categoryID,int locationID)
       {
           try
           {
               var param = new DbParameter[] { new SqlParameter { ParameterName = "@ProductName", Value = productName }, 
               new SqlParameter { ParameterName = "@ProductCode", Value = productCode },
               new SqlParameter { ParameterName = "@CategoryID", Value = categoryID },
               new SqlParameter { ParameterName = "@LocationID", Value = locationID }};

               return conn.GetContext().
                   ExecuteStoreQuery<ProductPricingViewModel>("Exec prc_GetProductList @ProductName,@ProductCode,@CategoryID,@LocationID", param).ToList();
           }
           catch (Exception ex)
           {
               _logger.LogError(ex, "An error occurred", "", "");
               throw;
           }
           
       }

       public IEnumerable<CurrentStockViewModel> GetCurrentStock(string productName, string productCode, int categoryID, int locationID)
       {
           try
           {
               var param = new DbParameter[] { new SqlParameter { ParameterName = "@ProductName", Value = productName }, 
               new SqlParameter { ParameterName = "@ProductCode", Value = productCode },
               new SqlParameter { ParameterName = "@CategoryID", Value = categoryID },
               new SqlParameter { ParameterName = "@LocationID", Value = locationID }};

               return conn.GetContext().
                   ExecuteStoreQuery<CurrentStockViewModel>("Exec prcCurrentStock @ProductName,@ProductCode,@CategoryID,@LocationID", param).ToList();
           }
           catch (Exception ex)
           {
               _logger.LogError(ex, "An error occurred", "", "");
               throw;
           }

       }

       public IEnumerable<SaleSearchViewModel> GetSaleList(string startdate, string enddate, int statusid,string invoiceno)
       {
           var param = new DbParameter[] { new SqlParameter { ParameterName = "@StartDate", Value = startdate }, 
               new SqlParameter { ParameterName = "@EndDate", Value = enddate },
               new SqlParameter { ParameterName = "@InvoiceNo", Value = invoiceno },
               new SqlParameter { ParameterName = "@StatusID", Value = statusid }};

           try
           {
               return conn.GetContext().
              ExecuteStoreQuery<SaleSearchViewModel>("Exec prc_GetSales @StartDate,@EndDate,@InvoiceNo,@StatusID", param).ToList();
           }
           catch (Exception ex)
           {
               _logger.LogError(ex, "An error occurred", "", "");
               throw;
           }
          
       }

       public IEnumerable<TransferStockViewModel> GetProductsAtLocation(int locationID,int productID,string productName)
       {
           var param = new DbParameter[] { new SqlParameter { ParameterName = "@LocationID", Value = locationID },
                                            new SqlParameter { ParameterName = "@ProductID", Value = productID },
                                            new SqlParameter { ParameterName = "@ProductName", Value = productName}};

           try
           {
               return conn.GetContext().
              ExecuteStoreQuery<TransferStockViewModel>("Exec prc_GetProductsAtLocation @LocationID,@ProductID,@ProductName", param).ToList();
           }
           catch (Exception ex)
           {
               _logger.LogError(ex, "An error occurred", "", "");
               throw;
           }

       }
    }
}
