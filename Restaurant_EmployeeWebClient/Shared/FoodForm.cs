using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Radzen;
using Restaurant_Common.Models;
using Restaurant_EmployeeWebClient.Services;

namespace Restaurant_EmployeeWebClient.Shared
{
    public partial class FoodForm
    {
        [Parameter]
        public Food Food { get; set; }

        [Parameter]
        public Func<Task> SubmitForm { get; set; }

        [Parameter]
        public string ButtonTitle { get; set; }

        [Parameter]
        public string CompTitle { get; set; }

        [Parameter]
        public IEnumerable<FoodType> FoodTypes { get; set; }

        [Inject]
        public IFileUpload fileUpload { get; set; } 

        void OnProgress(UploadProgressArgs args)
        {
            var info = $"% / {args.Loaded} of {args.Total} bytes.";
            var progress = args.Progress;

            if (args.Progress == 100)
            {
                foreach (var file in args.Files)
                {
                    this.Food.ImageUrl = "wwwroot/images/" + file.Name;
                }
            }
        }

        async Task CachingImage(IFileListEntry file)
        {
            if (file != null)
            {
                await fileUpload.Upload(file);
            }
        }

    }
}
