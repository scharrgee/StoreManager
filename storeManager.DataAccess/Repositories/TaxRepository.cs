using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class TaxRepository : Repository<Tax, int>, ITaxRepository
    {
         Connection conn;
         public TaxRepository()
         {
             conn = new Connection();
         }

         //#region IRepository<Tax,string> Members

         //public Tax GetById(int id)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        return ctx.Taxes.Where(t => t.TaxID == id).FirstOrDefault();
         //    }
         //}

         //public List<Tax> GetAll()
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        return ctx.Taxes.ToList();
         //    }
         //}

         //public void SaveObject(Tax entity)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        ctx.Taxes.Attach(new Tax { TaxID = entity.TaxID });
         //        ctx.Taxes.ApplyCurrentValues(entity);
         //        ctx.SaveChanges();
         //    }
         //}

         //public void AddObject(Tax entity)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        ctx.Taxes.AddObject(entity);
         //        ctx.SaveChanges();
         //    }
         //}

         //public void DeleteObject(Tax entity)
         //{
         //    using (StoreManagerDBEntities ctx = conn.GetContext())
         //    {
         //        ctx.Taxes.DeleteObject(new Tax { TaxID = entity.TaxID });
         //        ctx.SaveChanges();
         //    }
         //}

         //#endregion
    }
}
