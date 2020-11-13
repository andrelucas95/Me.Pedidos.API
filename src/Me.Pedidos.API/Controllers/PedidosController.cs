using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Me.Pedidos.API.Models.Commands;
using Me.Pedidos.API.Models.Errors;
using Me.Pedidos.API.Models.Results;
using Me.Pedidos.Domain.Repositories;
using Me.Pedidos.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Me.Pedidos.API.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly AtualizarPedidoService _atualizarPedidoService;

        public PedidosController(IPedidoRepository pedidoRepository, AtualizarPedidoService atualizarPedidoService)
        {
            _pedidoRepository = pedidoRepository;
            _atualizarPedidoService = atualizarPedidoService;
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost, Route("")]
        public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoCommand comand)
        {
            _pedidoRepository.Add(comand.Map());
            var result = await _pedidoRepository.UnitOfWork.Commit();
            
            return Ok();
        }

        [ProducesResponseType(typeof(List<PedidoResultJson>), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet, Route("")]
        public async Task<IActionResult> ObterPedidos()
        {
            var pedidos = await _pedidoRepository.ObterTodos();
            return Ok(pedidos.Select(p => new PedidoResultJson(p)).ToList());
        }

        [ProducesResponseType(typeof(PedidoResultJson), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet, Route("{codigoPedido}")]
        public async Task<IActionResult> ObterPedido([FromRoute] string codigoPedido)
        {
            var pedido = await _pedidoRepository.BuscarPorCodigo(codigoPedido);

            if (pedido == null) return new CodigoPedidoInvalidoError();

            return Ok(new PedidoResultJson(pedido));
        }

        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(PedidoAtualizadoResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProcessingError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost, Route("status")]
        public async Task<IActionResult> AtualizarStatus([FromBody] AtualizarPedidoCommand command)
        {
            await _atualizarPedidoService.Process(command.Map());

            if (_atualizarPedidoService.CodigoPedidoInvalido) return new CodigoPedidoInvalidoError();
            if (_atualizarPedidoService.Aprovado) return new PedidoAprovadoError();
            if (_atualizarPedidoService.Reprovado) return new PedidoReprovadoError();
            if (_atualizarPedidoService.AprovadoValorAMaior) return new PedidoAprovadoValorAMaiorError();
            if (_atualizarPedidoService.AprovadoQtdAMaior) return new PedidoAprovadoQtdAMaiorError();
            if (_atualizarPedidoService.AprovadoValorAMenor) return new PedidoAprovadoValorAMenorError();
            if (_atualizarPedidoService.AprovadoQtdAMenor) return new PedidoAprovadoQtdAMenorError();

            return Ok(new PedidoAtualizadoResult(_atualizarPedidoService.Pedido));
        }
    }
}