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
        public IActionResult Get(int id)
        {
            var food = _foodRepository.GetFirstFoodByParameter(nameof(IFood.Id), id);

            if (food != null)
                return Ok(food);
            else
                return NotFound("Food not found!");
        }
        
        [HttpGet("foodtype/{typeId}")]
        [ProducesResponseType(200, Type = typeof(IList<Food>))]
        public IActionResult GetByFoodTypeId(int typeId)
        {
            var food = _foodRepository.GetFoodsByParameter(nameof(IFood.FoodTypeId), typeId);

            if (food != null)
                return Ok(food);
            else
                return NotFound("Food not found!");
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Post(Food foodCreate)
        {
            if (foodCreate == null)
                return BadRequest(foodCreate);

            var existFood = _foodRepository.GetFirstFoodByParameter(nameof(IFood), foodCreate.Name);

            if (existFood != null)
                return UnprocessableEntity(foodCreate); // Food is already exist

            _foodRepository.AddFood(foodCreate);

            return Ok($"{foodCreate.Name} food adding successful!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Put(Food food, int id)
        {
            var existFood = _foodRepository.GetFirstFoodByParameter(nameof(IFood.Id), id);

            if (existFood != null)
            {
                _foodRepository.UpdateFood(food);

                return Ok($"{food.Name} food updating successful!");
            }

            return NotFound("Food not found!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(int id)
        {
            var existFood = _foodRepository.GetFirstFoodByParameter(nameof(IFood.Id), id);

            if (existFood != null)
            {
                _foodRepository.DeleteFood(existFood);

                return Ok($"{existFood.Name} food deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
