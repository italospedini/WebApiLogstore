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
        }
    }
}
