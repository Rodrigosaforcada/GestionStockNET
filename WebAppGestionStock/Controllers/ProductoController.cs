using GestionStock.Core.Business;
using GestionStock.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppGestionStock.Models;

namespace WebAppGestionStock.Controllers
{
    public class ProductoController : Controller
    {
            private readonly ProductoBusiness _productoBusiness;

            public ProductoController(ProductoBusiness productoBusiness)
            {
                _productoBusiness = productoBusiness;
            }

            [HttpGet]
        public IActionResult Index()
        {
            List<Producto> productos = _productoBusiness.GetAll().Productos;
            if (productos == null)
            {
                // Manejar el caso cuando productoResult o productoResult.Productos es null
                return View(new List<Producto>()); // Pasar una lista vacía a la vista
            }
            return View(productos);
        }
    
        [Route("api/producto/{produtoId}/stock/")]
       public IActionResult Stock(int produtoId)
        {
            var productos = _productoBusiness.GetStockProducto(produtoId);

            var model = new ProductoStockViewModel()
            {
                CantidadProductoStock = productos
            };

            return View(model);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

