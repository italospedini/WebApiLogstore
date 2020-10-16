using Logstore.Api;
using Logstore.Crosscutting.DI;
using Logstore.Domain.Entities;
using Logstore.Infra.Repositories.Interfaces.Clientes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Tests
{
    [TestClass]
    public class ClienteTests
    {
        private static IClienteRepository _clienteRepository;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration configuration = configurationBuilder.Build();

            Startup startup = new Startup(configuration);
            IServiceCollection services = new ServiceCollection();
            startup.ConfigureServices(services);

            RegisterDI.Register(services, configuration);

            _clienteRepository = (IClienteRepository)services.BuildServiceProvider().GetRequiredService(typeof(IClienteRepository));
        }

        [TestMethod]
        public void Should_Register_Cliente()
        {
            Cliente newCliente = new Cliente("Rua Tal");

            Cliente clienteRegistrado = _clienteRepository.Add(newCliente).Result;

            Assert.IsTrue(clienteRegistrado.Id > 0);
        }
    }
}
