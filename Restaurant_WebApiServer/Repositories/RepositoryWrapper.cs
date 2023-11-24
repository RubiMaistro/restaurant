using Restaurant_Common.Interfaces.Repositories;
using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RestaurantContext _context;
        private IFoodTypeRepository _foodTypeRepository;
        public IFoodTypeRepository FoodTypeRepository
        {
            get
            {
                if ( _foodTypeRepository == null )
                {
                    _foodTypeRepository = new FoodTypeRepository(_context);
                }
                return _foodTypeRepository;
            }
        }

        public RepositoryWrapper(RestaurantContext restaurantContext)
        {
            _context = restaurantContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
