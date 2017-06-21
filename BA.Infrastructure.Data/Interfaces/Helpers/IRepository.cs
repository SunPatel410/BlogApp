using BA.Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BA.Infrastructure.Data.Interfaces.Helpers
{
    public interface IRepository<T> where T : TEntity
    {
        /// <summary>
        /// Gets an entity based on the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Gets all the possible entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Gets specific entities limited by Lambda query
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds new entity to the database
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        
        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Removes entity from the database
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
    }
}
