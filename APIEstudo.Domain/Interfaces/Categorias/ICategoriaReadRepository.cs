using APIEstudo.Domain.Entities;

namespace APIEstudo.Domain.Interfaces.Categorias
{
    public interface ICategoriaReadRepository
    {
        Task<bool> ValidateCategoriaExistAsync(string nome);
        Task<List<Categoria>> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(Guid id);
    }
}
