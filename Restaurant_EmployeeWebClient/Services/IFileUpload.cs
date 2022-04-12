using BlazorInputFile;

namespace Restaurant_EmployeeWebClient.Services
{
    public interface IFileUpload
    {
        Task Upload(IFileListEntry file);
    }
}
