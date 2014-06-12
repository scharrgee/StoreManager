using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        Connection conn;
        public CategoryRepository()
        {
            conn = new Connection();
        }
        //#region IRepository<Category> Members

        //public Category GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        var category = ctx.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
        //        return category;
        //    }
        //}

        //public List<Category> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        var categories = from c in ctx.Categories
        //                         select c;

        //        return categories.ToList();
        //    }
        //}

        //public void SaveObject(Category entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Categories.Attach(new Category { CategoryID = entity.CategoryID });
        //        ctx.Categories.ApplyCurrentValues(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void AddObject(Category entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Categories.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Category entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Categories.DeleteObject(new Category { CategoryID = entity.CategoryID });
        //        ctx.SaveChanges();
        //    }
        //}

        //#endregion

    }
}
