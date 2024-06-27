using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GestionStock.Core.Business;

namespace GestionStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoBusiness _productoBusiness;

        public ProductoController(ProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }

        [HttpGet("{id}/stock")]
        public async Task<IActionResult> GetStock(int id)
        {
            var stock = await Task.Run(() => _productoBusiness.CalcularStockActual(id));
            if (stock == 0)
            {
                return NotFound();
            }
            return Ok(new { Stock = stock });
        }
    }
}