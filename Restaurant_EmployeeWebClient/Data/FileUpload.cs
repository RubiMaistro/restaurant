using BlazorInputFile;
using Restaurant_EmployeeWebClient.Services;

namespace Restaurant_EmployeeWebClient.Data
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _oWebHostEnvironment;

        public FileUpload(IWebHostEnvironment oWebHostEnvironment)
        {
            _oWebHostEnvironment = oWebHostEnvironment;
        }

        public async Task Upload(IFileListEntry file)
        {
            var path = Path.Combine(_oWebHostEnvironment.ContentRootPath, "wwwroot/images", file.Name);
            var memoryStream = new MemoryStream();
            await file.Data.CopyToAsync(memoryStream);

            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}
