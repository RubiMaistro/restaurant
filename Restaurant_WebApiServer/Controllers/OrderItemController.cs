using Microsoft.AspNetCore.Mvc;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food/ordered")]
    public class OrderItemController : Controller
    {
        private readonly IOrderItemRepository _orderedFoodRepository;
        public OrderItemController(IOrderItemRepository orderedFoodRepository)
        {
            _orderedFoodRepository = orderedFoodRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderItem>))]
        public IActionResult Get()
        {
            var foods = _orderedFoodRepository.GetOrders();

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
            var food = _orderedFoodRepository.GetOrderById(id);

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
            _orderedFoodRepository.AddOrder(food);

            return Ok($"The {food.FoodId} id of food item adding successful!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(long id)
        {
            var food = _orderedFoodRepository.GetOrderById(id);

            if (food != null)
            {
                _orderedFoodRepository.DeleteOrder(food);

                return Ok($"The {food.Id} id of food item deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
