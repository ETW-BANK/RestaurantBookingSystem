
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Access.Data;
using Restaurant.Data.Access.Repository;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Data.Access.Repository.Services;
using Restaurant.Data.Access.Repository.Services.IServices;

namespace RetaurantBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionstring = builder.Configuration.GetConnectionString("RestDb");
            builder.Services.AddDbContext<RestaurantDbContext>(option=>option.UseSqlServer(connectionstring));  
            builder.Services.AddControllers();


            
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
           builder.Services.AddScoped<ITableRepository, TablesRepository>();
            builder.Services.AddScoped<ITableService, TableService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
