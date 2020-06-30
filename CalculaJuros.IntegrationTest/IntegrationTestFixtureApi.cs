using CalculaJuros;
using System;
using System.Net.Http;
using Xunit;

namespace CalculaJuros.IntegrationTest
{
    [CollectionDefinition(nameof(IntegrationApiTestFixtureCollection))]
    public class IntegrationApiTestFixtureCollection : ICollectionFixture<IntegrationTestFixture<StartupApiTest>>
    {

    }

    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly CalculaJurosAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOptions = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new CalculaJurosAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }
        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
