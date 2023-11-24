using Restaurant_Common.Interfaces.Repositories;
using Restaurant_WebApiServer.DataObjects;
using System.Linq.Expressions;

namespace Restaurant_WebApiServer.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RestaurantContext RestaurantContext { get; set; }
        public RepositoryBase(RestaurantContext restaurantContext)
        {
            RestaurantContext = restaurantContext;
        }
        public IQueryable<T> FindAll() => RestaurantContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition) => 
            RestaurantContext.Set<T>().Where(condition).AsNoTracking();
        public void Create(T entity) => RestaurantContext.Set<T>().Add(entity);
        public void Update(T entity) => RestaurantContext.Set<T>().Update(entity);
        public void Delete(T entity) => RestaurantContext.Set<T>().Remove(entity);
    }
}
