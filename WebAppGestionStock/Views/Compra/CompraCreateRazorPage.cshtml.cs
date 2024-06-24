using GestionStock.Core.DataEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppGestionStock.Views.Compra
{ 
    [BindProperties]
    public class CompraCreateRazorPageModel : PageModel
    {
        private readonly GestionStockContext _db;
        public GestionStock.Core.Entities.Compra Compra { get; set; }
        public CompraCreateRazorPageModel(GestionStockContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(GestionStock.Core.Entities.Compra compra)
        {
            //await compraBusiness.CreateCompra(compra.fecha, compra.productoId, compra.cantidad, compra.usuarioId);
            await _db.Compras.AddAsync(compra);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
