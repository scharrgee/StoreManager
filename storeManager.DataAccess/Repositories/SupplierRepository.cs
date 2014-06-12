using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class SupplierRepository : Repository<Supplier, int>, ISupplierRepository
    {
        Connection conn;

        public SupplierRepository()
        {
            conn = new Connection();
        }

        //#region IRepository<Supplier> Members

        //public List<Supplier> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return (from s in ctx.Suppliers
        //                select s).ToList();
        //    }
        //}

        //public void SaveObject(Supplier entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Suppliers.Attach(new Supplier { SupplierID = entity.SupplierID });
        //        ctx.Suppliers.ApplyCurrentValues(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void AddObject(Supplier entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Suppliers.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Supplier entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Suppliers.DeleteObject(new Supplier { SupplierID = entity.SupplierID });
        //        ctx.SaveChanges();
        //    }
        //}

        //public Supplier GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return ctx.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
        //    }
        //}

        //#endregion
    }
}
