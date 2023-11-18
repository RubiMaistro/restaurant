namespace Restaurant_Common.Interfaces.Models
{
    public interface IOrder
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
