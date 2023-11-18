using Restaurant_Common.Models;
using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly RestaurantContext _context;
        public OrderItemRepository(RestaurantContext context)
        {
            _context = context;
        }
        public IList<OrderItem> GetOrders()
        {
            if (_context.OrderedFoods != null)
                return _context.OrderedFoods.ToList();
            return new List<OrderItem>();
        }

        public OrderItem GetOrderById(long id)
        {
            if (_context.OrderedFoods != null)
            {
                var orderedFood = _context.OrderedFoods.Where(order => order.Id == id);
                if (orderedFood.Any())
                    return orderedFood.First();
            }
            return new OrderItem();
        }

        public void AddOrder(OrderItem order)
        {
            if (_context.OrderedFoods != null)
            {
                _context.OrderedFoods.Add(order);
                _context.SaveChanges();
            }
        }

        public void DeleteOrder(OrderItem order)
        {
            if (_context.OrderedFoods != null)
            {
                _context.OrderedFoods.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
