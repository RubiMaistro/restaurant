using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; } 

        public Order(double price)
        {
            Price = price;
            CreatedDate = DateTime.Now;
            Status = OrderStatus.Recorded;
        }

    }
}
