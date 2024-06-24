using GestionStock.Core.Business;
using GestionStock.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppGestionStock.Models;

namespace WebAppGestionStock.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly ProductoBusiness _productoBusiness;

        public ProductoController(ProductoBusiness productoBusiness, ILogger<ProductoController> logger)
        {
            _logger = logger;
            _productoBusiness = productoBusiness;

            //_usuarioBusiness = new UsuarioBusiness();
        }

        public IActionResult Index()
        {
            var productos = _productoBusiness.GetAll();

            var model = new ProductoListViewModel()
            {
                Nombre = "Productos del Sistema Gestion de Stock",
                Cantidad = $"Cantidad de Productos: {productos.Productos.Count}",
                ProductosResult = productos
            };

            return View(model);
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
        public IActionResult Deatils()
        {
            return View("DetailsInternal");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
