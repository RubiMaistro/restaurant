using Restaurant_Common.Interfaces.Repositories.Base;
using Restaurant_Common.Models.Filter;
using Restaurant_WebApiServer.DataObjects;
using System.Linq.Expressions;
using System.Security;

namespace Restaurant_WebApiServer.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RestaurantContext RestaurantContext { get; set; }
        public RepositoryBase(RestaurantContext restaurantContext)
        {
            RestaurantContext = restaurantContext;
        }
        public IQueryable<T> FindAll() =>
             RestaurantContext.Set<T>()
                .AsNoTracking()
                .AsQueryable();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition) => 
            RestaurantContext.Set<T>()
            .Where(condition)
            .AsNoTracking()
            .AsQueryable();
        public void Create(T entity) => RestaurantContext.Set<T>().Add(entity);
        public void Update(T entity) => RestaurantContext.Set<T>().Update(entity);
        public void Delete(T entity) => RestaurantContext.Set<T>().Remove(entity);
    }
}
