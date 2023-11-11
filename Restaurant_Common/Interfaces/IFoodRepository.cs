namespace Restaurant_Common.Interfaces
{
    public interface IFoodRepository
    {
        public IList<Food> GetFoods();
        public Food GetFoodById(long id);
        public void AddFood(Food food);
        public void UpdateFood(Food food);
        public void DeleteFood(Food food);
    }
}
