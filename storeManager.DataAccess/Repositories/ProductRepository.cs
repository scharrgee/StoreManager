using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        //Connection conn;
        IErrorLogRepository _logger;

        public ProductRepository()
        {
            //conn = new Connection();
            _logger = new ErrorLogRepository();
        }


        //#region IRepository<Product> Members

        //public Product GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return ctx.Products.Where(x => x.ProductID == id).FirstOrDefault();
        //    }
        //}

        //public List<Product> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return ctx.Products.Where(p => p.OnSale == true).ToList();
        //    }
        //}

        //public void SaveObject(Product entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Products.Attach(new Product { ProductID = entity.ProductID });
        //        ctx.Products.ApplyCurrentValues(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void AddObject(Product entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Products.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Product entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Products.DeleteObject(new Product { ProductID = entity.ProductID });
        //        ctx.SaveChanges();
        //    }
        //}

        ////public Product GetById(int id)
        ////{
        ////    using (StoreManagerDBEntities ctx = conn.GetContext())
        ////    {
        ////        return ctx.Products.Where(x => x.ProductID == id).FirstOrDefault();
        ////    }
        ////}

        //public void Discontinue(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        Product product = ctx.Products.Where(p => p.ProductID ==id).FirstOrDefault();
        //        product.OnSale = false;

        //        SaveObject(product);
        //    }
        //}

        //#endregion

        public void Discontinue(int id)
        {
            try
            {
                using (StoreManagerDBEntities ctx = new Connection().GetContext())
                {
                    Product product = ctx.Products.Where(p => p.ProductID == id).FirstOrDefault();
                    product.OnSale = false;

                    UpdateObject(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

       public List<string> GetExistingBarCodes()
        {
            try
            {
                using (StoreManagerDBEntities ctx = new Connection().GetContext())
                {
                    return ctx.Products.Select(p => p.Barcode).Distinct().ToList();                  
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
