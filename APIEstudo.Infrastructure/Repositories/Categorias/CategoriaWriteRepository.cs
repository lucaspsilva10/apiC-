using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Categorias;
using APIEstudo.Infrastructure.Persistence;

namespace APIEstudo.Infrastructure.Repositories.Categorias
{
    public class CategoriaWriteRepository : ICategoriaWriteRepository
    {
        private readonly AppDbContext _context;

        public CategoriaWriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> DeleteCategoriaAsync(Guid id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if(categoria == null)
                return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
