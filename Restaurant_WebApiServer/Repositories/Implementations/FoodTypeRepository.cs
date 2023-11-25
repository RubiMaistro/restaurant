using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories.Implementations
{
    public class FoodTypeRepository : RepositoryBase<FoodType>, IFoodTypeRepository
    {
        public FoodTypeRepository(RestaurantContext context)
            : base(context)
        {
        }

    }
}
