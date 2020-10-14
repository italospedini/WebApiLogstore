using Logstore.Service.Interfaces.Pizza;
using Logstore.Service.Services.Pizza;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Crosscutting.DI
{
    public static class RegisterDI
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IPizzaService), typeof(PizzaService));
            //services.AddScoped(typeof(IPizzaRepository), typeof(PizzaRepository));

            //services.AddDbContext<ConcreteDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConcreteAPIConnString")));
        }
    }
}
