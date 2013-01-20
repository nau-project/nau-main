using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataBaseLibrary.Repositrory
{
    /// <summary>
    ///   Generic repository.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Methods

        /// <summary>
        ///   Returns the list of all entities.
        /// </summary>
        List<TEntity> GetAll(int pageNum = 0, int pageSize = 0);

        /// <summary>
        ///   Returns entity with the provided <paramref name = "id" />.
        /// </summary>
        TEntity GetById(Guid id);

        /// <summary>
        ///   Returns entities that are filtered with the <paramref name = "filter" /> param and ordered with the <paramref
        ///    name = "orderBy" /> param.
        ///   <paramref name = "includeProperties" /> param allow to specify what properties should be loaded from the data store along with the entities.
        /// </summary>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties,
                                 int pageNum = 0, int pageSize = 0);

        /// <summary>
        ///   Adds entity to the data store.
        /// </summary>
        void Insert(TEntity entity);
        
        /// <summary>
        ///   Adds list of entities to the data store.
        /// </summary>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        ///   Deletes entity with the provided <paramref name = "id" /> from the data store.
        /// </summary>
        /// <param name = "id"></param>
        void Delete(Guid id);

        /// <summary>
        ///   Deletes entity from the data store.
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        ///   Deletes list of entities from the data store.
        /// </summary>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        ///   Attaches entity, that already exists in the data store, to the repository.
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        ///   Attaches list of entities, that already exist in the data store, to the repository.
        /// </summary>
        void Update(IEnumerable<TEntity> entities);

        #endregion
    }
}