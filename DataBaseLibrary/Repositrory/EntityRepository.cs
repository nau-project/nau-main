#region Usages

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataBaseLibrary.Repositrory;

#endregion

namespace DataBaseLibrary.Repositories
{
    /// <inheritdoc />
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly DataContext context;
        private readonly DbSet<TEntity> dbSet;

        #endregion

        #region Constructors

        public EntityRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        #endregion

        #region IRepository<TEntity> Members

        /// <inheritdoc />
        public List<TEntity> GetAll(int pageNum = 0, int pageSize = 0)
        {
            if (pageNum <= 0 || pageSize <=0)
            {
                return dbSet.ToList();
            }
                
            return dbSet.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <inheritdoc />
        public virtual TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int pageNum = 0, int pageSize = 0)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            IQueryable<TEntity> res = orderBy != null ? orderBy(query) : query;
            
            if (pageNum <= 0 || pageSize <= 0)
            {
                return res;
            }

            return res.Skip((pageNum - 1) * pageSize).Take(pageSize);
        }

        /// <inheritdoc />
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <inheritdoc />
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Insert(entity);
            }
        }

        /// <inheritdoc />
        public virtual void Delete(Guid id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        /// <inheritdoc />
        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Delete(entity);
            }
        }

        /// <inheritdoc />
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <inheritdoc />
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Update(entity);
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public virtual int SaveChanges()
        {
            return context.SaveChanges();
        }

        #endregion
    }
}