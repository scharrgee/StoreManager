using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace storeManager.ViewModel
{
  public  class SaleSearchViewModel
    {
        #region Primitive Properties

        public string InvoiceNumber
        {
            get;
            set;
        }


        public string InvoiceDate
        {
            get;
            set;
        }

        public string SaleStatus
        {
            get;
            set;
        }


        public Nullable<int> SaleStatusID
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public virtual Nullable<decimal> AmountPaid
        {
            get;
            set;
        }

        public Nullable<decimal> Balance
        {
            get;
            set;
        }


        public int SaleID
        {
            get;
            set;
        }

        #endregion
    }

  public class EditSaleViewModel
  {
      public string SaleID { get; set; }
      public string OrderNumber { get; set; }
  }
}
