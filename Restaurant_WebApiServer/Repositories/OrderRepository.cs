using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantContext _context;
        public OrderRepository(RestaurantContext context)
        {
            _context = context;
        }
        public IList<Order> GetOrders()
        {
            if (_context.Orders != null)
                return _context.Orders.ToList();
            return new List<Order>();
        }
        public Order GetFirstOrderByParameter<T>(string propertyName, T value)
        {
            if (value is null)
                return new();
            return GetOrdersByParameter(propertyName, value).FirstOrDefault()
                ?? new();
        }
        public IList<Order> GetOrdersByParameter<T>(string propertyName, T value)
        {
            if (value is null)
                return new List<Order>();
            return _context.Orders?.AsNoTracking().AsEnumerable().Where(order
                => value.Equals(order.GetType().GetProperty(propertyName)?.GetValue(order))).ToList()
                ?? new List<Order>();
        }
        public void AddOrder(Order order)
        {
            _context.Orders?.Add(order);
            _context.SaveChanges();
        }
        public void UpdateOrder(Order order)
        {
            var exist = GetFirstOrderByParameter(nameof(IOrder.Id), order.Id);

            if (exist != null)
            {
                exist.Price = order.Price;
                exist.Status = order.Status;
                _context.Orders?.Update(exist);
                _context.SaveChanges();
            }
        }
        public void DeleteOrder(Order order)
        {
            _context.Orders?.Remove(order);
            _context.SaveChanges();
        }

    }
}
