using Microsoft.AspNetCore.Mvc;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public FoodController(IRepositoryWrapper epositoryWrapper)
        {
            _repository = epositoryWrapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Food>))]
        public IActionResult Get([FromQuery] QueryParameters parameters)
        {
            var foods = _repository.FoodRepository.FindAll().GetByQueryParameters(parameters);
            if (foods != null)
                return Ok(foods);

            return NotFound("No foods to display!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Food))]
        public IActionResult Get(int id)
        {
            var food = _repository.FoodRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (food != null)
                return Ok(food);

            return NotFound("Food not found!");
        }
        
        [HttpGet("foodtype/{typeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Food>))]
        public IActionResult GetByFoodTypeId([FromQuery] QueryParameters parameters, int typeId)
        {
            var foods = _repository.FoodRepository
                .FindByCondition(x => x.FoodTypeId.Equals(typeId))
                .GetByQueryParameters(parameters);

            if (foods != null)
                return Ok(foods);
            else
                return NotFound("Food not found!");
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Post(Food foodCreate)
        {
            if (foodCreate == null)
                return BadRequest(foodCreate);

            var existFood = _repository.FoodRepository
                .FindByCondition(x => x.Name.Equals(foodCreate.Name))
                .FirstOrDefault();

            if (existFood != null)
                return UnprocessableEntity(foodCreate); // Food is already exist

            _repository.FoodRepository.Create(foodCreate);
            _repository.Save();

            return Ok($"{foodCreate.Name} food adding successful!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Put(Food food, int id)
        {
            var existFood = _repository.FoodRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (existFood != null)
            {
                _repository.FoodRepository.Update(food);
                _repository.Save();
                return Ok($"{food.Name} food updating successful!");
            }
            else
            {
                _repository.FoodRepository.Create(food);
                _repository.Save();
                return Ok($"{food.Name} food adding successful!");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(int id)
        {
            var existFood = _repository.FoodRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (existFood != null)
            {
                _repository.FoodRepository.Delete(existFood);
                _repository.Save();
                return Ok($"{existFood.Name} food deleting successful!");
            }

            return NotFound("Food not found!");
        }
    }
}
