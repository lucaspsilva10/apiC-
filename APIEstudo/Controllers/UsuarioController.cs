using APIEstudo.Application.Commands.Usuarios;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIEstudo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController: ControllerBase
    {
        private readonly ICommandHandler<CreateUsuarioCommand, MensagemResponse> _createHandler;
        public UsuarioController(ICommandHandler<CreateUsuarioCommand, MensagemResponse> createHandler)
        {
            _createHandler = createHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioCommand command)
        {
            var mensagem = await _createHandler.HandleAsync(command);
            return Ok(mensagem);
        }
    }
}
