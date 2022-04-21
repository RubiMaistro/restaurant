using Restaurant_Common.Models;

namespace Restaurant_CustomerWebClient.Data
{
    [Serializable]
    public class StateContainer
    {
        private Order? _order { get; set; }
        public Order Order
        {
            get { return Instance._order; }
            set { Instance._order = value; NotifyStateChanged(); }
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
