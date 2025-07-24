using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Usuarios;
using System.Text.RegularExpressions;

namespace APIEstudo.Application.Commands.Usuarios.Handlers
{
    public class CreateUsuarioHandler : ICommandHandler<CreateUsuarioCommand, MensagemResponse>
    {
        private readonly IUsuarioReadRepository _read;
        private readonly IUsuarioWriteRepository _write;

        public CreateUsuarioHandler(IUsuarioReadRepository read, IUsuarioWriteRepository write)
        {
            _read = read;
            _write = write;
        }

        public async Task<MensagemResponse> HandleAsync(CreateUsuarioCommand command)
        {
            command.Cpf = Regex.Replace(command.Cpf, @"[^\d]", "");
            command.Senha = BCrypt.Net.BCrypt.HashPassword(command.Senha);

            if (await _read.ValidateCPFExistAsync(command.Cpf))
                throw new Exception("CPF já cadastrado.");

            if (await _read.ValidateEmailExistAsync(command.Email))
                throw new Exception("Email já cadastrado.");

            var usuario = new Usuario(command.Nome, command.Cpf, command.Email, command.Senha);
            await _write.CreateUsuarioAsync(usuario);

            return new MensagemResponse { Mensagem = "Usuário criado com sucesso"};
        }
    }
}
