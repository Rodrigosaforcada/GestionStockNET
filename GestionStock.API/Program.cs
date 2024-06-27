using Microsoft.EntityFrameworkCore;
using GestionStock.Core.DataEF;
using Microsoft.Extensions.DependencyInjection;
using GestionStock.Core.Business;

namespace GestionStock.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddDbContext<GestionStockContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

            builder.Services.AddScoped<ProductoBusiness>(); 
            builder.Services.AddControllers();
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
