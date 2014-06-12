using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
    {
        Connection conn;

        public EmployeeRepository()
        {
            conn = new Connection();
        }

        //#region IRepository<Employee> Members

        //public Employee GetById(int id)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return ctx.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
        //    }
        //}

        //public List<Employee> GetAll()
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        return (from e in ctx.Employees
        //                select e).ToList();
        //    }
        //}

        //public void SaveObject(Employee entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Employees.Attach(new Employee { EmployeeID = entity.EmployeeID });
        //        ctx.Employees.ApplyCurrentValues(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void AddObject(Employee entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Employees.AddObject(entity);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteObject(Employee entity)
        //{
        //    using (StoreManagerDBEntities ctx = conn.GetContext())
        //    {
        //        ctx.Employees.DeleteObject(new Employee { EmployeeID = entity.EmployeeID });
        //        ctx.SaveChanges();
        //    }
        //}

        //public Employee GetById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion

        public Employee GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
