using System;
using CalculaJuros.Services;
using Xunit;

namespace CalculaJuros.UnitTest
{
    public class JurosServiceTests
    {
        [Fact]
        public void Calcular()
        {
            JurosService jurosService = new JurosService();
            decimal valorFinal = jurosService.Calcular(100, 5, 0.01m);
            Assert.Equal(105.10m, valorFinal);
        }
    }
}
