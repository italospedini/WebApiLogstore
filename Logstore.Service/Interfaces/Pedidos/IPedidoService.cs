﻿using Logstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Service.Interfaces.Pedidos
{
    public interface IPedidoService
    {
        Task<ICollection<Pedido>> GetHistorico(int idcliente);

        Task<int> Incluir(Pedido pedido);

        Task<Pedido> GetByNumeroPedido(int numeroPedido);
    }
}
