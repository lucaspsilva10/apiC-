using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Bancos;
using APIEstudo.Infrastructure.Persistence;


namespace APIEstudo.Infrastructure.Repositories.Bancos
{
    public class BancoWriteRepository : IBancoWriteRepository 
    {
        private readonly AppDbContext _context;

        public BancoWriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Banco> CreateBancoAsync(Banco banco)
        {
            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();
            return banco;
        }

        public async Task<Banco> UpdateBancoAsync(Banco banco)
        {
            _context.Bancos.Update(banco);
            await _context.SaveChangesAsync();
            return banco;
        }

        public async Task<bool> DeleteBancoAsync(Guid id)
        {
            var banco = await _context.Bancos.FindAsync(id);
            if (banco == null)
                return false;

            _context.Bancos.Remove(banco);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
