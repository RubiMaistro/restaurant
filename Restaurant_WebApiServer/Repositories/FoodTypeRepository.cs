using Restaurant_WebApiServer.DataObjects;

namespace Restaurant_WebApiServer.Repositories
{
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly RestaurantContext _context;
        public FoodTypeRepository(RestaurantContext context)
        {
            _context = context;
        }
        public IList<FoodType> GetFoodTypes()
        {
            if (_context.FoodTypes != null)
                return _context.FoodTypes.ToList();
            return new List<FoodType>();
        }

        public FoodType GetFoodTypeById(long id)
        {
            if (_context.FoodTypes != null)
            {
                var types = _context.FoodTypes.Where(type => type.Id == id);
                if (types.Any())
                    return types.First();
            }
            return new FoodType();
        }

        public void AddFoodType(FoodType type)
        {
            if (_context.FoodTypes != null)
            {
                _context.FoodTypes.Add(type);
                _context.SaveChanges();
            }
        }

        public void UpdateFoodType(FoodType type)
        {
            if (_context.FoodTypes != null)
            {
                _context.FoodTypes.Update(type);
                _context.SaveChanges();
            }
        }

        public void DeleteFoodType(FoodType type)
        {
            if (_context.FoodTypes != null)
            {
                _context.FoodTypes.Remove(type);
                _context.SaveChanges();
            }
        }
    }
}
