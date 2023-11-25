namespace Restaurant_Common.Interfaces.Repositories.Implementations
{
    public interface IOrderItemRepository
    {
        /// <summary>
        /// Get all OrderItems from database
        /// </summary>
        /// <returns></returns>
        public IList<OrderItem> GetOrderItems();
        /// <summary>
        /// Get an OrderItem from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderItem GetOrderItemById(long id);
        /// <summary>
        /// Add an OrderItem to database
        /// </summary>
        /// <param name="order"></param>
        public void AddOrderItem(OrderItem order);
        /// <summary>
        /// Update an OrderItem in database
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrderItem(OrderItem order);
        /// <summary>
        /// Delete an OrderItem from database
        /// </summary>
        /// <param name="order"></param>
        public void DeleteOrderItem(OrderItem order);
    }
}
