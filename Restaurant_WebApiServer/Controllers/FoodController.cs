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
        public async Task<IActionResult> Post([FromForm] Food food)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(food);

            if (food == null)
                return BadRequest(food);

            var existFood = _repository.FoodRepository
                .FindByCondition(x => x.Name.Equals(food.Name))
                .FirstOrDefault();

            if (existFood != null)
                return UnprocessableEntity(food); // Food is already exist

            //create a new Food instance.  
            Food newFood = new()
            {
                FoodTypeId = food.FoodTypeId,
                Name = food.Name,
                Description = food.Description,
                Price = food.Price,
            };

            //create a Photo list to store the upload files.  
            List<Photo> photolist = new List<Photo>();
            if (food.Files.Count > 0)
            {
                foreach (var formFile in food.Files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(memoryStream);
                            // Upload the file if less than 2 MB  
                            if (memoryStream.Length < 2097152)
                            {
                                //based on the upload file to create Photo instance.  
                                //You can also check the database, whether the image exists in the database.  
                                Photo newphoto = new()
                                {
                                    Bytes = memoryStream.ToArray(),
                                    Description = formFile.FileName,
                                    FileExtension = Path.GetExtension(formFile.FileName),
                                    Size = formFile.Length,
                                };
                                //add the photo instance to the list.  
                                photolist.Add(newphoto);
                            }
                            else
                            {
                                ModelState.AddModelError("File", "The file is too large.");
                            }
                        }
                    }
                }
            }
            //assign the photos to the Product, using the navigation property.  
            newFood.Photos = photolist;

            _repository.FoodRepository.Create(newFood);
            _repository.Save();

            return Ok($"{newFood.Name} food adding successful!");
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
