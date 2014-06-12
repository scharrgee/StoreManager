using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using storeManager.ViewModel;

namespace BusinessLayer
{
    public class ProductService : ServiceBase<Product, int>, IProductService
    {
        private IProductRepository _productRepository;
        private IProductLocationRepository _productLocation;
        IErrorLogRepository _logger;

        public ProductService()
            : base(new ProductRepository())
        {
            _productRepository = new ProductRepository();
            _productLocation = new ProductLocationRepository();
            _logger = new ErrorLogRepository();
        }

        #region IProductService Members

        public void CalculateSellingPrice(decimal percent, decimal purchasePrice, out decimal sellingPrice, out decimal profitMargin)
        {
            try
            {
                decimal percentage = percent / 100;

                sellingPrice = Math.Round((percentage * purchasePrice) + purchasePrice, 2);
                profitMargin = Math.Round(sellingPrice - purchasePrice, 2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public void ReduceInventory(int qty, int productID, int locationID)
        {
            try
            {
                int stockQty = 0;
                ProductLocation prodloc = _productLocation.GetSingle(l => l.ProductID == productID && l.LocationID == locationID);

                stockQty = (int)prodloc.Quantity - qty;

                prodloc.Quantity = stockQty;

                _productLocation.UpdateObject(prodloc, p => p.Id == prodloc.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
    
        }

        public void AddInventory(int qty, int productID, int locationID)
        {
            try
            {
                int stockQty = 0;
                ProductLocation prodloc = _productLocation.GetSingle(l => l.ProductID == productID && l.LocationID == locationID);

                stockQty = (int)prodloc.Quantity + qty;

                prodloc.Quantity = stockQty;

                _productLocation.UpdateObject(prodloc, p => p.Id == prodloc.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public int GetCurrentStock(int productid, int locationid)
        {
            try
            {
                ProductLocation productLocation = _productLocation.GetSingle(l => l.ProductID == productid && l.LocationID == locationid);

                if (productLocation == null) return 0;

                return (int)productLocation.Quantity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
            //return _productRepository.GetSingle(p => p.ProductID == productid).Quantity;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public void AdjustStock(Product product)
        {
            try
            {
                Product newProduct = _productRepository.GetById(product.ProductID);

                newProduct.Quantity += product.Quantity;
                newProduct.ReorderLevel = product.ReorderLevel == 0 ? newProduct.ReorderLevel : product.ReorderLevel;
                newProduct.UnitPrice = product.UnitPrice;
                newProduct.AdjustmentReason = product.AdjustmentReason;

                _productRepository.UpdateObject(newProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public DataTable MapToTable(Func<IEnumerable<Product>> productList)
        {
            try
            {
                DataTable dt = new DataTable();
                IEnumerable<Product> products = productList();

                dt = CreateTable();

                foreach (var product in products)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = product.ProductID;
                    dr["Name"] = product.ProductName;
                    dr["Qty"] = product.Quantity;
                    dr["Price"] = product.UnitPrice;
                    dr["PurchasePrice"] = product.PurchasePrice;
                    dr["SellingPrice"] = product.SellingPrice;
                    dr["ManufactureDate"] = product.ManufactureDate.Value.ToShortDateString();
                    dr["ExpiryDate"] = product.ExpiryDate.Value.ToShortDateString();
                    dr["ReorderLevel"] = product.ReorderLevel;
                    dr["Desc"] = product.Description;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        private DataTable CreateTable()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn[] cols;

                cols = new DataColumn[]{new DataColumn("ID",typeof(string)),
                  new DataColumn("Name",typeof(string)),
                  new DataColumn("Qty",typeof(string)),
                  new DataColumn("Price",typeof(string)),
                  new DataColumn("PurchasePrice",typeof(string)),
                  new DataColumn("SellingPrice",typeof(string)),
                  new DataColumn("ManufactureDate",typeof(string)),
                  new DataColumn("ExpiryDate",typeof(string)),
                  new DataColumn("ReorderLevel",typeof(string)),
                  new DataColumn("Desc",typeof(string))
            };

                dt.Columns.AddRange(cols);

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            

        }

        public void Discontinue(int id)
        {
            try
            {
                _productRepository.Discontinue(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
                   
        }

        public List<string> GetExistingBarCodes()
        {
            return _productRepository.GetExistingBarCodes();
        }

        #endregion
    }
}
