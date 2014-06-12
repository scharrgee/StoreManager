using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace BusinessLayer
{
    public class ProductLocationService : ServiceBase<ProductLocation, int>, IProductLocationService
    {
        ProductLocationRepository _repository;
        public ProductLocationService():base(new ProductLocationRepository())
        {
            _repository = new ProductLocationRepository();
        }
    }
}
