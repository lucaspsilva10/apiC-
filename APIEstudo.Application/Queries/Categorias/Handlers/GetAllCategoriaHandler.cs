using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Categorias;
using APIEstudo.Domain.Interfaces.Categorias;
using AutoMapper;

namespace APIEstudo.Application.Queries.Categorias.Handlers
{
    public class GetAllCategoriaHandler : IQueryHandler<GetAllCategoriaQuery, List<GetAllCategoriaResponse>>
    {
        private readonly ICategoriaReadRepository _categoriaReadRepository;
        private readonly IMapper _mapper;
        public GetAllCategoriaHandler(ICategoriaReadRepository categoriaReadRepository, IMapper mapper) 
        {
            _categoriaReadRepository = categoriaReadRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoriaResponse>> HandleAsync(GetAllCategoriaQuery query)
        {
            var categorias = await _categoriaReadRepository.GetAllCategoriasAsync();

            if (categorias == null || !categorias.Any())
                throw new Exception("Nenhuma categoria cadastrada no sistema");

            return _mapper.Map<List<GetAllCategoriaResponse>>(categorias);
        }
    }
}
