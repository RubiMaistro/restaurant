using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Food>> Get()
        {
            var foods = FoodRepository.GetFoods();

            if (foods != null)
            {
                return Ok(foods);
            }

            return NotFound("No foods to display!");
        }

        [HttpGet("{id}")]
        public ActionResult<Food> Get(long id)
        {
            var food = FoodRepository.GetFoodById(id);

            if (food != null)
            {
                return Ok(food);
            }
            else
            {
                return NotFound("Food not found!");
            }
        }

        [HttpPost]
        public ActionResult Post(Food food)
        {
            FoodRepository.AddFood(food);

            return Ok($"{food.Name} food adding successful!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(Food food, long id)
        {
            var FoodFromDb = FoodRepository.GetFoodById(id);

            if (FoodFromDb != null)
            {
                FoodRepository.UpdateFood(food);

                return Ok($"{food.Name} food updating successful!");
            }

            return NotFound("Food not found!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var food = FoodRepository.GetFoodById(id);

            if (food != null)
            {
                FoodRepository.DeleteFood(food);

                return Ok($"{food.Name} food deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
