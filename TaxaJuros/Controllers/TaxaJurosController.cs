using Microsoft.AspNetCore.Mvc;

namespace TaxaJuros.Controllers
{
    [ApiController]
    [Route("/taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public decimal Get()
        {
            return 0.01m;
        }
    }
}
