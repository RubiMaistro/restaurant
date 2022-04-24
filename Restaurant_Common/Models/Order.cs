using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Common.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }

        public Order()
        {
            Price = 0;
            CreatedDate = DateTime.Now;
            Status = OrderStatus.Recorded;
        }



    }
}
