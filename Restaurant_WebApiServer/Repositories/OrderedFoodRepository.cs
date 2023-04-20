using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class OrderedFoodRepository
    {
        public static IList<OrderedFood> GetOrders()
        {
            using (var database = new RestaurantContext())
            {
                var orders = database.OrderedFoods.ToList();

                return orders;
            }
        }

        public static OrderedFood GetOrderById(long id)
        {
            using (var database = new RestaurantContext())
            {
                var order = database.OrderedFoods.Where(order => order.Id == id).FirstOrDefault();

                return order;
            }
        }

        public static void AddOrder(OrderedFood order)
        {
            using (var database = new RestaurantContext())
            {
                database.OrderedFoods.Add(order);

                database.SaveChanges();
            }
        }

        public static void DeleteOrder(OrderedFood order)
        {
            using (var database = new RestaurantContext())
            {
                database.OrderedFoods.Remove(order);

                database.SaveChanges();
            }
        }
    }
}
