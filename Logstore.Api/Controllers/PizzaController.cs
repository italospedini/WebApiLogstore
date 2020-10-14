using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Logstore.Api.Models.Pizza;
using Logstore.Domain.Entities;
using Logstore.Service.ApiResponse;
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
        [Route("Cardapio")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Catálogo de pizzas retornado", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Method not found", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Error at server", Type = typeof(PizzaSaboresViewModel))]
        public async Task<ActionResult<ICollection<PizzaSaboresViewModel>>> GetCardapio()
        {
            return Ok(_mapper.Map<List<PizzaSaboresViewModel>>(await _pizzaService.GetCardapio()));
        }

        [HttpPost()]
        [Route("Cadastrar")]
        [SwaggerResponse(StatusCodes.Status201Created, Description = "Pizza cadastrada com sucesso", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Method not found", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Modelo inválido", Type = typeof(ApiResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Error at server", Type = typeof(PizzaSaboresViewModel))]
        public async Task<ActionResult<ApiResponse>> CadastrarPizza([FromBody] PizzaSaboresViewModel pizzaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest, "Modelo inválido"));
            }

            PizzaSaboresViewModel response = _mapper.Map<PizzaSaboresViewModel>(
                                                await _pizzaService.Cadastrar(_mapper.Map<PizzaSabores>(pizzaViewModel)));

            if (!(response.Id.Equals(0)))
                return Created(response.Id.ToString(), _mapper.Map<PizzaSaboresViewModel>(response));
            else
                return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest, "Pizza já cadastrada."));
        }
    }
}
