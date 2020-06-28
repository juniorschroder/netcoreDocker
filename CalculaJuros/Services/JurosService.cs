using System;
using CalculaJuros.ExtensionMethods;

namespace CalculaJuros.Services
{
    public class JurosService : IJurosService
    {
        public JurosService() { }

        public decimal RetornaTaxaJuros()
        {
            return 0.01m;
        }

        public decimal Calcular(decimal valorInicial, int tempo, decimal taxa)
        {
            decimal valorFinal = valorInicial * (decimal)Math.Pow(1 + Convert.ToDouble(taxa),tempo);
            return valorFinal.Truncate(2);
        }
    }
}
