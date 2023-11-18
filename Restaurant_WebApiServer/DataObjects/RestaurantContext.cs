using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_WebApiServer.DataObjects;

public partial class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
    {
    }
    public DbSet<Food>? Foods { get; set; }
    public DbSet<FoodType>? FoodTypes { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderedFoods { get; set; }

    public RestaurantContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}
