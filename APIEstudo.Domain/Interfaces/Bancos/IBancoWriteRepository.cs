using APIEstudo.Domain.Entities;

namespace APIEstudo.Domain.Interfaces.Bancos
{
    public interface IBancoWriteRepository
    {
        Task<Banco> CreateBancoAsync(Banco banco);
        Task<Banco> UpdateBancoAsync(Banco banco);
        Task<bool> DeleteBancoAsync(Guid id);
    }
}
