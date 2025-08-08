using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Lancamentos;
using APIEstudo.Infrastructure.Persistence;

namespace APIEstudo.Infrastructure.Repositories.Lancamentos
{
    public class LancamentoWriteRepository : ILancamentoWriteRepository
    {
        private readonly AppDbContext _context;

        public LancamentoWriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lancamento> CreateLancamentoAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<Lancamento> UpdateLancamentoAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Update(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<bool> DeleteLancamentoAsync(Guid id) 
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null)
                return false;

            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
