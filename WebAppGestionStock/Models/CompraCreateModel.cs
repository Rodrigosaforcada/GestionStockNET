using GestionStock.Core.Business;
using GestionStock.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GestionStock.Core.DataEF;

namespace WebAppGestionStock.Models
{
    public class CompraCreateModel : PageModel
    {
        private readonly GestionStockContext _db;

        [BindProperty]
        public Compra Compra { get; set; }

        public CompraCreateModel(GestionStockContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPost(Compra compra)
        {
            //await compraBusiness.CreateCompra(compra.fecha, compra.productoId, compra.cantidad, compra.usuarioId);
            await _db.Compras.AddAsync(compra);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
