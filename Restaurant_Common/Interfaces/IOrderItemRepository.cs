using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Interfaces
{
    public interface IOrderItemRepository
    {
        public IList<OrderItem> GetOrders();
        public OrderItem GetOrderById(long id);
        public void AddOrder(OrderItem order);
        public void DeleteOrder(OrderItem order);
    }
}
