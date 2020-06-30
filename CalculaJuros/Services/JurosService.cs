using System;
using System.Net.Http;
using CalculaJuros.ExtensionMethods;

namespace CalculaJuros.Services
{
    public class JurosService : IJurosService
    {
        public JurosService() { }

        public decimal RetornaTaxaJuros()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage retorno = httpClient.GetAsync("https://localhost:5001/taxaJuros").Result;
            return Convert.ToDecimal(retorno.Content.ReadAsStringAsync().Result);
        }

        public decimal Calcular(decimal valorInicial, int tempo, decimal taxa)
        {
            decimal valorFinal = valorInicial * (decimal)Math.Pow(1 + Convert.ToDouble(taxa),tempo);
            return valorFinal.Truncate(2);
        }
    }
}
