using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using storeManager.ViewModel;

namespace BusinessLayer
{
    public class StoredProcedureGatewayService
    {
        StoredProcedureGatewayRepository _repository;
        IErrorLogRepository _logger;

        public StoredProcedureGatewayService()
        {
            _repository = new StoredProcedureGatewayRepository();
            _logger = new ErrorLogRepository();
        }

        public IEnumerable<ProductSearchViewModel> GetProducts(string productName, string productCode, int categoryID)
        {
            try
            {
                return _repository.GetProducts(productName, productCode, categoryID);
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
                return _repository.GetProductList(productName, productCode, categoryID,locationID);
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
                return _repository.GetCurrentStock(productName, productCode, categoryID, locationID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }


        }

        public IEnumerable<SaleSearchViewModel> GetSaleList(string startdate, string enddate, int statusid, string invoiceno)
        {
            try
            {
                return _repository.GetSaleList(startdate, enddate, statusid, invoiceno);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
                      
        }

        public IEnumerable<TransferStockViewModel> GetProductsAtLocation(int locationID, int productID, string productName)
        {
            try
            {
                return _repository.GetProductsAtLocation(locationID, productID, productName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }
    }
}
