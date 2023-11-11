using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Interfaces
{
    public interface IFoodTypeRepository
    {
        public IList<FoodType> GetFoodTypes();
        public FoodType GetFoodTypeById(long id);
        public void AddFoodType(FoodType type);
        public void UpdateFoodType(FoodType type);
        public void DeleteFoodType(FoodType type);
    }
}
