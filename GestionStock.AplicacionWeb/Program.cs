using Microsoft.EntityFrameworkCore;
using GestionStock.Core.DataEF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestionStock.Core.Business;


namespace GestionStock.AplicacionWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddDbContext<GestionStockContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));


            
            builder.Services.AddScoped<UsuarioRepository>();
            builder.Services.AddScoped<UsuarioBusiness>();
            builder.Services.AddScoped<ProductoRepository>();
            builder.Services.AddScoped<ProductoBusiness>();
            builder.Services.AddScoped<VentaRepository>();
            builder.Services.AddScoped<VentaBusiness>();
            builder.Services.AddScoped<CompraRepository>();
            builder.Services.AddScoped<CompraBusiness>();

            
            builder.Services.AddControllersWithViews();

            
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Usuario/Login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Registro}/{id?}");

            app.Run();
        }
    }
}