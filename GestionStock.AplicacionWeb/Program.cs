using Microsoft.EntityFrameworkCore;
using GestionStock.Core.DataEF;
using Microsoft.AspNetCore.Authentication.Cookies; // Importación para la autenticación con cookies
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

            // Agregar servicios al contenedor.
            builder.Services.AddDbContext<GestionStockContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));


            // Registrar los repositorios y servicios de negocio
            builder.Services.AddScoped<UsuarioBusiness>();
            builder.Services.AddScoped<ProductoRepository>();
            builder.Services.AddScoped<ProductoBusiness>();
            builder.Services.AddScoped<VentaRepository>();
            builder.Services.AddScoped<VentaBusiness>();
            builder.Services.AddScoped<CompraRepository>();
            builder.Services.AddScoped<CompraBusiness>();

            // Agregar controladores con vistas (MVC)
            builder.Services.AddControllersWithViews();

            // Agregar autenticación y autorización
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login"; // Ruta de inicio de sesión
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configurar el pipeline de la aplicación.
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

            app.UseAuthentication(); // Asegúrate de que esto esté antes de UseAuthorization
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Venta}/{action=Lista}/{id?}");

            app.Run();
        }
    }
}