using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using storeManager.UI.ViewModels;

namespace storeManager.UI.EventHub
{
    public delegate decimal SendData();

    public static class Hub
    {
        public static event EventHandler<EventHubAgs> GenericInfo;
        public static event EventHandler<ProductListAddedEventArgs> ProductListAdded;
        public static event EventHandler<EventHubAgs> TaxInfo;
        public static event EventHandler<EventHubAgs> SetDiscountAmount;
        public static event EventHandler<ProductUpdateEventArgs> UpdateProduct;
        public static event EventHandler<EditSaleEventArgs> EditSale;
        public static event EventHandler<TransferStockEventArgs> TransferStaock;


        public static void OnGenericInfoCall(string id, string data, string control)
        {
            if (GenericInfo != null)
            {
                EventHubAgs arg = new EventHubAgs() { Data = data, ID = id, ControlName = control };

                GenericInfo(null, arg);
            }
        }

        public static void OnSetDiscountAmount(string id, string data, string control)
        {
            if (SetDiscountAmount != null)
            {
                EventHubAgs arg = new EventHubAgs() { Data = data, ID = id, ControlName = control };

                SetDiscountAmount(null, arg);
            }
        }

        public static void OnTaxInfoCall(string id, string data, string control)
        {
            if (TaxInfo != null)
            {
                EventHubAgs arg = new EventHubAgs() { Data = data, ID = id, ControlName = control };

                TaxInfo(null, arg);
            }
        }

        public static void OnProductListAdded(IEnumerable<AddedRowViewModel> addedProducts)
        {
            if (ProductListAdded != null)
            {
                ProductListAddedEventArgs arg = new ProductListAddedEventArgs() { AddedRows = addedProducts };

                ProductListAdded(null, arg);
            }
        }

        public static void OnProductTransfer(IEnumerable<int> locationids, int productid = 0)
        {
            if (TransferStaock != null)
            {
                TransferStockEventArgs arg = new TransferStockEventArgs() { LocationID = locationids, ProductID = productid };

                TransferStaock(null, arg);
            }
        }

        public static void OnProductUpdate(int productID)
        {
            if (UpdateProduct != null)
            {
                ProductUpdateEventArgs arg = new ProductUpdateEventArgs() { ProductID = productID };

                UpdateProduct(null, arg);
            }
        }

        public static void OnSaleEdit(int saleID)
        {
            if (EditSale != null)
            {
                EditSaleEventArgs arg = new EditSaleEventArgs() { SaleID = saleID };

                EditSale(null, arg);
            }
        }
    }


    public class EventHubAgs : EventArgs
    {
        public string ID { get; set; }
        public string Data { get; set; }
        public string ControlName { get; set; }
    }

    public class ProductListAddedEventArgs : EventArgs
    {
        public AddedRowViewModel AddedRow { get; set; }
        public IEnumerable<AddedRowViewModel> AddedRows { get; set; }
    }

    public class ProductUpdateEventArgs : EventArgs
    {
        public int ProductID { get; set; }
    }

    public class EditSaleEventArgs : EventArgs
    {
        public int SaleID { get; set; }
    }

    public class TransferStockEventArgs : EventArgs
    {
        public IEnumerable<int> LocationID { get; set; }
        public int ProductID { get; set; }
    }
}
