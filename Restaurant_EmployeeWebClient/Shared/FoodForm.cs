using Microsoft.AspNetCore.Components;
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
    }
}
