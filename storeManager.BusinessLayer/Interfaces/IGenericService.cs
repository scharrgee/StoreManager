using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IGenericService<T>:IServiceBase<T,int>
    {
        //T GetById(Func<T, bool> predicate);
        //List<T> GetAll();
    }
}
