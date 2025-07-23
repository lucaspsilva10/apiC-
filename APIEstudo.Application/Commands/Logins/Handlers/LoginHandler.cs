using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Logins;
using APIEstudo.Domain.Interfaces.Logins;
using APIEstudo.Domain.Interfaces.Usuarios;

namespace APIEstudo.Application.Commands.Logins.Handlers
{
    public class LoginHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IUsuarioReadRepository _readRepo;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public LoginHandler(IUsuarioReadRepository readRepo, IJwtTokenGenerator tokenGenerator)
        {
            _readRepo = readRepo;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginResponse> HandleAsync(LoginCommand command)
        {
            var usuario = await _readRepo.GetUsuarioByEmailAsync(command.Email);
            var verificacao = BCrypt.Net.BCrypt.Verify(command.Senha, usuario.Senha);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(command.Senha.Trim(), usuario.Senha))
                throw new UnauthorizedAccessException("Email ou senha inválidos");

            var token = _tokenGenerator.GenerateToken(usuario);

            return new LoginResponse
            {
                Token = token,
                Usuario = new DadosUsuarioLogado
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = command.Email,
                }
            };
        }
    }
}
