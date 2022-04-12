﻿using Microsoft.AspNetCore.Components;
using Restaurant_Common.Models;

namespace Restaurant_CustomerWebClient.Pages
{
    public partial class FoodMenu
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        public List<Food> Foods { get; set; }
        public List<FoodType> FoodTypes { get; set; }
        public int SelectedFoodTypeId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var foods = await HttpClient.GetFromJsonAsync<List<Food>>("food");

            Foods = foods.Where(x => x.FoodTypeId == SelectedFoodTypeId).ToList();

            FoodTypes = await HttpClient.GetFromJsonAsync<List<FoodType>>("food/type");
        }

        void SelectedIndexMethod(int index)
        {
            SelectedFoodTypeId = index;
        }
    }
}
