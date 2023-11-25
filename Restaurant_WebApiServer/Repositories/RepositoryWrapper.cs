namespace Restaurant_WebApiServer.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RestaurantContext _context;
        private IFoodRepository _foodRepository;
        private IFoodTypeRepository _foodTypeRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        public IFoodRepository FoodRepository
        {
            get
            {
                if (_foodRepository == null)
                {
                    _foodRepository = new FoodRepository(_context);
                }
                return _foodRepository;
            }
        }
        public IFoodTypeRepository FoodTypeRepository
        {
            get
            {
                if ( _foodTypeRepository == null )
                {
                    _foodTypeRepository = new FoodTypeRepository(_context);
                }
                return _foodTypeRepository;
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context);
                }
                return _orderRepository;
            }
        }
        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                if (_orderItemRepository == null)
                {
                    _orderItemRepository = new OrderItemRepository(_context);
                }
                return _orderItemRepository;
            }
        }
        
        public RepositoryWrapper(RestaurantContext restaurantContext)
        {
            _context = restaurantContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
