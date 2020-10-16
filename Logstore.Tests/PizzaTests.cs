using Logstore.Api;
using Logstore.Crosscutting.DI;
using Logstore.Domain.Entities;
using Logstore.Service.Interfaces.Pizza;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Logstore.Tests
{
    [TestClass]
    public class PizzaTests
    {
        private static IPizzaService _pizzaService;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration configuration = configurationBuilder.Build();

            Startup startup = new Startup(configuration);
            IServiceCollection services = new ServiceCollection();
            startup.ConfigureServices(services);

            RegisterDI.Register(services, configuration);

            _pizzaService = (IPizzaService)services.BuildServiceProvider().GetRequiredService(typeof(IPizzaService));
        }

        [TestMethod]
        public void Should_List_Pizzas()
        {
            IEnumerable<PizzaSabores> pizzas = _pizzaService.GetCardapio().Result;

            Assert.IsTrue(pizzas.Any());
        }

        [TestMethod]
        public void Should_Register_Pizza()
        {
            PizzaSabores newPizza = new PizzaSabores("Pizza Teste", decimal.Parse("45,87"), true, true);

            PizzaSabores pizzaRegistrada = _pizzaService.Cadastrar(newPizza).Result;

            Assert.IsTrue(pizzaRegistrada.Id > 0);
        }

    }
}
