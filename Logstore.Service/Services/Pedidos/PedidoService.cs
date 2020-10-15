﻿using Logstore.Domain.Entities;
using Logstore.Infra.Repositories.Interfaces.Pedidos;
using Logstore.Infra.Repositories.Interfaces.Pizza;
using Logstore.Service.Interfaces.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Service.Services.Pedidos
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPizzaSaboresRepository _pizzaSaboresRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                            IPizzaSaboresRepository pizzaSaboresRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._pizzaSaboresRepository = pizzaSaboresRepository;
        }

        async Task<ICollection<Pedido>> IPedidoService.GetHistorico(int idcliente)
        {
            return await _pedidoRepository.GetHistorico(idcliente);
        }

        async Task<int> IPedidoService.Incluir(Pedido pedido)
        {
            bool pedidoValido = pedido.PedidoValido();

            if (!pedidoValido)
                return -1;

            ICollection<PizzaSabores> pizzas = await GetPizzas(pedido.Pizzas.Select(x => x.IdPizzaSabor1).Union(pedido.Pizzas.Where(x => x.IdPizzaSabor2 != null).Select(x =>  x.IdPizzaSabor2.Value)));

            pedido.CalcularValorTotal(pizzas);
            pedido.Criar();

            Pedido result = await _pedidoRepository.Add(pedido);

            return result.Id;
        }

        private async Task<ICollection<PizzaSabores>> GetPizzas(IEnumerable<int> idsPizzas)
        {
            return await _pizzaSaboresRepository.GetPizzasByIds(idsPizzas);
        }

        async Task<Pedido> IPedidoService.GetByNumeroPedido(int numeroPedido)
        {
            return await _pedidoRepository.GetByNumeroPedido(numeroPedido);
        }

    }
}
