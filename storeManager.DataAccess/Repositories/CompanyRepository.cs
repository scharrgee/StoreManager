using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        Connection conn;

        public CompanyRepository()
        {
            conn = new Connection();
        }

        //#region IRepository<Company> Members

        //public Company GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        var company = ctx.Companies.Where(x => x.CompanyID == id).FirstOrDefault();
        //        return company;
        //    }
        //}

        //public List<Company> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        var company = (from c in ctx.Companies
        //                       select c).ToList();

        //        return company;
        //    }
        //}

        public void UpdateCompany(Company entity)
        {
            using (StoreManagerDBEntities ctx = new Connection().GetContext())
            {
                ctx.Companies.Attach(new Company { CompanyID = entity.CompanyID });
                ctx.Companies.ApplyCurrentValues(entity);
                ctx.SaveChanges();
            }
        }

        //public void UpdateCompany(Company entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Companies.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Company entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Companies.DeleteObject(new Company { CompanyID = entity.CompanyID });
        //        ctx.SaveChanges();
        //    }
        //}

        //#endregion

    }
}
