using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class ProductLocationRepository : Repository<ProductLocation, int>, IProductLocationRepository
    {
        Connection conn;
        public ProductLocationRepository()
        {
            conn = new Connection();
        }

        public void UpdateProductLocation(ProductLocation entity)
        {
            using (StoreManagerDBEntities ctx = new StoreManagerDBEntities())
            {
                ProductLocation loc = ctx.ProductLocations.Where(p => p.Id == entity.Id).FirstOrDefault();

                ctx.ProductLocations.Attach(loc);
                ctx.ProductLocations.ApplyCurrentValues(entity);
                ctx.SaveChanges();
            }
        }
    }
}
