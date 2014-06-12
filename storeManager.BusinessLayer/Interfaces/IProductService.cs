using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using storeManager.Entities;


namespace BusinessLayer.Interfaces
{
    public interface IProductService : IServiceBase<Product, int>
    {
        //Product GetProductByID(string id);
        IEnumerable<Product> GetAllProducts();
        void CalculateSellingPrice(decimal percent, decimal purchasePrice, out decimal sellingPrice, out decimal profitMargin);
        //void AddProduct(Product product);
        //void DeleteProduct(Product product);
        //void SaveProduct(Product product);
        void ReduceInventory(int qty, int productID, int locationID);
        void AddInventory(int qty, int productID, int locationID);
        int GetCurrentStock(int productid, int locationid);
        void AdjustStock(Product product);
        DataTable MapToTable(Func<IEnumerable<Product>> productList);
        void Discontinue(int id);
        List<string> GetExistingBarCodes();
    }
}
