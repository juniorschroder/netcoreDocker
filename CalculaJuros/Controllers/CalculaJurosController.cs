using CalculaJuros.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.Controllers
{
    [ApiController]
    [Route("/calculajuros")]
    public class CalculaJurosController : ControllerBase
    {
        private IJurosService _jurosService;

        public CalculaJurosController(IJurosService jurosService)
        {
            _jurosService = jurosService;
        }

        [HttpGet]
        public decimal Get(decimal valorinicial, int meses)
        {
            return _jurosService.Calcular(valorinicial, meses, 0.01m);
        }
    }
}
