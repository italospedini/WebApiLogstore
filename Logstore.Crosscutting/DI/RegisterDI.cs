﻿using Logstore.Infra.Context;
using Logstore.Infra.Repositories.Interfaces.Pedidos;
using Logstore.Infra.Repositories.Interfaces.Pizza;
using Logstore.Infra.Repositories.Pedidos;
using Logstore.Infra.Repositories.Pizza;
using Logstore.Service.Interfaces.Pedidos;
using Logstore.Service.Interfaces.Pizza;
using Logstore.Service.Services.Pedidos;
using Logstore.Service.Services.Pizza;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logstore.Crosscutting.DI
{
    public static class RegisterDI
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IPizzaService), typeof(PizzaService));
            services.AddScoped(typeof(IPedidoService), typeof(PedidoService));

            services.AddScoped(typeof(IPizzaSaboresRepository), typeof(PizzaSaboresRepository));
            services.AddScoped(typeof(IPedidoRepository), typeof(PedidoRepository));

            string AppPath = Environment.CurrentDirectory;
            string SqliteDbPath = Path.Combine(Directory.GetParent(AppPath).FullName, "Logstore.Infra", "LogstoreAPI.db");

            services.AddDbContext<LogstoreDbContext>(options => options.UseSqlite(string.Concat("Data Source = ", SqliteDbPath)));
        }
    }
}