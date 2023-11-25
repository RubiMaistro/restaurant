using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Interfaces.Repositories;
using Restaurant_Common.Models;
using Restaurant_Common.Models.Filter;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/food/type")]
    public class FoodTypeController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public FoodTypeController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FoodType>))]
        public IActionResult Get([FromQuery] QueryParameters parameters)
        {
            var types = _repository.FoodTypeRepository
                .FindAll()
                .GetByQueryParameters(parameters);

            if (types != null)
            {
                return Ok(types);
            }

            return NotFound("No food types to display!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FoodType))]
        [ProducesResponseType(404, Type = typeof(FoodType))]
        public IActionResult Get([FromQuery] QueryParameters parameters, long id)
        {
            var type = _repository.FoodTypeRepository
                .FindByCondition(x => x.Id.Equals(id))
                .GetByQueryParameters(parameters)
                .FirstOrDefault();

            if (type != null)
                return Ok(type);
            else
                return NotFound("Food type not found!");
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Post(FoodType type)
        {
            _repository.FoodTypeRepository.Create(type);
            _repository.Save();

            return Ok($"{type.Name} food type adding successful!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult Put(FoodType type, long id)
        {
            var FoodTypeFromDb = _repository.FoodTypeRepository
                .FindByCondition(x => x.Id == id)
                .FirstOrDefault();

            if (FoodTypeFromDb != null)
            {
                _repository.FoodTypeRepository.Update(type);
                _repository.Save();

                return Ok($"{type.Name} food type updating successful!");
            }
            else
            {
                _repository.FoodTypeRepository.Create(type);
                _repository.Save();
            }

            return NotFound("Food not found!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult Delete(long id)
        {
            var type = _repository.FoodTypeRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (type != null)
            {
                _repository.FoodTypeRepository.Delete(type);
                _repository.Save();

                return Ok($"{type.Name} food type deleting successful!");
            }

            return NotFound("Food type not found!");
        }
    }
}
