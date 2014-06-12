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
    public class GenericService<T> : ServiceBase<T, int>, IGenericService<T> where T : class
    {

        IGenericRepository<T> repo;

        public GenericService()
            : base(new GenericRepository<T>())
        {
            repo = new GenericRepository<T>();
        }

        //public T GetById(Func<T, bool> predicate)
        //{
        //    return repo.GetById(predicate);
        //}

        //public List<T> GetAll()
        //{
        //    return repo.GetAll();
        //}
    }
}
