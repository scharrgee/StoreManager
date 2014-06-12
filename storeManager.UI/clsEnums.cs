using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace storeManager.UI
{
    public enum EntityState
    {
        New = 1, Dirty = 2
    }

    public enum CardTypes : int
    {
        GiftCard = 1,
        DebitCard = 2,
        Coupon = 3
    }

    public enum SaleStatuses : int
    {
        All = 0,
        Open = 1,
        Closed = 2,
        Quote = 3,
        Order = 4,
        Invoiced = 5,
        Cancelled = 6
    }

    public enum ApplicationFroms
    {
        ucAdjustStock = 1,
        ucCardInfo = 2,
        ucNewProduct = 3,
        ucOrder = 4,
        ucProductList = 5,
        ucProductPricing = 6,
        ucQuote = 7,
        ucSale = 8,
        ucSalesList = 9,
        ucTransferStocks = 10,
        frmAddCompany = 11,
        frmReportParameters = 12,
        ucCurrentStock = 13
    }

    public enum Prefix
    {
        INV = 1,
        ORD = 2,
        QUO = 3
    }

   public class OperationStatus
   {
       public const string SUCCESS_ADD = "information has been commited successfully";
       public const string SUCCESS_UPDATE = "Changes has been submittes successfully";
       public const string SUCCESS = "";
       public const string FAILURE = "Operation has been terminated due to an error";

   }

   public static class CurrentUser
   {
       public static bool LogInSuccessful = false;
       public static User User { get; set; }
   }
}
