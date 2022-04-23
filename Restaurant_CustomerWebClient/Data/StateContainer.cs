using Restaurant_Common.Models;

namespace Restaurant_CustomerWebClient.Data
{
    [Serializable]
    public class StateContainer
    {
        private IList<int> _foodIds { get; set; }
        public IList<int> FoodIds 
        { 
            get { return Instance._foodIds; } 
            set { Instance._foodIds = value; } 
        }

        static StateContainer container = new StateContainer();
        public StateContainer Instance
        {
            get { return container; }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
