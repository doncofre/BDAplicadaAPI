using Microsoft.AspNetCore.Mvc;

namespace BDAplicadaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller
    {
        [HttpGet(Name = "GetProductos")]
        public async Task<IEnumerable<DTO.Producto>> GetProductos()
        {
            var producto = await new Metodos.ProductosQuery().GetProductos();


            return producto;
            
        }
    }
}
