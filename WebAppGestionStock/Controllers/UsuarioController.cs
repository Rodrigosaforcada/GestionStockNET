using GestionStock.Core.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GestionStock.Core.Entities;

namespace WebAppGestionStock.Controllers

{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBusiness _usuarioBusiness;

        public UsuarioController(UsuarioBusiness usuarioBusiness)
        {
           _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        public IActionResult Lista()
        {
            List<Usuario> usuarios = _usuarioBusiness.GetAll().Usuarios;
            if (usuarios == null)
            {
                // Manejar el caso cuando usuarioResult  es null
                return View(new List<Usuario>()); // Pasar una lista vacía a la vista
            }
            return View(usuarios);



        }

    }
}