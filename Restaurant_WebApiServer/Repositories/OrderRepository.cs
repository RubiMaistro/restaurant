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
            return _context.Orders?.AsEnumerable().Where(order
                => value.Equals(order.GetType().GetProperty(propertyName)?.GetValue(order))).ToList()
                ?? new();
        }
        public Order GetOrderById(long id) => _context.Orders?
            .FirstOrDefault(order => order.Id == id) ?? new Order();
        public void AddOrder(Order order)
        {
            _context.Orders?.Add(order);
            _context.SaveChanges();
        }
        public void UpdateOrder(Order order)
        {
            _context.Orders?.Update(order);
            _context.SaveChanges();
        }
        public void DeleteOrder(Order order)
        {
            _context.Orders?.Remove(order);
            _context.SaveChanges();
        }

    }
}
