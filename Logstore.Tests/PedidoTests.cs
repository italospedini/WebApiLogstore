using Logstore.Api;
using Logstore.Crosscutting.DI;
using Logstore.Domain.Entities;
using Logstore.Service.Interfaces.Pedidos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Tests
{
    [TestClass]
    public class PedidoTests
    {
        private static IPedidoService _pedidoService;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration configuration = configurationBuilder.Build();

            Startup startup = new Startup(configuration);
            IServiceCollection services = new ServiceCollection();
            startup.ConfigureServices(services);

            RegisterDI.Register(services, configuration);

            _pedidoService = (IPedidoService)services.BuildServiceProvider().GetRequiredService(typeof(IPedidoService));
        }

        [TestMethod]
        public void Should_Return_List_Not_Null()
        {
            IEnumerable<Pedido> pedidos = _pedidoService.GetHistorico(1).Result;

            Assert.IsTrue(pedidos != null);
        }

        [TestMethod]
        public void Should_Insert_Pedido()
        {
            Pedido newPedido = new Pedido(1, new List<Pizza> { new Pizza() { IdPizzaSabor1 = 1 } }, "Rua Tal");

            int pedidoRegistrado = _pedidoService.Incluir(newPedido).Result;

            Assert.IsTrue(pedidoRegistrado > 0);
        }

    }
}
