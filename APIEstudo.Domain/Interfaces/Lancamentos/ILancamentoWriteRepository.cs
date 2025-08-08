using APIEstudo.Domain.Entities;

namespace APIEstudo.Domain.Interfaces.Lancamentos
{
    public interface ILancamentoWriteRepository
    {
        Task<Lancamento> CreateLancamentoAsync(Lancamento lancamento);
        Task<Lancamento> UpdateLancamentoAsync(Lancamento lancamento);
        Task<bool> DeleteLancamentoAsync(Guid id);
    }
}
