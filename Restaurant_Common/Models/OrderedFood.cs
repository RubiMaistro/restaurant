using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Models
{
    public class OrderedFood : IFood
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
        public int FoodTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        public OrderedFood()
        {

        }
        public OrderedFood(int foodId, int orderId)
        {
            FoodId = foodId;
            OrderId = orderId;
            OrderDate = DateTime.Now;
        }
    }
}
