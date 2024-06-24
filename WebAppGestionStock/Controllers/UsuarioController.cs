using GestionStock.Core.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppGestionStock.Models;

namespace WebAppGestionStock.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly UsuarioBusiness _usuarioBusiness;

        public UsuarioController(UsuarioBusiness usuarioBusiness, ILogger<UsuarioController> logger)
        {
            _logger = logger;
            _usuarioBusiness = usuarioBusiness;

            //_usuarioBusiness = new UsuarioBusiness();
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioBusiness.GetAll();

            var model = new UsuarioListViewModel()
            {
                Nombre = "Usuarios del Sistema Gestion de Stock",
                Cantidad = $"Cantidad de Usuarios: {usuarios.Usuarios.Count}",
                UsuariosResult = usuarios
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
