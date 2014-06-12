using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using storeManager.Entities;

namespace DataAccess.Interfaces
{
    public interface IProductLocationRepository : IRepository<ProductLocation, int>
    {
        void UpdateProductLocation(ProductLocation entity);
    }
}
