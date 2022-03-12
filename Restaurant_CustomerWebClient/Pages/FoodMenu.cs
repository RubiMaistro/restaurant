﻿using Microsoft.AspNetCore.Components;
using Restaurant_Common.Models;
using System.Net.Http.Json;

namespace Restaurant_CustomerWebClient.Pages
{
    public partial class FoodMenu
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        public IList<Food> Foods { get; set; }

        protected override async Task OnInitializedAsync()      
        {
            Foods = await HttpClient.GetFromJsonAsync<IList<Food>>("food");
            await base.OnInitializedAsync();
        }
    }
}