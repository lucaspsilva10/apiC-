using APIEstudo.Domain.Entities;


namespace APIEstudo.Domain.Interfaces.Categorias
{
    public interface ICategoriaWriteRepository
    {
        Task<Categoria> CreateCategoriaAsync(Categoria categoria);
        Task<Categoria> UpdateCategoriaAsync(Categoria categoria);
        Task<bool> DeleteCategoriaAsync(Guid id);
    }
}
