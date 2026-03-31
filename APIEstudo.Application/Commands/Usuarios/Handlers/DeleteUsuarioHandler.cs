using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Interfaces.Usuarios;

namespace APIEstudo.Application.Commands.Usuarios.Handlers
{
    public class DeleteUsuarioHandler : ICommandHandler<DeleteUsuarioCommand, MensagemResponse>
    {
        private readonly IUsuarioWriteRepository _writeRepository;

        public DeleteUsuarioHandler(IUsuarioWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<MensagemResponse> HandleAsync(DeleteUsuarioCommand command)
        {
            var deleteUsuario = await _writeRepository.DeleteUsuarioAsync(command.Id);

            if (!deleteUsuario)
                throw new Exception("Usuário não encontrado.");

            return new MensagemResponse { Mensagem = "Usuário deletado com sucesso." };
        }
    }
}
