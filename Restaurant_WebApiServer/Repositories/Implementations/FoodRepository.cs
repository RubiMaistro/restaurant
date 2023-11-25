using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant_Common.Models;
using Restaurant_Common.Models.Filter;
using Restaurant_WebApiServer.DataObjects;

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
