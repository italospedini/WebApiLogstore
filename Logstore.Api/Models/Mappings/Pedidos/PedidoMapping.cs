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
            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(to => to.NumeroPedido, opt => opt.MapFrom(src => src.Id));

            CreateMap<PedidoViewModel, Pedido>()
                .ForMember(to => to.Id, opt => opt.Ignore());

            CreateMap<InputPedidoModel, Pedido>()
                .ForMember(to => to.Id, opt => opt.Ignore())
                .ForMember(to => to.Data_Pedido, opt => opt.Ignore())
                .ForMember(to => to.ValorTotalPedido, opt => opt.Ignore());
        }
    }
}
