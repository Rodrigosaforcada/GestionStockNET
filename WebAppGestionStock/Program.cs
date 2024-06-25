using GestionStock.Core.Business;
using GestionStock.Core.DataEF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioBusiness>();
builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<CompraBusiness>();
builder.Services.AddScoped<VentaRepository>();
builder.Services.AddScoped<VentaBusiness>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ProductoBusiness>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "ProductoStock",
    pattern: "{controller=Producto}/{action=Index}/{productoId?}");

app.Run();
