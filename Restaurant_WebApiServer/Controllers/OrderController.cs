using Microsoft.AspNetCore.Mvc;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public OrderController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult Get([FromQuery] QueryParameters parameters)
        {
            var orders = _repository.OrderRepository
                .FindAll()
                .GetByQueryParameters(parameters);
            if (orders != null)
                return Ok(orders);

            return NotFound("No orders to display!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        public IActionResult GetById(int id)
        {
            var order = _repository.OrderRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (order != null)
                return Ok(order);

            return NotFound("Order not found!");
        }

        [HttpGet("status/{status}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetAllByStatus(OrderStatus status)
        {
            var orders = _repository.OrderRepository
                .FindByCondition(x => x.Status.Equals(status))
                .ToList();

            if (orders != null && orders.Count > 0)
                return Ok(orders);

            return NotFound("No orders to display!");
        }
        [HttpGet("price/{price}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetAllByPrice(double price)
        {
            var orders = _repository.OrderRepository
                .FindByCondition(x => x.Price.Equals(price))
                .ToList();
                
            if (orders != null && orders.Count > 0)
                return Ok(orders);

            return NotFound("No orders to display!");
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Post(Order orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(orderCreate);

            var existingOrder = _repository.OrderRepository
                .FindByCondition(x => x.Id == orderCreate.Id)
                .FirstOrDefault();

            if (existingOrder != null)
                return UnprocessableEntity(orderCreate);

            _repository.OrderRepository.Create(orderCreate);
            _repository.Save();

            return Ok($"The '{orderCreate.Id}' id of order adding successful!");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Put(Order order, int id)
        {
            var existingOrder = _repository.OrderRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (existingOrder != null)
            {
                _repository.OrderRepository.Update(order);
                _repository.Save();
                return Ok($"{order.Id} order updating successful!");
            }
            else
            {
                _repository.OrderRepository.Create(order);
                _repository.Save();
                return Ok($"{order.Id} order adding successful!");
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(int id)
        {
            var existingOrder = _repository.OrderRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (existingOrder != null)
            {
                _repository.OrderRepository.Delete(existingOrder);
                _repository.Save();

                return Ok($"{existingOrder.Id} order deleting successful!");
            }

            return NotFound("Order not found!");
        }
    }
}
