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
        public int FoodTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public Food() { }
        public Food(int id, int foodTypeId, string name, string description, int price, string image)
        {
            Id = id;
            FoodTypeId = foodTypeId;
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = image;
        }

    }
}
