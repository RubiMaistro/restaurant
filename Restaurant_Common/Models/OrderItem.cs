using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Common.Models
{
    public class OrderItem : IOrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public int FoodId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int Quantity { get; set; }


        public OrderItem()
        {

        }
        public OrderItem(int foodId, int orderId, int quantity)
        {
            FoodId = foodId;
            OrderId = orderId;
            OrderDate = DateTime.Now;
            Quantity = quantity;
        }
    }
}
