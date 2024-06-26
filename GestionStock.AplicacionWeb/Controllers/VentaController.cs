using Microsoft.AspNetCore.Mvc;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using GestionStock.Core.Business;

namespace GestionStock.AplicacionWeb.Controllers
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
        public IActionResult Lista()
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
        public IActionResult NuevaVenta()
        {
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.CurrentDateTime = currentDateTime;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> NuevaVenta(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            // Calcular el stock actual
            int stockDisponible = _productoBusiness.CalcularStockActual(productoId);

            // Verificar si hay suficiente stock para la venta
            if (cantidad <= stockDisponible)
            {
                var result = _ventaBusiness.CreateVenta(fecha, productoId, cantidad, usuarioId);
                TempData["SuccessMessage"] = "Venta realizada con éxito.";
                await Task.Delay(5000);
                return RedirectToAction(nameof(Lista));   
            }
            else
            { 
                TempData["ErrorMessage"] = "No hay suficiente stock disponible para realizar esta venta.";
                await Task.Delay(5000);
                return RedirectToAction(nameof(NuevaVenta));           
            }
        }
} }

  