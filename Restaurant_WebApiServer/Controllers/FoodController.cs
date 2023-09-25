using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodController : Controller
    {
        private readonly IFoodRepository _foodRepository;
        public FoodController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Food>))]
        public IActionResult Get()
        {
            var foods = _foodRepository.GetFoods();

            if (foods != null)
            {
                return Ok(foods);
            }

            return NotFound("No foods to display!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Food))]
        public IActionResult Get(long id)
        {
            var food = _foodRepository.GetFoodById(id);

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
        [ProducesResponseType(200)]
        public IActionResult Post(Food foodCreate)
        {
            if (foodCreate == null)
                return BadRequest(foodCreate);

            var foods = _foodRepository.GetFoods()
                .Where(c => c.Name.Trim().ToUpper() == foodCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (foods != null)
            {
                return StatusCode(422, foodCreate); // Food is already exist
            }

            _foodRepository.AddFood(foodCreate);

            return Ok($"{foodCreate.Name} food adding successful!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Put(Food food, long id)
        {
            var FoodFromDb = _foodRepository.GetFoodById(id);

            if (FoodFromDb != null)
            {
                _foodRepository.UpdateFood(food);

                return Ok($"{food.Name} food updating successful!");
            }

            return NotFound("Food not found!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(long id)
        {
            var food = _foodRepository.GetFoodById(id);

            if (food != null)
            {
                _foodRepository.DeleteFood(food);

                return Ok($"{food.Name} food deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
