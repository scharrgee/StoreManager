using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities.Interfaces;

namespace storeManager.Entities
{
    public partial class Product : IProduct
    {
        public int ID
        {
            get { return this.ProductID; }
        }

        public string DisplayName
        {
            get { return this.ProductName; }
        }

        public decimal ItemPrice
        {
            get { return this.UnitPrice; }
        }

        public decimal ProdMeasurementID
        {
            get { return this.MeasurementID; }
        }
    }
}
