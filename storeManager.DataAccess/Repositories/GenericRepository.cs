using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Objects;

using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
   public class GenericRepository<T> :Repository<T,int>, IGenericRepository<T> where T : class
    {
        Connection conn;

        ObjectSet<T> set;
        public GenericRepository()
        {
            conn = new Connection();
            set = conn.GetContext().CreateObjectSet<T>();
        }

        //public T GetById(Func<T,bool> predicate)
        //{
        //    return set.Where<T>(predicate).FirstOrDefault<T>();
        //}

        //public List<T> GetAll()
        //{
        //    //var list = set.ToList();
        //    return set.ToList();
        //}
    }
}
