using System.ComponentModel.DataAnnotations;

namespace Restaurant_Common.Interfaces.Models
{
    public interface IOrderItem
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
