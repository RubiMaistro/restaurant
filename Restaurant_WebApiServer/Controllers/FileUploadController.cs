using Microsoft.AspNetCore.Mvc;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _oWebHostEnvironment;

        public FileUploadController(IWebHostEnvironment oWebHostEnvironment)
        {
            _oWebHostEnvironment = oWebHostEnvironment;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get([FromRoute]string name)
        {
            string[] sub = name.Split(".");
            var path = Path.Combine(_oWebHostEnvironment.ContentRootPath, $"wwwroot/images");
            string filePath = Path.Combine(path, name);

            if (System.IO.File.Exists(filePath))
            {
                byte [] bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, $"image/{sub[1]}");
            }

            return null;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string[] sub = file.FileName.Split(".");

                    var path = Path.Combine(_oWebHostEnvironment.ContentRootPath, $"wwwroot/images");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string filePath = Path.Combine(path, file.FileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(stream);
                        stream.Flush();
                        return Ok("Upload Successful");
                    }
                }
                else
                {
                    return BadRequest("Upload Failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
