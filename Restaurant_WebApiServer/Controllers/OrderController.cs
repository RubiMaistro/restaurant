using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            var orders = _orderRepository.GetOrders();

            if (orders != null)
            {
                return Ok(orders);
            }

            return NotFound("No orders to display!");
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(long id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound("Order not found!");
            }
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            var orders = _orderRepository.GetOrders();

            order.Id = GetNewId(orders);
            _orderRepository.AddOrder(order);

            return Ok($"The '{order.Id}' id of food adding successful!");
        }

        private int GetNewId(IList<Order> orders)
        {
            int newId = 0;
            foreach(var order in orders)
            {
                if(newId <= order.Id)
                {
                    newId = order.Id;
                }
            }
            return newId + 1;
        }

        [HttpPut("{id}")]
        public ActionResult Put(Order order, long id)
        {
            var OrderFromDb = _orderRepository.GetOrderById(id);

            if (OrderFromDb != null)
            {
                _orderRepository.UpdateOrder(order);

                return Ok($"{order.Id} order updating successful!");
            }

            return NotFound("Order not found!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (order != null)
            {
                _orderRepository.DeleteOrder(order);

                return Ok($"{order.Id} food deleting successful!");
            }

            return NotFound("Order not found!");
        }
    }
}
