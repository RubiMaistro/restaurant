using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class FoodRepository
    {
        public static IList<Food> GetFoods()
        {
            using (var database = new RestaurantContext())
            {
                var foods = database.Foods.ToList();

                return foods;
            }
        }

        public static Food GetFoodById(long id)
        {
            using (var database = new RestaurantContext())
            {
                var food = database.Foods.Where(food => food.Id == id).FirstOrDefault();

                return food;
            }
        }

        public static void AddFood(Food food)
        {
            using (var database = new RestaurantContext())
            {
                database.Foods.Add(food);

                database.SaveChanges();
            }
        }

        public static void UpdateFood(Food food)
        {
            using (var database = new RestaurantContext())
            {
                database.Foods.Update(food);

                database.SaveChanges();
            }
        }

        public static void DeleteFood(Food food)
        {
            using (var database = new RestaurantContext())
            {
                database.Foods.Remove(food);

                database.SaveChanges();
            }
        }
    }
}
