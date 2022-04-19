using Restaurant_Common.Models;

namespace Restaurant_CustomerWebClient.Data
{
    public class StateContainer
    {
        private Order? _order;

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
