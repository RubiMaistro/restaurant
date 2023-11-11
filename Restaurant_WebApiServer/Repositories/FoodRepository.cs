using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly RestaurantContext _context;
        public FoodRepository(RestaurantContext context)
        {
            _context = context;
        }

        public IList<Food> GetFoods()
        {
            if (_context.Foods != null)
                return _context.Foods.ToList();
            return new List<Food>();
        }

        public Food GetFoodById(long id)
        {
            if (_context.Foods != null)
            {
                var foods = _context.Foods.Where(food => food.Id == id);
                if (foods.Any())
                    return foods.First();
            }
            return new Food();
        }

        public void AddFood(Food food)
        {
            if (_context.Foods != null)
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
            }
        }

        public void UpdateFood(Food food)
        {
            if (_context.Foods != null)
            {
                _context.Foods.Update(food);
                _context.SaveChanges();
            }
        }

        public void DeleteFood(Food food)
        {
            if (_context.Foods != null)
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
            }
        }
    }
}
