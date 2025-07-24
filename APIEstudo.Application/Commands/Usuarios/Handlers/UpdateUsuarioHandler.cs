using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Interfaces.Usuarios;
using System.Text.RegularExpressions;

namespace APIEstudo.Application.Commands.Usuarios.Handlers
{
    public class UpdateUsuarioHandler : ICommandHandler<UpdateUsuarioCommand, MensagemResponse>
    {
        private readonly IUsuarioReadRepository _readRepository;
        private readonly IUsuarioWriteRepository _writeRepository;

        public UpdateUsuarioHandler (IUsuarioReadRepository readRepository, IUsuarioWriteRepository writeRepository )
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<MensagemResponse> HandleAsync(UpdateUsuarioCommand command)
        {
            var usuario = await _readRepository.GetUsuarioByIdAsync(command.Id)
                ?? throw new Exception("Usuário não encontrado.");

            if (!string.IsNullOrWhiteSpace(command.Senha) &&
                !BCrypt.Net.BCrypt.Verify(command.Senha, usuario.Senha))
            {
                usuario.AtualizarSenha(command.Senha);
            }

            if (!string.IsNullOrWhiteSpace(command.Cpf))
            {
                var cpfSemFormatacao = Regex.Replace(command.Cpf, @"[^\d]", "");

                if (cpfSemFormatacao != usuario.Cpf &&
                    await _readRepository.ValidateCPFExistAsync(cpfSemFormatacao))
                {
                    throw new Exception("CPF já cadastrado.");
                }

                usuario.AtualizarCPF(cpfSemFormatacao);
            }

            if (!string.IsNullOrWhiteSpace(command.Email) && command.Email != usuario.Email)
            {
                if (await _readRepository.ValidateEmailExistAsync(command.Email))
                    throw new Exception("Email já cadastrado.");

                usuario.AtualizarEmail(command.Email);
            }

            if (!string.IsNullOrWhiteSpace(command.Nome) && command.Nome != usuario.Nome)
            {
                usuario.AtualizarNome(command.Nome);
            }

            await _writeRepository.UpdateUsuarioAsync(usuario);

            return new MensagemResponse { Mensagem = "Dados do Usuário alterados." };
        }
    }
}
