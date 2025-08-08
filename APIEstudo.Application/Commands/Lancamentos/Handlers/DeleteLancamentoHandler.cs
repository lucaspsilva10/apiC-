using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Interfaces.Lancamentos;

namespace APIEstudo.Application.Commands.Lancamentos.Handlers
{
    public class DeleteLancamentoHandler : ICommandHandler<DeleteLancamentoCommand, MensagemResponse>
    {
        private readonly ILancamentoWriteRepository _lancamentoWriteRepository;

        public DeleteLancamentoHandler(ILancamentoWriteRepository lancamentoWriteRepository)
        {
            _lancamentoWriteRepository = lancamentoWriteRepository;
        }

        public async Task<MensagemResponse> HandleAsync(DeleteLancamentoCommand command)
        {
            var deleteLancamento = await _lancamentoWriteRepository.DeleteLancamentoAsync(command.Id);

            if (!deleteLancamento)
                throw new ArgumentException("Lançamento não encontrado");

            return new MensagemResponse { Mensagem = "Lançamento deletado com sucesso" };
        }
    }
}
