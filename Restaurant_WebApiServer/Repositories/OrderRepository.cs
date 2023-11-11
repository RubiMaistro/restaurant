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

        public Order GetOrderById(long id)
        {
            if (_context.Orders != null)
            {
                var order = _context.Orders.Where(order => order.Id == id);
                if (order.Any())
                    return order.First();
            }
            return new Order();
        }

        public void AddOrder(Order order)
        {
            if (_context.Orders != null)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            if (_context.Orders != null)
            {
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
        }

        public void DeleteOrder(Order order)
        {
            if (_context.Orders != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
