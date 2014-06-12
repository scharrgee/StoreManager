using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using storeManager.Entities;
//using storeManager.Entities.Interfaces;
using DataAccess.Interfaces;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public abstract class Repository<TEntity, Tid> : IRepository<TEntity, Tid> where TEntity : class
    {
        //Connection conn;
        private StoreManagerDBEntities ctx;
        IErrorLogRepository _logger;

        private ObjectSet<TEntity> objectSet;

        public Repository()
        {
            //conn = new Connection();
            _logger = new ErrorLogRepository();
        }

        public StoreManagerDBEntities CurrentContext
        {
            get
            {
                initializeContext();
                return this.ctx;
            }
        }

        protected virtual void initializeContext()
        {
            //this.ctx = new StoreManagerDBEntities();
            this.ctx = new Connection().GetContext();
            this.objectSet = ctx.CreateObjectSet<TEntity>();
        }

        protected virtual void DisposeContext()
        {
            //ctx.Dispose();
            ctx = null;
        }

        #region IRepository<TEntity,Tid> Members

        public virtual TEntity GetById(Tid id)
        {
            initializeContext();

            throw new NotImplementedException();

            // DisposeContext();
        }

        public virtual IList<TEntity> GetAll()
        {
            try
            {
                IList<TEntity> results;

                initializeContext();

                results = this.objectSet.ToList();

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            finally
            {
                DisposeContext();
            }


        }

        public virtual void UpdateObject(TEntity entity, Func<TEntity, bool> predicate)
        {
            try
            {
                initializeContext();

                TEntity original = objectSet.Where(predicate).FirstOrDefault();

                objectSet.Context.AttachTo(this.objectSet.EntitySet.Name, original);
                objectSet.Context.CreateObjectSet<TEntity>().ApplyCurrentValues(entity);
                objectSet.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            finally
            {
                DisposeContext();
            }

        }

        public virtual TEntity AddObject(TEntity entity)
        {
            try
            {
                initializeContext();

                this.objectSet.AddObject(entity);
                ctx.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            finally
            {
                DisposeContext();
            }
        }

        public virtual void DeleteObject(TEntity entity)
        {
            try
            {
                initializeContext();

                objectSet.Context.AttachTo(this.objectSet.EntitySet.Name, entity);
                objectSet.Context.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Deleted);

                objectSet.Context.SaveChanges();


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            finally
            {
                DisposeContext();
            }

        }

        public virtual IEnumerable<TEntity> Query(Func<TEntity, bool> predicate)
        {
            try
            {
                initializeContext();

                IEnumerable<TEntity> results;

                results = this.objectSet.Where(predicate).ToList();

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            finally
            {
                DisposeContext();
            }

        }

        public virtual TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            try
            {
                initializeContext();

                TEntity results;

                results = this.objectSet.Where(predicate).SingleOrDefault();

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            finally
            {
                DisposeContext();
            }

        }

        #endregion


        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                initializeContext();

                IQueryable<TEntity> results;

                results = this.objectSet.Where(predicate);

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            finally
            {
                DisposeContext();
            }

        }

        private T GetPropertyValue<T>(object o, string propertyName)
        {
            Type type = o.GetType();
            PropertyInfo info = type.GetProperty(propertyName);
            T value = (T)info.GetValue(o, null);
            return value;
        }


        public void UpdateObject(TEntity entity)
        {
            throw new NotImplementedException();
        }


        //public IQueryable<TEntity> All(string includes)
        //{
        //    ObjectQuery<TEntity> value = objectSet;
        //    if (String.IsNullOrEmpty(includes))
        //    {
        //        foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            value = value.Include(includeProperty.Trim());
        //        }
        //    }
        //    return value;
        //}

        public IEnumerable<TEntity> All(string includes)
        {
            ObjectQuery<TEntity> value = objectSet;
            if (String.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    value = value.Include(includeProperty.Trim());
                }
            }
            return value.ToList() ;
        }
    }
}
