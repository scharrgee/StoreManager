using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        Connection conn;

        public CustomerRepository()
        {
            conn = new Connection();
        }

        //#region IRepository<Customer> Members

        //public Customer GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        var customer = ctx.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
        //        return customer;
        //    }
        //}

        //public List<Customer> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return (from c in ctx.Customers
        //                select c).ToList();
        //    }
        //}

        //public void SaveObject(Customer entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Customers.Attach(new Customer { CustomerID = entity.CustomerID });
        //        ctx.Customers.ApplyCurrentValues(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void AddObject(Customer entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Customers.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Customer entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Customers.DeleteObject(new Customer { CustomerID = entity.CustomerID });
        //        ctx.SaveChanges();
        //    }
        //}

        //public Customer GetById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion

        public Customer GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
