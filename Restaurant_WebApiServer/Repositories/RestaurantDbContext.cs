using Microsoft.EntityFrameworkCore;
using Restaurant_Common.Models;

namespace Restaurant_WebApiServer.Repositories
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Food>? Foods { get; set; }
        public DbSet<FoodType>? FoodTypes { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderedFood>? OrderedFoods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Integrated Security=True;");
        }
    }
}
