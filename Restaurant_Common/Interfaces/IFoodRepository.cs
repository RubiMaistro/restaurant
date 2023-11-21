using Restaurant_Common.Models.Filter;

namespace Restaurant_Common.Interfaces
{
    public interface IFoodRepository
    {
        /// <summary>
        /// Get all Food object from database
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Food>> GetFoodsAsync(QueryParameters parameters);
        /// <summary>
        /// Get first Food object from database by parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Food GetFirstFoodByParameter<T>(string propertyName, T value);
        /// <summary>
        /// Get all Food object from database by parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IList<Food> GetFoodsByParameter<T>(string propertyName, T value);
        /// <summary>
        /// Add a Food object to database
        /// </summary>
        /// <param name="food"></param>
        public void AddFood(Food food);
        /// <summary>
        /// Update a Food object in database
        /// </summary>
        /// <param name="food"></param>
        public void UpdateFood(Food food);
        /// <summary>
        /// Delete a Food object from database
        /// </summary>
        /// <param name="food"></param>
        public void DeleteFood(Food food);
    }
}
