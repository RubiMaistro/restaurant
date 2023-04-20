using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public interface IFoodRepository
    {
        public IList<Food> GetFoods();
        public Food GetFoodById(long id);
        public void AddFood(Food food);
        public void UpdateFood(Food food);
        public void DeleteFood(Food food);
    }

    public class FoodRepository : IFoodRepository
    {
        public FoodRepository()
        {
        }

        public IList<Food> GetFoods()
        {
            using (var database = new RestaurantContext())
            {
                var foods = database.Foods.ToList();

                return foods;
            }
        }

        public Food GetFoodById(long id)
        {
            using (var database = new RestaurantContext())
            {
                var food = database.Foods.Where(food => food.Id == id).FirstOrDefault();

                return food;
            }
        }

        public void AddFood(Food food)
        {
            using (var database = new RestaurantContext())
            {
                database.Foods.Add(food);

                database.SaveChanges();
            }
        }

        public void UpdateFood(Food food)
        {
            using (var database = new RestaurantContext())
            {
                database.Foods.Update(food);

                database.SaveChanges();
            }
        }

        public void DeleteFood(Food food)
        {
            using (var database = new RestaurantContext())
            {
                database.Foods.Remove(food);

                database.SaveChanges();
            }
        }
    }
}
