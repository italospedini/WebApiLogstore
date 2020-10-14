using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Logstore.Api.Models.Pizza;
using Logstore.Service.Interfaces.Pizza;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Logstore.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPizzaService _pizzaService;

        public PizzaController(IMapper mapper,
                                IPizzaService pizzaService)
        {
            this._mapper = mapper;
            this._pizzaService = pizzaService;
        }

        [HttpGet()]
        [Route("CardapioPizzas")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "List of pizzas returned", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Method not found", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Error at server", Type = typeof(PizzaSaboresViewModel))]
        public async Task<ActionResult<ICollection<PizzaSaboresViewModel>>> CardapioPizzas()
        {
            return Ok(_mapper.Map<List<PizzaSaboresViewModel>>(await _pizzaService.GetCardapioPizzas()));
        }

    }
}
