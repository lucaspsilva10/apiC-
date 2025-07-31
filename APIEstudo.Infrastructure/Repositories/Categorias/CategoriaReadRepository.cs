using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Categorias;
using APIEstudo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace APIEstudo.Infrastructure.Repositories.Categorias
{
    public class CategoriaReadRepository : ICategoriaReadRepository
    {
        private readonly AppDbContext _context;

        public CategoriaReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateCategoriaExistAsync(string nome)
        {
            return await _context.Categorias.AnyAsync(n => n.Nome == nome);
        }

        public async Task<List<Categoria>> GetAllCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(Guid id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
