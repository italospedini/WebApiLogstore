using AutoMapper;
using Logstore.Api.Models.Pizza;
using Logstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Mappings.Pizza
{
    public class PizzaMapping : Profile
    {
        public PizzaMapping()
        {
            CreateMap<PizzaSabores, PizzaSaboresViewModel>();

            CreateMap<PizzaSaboresViewModel, PizzaSabores>()
                .ForMember(src => src.Ativa, opt => opt.Ignore())
                .ForMember(src => src.Disponivel, opt => opt.Ignore());

            CreateMap<Logstore.Domain.Entities.Pizza, PizzaViewModel>();

            CreateMap<PizzaViewModel, Logstore.Domain.Entities.Pizza>()
                .ForMember(x => x.Pedido, opt => opt.Ignore());

            CreateMap<InputPizzaPedidoModel, Logstore.Domain.Entities.Pizza>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.IdPedido, opt => opt.Ignore())
                .ForMember(x => x.Pedido, opt => opt.Ignore())
                .ForMember(x => x.PrecoTotal, opt => opt.Ignore())
                .ForMember(x => x.Sabor1, opt => opt.Ignore())
                .ForMember(x => x.Sabor2, opt => opt.Ignore());
        }
    }
}
