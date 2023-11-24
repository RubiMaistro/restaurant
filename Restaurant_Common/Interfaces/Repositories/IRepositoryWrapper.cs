using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IFoodTypeRepository FoodTypeRepository { get; }
        void Save();
    }
}
