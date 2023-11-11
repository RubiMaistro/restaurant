using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Interfaces
{
    public interface IOrderRepository
    {
        public IList<Order> GetOrders();
        public Order GetOrderById(long id);
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(Order order);
    }
}
