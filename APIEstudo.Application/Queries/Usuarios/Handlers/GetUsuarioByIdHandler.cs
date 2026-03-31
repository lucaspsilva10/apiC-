using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses.Usuarios;
using APIEstudo.Domain.Interfaces.Usuarios;
using AutoMapper;


namespace APIEstudo.Application.Queries.Usuarios.Handlers
{
    public class GetUsuarioByIdHandler : IQueryHandler<GetUsuarioByIdQuery, GetUsuarioByIdResponse>
    {
        private readonly IUsuarioReadRepository _readRepo;
        private readonly IMapper _mapper;

        public GetUsuarioByIdHandler(IUsuarioReadRepository readRepo, IMapper mapper)
        {
            _readRepo = readRepo;
            _mapper = mapper;
        }

        public async Task<GetUsuarioByIdResponse> HandleAsync(GetUsuarioByIdQuery query)
        {
            var usuario = await _readRepo.GetUsuarioByIdAsync(query.Id)
                ?? throw new Exception("Usuário não encontrado.");

            return _mapper.Map<GetUsuarioByIdResponse>(usuario);
        }
    }
}
