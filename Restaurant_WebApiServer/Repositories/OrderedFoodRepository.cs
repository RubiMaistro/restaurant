using Restaurant_Common.Models;
using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class OrderedFoodRepository : IOrderedFoodRepository
    {
        private readonly RestaurantContext _context;
        public OrderedFoodRepository(RestaurantContext context)
        {
            _context = context;
        }
        public IList<OrderedFood> GetOrders()
        {
            if (_context.OrderedFoods != null)
                return _context.OrderedFoods.ToList();
            return new List<OrderedFood>();
        }

        public OrderedFood GetOrderById(long id)
        {
            if (_context.OrderedFoods != null)
            {
                var orderedFood = _context.OrderedFoods.Where(order => order.Id == id);
                if (orderedFood.Any())
                    return orderedFood.First();
            }
            return new OrderedFood();
        }

        public void AddOrder(OrderedFood order)
        {
            if (_context.OrderedFoods != null)
            {
                _context.OrderedFoods.Add(order);
                _context.SaveChanges();
            }
        }

        public void DeleteOrder(OrderedFood order)
        {
            if (_context.OrderedFoods != null)
            {
                _context.OrderedFoods.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
