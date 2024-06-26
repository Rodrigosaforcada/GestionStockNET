using Microsoft.AspNetCore.Mvc;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using GestionStock.Core.Business;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionStock.AplicacionWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoBusiness _productoBusiness;

        public ProductoController(ProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }

        [HttpGet]
        public IActionResult ListaProductos()
        {
            List<Producto> productos = _productoBusiness.GetAll().Productos;
            if (productos == null)
            {
                // Manejar el caso cuando productoResult o productoResult.Productos es null
                return View(new List<Producto>()); // Pasar una lista vacía a la vista
            }
            return View(productos);  
        }

        [HttpGet]
        public IActionResult NuevoProducto()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult NuevoProducto(string nombre, int categoriaId)
        {
            var result = _productoBusiness.CreateProducto(nombre, categoriaId);
            return RedirectToAction(nameof(ListaProductos));
        }

    }
}
