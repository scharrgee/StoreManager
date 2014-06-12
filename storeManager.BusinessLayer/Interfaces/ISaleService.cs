using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ISaleService : IServiceBase<Sale, string>
    {
        //List<Sale> GetAllSales();
        //Sale GetSaleByID(string id);
        //void AddSale(Sale sale);
        //void UpdateSale(Sale sale);
        //void DeleteSale(Sale sale);
        void RollBackSaleTransaction(string invoiceNo);
        void CalculateLineTotal(int lineItmQty, decimal lineItmPrice, decimal tax, decimal discount, out decimal subTotal, out decimal total);
        List<string> GetInvoiceNos(string invoiveNo);
        decimal CalculateTax(decimal saleAmount, decimal taxAmont);
        int GetSaleStatus(decimal saleAmount, decimal amoutPaid);
    }
}
