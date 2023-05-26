using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HotelContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });
            builder.Services.AddScoped<IRepo<Hotel , int> , HotelRepo>();
            builder.Services.AddScoped<IRepo<Branch , int> , BranchRepo>();
            builder.Services.AddScoped<HotelServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}