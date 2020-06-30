using CalculaJuros;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.IntegrationTest
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class FixturesTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _integrationTestFixture;
        public FixturesTest(IntegrationTestFixture<StartupApiTest> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Fact]
        public async Task Calcula_Juros_Via_Api()
        {
            var requisicao = await _integrationTestFixture.Client.GetAsync($"/calculajuros?valorinicial=100&meses=5");
            var resposta = await requisicao.Content.ReadAsStringAsync();

            Assert.True(requisicao.IsSuccessStatusCode);
            Assert.Contains("105.1", resposta);
        }
    }
}
