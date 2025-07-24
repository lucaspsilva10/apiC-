using APIEstudo.Application.Commands.Logins;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Logins;
using Microsoft.AspNetCore.Mvc;

namespace APIEstudo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase   
    {
        private readonly ICommandHandler<LoginCommand, LoginResponse> _loginHandler;

        public LoginController(ICommandHandler<LoginCommand, LoginResponse> loginHandler)
        {
            _loginHandler = loginHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                var response = await _loginHandler.HandleAsync(command);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
