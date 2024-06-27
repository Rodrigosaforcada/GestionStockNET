﻿using Microsoft.AspNetCore.Mvc;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using GestionStock.Core.Business;

namespace GestionStock.AplicacionWeb.Controllers
{
    public class VentaController : Controller
    {
        private readonly VentaBusiness _ventaBusiness;
        private readonly ProductoBusiness _productoBusiness;

        public VentaController(VentaBusiness ventaBusiness)
        {
            _ventaBusiness = ventaBusiness;
            _productoBusiness = new ProductoBusiness();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            List<Venta> ventas = _ventaBusiness.GetAll().Ventas;
            if (ventas == null)
            {
                // Manejar el caso cuando ventaResult  es null
                return View(new List<Venta>()); // Pasar una lista vacía a la vista
            }
            List<Producto> productos = _productoBusiness.GetAll().Productos;
            if (productos == null)
            {
                productos = new List<Producto>();
            }

            // Crea un diccionario para mapear productoId a nombre de producto
            var productoNombres = productos.ToDictionary(p => p.productoId, p => p.nombre);

            // Pasa las compras y los nombres de productos a la vista
            ViewBag.ProductoNombres = productoNombres;
            return View(ventas);



        }

        [HttpGet]
        public IActionResult NuevaVenta()
        {
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.CurrentDateTime = currentDateTime;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> NuevaVenta(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            // Calcular el stock actual
            int stockDisponible = _productoBusiness.CalcularStockActual(productoId);

            // Verificar si hay suficiente stock para la venta
            if (cantidad <= stockDisponible)
            {
                var result = _ventaBusiness.CreateVenta(fecha, productoId, cantidad, usuarioId);
                ViewData["SuccessMessage"] = "Venta realizada con éxito.";
                
                return View();   
            }
            else
            { 
                ViewData["ErrorMessage"] = "No hay suficiente stock disponible para realizar esta venta.";
                await Task.Delay(5000);
                return View();           
            }
        }
} }

  