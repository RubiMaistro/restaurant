using Restaurant_Common.Models;

namespace Restaurant_WebApiServer.Repositories
{
    public class OrderRepository
    {
        public static IList<Order> GetOrders()
        {
            using (var database = new RestaurantDbContext())
            {
                var orders = database.Orders.ToList();

                return orders;
            }
        }

        public static Order GetOrderById(long id)
        {
            using (var database = new RestaurantDbContext())
            {
                var order = database.Orders.Where(order => order.Id == id).FirstOrDefault();

                return order;
            }
        }

        public static void AddOrder(Order order)
        {
            using (var database = new RestaurantDbContext())
            {
                database.Orders.Add(order);

                database.SaveChanges();
            }
        }

        public static void UpdateOrder(Order order)
        {
            using (var database = new RestaurantDbContext())
            {
                database.Orders.Update(order);

                database.SaveChanges();
            }
        }

        public static void DeleteOrder(Order order)
        {
            using (var database = new RestaurantDbContext())
            {
                database.Orders.Remove(order);

                database.SaveChanges();
            }
        }
    }
}
