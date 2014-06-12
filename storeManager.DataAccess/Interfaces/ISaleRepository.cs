using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace DataAccess.Interfaces
{
    public interface ISaleRepository : IRepository<Sale,string>
    {
        void RollBackSaleTransaction(string invoiceNo);
        List<string> GetInvoiceNos(string invoiceNo);
    }
}
