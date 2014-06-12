using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity, Tid> where TEntity : class
    {
        TEntity GetById(Tid id);
        IList<TEntity> GetAll();
        void UpdateObject(TEntity entity);
        void UpdateObject(TEntity entity, Func<TEntity, bool> predicate);
        TEntity AddObject(TEntity entity);
        void DeleteObject(TEntity entity);
        IEnumerable<TEntity> Query(Func<TEntity, bool> predicate);
        TEntity GetSingle(Func<TEntity, bool> predicate);
        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> All(string includes);
    }
}
