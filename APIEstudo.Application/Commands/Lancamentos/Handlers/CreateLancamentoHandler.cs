using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Lancamentos;
using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Bancos;
using APIEstudo.Domain.Interfaces.Categorias;
using APIEstudo.Domain.Interfaces.Lancamentos;

namespace APIEstudo.Application.Commands.Lancamentos.Handlers
{
    public class CreateLancamentoHandler : ICommandHandler<CreateLancamentoCommand, CreateLancamentoResponse>
    {
        private readonly IBancoReadRepository _bancoReadRepository;
        private readonly ICategoriaReadRepository _categoriaReadRepository;
        private readonly ILancamentoWriteRepository _lancamentoWriteRepository;

        public CreateLancamentoHandler(IBancoReadRepository bancoReadRepository,
                                       ICategoriaReadRepository categoriaReadRepository,
                                       ILancamentoWriteRepository lancamentoWriteRepository)
        {
            _bancoReadRepository = bancoReadRepository;
            _categoriaReadRepository = categoriaReadRepository;
            _lancamentoWriteRepository = lancamentoWriteRepository;
        }

        public async Task<CreateLancamentoResponse> HandleAsync(CreateLancamentoCommand command)
        {
            var banco = await _bancoReadRepository.GetBancoByNomeAsync(command.NomeBanco.ToUpper())
                ?? throw new Exception("Banco não encontrado, verifique o nome e digite novamente");

            var categoria = await _categoriaReadRepository.GetCategoriaByNomeAsync(command.NomeCategoria.ToUpper())
                ?? throw new Exception("Categoria não encontrada, verifirque o nome e digite novamente");

            var lancamento = new Lancamento(command.UsuarioId, banco.Id, categoria.Id, command.Descricao,
                command.Valor, command.DataLancamento, command.TipoLancamento);

            await _lancamentoWriteRepository.CreateLancamentoAsync(lancamento);

            return new CreateLancamentoResponse
            {
                NomeBanco = banco.Nome,
                NomeCategoria = categoria.Nome,
                Descricao = command.Descricao.ToUpper(),
                Valor = command.Valor,
                DataLancamento = command.DataLancamento
            };
        }
    }
}
