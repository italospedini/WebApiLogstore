using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Logstore.Api.Models.Pedidos;
using Logstore.Api.Models.Pizza;
using Logstore.Domain.Entities;
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
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Histórico de pedidos do cliente retornado", Type = typeof(PedidoViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Method not found", Type = typeof(ObjectResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Error at server", Type = typeof(ObjectResult))]
        public async Task<ActionResult<ICollection<PedidoViewModel>>> GetHistorico([FromRoute] int idCliente)
        {
            try
            {
                return Ok(_mapper.Map<List<PedidoViewModel>>(await _pedidoService.GetHistorico(idCliente)));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex) { StatusCode = StatusCodes.Status500InternalServerError, Value = ex.Message };
            }
        }

        [HttpPost()]
        [Route("Incluir")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Pedido incluído", Type = typeof(PedidoViewModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Modelo de pedido inválido", Type = typeof(ObjectResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Method not found", Type = typeof(ObjectResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Error at server", Type = typeof(ObjectResult))]
        public async Task<ActionResult<PedidoViewModel>> Incluir([FromBody] InputPedidoModel pedidoViewModel)
        {
            try
            {
                if (!ModelState.IsValid || !pedidoViewModel.ModelIsValid())
                {
                    return new ObjectResult("Modelo inválido") { StatusCode = StatusCodes.Status400BadRequest, Value = "Modelo inválido" };
                }

                int numeroPedido = await _pedidoService.Incluir(_mapper.Map<Pedido>(pedidoViewModel));

                if (numeroPedido == -1)
                    return new ObjectResult("Modelo inválido") { StatusCode = StatusCodes.Status400BadRequest, Value = "Modelo inválido" };
                else if (numeroPedido == -2)
                    return new ObjectResult("Pizza inexistente") { StatusCode = StatusCodes.Status400BadRequest, Value = "Pizza inexistente" };

                PedidoViewModel pedido = _mapper.Map<PedidoViewModel>(await _pedidoService.GetByNumeroPedido(numeroPedido));

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex) { StatusCode = StatusCodes.Status500InternalServerError, Value = ex.Message };
            }
        }
    }
}
