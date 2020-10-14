using AutoMapper;
using Logstore.Api.Models.Pedidos;
using Logstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Mappings.Pedidos
{
    public class PedidoMapping : Profile
    {
        public PedidoMapping()
        {
            CreateMap<Pedido, PedidoViewModel>();
        }
    }
}
