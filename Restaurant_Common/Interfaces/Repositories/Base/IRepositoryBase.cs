using Restaurant_Common.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Get all T object from database
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();
        /// <summary>
        /// Get T objects from database by condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition);
        /// <summary>
        /// Add a T object to database
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);
        /// <summary>
        /// Update a T object in database
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// Delete a T object from database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
