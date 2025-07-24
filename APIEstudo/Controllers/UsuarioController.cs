using APIEstudo.Application.Commands.Usuarios;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Queries.Usuarios;
using APIEstudo.Application.Responses;
using APIEstudo.Application.Responses.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIEstudo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController: ControllerBase
    {
        private readonly ICommandHandler<CreateUsuarioCommand, MensagemResponse> _createHandler;
        private readonly ICommandHandler<UpdateUsuarioCommand, MensagemResponse> _updateHandler;
        private readonly IQueryHandler<GetUsuarioByIdQuery, GetUsuarioByIdResponse> _queryHandler;
        private readonly ICommandHandler<DeleteUsuarioCommand, MensagemResponse> _deleteHandler;
        public UsuarioController(ICommandHandler<CreateUsuarioCommand, MensagemResponse> createHandler,
            ICommandHandler<UpdateUsuarioCommand, MensagemResponse> updateHandler,
            IQueryHandler<GetUsuarioByIdQuery, GetUsuarioByIdResponse> queryHandler,
            ICommandHandler<DeleteUsuarioCommand, MensagemResponse> deleteHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _queryHandler = queryHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioCommand command)
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
        [HttpPut("alterar")]
        public async Task<IActionResult> UpdateUsuario([FromBody] UpdateUsuarioCommand command)
        {
            try
            {
                var mensagem = await _updateHandler.HandleAsync(command);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(Guid id)
        {
            try
            {
                var query = new GetUsuarioByIdQuery(id);
                var usuario = await _queryHandler.HandleAsync(query);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            try
            {
                var idUsuario = new DeleteUsuarioCommand(id);
                var response = await _deleteHandler.HandleAsync(idUsuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

    }
}
