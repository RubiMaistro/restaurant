using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Models
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; } 
        [Required]
        public FoodType FoodType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        public Food(int id, FoodType foodType, string name, string description, int price)
        {
            Id = id;
            FoodType = foodType;
            Name = name;
            Description = description;
            Price = price;
        }

    }
}
