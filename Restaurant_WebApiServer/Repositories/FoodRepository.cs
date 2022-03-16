using Restaurant_Common.Models;

namespace Restaurant_WebApiServer.Repositories
{
    public class FoodRepository
    {
        public static IList<Food> GetFoods()
        {
            using (var database = new RestaurantDbContext())
            {
                var foods = database.Foods.ToList();

                return foods;
            }
        }

        public static Food GetFoodById(long id)
        {
            using (var database = new RestaurantDbContext())
            {
                var food = database.Foods.Where(food => food.Id == id).FirstOrDefault();

                return food;
            }
        }

        public static void AddFood(Food food)
        {
            using (var database = new RestaurantDbContext())
            {
                database.Foods.Add(food);

                database.SaveChanges();
            }
        }

        public static bool UpdateFood(Food food, long id)
        {
            using (var database = new RestaurantDbContext())
            {
                var dbFood = database.Foods.Where(food => food.Id == id).FirstOrDefault();

                if (dbFood != null)
                {
                    database.Foods.Update(food);

                    database.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public static void DeleteFood(Food food)
        {
            using (var database = new RestaurantDbContext())
            {
                database.Foods.Remove(food);

                database.SaveChanges();
            }
        }
    }
}
