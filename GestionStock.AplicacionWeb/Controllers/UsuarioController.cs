using GestionStock.Core.Business;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionStock.AplicacionWeb.Controllers
{ }

    /*public class CompraController : Controller
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
            return View();
        }

        [HttpPost]
        public IActionResult NuevaCompra(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            var result = _compraBusiness.CreateCompra(fecha, productoId, cantidad, usuarioId);
            return RedirectToAction(nameof(Lista));
        }
    }
}*/
