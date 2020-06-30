using System;
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
            try
            {
                decimal taxaJuros = _jurosService.RetornaTaxaJuros();
                return _jurosService.Calcular(valorinicial, meses, taxaJuros);
            }
            catch (Exception e)
            {
                throw new System.Exception("Não foi possível realizar o calculo de juros", e.InnerException);
            }
        }
    }
}
