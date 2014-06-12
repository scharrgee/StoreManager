using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using storeManager.Entities;

namespace DataAccess.Interfaces
{
    public interface IProductAjustmentRepository : IRepository<ProductAdjustment, int>
    {
    }
}
