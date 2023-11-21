using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant_Common.Models;
using Restaurant_Common.Models.Filter;
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
        
        public async Task<IEnumerable<Food>> GetFoodsAsync(QueryParameters parameters)
        {
            if (_context.Foods != null)
            {
                var allFoods = _context.Foods.AsQueryable();
                var pagedFoods = await allFoods
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .ToListAsync();

                return pagedFoods;
            }
            return new List<Food>();
        }
        public Food GetFirstFoodByParameter<T>(string propertyName, T value)
        {
            if (value is null) 
                return new(); 
            return GetFoodsByParameter(propertyName, value).FirstOrDefault() ?? new();
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
