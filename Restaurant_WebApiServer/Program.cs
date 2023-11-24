using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant_Common.Interfaces.Repositories;
using Restaurant_WebApiServer.DataObjects;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer
{
    public class Program
    {
        private static WebApplicationBuilder? _builder { get; set; }
        private static ConfigurationManager? _config { get; set; }
        public static void Main(string[] args)
        {
            _builder = WebApplication.CreateBuilder(args);
            _config = _builder.Configuration;
            // Add services to the container.
            AddServices(_builder.Services);

            var app = _builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // CORS enabled all origin url, method, header
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddDbContext<RestaurantContext>(options =>
            //{
            //    options.UseSqlServer(_config.GetConnectionString("RestaurantDb"),
            //        sqlServerOptionsAction: sqlOptions =>
            //        {
            //            sqlOptions.EnableRetryOnFailure(
            //                maxRetryCount: 10,
            //                maxRetryDelay: TimeSpan.FromSeconds(5),
            //                errorNumbersToAdd: null);
            //        });
            //});

            // CORS enabled
            services.AddCors();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddDbContext<RestaurantContext>(options =>
                options.UseMySQL(_config?.GetConnectionString("RestaurantDb")));
        }
        
    }
}
