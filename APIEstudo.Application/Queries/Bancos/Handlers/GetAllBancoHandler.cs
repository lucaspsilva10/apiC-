using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Bancos;
using APIEstudo.Domain.Interfaces.Bancos;
using AutoMapper;


namespace APIEstudo.Application.Queries.Bancos.Handlers
{
    public class GetAllBancoHandler : IQueryHandler<GetAllBancoQuery, List<GetAllBancoResponse>>
    {
        private readonly IBancoReadRepository _bancoReadRepository;
        private readonly IMapper _mapper;

        public GetAllBancoHandler(IBancoReadRepository bancoReadRepository, IMapper mapper)
        {
            _bancoReadRepository = bancoReadRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBancoResponse>> HandleAsync(GetAllBancoQuery query)
        {
            var bancos = await _bancoReadRepository.GetAllBancosAsync() ?? 
                throw new Exception("Nenhum banco cadastrado no sistema"); ;

            return _mapper.Map<List<GetAllBancoResponse>>(bancos);   
        }
    }
}
