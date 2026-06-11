
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReservationSystemBackend.Data;
using ReservationSystemBackend.Interfaces;
using ReservationSystemBackend.Repositories;
using ReservationSystemBackend.Services;

namespace ReservationSystemBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<HotelService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            var app = builder.Build();


            app.UseCors(options => { 
            options.AllowAnyHeader();
            options.AllowAnyMethod();
            options.WithOrigins("http://localhost:4200");

            });

            app.UseSwagger();
            app.UseSwaggerUI();

          

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
