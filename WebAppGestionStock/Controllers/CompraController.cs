using GestionStock.Core.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppGestionStock.Models;

namespace WebAppGestionStock.Controllers
{
    public class CompraController : Controller
    {
        private readonly ILogger<CompraController> _logger;
        private readonly CompraBusiness _compraBusiness;

        public CompraController(CompraBusiness compraBusiness, ILogger<CompraController> logger)
        {
            _logger = logger;
            _compraBusiness = compraBusiness;
        }

        public IActionResult Index()
        {
            var compras = _compraBusiness.GetAll();

            var model = new CompraListViewModel()
            {
                Titulo = "Compras en el Sistema Gestion de Stock",
                Cantidad = $"Cantidad de Compras: {compras.Compras.Count}",
                ComprasResult = compras
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
