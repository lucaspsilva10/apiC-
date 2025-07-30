using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Bancos;
using APIEstudo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace APIEstudo.Infrastructure.Repositories.Bancos
{
    public class BancoReadRepository : IBancoReadRepository
    {
        private readonly AppDbContext _context;

        public BancoReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateBancoExistAsync(string nome)
        {
            return await _context.Bancos.AnyAsync(u => u.Nome == nome);
        }

        public async Task<List<Banco>> GetAllBancosAsync()
        {
            return await _context.Bancos.ToListAsync();
        }

        public async Task<Banco> GetBancoByIdAsync(Guid id)
        {
            return await _context.Bancos.FirstOrDefaultAsync(b => b.Id == id);
        }
    }

}
