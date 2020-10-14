using Logstore.Domain.Entities;
using Logstore.Infra.Repositories.Interfaces.Pedidos;
using Logstore.Service.Interfaces.Pedidos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Service.Services.Pedidos
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        async Task<ICollection<Pedido>> IPedidoService.GetHistorico(int idcliente)
        {
            return await _pedidoRepository.GetHistorico(idcliente);
        }

        async Task<Pedido> IPedidoService.Incluir(Pedido pedido)
        {
            bool pedidoValido = pedido.PedidoValido();

            if (!pedidoValido)
                return pedido;

            pedido.CalcularValorTotalPedido();

            Pedido result = await _pedidoRepository.Add(pedido);

            return result;
        }

    }
}
