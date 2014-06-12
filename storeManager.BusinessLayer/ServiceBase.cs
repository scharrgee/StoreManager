using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Interfaces;
using BusinessLayer.Interfaces;
using DataAccess.Repositories;

namespace BusinessLayer
{
    public class ServiceBase<T, Tid> : IServiceBase<T, Tid> where T : class
    {
        private IRepository<T, Tid> _repository;
        IErrorLogRepository _logger;

        public ServiceBase(IRepository<T, Tid> repository)
        {
            _repository = repository;
            _logger = new ErrorLogRepository();
        }

        public ServiceBase() { }

        #region IServiceBase<T,Tid> Members

        public T GetSingle(Func<T, bool> predicate)
        {
            try
            {
                return this._repository.Query(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public IEnumerable<T> Query(Func<T, bool> predicate)
        {
            try
            {
                return this._repository.Query(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public T Add(T bzEntity)
        {
            try
            {
                return this._repository.AddObject(bzEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public void Delete(T bzEntity)
        {
            try
            {
                this._repository.DeleteObject(bzEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public void Update(T bzEntity)
        {
            try
            {
                this._repository.UpdateObject(bzEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                IEnumerable<T> list = this._repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        #endregion


        public IQueryable<T> Queryable(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {
                return this._repository.Queryable(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }


        public void Update(T entity, Func<T, bool> predicate)
        {
            try
            {
                this._repository.UpdateObject(entity, predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
        }

        public IEnumerable<T> All(string includes)
        {
            try
            {
               return this._repository.All(includes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
        }
    }
}
