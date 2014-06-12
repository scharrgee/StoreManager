using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ITaxService : IServiceBase<Tax, int>
    {
        //List<Tax> GetAllTaxes();
        //Tax GetTaxByID(int id);
    }
}
