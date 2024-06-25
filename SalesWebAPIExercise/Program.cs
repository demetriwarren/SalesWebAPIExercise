using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebAPIExercise.Data;
namespace SalesWebAPIExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext") //AppDbContext must match whats in the connection string in teh json file. 
                    ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());       //any origin(ip) can access this code(AllowAnyOrigin), Allow any client to edit the (AllowAnyMethod)Methods 

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
