using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Radzen;
using Restaurant_Common.Models;

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
        
        [Inject]
        public HttpClient HttpClient { get; set; }


        public IEnumerable<FoodType> FoodTypes { get; set; } = Enumerable.Empty<FoodType>();

        protected override async Task OnInitializedAsync()
        {
            FoodTypes = await HttpClient.GetFromJsonAsync<List<FoodType>>("food/type");
        }

        async Task OnProgress(UploadProgressArgs args)
        {
            var info = $"% / {args.Loaded} of {args.Total} bytes.";
            var progress = args.Progress;

            if (args.Progress == 100)
            {
                foreach (var file in args.Files)
                {
                    this.Food.ImageUrl = file.Name;

                    //await HttpClient.PostAsJsonAsync<FormFile>($"file/{file}", (FormFile) file);
                }
            }
        }

    }
}
