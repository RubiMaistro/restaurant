using Restaurant_Common.Models;

namespace Restaurant_WebApiServer.Repositories
{
    public class FoodTypeRepository
    {
        public static IList<FoodType> GetFoodTypes()
        {
            using (var database = new RestaurantDbContext())
            {
                var types = database.FoodTypes.ToList();

                return types;
            }
        }

        public static FoodType GetFoodTypeById(long id)
        {
            using (var database = new RestaurantDbContext())
            {
                var type = database.FoodTypes.Where(type => type.Id == id).FirstOrDefault();

                return type;
            }
        }

        public static void AddFoodType(FoodType type)
        {
            using (var database = new RestaurantDbContext())
            {
                database.FoodTypes.Add(type);

                database.SaveChanges();
            }
        }

        public static void UpdateFoodType(FoodType type)
        {
            using (var database = new RestaurantDbContext())
            {
                database.FoodTypes.Update(type);

                database.SaveChanges();
            }
        }

        public static void DeleteFoodType(FoodType type)
        {
            using (var database = new RestaurantDbContext())
            {
                database.FoodTypes.Remove(type);

                database.SaveChanges();
            }
        }
    }
}
