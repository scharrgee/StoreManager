using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace storeManager.ViewModel
{
   public class TransferStockViewModel
    {
        public string ProductName { get; set; }
        public int LocationID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
    }
}
