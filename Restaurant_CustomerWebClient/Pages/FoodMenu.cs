using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Radzen;
using Restaurant_Common.Models;

namespace Restaurant_CustomerWebClient.Pages
{
    public partial class FoodMenu
    {
        [Parameter]
        public string TypeId { get; set; }
        [Inject]
        HttpClient HttpClient { get; set; }
        [Inject]
        NotificationService NotificationService { get; set; }
        [Inject]
        ProtectedSessionStorage BrowserStorage { get; set; }
        public List<Food>? Foods { get; set; }
        public FoodType? FoodType { get; set; } = new FoodType();
        public string ImageServervicePath { get; set; }
        public ShoppingCartModel Cart { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
        }

        protected override async Task OnParametersSetAsync()
        {
            ImageServervicePath = "https://localhost:7000/api/file";

            FoodType = await HttpClient.GetFromJsonAsync<FoodType>($"food/type/{int.Parse(TypeId)}");

            var allFoodsFromDb = await HttpClient.GetFromJsonAsync<List<Food>>("food");

            Foods = allFoodsFromDb.Where(x => x.FoodTypeId == FoodType.Id).ToList();
        }

        public async void AddToCartAsync(Food food)
        {
            var result = await BrowserStorage.GetAsync<ShoppingCartModel>("Cart");
            Cart = result.Success ? result.Value : new ShoppingCartModel();

            Cart.Foods.Add(food);
            Cart.Order.Price += food.Price;

            BrowserStorage.SetAsync("Cart", Cart);

            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = "Sikeres hozzáadás!",
                Detail = $"Az {food.Name} hozzáadva a rendeléshez!",
                Duration = 5000
            });

            

        }
    }
}
