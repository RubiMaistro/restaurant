namespace Restaurant_Common.Interfaces
{
    public interface IFoodRepository
    {
        public IList<Food> GetFoods();
        public Food GetFoodById(int foodId);
        public Food GetFirstFoodByParameter<T>(string propertyName, T value);
        public IList<Food> GetFoodsByParameter<T>(string propertyName, T value);
        public void AddFood(Food food);
        public void UpdateFood(Food food);
        public void DeleteFood(Food food);
    }
}
