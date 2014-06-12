using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace BusinessLayer.Interfaces
{
    public interface IServiceBase<T, Tid>
    {
        T GetSingle(Func<T, bool> predicate);
        IEnumerable<T> Query(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        T Add(T bzEntity);
        void Delete(T bzEntity);
        //void Update(T bzEntity);
        void Update(T entity, Func<T, bool> predicate);
        IQueryable<T> Queryable(Expression<Func<T, bool>> predicate);
        IEnumerable<T> All(string includes);
    }
}
