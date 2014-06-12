using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ISupplierService : IServiceBase<Supplier, int>
    {
        //List<Supplier> GetAllSuppliers();
        //Supplier GetByID(string id);
    }
}
