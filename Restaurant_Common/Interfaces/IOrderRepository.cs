namespace Restaurant_Common.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Get all Order object from database
        /// </summary>
        /// <returns></returns>
        public IList<Order> GetOrders();
        /// <summary>
        /// Get first Order object from database by parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Order GetFirstOrderByParameter<T>(string propertyName, T value);
        /// <summary>
        /// Get all Food object from database by parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IList<Order> GetOrdersByParameter<T>(string propertyName, T value);
        /// <summary>
        /// Add an Order object to database
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order);
        /// <summary>
        /// Update an Order object from database
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(Order order);
        /// <summary>
        /// Delete an Order object from database
        /// </summary>
        /// <param name="order"></param>
        public void DeleteOrder(Order order);
    }
}
