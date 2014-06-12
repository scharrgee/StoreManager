using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;
using System.Data.Objects;

namespace DataAccess.Repositories
{
    public class BrandRepository : Repository<Brand, int>, IBrandRepository
    {

        Connection conn;
        public BrandRepository()
        {
            conn = new Connection();
        }

        //#region IRepository<Brand> Members

        //public Brand GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        var brand = ctx.Brands.Where(x => x.BrandID == id).FirstOrDefault();
        //        return brand;
        //    }
        //}

        //public List<Brand> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        var brand = (from b in ctx.Brands
        //                     select b).ToList();

        //        return brand;
        //    }
        //}

        public void UpdateBrand(Brand entity)
        {
            using (StoreManagerDBEntities ctx = conn.GetContext())
            {
                ctx.Brands.Attach(new Brand { BrandID = entity.BrandID });
                ctx.Brands.ApplyCurrentValues(entity);
                ctx.SaveChanges();

                ctx.Brands.Attach(entity);
                ObjectStateEntry o = ctx.ObjectStateManager.GetObjectStateEntry(entity);
                o.ChangeState(System.Data.EntityState.Modified);

                ctx.SaveChanges();
            }

            
        }

        //public void AddObject(Brand entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Brands.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Brand entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Brands.DeleteObject(new Brand { BrandID = entity.BrandID });
        //        ctx.SaveChanges();
        //    }
        //}

        //#endregion

    }
}
