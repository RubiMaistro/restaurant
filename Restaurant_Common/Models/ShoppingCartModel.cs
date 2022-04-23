using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Models
{
    public class ShoppingCartModel
    {
        private int _shoppingCartModelId { get; set; }
        public int ShoppingCartModelId
        {
            get { return _shoppingCartModelId; }
            set { _shoppingCartModelId = value; }
        }
        private IList<Food> _foods { get; set; }
        public IList<Food> Foods
        {
            get { return _foods; }
            set { _foods = value; }
        }
        private Order _order { get; set; }
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public ShoppingCartModel()
        {
            Foods = new List<Food>();
            Order = new Order();
        }

    }
}
