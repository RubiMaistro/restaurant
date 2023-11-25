using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Interfaces.Repositories.Base
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Food repository instance
        /// </summary>
        IFoodRepository FoodRepository { get; }
        /// <summary>
        /// FoodType repository instance
        /// </summary>
        IFoodTypeRepository FoodTypeRepository { get; }
        /// <summary>
        /// Order repository instance
        /// </summary>
        IOrderRepository OrderRepository { get; }
        /// <summary>
        /// OrderItem repository instance
        /// </summary>
        IOrderItemRepository OrderItemRepository { get; }
        /// <summary>
        /// Save all changes made in this context to the database
        /// </summary>
        void Save();
    }
}
