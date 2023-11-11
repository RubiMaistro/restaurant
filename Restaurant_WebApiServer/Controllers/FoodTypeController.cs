using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food/type")]
    public class FoodTypeController : Controller
    {
        private readonly IFoodTypeRepository _foodTypeRepository;

        public FoodTypeController(IFoodTypeRepository foodTypeRepository)
        {
            _foodTypeRepository = foodTypeRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<FoodType>> Get()
        {
            var types = _foodTypeRepository.GetFoodTypes();

            if (types != null)
            {
                return Ok(types);
            }

            return NotFound("No food types to display!");
        }

        [HttpGet("{id}")]
        public ActionResult<FoodType> Get(long id)
        {
            var type = _foodTypeRepository.GetFoodTypeById(id);

            if (type != null)
            {
                return Ok(type);
            }
            else
            {
                return NotFound("Food type not found!");
            }
        }

        [HttpPost]
        public ActionResult Post(FoodType type)
        {
            _foodTypeRepository.AddFoodType(type);

            return Ok($"{type.Name} food type adding successful!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(FoodType type, long id)
        {
            var FoodTypeFromDb = _foodTypeRepository.GetFoodTypeById(id);

            if (FoodTypeFromDb != null)
            {
                _foodTypeRepository.UpdateFoodType(type);

                return Ok($"{type.Name} food type updating successful!");
            }

            return NotFound("Food not found!");

            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var type = _foodTypeRepository.GetFoodTypeById(id);

            if (type != null)
            {
                _foodTypeRepository.DeleteFoodType(type);

                return Ok($"{type.Name} food type deleting successful!");
            }

            return NotFound("Food type not found!");
        }
    }
}
