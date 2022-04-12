using Microsoft.AspNetCore.Components;
using Restaurant_Common.Models;

namespace Restaurant_CustomerWebClient.Pages
{
    public partial class FoodMenu
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        public List<Food> Foods { get; set; }
        public List<FoodType> FoodTypes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Foods = await HttpClient.GetFromJsonAsync<List<Food>>("food");
            FoodTypes = await HttpClient.GetFromJsonAsync<List<FoodType>>("food/type");
        }
    }
}
