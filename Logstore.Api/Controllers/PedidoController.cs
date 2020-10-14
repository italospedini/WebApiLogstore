using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Logstore.Api.Models.Pedidos;
using Logstore.Api.Models.Pizza;
using Logstore.Service.Interfaces.Pedidos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Logstore.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPedidoService _pedidoService;

        public PedidoController(IMapper mapper,
                                IPedidoService pedidoService)
        {
            this._mapper = mapper;
            this._pedidoService = pedidoService;
        }

        [HttpGet()]
        [Route("Historico/{idCliente}")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Histórico de pedidos do cliente retornado", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Method not found", Type = typeof(PizzaSaboresViewModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Error at server", Type = typeof(PizzaSaboresViewModel))]
        public async Task<ActionResult<ICollection<PedidoViewModel>>> GetHistorico([FromRoute] int idCliente)
        {
            return Ok(_mapper.Map<List<PedidoViewModel>>(await _pedidoService.GetHistorico(idCliente)));
        }
    }
}
