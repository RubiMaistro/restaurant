namespace Restaurant_WebApiServer.Repositories.Implementations
{
    public class FoodRepository : RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(RestaurantContext context)
            : base(context)
        {
        }

    }
}
