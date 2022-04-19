using Microsoft.AspNetCore.Components;
using Restaurant_Common.Models;

namespace Restaurant_EmployeeWebClient.Pages.Foods
{
    public partial class FoodList
    {
        [Inject]
        public HttpClient? HttpClient { get; set; }
        public IList<Food>? Foods { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Foods = await HttpClient.GetFromJsonAsync<List<Food>>("food");
        }
    }
}
