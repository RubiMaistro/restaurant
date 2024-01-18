namespace Restaurant_WebApiServer.Repositories.Implementations
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(RestaurantContext context)
            : base(context)
        {

        }

    }
}
