using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food/ordered")]
    public class OrderItemController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public OrderItemController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderItem>))]
        public IActionResult Get([FromQuery] QueryParameters parameters)
        {
            var orderItems = _repository.OrderItemRepository
                .FindAll()
                .GetByQueryParameters(parameters);

            if (orderItems != null)
            {
                return Ok(orderItems);
            }

            return NotFound("No ordered food items to display!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderItem))]
        public IActionResult Get(long id)
        {
            var orderItem = _repository.OrderItemRepository
               .FindByCondition(x => x.Id.Equals(id))
               .FirstOrDefault();

            if (orderItem != null)
                return Ok(orderItem);
            
            return NotFound("Order Item not found!");
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Post(OrderItem orderItem)
        {
            if (orderItem == null)
                return BadRequest(orderItem);

            var existOrderItem = _repository.OrderItemRepository
                .FindByCondition(x => x.Id.Equals(orderItem.Id))
                .FirstOrDefault();

            if (existOrderItem != null)
                return UnprocessableEntity(orderItem);

            _repository.OrderItemRepository.Create(orderItem);
            _repository.Save();

            return Ok($"The {orderItem.FoodId} id of order item adding successful!");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Put(OrderItem orderItem, int id)
        {
            if (orderItem == null)
                return BadRequest(orderItem);

            var existOrderItem = _repository.OrderItemRepository
                .FindByCondition(x => x.Id.Equals(orderItem.Id))
                .FirstOrDefault();

            if (existOrderItem != null)
            {
                _repository.OrderItemRepository.Update(orderItem);
                _repository.Save();
                return Ok($"{orderItem.Id} order item updating successful!");
            }
            else
            {
                _repository.OrderItemRepository.Create(orderItem);
                _repository.Save();
                return Ok($"{orderItem.Id} order item adding successful!");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(long id)
        {
            var existOrderItem = _repository.OrderItemRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (existOrderItem != null)
            {
                _repository.OrderItemRepository.Delete(existOrderItem);
                _repository.Save();
                return Ok($"The {existOrderItem.Id} id of order item deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
