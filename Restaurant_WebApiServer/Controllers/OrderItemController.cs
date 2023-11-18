using Microsoft.AspNetCore.Mvc;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food/ordered")]
    public class OrderItemController : Controller
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemController(IOrderItemRepository orderedFoodRepository)
        {
            _orderItemRepository = orderedFoodRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderItem>))]
        public IActionResult Get()
        {
            var foods = _orderItemRepository.GetOrderItems();

            if (foods != null)
            {
                return Ok(foods);
            }

            return NotFound("No ordered food items to display!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderItem))]
        public IActionResult Get(long id)
        {
            var food = _orderItemRepository.GetOrderItemById(id);

            if (food != null)
            {
                return Ok(food);
            }
            else
            {
                return NotFound("Ordered food item not found!");
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Post(OrderItem food)
        {
            _orderItemRepository.AddOrderItem(food);

            return Ok($"The {food.FoodId} id of food item adding successful!");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Put(OrderItem orderItem, int id)
        {
            var existsOrderItem = _orderItemRepository.GetOrderItemById(id);

            if (existsOrderItem != null)
            {
                _orderItemRepository.UpdateOrderItem(orderItem);

                return Ok($"{orderItem.Id} order updating successful!");
            }

            return NotFound("Order not found!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(long id)
        {
            var food = _orderItemRepository.GetOrderItemById(id);

            if (food != null)
            {
                _orderItemRepository.DeleteOrderItem(food);

                return Ok($"The {food.Id} id of food item deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
