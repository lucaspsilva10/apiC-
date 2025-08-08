
using APIEstudo.Domain.Entities;

namespace APIEstudo.Domain.Interfaces.Lancamentos
{
    public interface ILancamentoReadRepository
    {
        Task<List<Lancamento>> GetAllLancamentosAsync();
        Task<Lancamento> GetLancamentoByIdAsync(Guid id);
    }
}
