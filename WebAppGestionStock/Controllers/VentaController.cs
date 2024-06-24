using GestionStock.Core.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppGestionStock.Models;

namespace WebAppGestionStock.Controllers
{
    public class VentaController : Controller
    {
        private readonly ILogger<VentaController> _logger;
        private readonly VentaBusiness _ventaBusiness;

        public VentaController(VentaBusiness ventaBusiness, ILogger<VentaController> logger)
        {
            _logger = logger;
            _ventaBusiness = ventaBusiness;
        }

        public IActionResult Index()
        {
            var ventas = _ventaBusiness.GetAll();

            var model = new VentaListViewModel()
            {
                Titulo = "Ventas del Sistema Gestion de Stock",
                Cantidad = $"Cantidad de Ventas: {ventas.Ventas.Count}",
                VentaResult = ventas
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
