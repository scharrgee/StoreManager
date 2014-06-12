using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace storeManager.ViewModel
{
    public class ProductSearchViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public decimal UnitPrice { get; set; }
        public int DaysBeforeExpiry { get; set; }
    }

    public class CurrentStockViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int LocationID { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductPricingViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
