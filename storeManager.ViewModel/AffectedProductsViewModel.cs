using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace storeManager.ViewModel
{
    public enum ProductState
    {
        Unchanged = 1,
        Modified = 2,
        Deleted = 3,
        Added = 4
    }

    public class AffectedProductsViewModel :IEqualityComparer<AffectedProductsViewModel>
    {
        public string InvoiceNumber { get; set; }
        public int ProductID { get; set; }
        public int SaleDetailID { get; set; }
        public int SaleID { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineDiscount { get; set; }
        public ProductState State { get; set; }


        public bool Equals(AffectedProductsViewModel x, AffectedProductsViewModel y)
        {
            return (x.ProductID == y.ProductID && x.State == y.State);
        }

        public int GetHashCode(AffectedProductsViewModel obj)
        {
            return (obj.State.ToString() + obj.ProductID.ToString()).GetHashCode();
        }
    }
}
