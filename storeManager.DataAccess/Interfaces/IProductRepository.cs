using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace DataAccess.Interfaces
{
    public interface IProductRepository : IRepository<Product,int>
    {
        void Discontinue(int id);
        List<string> GetExistingBarCodes();
    }
}
