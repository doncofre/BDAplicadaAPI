using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using System.Net;

namespace BDAplicadaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet(Name = "GetVendedores")]
        public async Task<IEnumerable<DTO.Vendedor>> GetVendedores(DateTime fechadesde, DateTime fechahasta, int idvendedor)
        {
            var vendedor = await new Metodos.VendedorQuery().GetVendedores(fechadesde,fechahasta,idvendedor);

            
            return vendedor;
          ;
        }
    }
}