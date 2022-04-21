using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Radzen;
using Restaurant_Common.Models;
using Restaurant_CustomerWebClient.Data;

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
        ProtectedLocalStorage BrowserStorage { get; set; }
        public List<Food>? Foods { get; set; }
        public FoodType? FoodType { get; set; } = new FoodType();

        protected override async Task OnParametersSetAsync()
        {
            FoodType = await HttpClient.GetFromJsonAsync<FoodType>($"food/type/{int.Parse(TypeId)}");

            var allFoodsFromDb = await HttpClient.GetFromJsonAsync<List<Food>>("food");

            Foods = allFoodsFromDb.Where(x => x.FoodTypeId == FoodType.Id).ToList();
        }

        async Task AddToCartAsync(Food food)
        {
            var result = await BrowserStorage.GetAsync<Order>("ShoppingCart");
            Order ShoppingCart = result.Success ? result.Value : new Order();

            ShoppingCart.Foods.Add(food);
            ShoppingCart.Price += food.Price;

            BrowserStorage.SetAsync("ShoppingCart", ShoppingCart);

            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = "Sikeres hozzáadás!",
                Detail = $"Az {food.Name} hozzáadva a rendeléshez!",
                Duration = 6000
            });

        }
    }
}
