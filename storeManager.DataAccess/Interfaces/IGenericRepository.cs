using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Interfaces
{
   public interface IGenericRepository<T>:IRepository<T,int> where T:class
    {
        //T GetById(Func<T,bool> predicate);
        //List<T> GetAll();
    }
}
