
using E_Commerce_Api.Data.Repo;
using E_Commerce_Api.Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;

namespace WEP_API
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

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                            options.UseSqlServer(
                                                builder.Configuration.GetConnectionString("DefaultConnection"),
                                                 b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                                                ));

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
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
