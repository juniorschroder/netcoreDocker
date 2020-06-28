using System;
namespace CalculaJuros.Services
{
    public interface IJurosService
    {
        decimal RetornaTaxaJuros();
        decimal Calcular(decimal valorInicial, int tempo, decimal taxa);
    }
}
