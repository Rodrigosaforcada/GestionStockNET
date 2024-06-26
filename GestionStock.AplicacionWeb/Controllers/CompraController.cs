using GestionStock.Core.Business;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionStock.AplicacionWeb.Controllers
{
    public class CompraController : Controller
    {
        private readonly CompraBusiness _compraBusiness;

        public CompraController(CompraBusiness compraBusiness)
        {
            _compraBusiness = compraBusiness;
        }

        [HttpGet]
        public IActionResult Lista()
        {
            List<Compra> compras = _compraBusiness.GetAll().Compras;
            if (compras == null)
            {
                // Manejar el caso cuando ventaResult  es null
                return View(new List<Compra>()); // Pasar una lista vacía a la vista
            }
            return View(compras);
        }

        [HttpGet]
        public IActionResult NuevaCompra()
        {
            //TempData["SuccessMessage"] =null;
           // TempData["ErrorMessage"] = null;
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.CurrentDateTime = currentDateTime;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevaCompra(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            DateTime fechaActual = DateTime.Now.Date;
            DateTime fechaMinima = fechaActual.AddDays(-7);

            if (fecha.Date < fechaMinima || fecha.Date > fechaActual)
            {
                TempData["ErrorMessage"] = "No se puede asignar una fecha con más de 7 días de anterioridad o que sea posterior al día de hoy.";
                await Task.Delay(10000);
              
                return RedirectToAction(nameof(NuevaCompra));
            }
            else
            {
            GenericResult result = _compraBusiness.CreateCompra(fecha, productoId, cantidad, usuarioId);

            TempData["SuccessMessage"] = "Compra creada exitosamente.";
            await Task.Delay(10000);
             
            }
            TempData["SuccessMessage"] = null;
            TempData["ErrorMessage"] = null;
            return RedirectToAction(nameof(Lista));

        }
    }
}
