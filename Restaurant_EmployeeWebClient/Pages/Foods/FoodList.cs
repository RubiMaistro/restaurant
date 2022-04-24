using Microsoft.AspNetCore.Components;
using Restaurant_Common.Models;

namespace Restaurant_EmployeeWebClient.Pages.Foods
{
    public partial class FoodList
    {
        [Inject]
        public HttpClient? HttpClient { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public IList<Food>? Foods { get; set; }

        public string ImageServervicePath { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ImageServervicePath = "https://localhost:7000/api/file";

            Foods = await HttpClient.GetFromJsonAsync<List<Food>>("food");
        }

    }
}
