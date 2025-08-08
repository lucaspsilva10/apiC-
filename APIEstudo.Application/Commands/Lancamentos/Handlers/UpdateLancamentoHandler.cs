using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Interfaces.Bancos;
using APIEstudo.Domain.Interfaces.Categorias;
using APIEstudo.Domain.Interfaces.Lancamentos;

namespace APIEstudo.Application.Commands.Lancamentos.Handlers
{
    public class UpdateLancamentoHandler : ICommandHandler<UpdateLancamentoCommand, MensagemResponse>
    {
        private readonly ILancamentoReadRepository _lancamentoReadRepository;
        private readonly ILancamentoWriteRepository _lancamentoWriteRepository;
        private readonly IBancoReadRepository _bancoReadRepository;
        private readonly ICategoriaReadRepository _categoriaReadRepository;

        public UpdateLancamentoHandler(ILancamentoReadRepository lancamentoReadRepository,
                                       ILancamentoWriteRepository lancamentoWriteRepository,
                                       IBancoReadRepository bancoReadRepository,
                                       ICategoriaReadRepository categoriaReadRepository)
        {
            _lancamentoReadRepository = lancamentoReadRepository;
            _lancamentoWriteRepository = lancamentoWriteRepository;
            _bancoReadRepository = bancoReadRepository;
            _categoriaReadRepository = categoriaReadRepository;
        }

        public async Task<MensagemResponse> HandleAsync(UpdateLancamentoCommand command)
        {
            var lancamento = await _lancamentoReadRepository.GetLancamentoByIdAsync(command.LancamentoId) 
                ?? throw new ArgumentException("Nenhum lançamento encontrado");

            var banco = await _bancoReadRepository.GetBancoByNomeAsync(command.NomeBanco.ToUpper())
                ?? throw new ArgumentException("Nenhum Banco encontrado com esse nome, digite um Banco válido");

            var categoria = await _categoriaReadRepository.GetCategoriaByNomeAsync(command.NomeCategoria.ToUpper())
                ?? throw new ArgumentException("Nenhuma Categoria encotrada com esse nome, digite uma Categoria válida");

            lancamento.AtualizarLancamento(banco.Id, categoria.Id, command.Descricao, command.Valor, command.DataLancamento, command.TipoLancamento);

            await _lancamentoWriteRepository.UpdateLancamentoAsync(lancamento);

            return new MensagemResponse { Mensagem = "Lançamento atualizado" };
        }
    }
}
