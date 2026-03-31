using APIEstudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Domain.Interfaces.Bancos
{
    public interface IBancoReadRepository
    {
        Task<bool> ValidateBancoExistAsync(string nome);
        Task<List<Banco>> GetAllBancosAsync();
        Task<Banco> GetBancoByIdAsync(Guid id);
        Task<Banco> GetBancoByNomeAsync(string nome);
    }
}
