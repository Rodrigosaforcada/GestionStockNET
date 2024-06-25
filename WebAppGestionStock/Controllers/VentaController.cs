using GestionStock.Core.Business;
using GestionStock.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppGestionStock.Models;


namespace WebAppGestionStock.Controllers
{
    public class VentaController : Controller
    {
        private readonly VentaBusiness _ventaBusiness;
        private readonly ProductoBusiness _productoBusiness;

        public VentaController(VentaBusiness ventaBusiness)
        {
            _ventaBusiness = ventaBusiness;
            _productoBusiness = new ProductoBusiness();
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Venta> ventas = _ventaBusiness.GetAll().Ventas;
            if (ventas == null)
            {
                // Manejar el caso cuando ventaResult  es null
                return View(new List<Venta>()); // Pasar una lista vacía a la vista
            }
            return View(ventas);



        }

        [HttpGet]
        public IActionResult IngresarVenta()
        {
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.CurrentDateTime = currentDateTime;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> IngresarVenta(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.CurrentDateTime = currentDateTime;
            // Calcular el stock actual
            int stockDisponible = _productoBusiness.GetStockProducto(productoId);

            // Verificar si hay suficiente stock para la venta
            if (cantidad > stockDisponible)
            {
            TempData["ErrorMessage"] = "No hay suficiente stock disponible para realizar esta venta.";
                await Task.Delay(10000);
                return View(nameof(IngresarVenta)); 
            }
            var result = _ventaBusiness.CreateVenta(fecha, productoId, cantidad, usuarioId);

            TempData["SuccessMessage"] = "Venta realizada con éxito.";
            await Task.Delay(10000);
            return RedirectToAction(nameof(Index));

        }
    }
}
