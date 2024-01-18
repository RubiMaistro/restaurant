namespace Restaurant_WebApiServer.Repositories.Implementations
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context)
            : base(context)
        {
            
        }
    }
}
