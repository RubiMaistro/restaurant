using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant_Common.Models;
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
        public Food GetFirstFoodByParameter<T>(string propertyName, T value)
        {
            if (value is null) 
                return new(); 
            return GetFoodsByParameter(propertyName, value).FirstOrDefault() 
                ?? new();
        }
        public IList<Food> GetFoodsByParameter<T>(string propertyName, T value)
        {
            if (value is null) 
                return new List<Food>(); 
            return _context.Foods?.AsEnumerable().Where(food 
                => value.Equals(food.GetType().GetProperty(propertyName)?.GetValue(food))).ToList() 
                ?? new();
        }
        public void AddFood(Food food)
        {
            _context.Foods?.Add(food);
            _context.SaveChanges();
        }
        public void UpdateFood(Food food)
        {
            _context.Foods?.Update(food);
            _context.SaveChanges();
        }
        public void DeleteFood(Food food)
        {
            _context.Foods?.Remove(food);
            _context.SaveChanges();
        }
        

    }
}
