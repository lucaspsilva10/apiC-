using APIEstudo.Application.Commands.Lancamentos;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Queries.Lancamentos;
using APIEstudo.Application.Responses;
using APIEstudo.Application.Responses.Lancamentos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIEstudo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly ICommandHandler<CreateLancamentoCommand, CreateLancamentoResponse> _createHandler;
        private readonly ICommandHandler<UpdateLancamentoCommand, MensagemResponse> _updateHandler;
        private readonly ICommandHandler<DeleteLancamentoCommand, MensagemResponse> _deleteHandler;
        private readonly IQueryHandler<GetAllLancamentoQuery, List<GetAllLancamentoResponse>> _getAllQueryHandler;
        public LancamentoController(ICommandHandler<CreateLancamentoCommand, CreateLancamentoResponse> createHandler,
                                    IQueryHandler<GetAllLancamentoQuery, List<GetAllLancamentoResponse>> getAllQueryHandler,
                                    ICommandHandler<UpdateLancamentoCommand, MensagemResponse> updateHandler,
                                    ICommandHandler<DeleteLancamentoCommand, MensagemResponse> deleteHandler)
        {
            _createHandler = createHandler;
            _getAllQueryHandler = getAllQueryHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [Authorize]
        [HttpPost("createLancamento")]
        public async Task<IActionResult> CreateLancamento([FromBody] CreateLancamentoCommand command)
        {
            try
            {
                var lancamento = await _createHandler.HandleAsync(command);
                return Ok(lancamento);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("getAllLancamentos")]
        public async Task<IActionResult> GetAllLancamento()
        {
            try
            {
                var result = await _getAllQueryHandler.HandleAsync(new GetAllLancamentoQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("updateLancamentos")]
        public async Task<IActionResult> UpdateLancamento([FromBody] UpdateLancamentoCommand command)
        {
            try
            {
                var lancamento = await _updateHandler.HandleAsync(command);
                return Ok(lancamento);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("deleteLancamentos/{id}")]
        public async Task<IActionResult> DeleteLancamento(Guid id)
        {
            try
            {
                var idLancamento = new DeleteLancamentoCommand(id);
                var mensagem = await _deleteHandler.HandleAsync(idLancamento);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
