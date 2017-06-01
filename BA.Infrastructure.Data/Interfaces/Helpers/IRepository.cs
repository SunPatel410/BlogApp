using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BA.Infrastructure.Data.Interfaces.Helpers
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets an entity based on the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Gets all the possible entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get();

        /// <summary>
        /// Gets specific entities limited by Lambda query
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds new entity to the database
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Removes entity from the database
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
    }
}
