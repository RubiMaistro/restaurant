using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Restaurant_Common.Models;

namespace Restaurant_WebApiServer.Repositories
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=CarRepairMechanicDb;Integrated Security=True;");
        }
    }
}
