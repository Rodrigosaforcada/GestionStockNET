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
        private readonly ProductoBusiness _productoBusiness;

        public CompraController(CompraBusiness compraBusiness, ProductoBusiness productoBusiness)
        {
            _compraBusiness = compraBusiness;
            _productoBusiness = productoBusiness;
        }

        [HttpGet]
        public IActionResult Lista()
        {
            List<Compra> compras = _compraBusiness.GetAll().Compras;
            if (compras == null)
            {
                return View(new List<Compra>());
            }

            List<Producto> productos = _productoBusiness.GetAll().Productos;
            if (productos == null)
            {
                productos = new List<Producto>();
            }

            // Crea un diccionario para mapear productoId a nombre de producto
            var productoNombres = productos.ToDictionary(p => p.productoId, p => p.nombre);

            // Pasa las compras y los nombres de productos a la vista
            ViewBag.ProductoNombres = productoNombres;
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
