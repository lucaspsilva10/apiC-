using APIEstudo.Application.Commands.Logins;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Logins;
using Microsoft.AspNetCore.Authorization;
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
            var token = await _loginHandler.HandleAsync(command);
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("protegido")]
        public IActionResult Get()
        {
            return Ok("Você está autenticado!");
        }
    }
}
