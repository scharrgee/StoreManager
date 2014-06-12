using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class SaleDetailRepository : Repository<SaleDetail, int>, ISaleDetailRepository
    {
        //Connection conn;

        public SaleDetailRepository()
        {
            //conn = new Connection();
        }

        //#region IRepository<SaleDetail> Members

        //public SaleDetail GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return ctx.SaleDetails.Where(x => x.SalesDetailsID == id).FirstOrDefault();
        //    }
        //}

        //public List<SaleDetail> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return (from s in ctx.SaleDetails
        //                select s).ToList();
        //    }
        //}

        //public void SaveObject(SaleDetail entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.SaleDetails.Attach(new SaleDetail { SalesDetailsID = entity.SalesDetailsID });
        //        ctx.SaleDetails.ApplyCurrentValues(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void AddObject(SaleDetail entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.SaleDetails.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(SaleDetail entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.SaleDetails.DeleteObject(new SaleDetail { SalesDetailsID = entity.SalesDetailsID });
        //        ctx.SaveChanges();
        //    }
        //}

        //#endregion

        //#region IRepository<SaleDetail> Members

        //public SaleDetail GetById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion

        public SaleDetail GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
