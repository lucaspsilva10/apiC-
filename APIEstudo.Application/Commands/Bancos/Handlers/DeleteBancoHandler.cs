using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Interfaces.Bancos;


namespace APIEstudo.Application.Commands.Bancos.Handlers
{
    public class DeleteBancoHandler : ICommandHandler<DeleteBancoCommand, MensagemResponse>
    {
        private readonly IBancoWriteRepository _bancoWriteRepository;

        public DeleteBancoHandler(IBancoWriteRepository bancoWriteRepository)
        {
            _bancoWriteRepository = bancoWriteRepository;
        }

        public async Task<MensagemResponse> HandleAsync(DeleteBancoCommand command)
        {
            var deleteBanco = await _bancoWriteRepository.DeleteBancoAsync(command.Id);

            if (!deleteBanco)
                throw new Exception("Banco não encontrado");

            return new MensagemResponse() { Mensagem = "Banco deletado com sucesso" };
        }
    }
}
