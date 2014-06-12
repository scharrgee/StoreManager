using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
namespace BusinessLayer.Interfaces
{
    public interface ICustomerService : IServiceBase<Customer, string>
    {
        //List<Customer> GetAllCustomers();
        //Customer GetByID(string id);
    }
}
