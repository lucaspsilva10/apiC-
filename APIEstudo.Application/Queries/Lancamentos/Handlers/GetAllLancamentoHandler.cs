using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Lancamentos;
using APIEstudo.Domain.Interfaces.Bancos;
using APIEstudo.Domain.Interfaces.Categorias;
using APIEstudo.Domain.Interfaces.Lancamentos;
using APIEstudo.Domain.Interfaces.Usuarios;

namespace APIEstudo.Application.Queries.Lancamentos.Handlers
{
    public class GetAllLancamentoHandler: IQueryHandler<GetAllLancamentoQuery, List<GetAllLancamentoResponse>>
    {
        private readonly ILancamentoReadRepository _lancamentoReadRepository;
        private readonly IBancoReadRepository _bancoReadRepository;
        private readonly ICategoriaReadRepository _categoriaReadRepository;
        private readonly IUsuarioReadRepository _usuarioReadRepository;

        public GetAllLancamentoHandler(ILancamentoReadRepository lancamentoReadRepository,
                                       IBancoReadRepository bancoReadRepository,
                                       ICategoriaReadRepository categoriaReadRepository,
                                       IUsuarioReadRepository usuarioReadRepository)
        {
            _lancamentoReadRepository = lancamentoReadRepository;
            _bancoReadRepository = bancoReadRepository;
            _categoriaReadRepository = categoriaReadRepository;
            _usuarioReadRepository = usuarioReadRepository;
        }

        public async Task<List<GetAllLancamentoResponse>> HandleAsync(GetAllLancamentoQuery query)
        {
            var bancos = await _bancoReadRepository.GetAllBancosAsync();
            var categorias = await _categoriaReadRepository.GetAllCategoriasAsync();
            var lancamentos = await _lancamentoReadRepository.GetAllLancamentosAsync();
            var usuarios = await _usuarioReadRepository.GetAllUsuarioAsync();

            var bancoDict = bancos.ToDictionary(b => b.Id);
            var categoriaDict = categorias.ToDictionary(c => c.Id);
            var usuarioDict = usuarios.ToDictionary(u => u.Id);

            var responses = lancamentos.Select(l => new GetAllLancamentoResponse
            {
                NomeUsuario = usuarioDict.GetValueOrDefault(l.UsuarioId)?.Nome,
                NomeBanco = bancoDict.GetValueOrDefault(l.BancoId)?.Nome,
                NomeCategoria = categoriaDict.GetValueOrDefault(l.CategoriaId)?.Nome,
                Descricao = l.Descricao,
                Valor = l.Valor,
                DataLancamento = l.DataLancamento,
                Tipo = l.Tipo,
                DataCriacao = l.CriadoEm
            }).ToList();

            return responses;
        }

    }
}
