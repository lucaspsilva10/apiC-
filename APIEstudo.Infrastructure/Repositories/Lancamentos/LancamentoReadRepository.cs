using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Lancamentos;
using APIEstudo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace APIEstudo.Infrastructure.Repositories.Lancamentos
{
    public class LancamentoReadRepository : ILancamentoReadRepository
    {
        private readonly AppDbContext _context;

        public LancamentoReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lancamento>> GetAllLancamentosAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<Lancamento> GetLancamentoByIdAsync(Guid id)
        {
            return await _context.Lancamentos.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
