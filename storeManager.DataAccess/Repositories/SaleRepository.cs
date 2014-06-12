using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class SaleRepository : Repository<Sale, int>, ISaleRepository
    {
        //Connection conn;
        IErrorLogRepository _logger;

        public SaleRepository()
        {
            //conn = new Connection();
            _logger = new ErrorLogRepository();
        }

        //#region IRepository<Sale> Members

        //public Sale GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return ctx.Sales.Where(x => x.InvoiceNumber == id.ToString()).FirstOrDefault();
        //    }
        //}

        //public List<Sale> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return (from s in ctx.Sales
        //                select s).ToList();
        //    }
        //}

        //public void SaveObject(Sale entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Sales.Attach(new Sale { InvoiceNumber = entity.InvoiceNumber });
        //        ctx.Sales.ApplyCurrentValues(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void AddObject(Sale entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Sales.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Sale entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Sales.DeleteObject(new Sale { InvoiceNumber = entity.InvoiceNumber });
        //        ctx.SaveChanges();
        //    }
        //}

        //#endregion

        //#region IRepository<Sale> Members

        //public Sale GetById<Tid>(Tid id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return ctx.Sales.Where(x => x.InvoiceNumber == id.ToString()).FirstOrDefault();
        //    }
        //}

        //#endregion

        #region ISale Members

        public void RollBackSaleTransaction(string invoiceNo)
        {
            try
            {
                using (StoreManagerDBEntities ctx = new Connection().GetContext())
                {
                    ctx.SaleDetails.DeleteObject(new SaleDetail { InvoiceNumber = invoiceNo });
                    ctx.Sales.DeleteObject(new Sale { InvoiceNumber = invoiceNo });

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public List<string> GetInvoiceNos(string invoiceNo)
        {
            try
            {
                using (StoreManagerDBEntities ctx = new Connection().GetContext())
                {
                    var invoices = (from s in ctx.Sales
                                    where s.InvoiceNumber.Contains(invoiceNo)
                                    select s.InvoiceNumber);
                    return invoices.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");   
                throw;
            }
            
        }

        #endregion

        #region IRepository<Sale,string> Members

        public Sale GetById(string id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
