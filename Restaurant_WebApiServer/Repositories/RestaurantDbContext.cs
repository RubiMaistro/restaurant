using Microsoft.EntityFrameworkCore;
using Restaurant_Common.Models;

namespace Restaurant_WebApiServer.Repositories
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Food>? Foods { get; set; }
        public DbSet<FoodType>? FoodTypes { get; set; }
        public DbSet<Order>? Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\ProjectModels;Database=RestaurantDb;Integrated Security=True;");
        }
    }
}
