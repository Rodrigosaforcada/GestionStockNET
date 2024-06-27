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
            // Buscar el usuario por nombre
            Usuario usuario = _usuarioBusiness.GetUsuarioByNombre(model.Nombre);
            if (usuario == null)
            {
                ViewData["ErrorMessage"] = "Usuario no encontrado.";
                return View();
            }

            // Verificar la contraseña usando el ID del usuario
            bool result = _usuarioBusiness.ControlContrasena(usuario.usuarioId, model.Contrasena);
            if (!result)
            {
                ViewData["ErrorMessage"] = "Nombre de usuario o contraseña incorrectos.";
                return View();
            }
         
                return View("~/Views/Home/Index.cshtml");
             }
            public IActionResult Salir()
            {
                return RedirectToAction("Login", "Usuario");
            }
       
    } }



