using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class PaymentModeRepository : Repository<PaymentMode, int>, IPaymentModeRepository
    {
        // Connection conn;
         IErrorLogRepository _logger;
         public PaymentModeRepository()
         {
             //conn = new Connection();
             _logger = new ErrorLogRepository();
         }

         //#region IRepository<PaymentMode,int> Members

         //public PaymentMode GetById(int id)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        return ctx.PaymentModes.Where(p => p.PaymentModeID == id).FirstOrDefault();
         //    }
         //}

         //public List<PaymentMode> GetAll()
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        return ctx.PaymentModes.ToList();
         //    }
         //}

         //public void SaveObject(PaymentMode entity)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        ctx.PaymentModes.Attach(new PaymentMode { PaymentModeID = entity.PaymentModeID });
         //        ctx.PaymentModes.ApplyCurrentValues(entity);
         //        ctx.SaveChanges();
         //    }
         //}

         //public void AddObject(PaymentMode entity)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        ctx.PaymentModes.AddObject(entity);
         //        ctx.SaveChanges();
         //    }
         //}

         //public void DeleteObject(PaymentMode entity)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        ctx.Taxes.DeleteObject(new Tax { TaxID = entity.PaymentModeID });
         //        ctx.SaveChanges();
         //    }
         //}

         //public PaymentMode[] GetPaymentModes()
         //{
         //    try
         //    {
         //        using (StoreManagerDBEntities ctx = conn.GetContext())
         //        {
         //            return ctx.PaymentModes.ToArray();
         //            //return null;
         //        }
         //    }
         //    catch (Exception ex)
         //    {
                 
         //        throw;
         //    }
            
         //}

         //#endregion

         public PaymentMode[] GetPaymentModes()
         {
             try
             {
                 using (StoreManagerDBEntities ctx = new Connection().GetContext())
                 {
                     return ctx.PaymentModes.ToArray();
                     //return null;
                 }
             }
             catch (Exception ex)
             {
                 _logger.LogError(ex, "An error occurred", "", "");
                 throw;
             }
            
         }
    }
}
