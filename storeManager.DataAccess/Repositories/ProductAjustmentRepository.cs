using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class ProductAjustmentRepository : Repository<ProductAdjustment, int>, IProductAjustmentRepository
    {
    }
}
