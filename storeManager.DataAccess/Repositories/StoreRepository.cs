using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    //public class StoreRepository : IStoreRepository
    //{
    //    Connection conn;

    //    public StoreRepository()
    //    {
    //        conn = new Connection();
    //    }

    //    #region IRepository<Store> Members

    //    public Store GetById(int id)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            return ctx.Stores.Where(x => x.StoreID == id).FirstOrDefault();
    //        }
    //    }

    //    public List<Store> GetAll()
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            return (from s in ctx.Stores
    //                    select s).ToList();
    //        }
    //    }

    //    public void SaveObject(Store entity)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            ctx.Stores.Attach(new Store { StoreID = entity.StoreID });
    //            ctx.Stores.ApplyCurrentValues(entity);
    //            ctx.SaveChanges();
    //        }
    //    }

    //    public void AddObject(Store entity)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            ctx.Stores.AddObject(entity);
    //            ctx.SaveChanges();
    //        }
    //    }

    //    public void DeleteObject(Store entity)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            ctx.Stores.DeleteObject(new Store { StoreID = entity.StoreID });
    //            ctx.SaveChanges();
    //        }
    //    }

    //    #endregion

    //    #region IRepository<Store> Members

    //    public Store GetById<Tid>(Tid id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    #endregion
    //}
}
