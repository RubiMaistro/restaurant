using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food/ordered")]
    public class OrderedFoodController : Controller
    {
        private readonly IOrderedFoodRepository _orderedFoodRepository;
        public OrderedFoodController(IOrderedFoodRepository orderedFoodRepository)
        {
            _orderedFoodRepository = orderedFoodRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<OrderedFood>> Get()
        {
            var foods = _orderedFoodRepository.GetOrders();

            if (foods != null)
            {
                return Ok(foods);
            }

            return NotFound("No ordered foods to display!");
        }

        [HttpGet("{id}")]
        public ActionResult<OrderedFood> Get(long id)
        {
            var food = _orderedFoodRepository.GetOrderById(id);

            if (food != null)
            {
                return Ok(food);
            }
            else
            {
                return NotFound("Ordered food not found!");
            }
        }

        [HttpPost]
        public ActionResult Post(OrderedFood food)
        {
            _orderedFoodRepository.AddOrder(food);

            return Ok($"The {food.FoodId} id of food adding successful!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var food = _orderedFoodRepository.GetOrderById(id);

            if (food != null)
            {
                _orderedFoodRepository.DeleteOrder(food);

                return Ok($"The {food.Id} id of food deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
