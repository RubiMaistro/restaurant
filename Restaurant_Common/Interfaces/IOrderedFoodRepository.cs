using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Interfaces
{
    public interface IOrderedFoodRepository
    {
        public IList<OrderedFood> GetOrders();
        public OrderedFood GetOrderById(long id);
        public void AddOrder(OrderedFood order);
        public void DeleteOrder(OrderedFood order);
    }
}
