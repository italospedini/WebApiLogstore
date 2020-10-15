using Logstore.Domain.Entities;
using Logstore.Infra.Repositories.Interfaces.Clientes;
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
        private readonly IClienteRepository _clienteRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                            IPizzaSaboresRepository pizzaSaboresRepository,
                            IClienteRepository clienteRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._pizzaSaboresRepository = pizzaSaboresRepository;
            this._clienteRepository = clienteRepository;
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

            IEnumerable<int> IdsPizzas = pedido.Pizzas.Select(x => x.IdPizzaSabor1).Union(pedido.Pizzas.Where(x => x.IdPizzaSabor2 != null).Select(x => x.IdPizzaSabor2.Value));
            ICollection<PizzaSabores> pizzas = await GetPizzas(IdsPizzas);

            if (pizzas.Count != IdsPizzas.Count())
                return -2; // Id de pizza inexistente

            bool clienteExiste = await _clienteRepository.ClienteExiste(pedido.IdCliente);

            if (!clienteExiste)
            {
                Cliente newCliente = new Cliente(pedido.Endereco_Entrega);
                Cliente cliente = await _clienteRepository.Add(newCliente);
                pedido.SetCliente(cliente.Id);
            }

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
