using APIEstudo.Application.Responses.Bancos;
using APIEstudo.Application.Responses.Categorias;
using APIEstudo.Application.Responses.Lancamentos;
using APIEstudo.Application.Responses.Usuarios;
using APIEstudo.Domain.Entities;
using AutoMapper;


namespace APIEstudo.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, GetUsuarioByIdResponse>();
            CreateMap<Banco, GetAllBancoResponse>();
            CreateMap<Categoria, GetAllCategoriaResponse>();
            CreateMap<Lancamento, GetAllLancamentoResponse>();
        }
    }
}
