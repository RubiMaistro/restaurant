using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetAll()
        {
            var orders = _orderRepository.GetOrders();

            if (orders != null)
                return Ok(orders);

            return NotFound("No orders to display!");
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        public IActionResult GetById(int id)
        {
            var order = _orderRepository.GetFirstOrderByParameter(nameof(IOrder.Id), id);
            if (order != null)
                return Ok(order);
            else
                return NotFound("Order not found!");
        }
        [HttpGet("status/{status}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetAllByStatus(OrderStatus status)
        {
            var orders = _orderRepository.GetOrdersByParameter(nameof(IOrder.Status), status);

            if (orders != null && orders.Count > 0)
                return Ok(orders);

            return NotFound("No orders to display!");
        }
        [HttpGet("price/{price}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetAllByStatus(double price)
        {
            var orders = _orderRepository.GetOrdersByParameter(nameof(IOrder.Price), price);

            if (orders != null && orders.Count > 0)
                return Ok(orders);

            return NotFound("No orders to display!");
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Post(Order order)
        {
            _orderRepository.AddOrder(order);

            return Ok($"The '{order.Id}' id of order adding successful!");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Put(Order order, int id)
        {
            var OrderFromDb = _orderRepository.GetFirstOrderByParameter(nameof(IOrder), id);

            if (OrderFromDb != null)
            {
                _orderRepository.UpdateOrder(order);

                return Ok($"{order.Id} order updating successful!");
            }

            return NotFound("Order not found!");
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(int id)
        {
            var order = _orderRepository.GetFirstOrderByParameter(nameof(IOrder.Id), id);

            if (order != null)
            {
                _orderRepository.DeleteOrder(order);

                return Ok($"{order.Id} order deleting successful!");
            }

            return NotFound("Order not found!");
        }
    }
}
