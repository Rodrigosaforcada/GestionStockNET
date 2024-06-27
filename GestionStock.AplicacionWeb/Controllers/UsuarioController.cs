using GestionStock.AplicacionWeb.Models;
using GestionStock.Core.Business;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace GestionStock.AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBusiness _usuarioBusiness;

        public UsuarioController(UsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }


        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        /*[HttpPost]
        public async Task<IActionResult> Registro(string nombreNuevoUsuario, string contrasenaNuevoUsuario)
        {

           var result = _usuarioBusiness.CreateUsuario(nombreNuevoUsuario, contrasenaNuevoUsuario);
           await Task.Delay(5000);
            ViewData["SuccessMessage"] = "Usuario creado exitosamente";
            return View();
            }*/
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _usuarioBusiness.CreateUsuario(model.Nombre, model.Contrasena);

                ViewData["SuccessMessage"] = "Usuario creado exitosamente";
                await Task.Delay(5000);
                return RedirectToAction(nameof(Login));
            }

            ViewData["ErrorMessage"] = "El nombre de usuario y la contraseña no pueden estar vacíos.";
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _usuarioBusiness.ControlContrasena(model.Nombre, model.Contrasena);

                if (!result)
                {
                    ViewData["ErrorMessage"] = "No estás registrado";
                    await Task.Delay(5000);
                    return View(model);
                }
               
            }
                return View("~/Views/Home/Index.cshtml");
             }
            public IActionResult Salir()
            {
                return RedirectToAction("Login", "Usuario");
            }
       
    } }



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
