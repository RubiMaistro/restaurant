using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food/type")]
    public class FoodTypeController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<FoodType>> Get()
        {
            var types = FoodTypeRepository.GetFoodTypes();

            if (types != null)
            {
                return Ok(types);
            }

            return NotFound("No food types to display!");
        }

        [HttpGet("{id}")]
        public ActionResult<FoodType> Get(long id)
        {
            var type = FoodTypeRepository.GetFoodTypeById(id);

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
            FoodTypeRepository.AddFoodType(type);

            return Ok($"{type.Name} food type adding successful!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(FoodType type, long id)
        {
            var FoodTypeFromDb = FoodTypeRepository.GetFoodTypeById(id);

            if (FoodTypeFromDb != null)
            {
                FoodTypeRepository.UpdateFoodType(type);

                return Ok($"{type.Name} food type updating successful!");
            }

            return NotFound("Food not found!");

            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var type = FoodTypeRepository.GetFoodTypeById(id);

            if (type != null)
            {
                FoodTypeRepository.DeleteFoodType(type);

                return Ok($"{type.Name} food type deleting successful!");
            }

            return NotFound("Food type not found!");
        }
    }
}
