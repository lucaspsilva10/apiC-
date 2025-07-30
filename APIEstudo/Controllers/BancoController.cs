using APIEstudo.Application.Commands.Bancos;
using APIEstudo.Application.Commands.Usuarios;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Queries.Bancos;
using APIEstudo.Application.Queries.Bancos.Handlers;
using APIEstudo.Application.Responses;
using APIEstudo.Application.Responses.Bancos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIEstudo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly ICommandHandler<CreateBancoCommand, MensagemResponse> _createHandler;
        private readonly ICommandHandler<UpdateBancoCommand, MensagemResponse> _updateHandler;
        private readonly IQueryHandler<GetAllBancoQuery, List<GetAllBancoResponse>> _getAllHandler;
        private readonly ICommandHandler<DeleteBancoCommand, MensagemResponse> _deleteBanco;

        public BancoController(ICommandHandler<CreateBancoCommand, MensagemResponse> createHandler,
            IQueryHandler<GetAllBancoQuery, List<GetAllBancoResponse>> getAllHandler,
            ICommandHandler<UpdateBancoCommand, MensagemResponse> updateHandler,
            ICommandHandler<DeleteBancoCommand, MensagemResponse> deleteBanco)
        {
            _createHandler = createHandler;
            _getAllHandler = getAllHandler;
            _updateHandler = updateHandler;
            _deleteBanco = deleteBanco;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateBancoCommand command)
        {
            try
            {
                var mensagem = await _createHandler.HandleAsync(command);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("ObterBancos")]
        public async Task<IActionResult> GetAllBancos()
        {
            try
            {
                var result = await _getAllHandler.HandleAsync(new GetAllBancoQuery());
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("UpdateBanco")]
        public async Task<IActionResult> UpdateBanco([FromBody] UpdateBancoCommand command)
        {
            try
            {
                var mensagem = await _updateHandler.HandleAsync(command);
                return Ok(mensagem);
            }catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("deleteBanco/{id}")]
        public async Task<IActionResult> DeleteBanco(Guid id)
        {
            try
            {
                var idBanco = new DeleteBancoCommand(id);

                var mensagem = await _deleteBanco.HandleAsync(idBanco);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
