using APIEstudo.Domain.Entities;

namespace APIEstudo.Domain.Interfaces.Usuarios
{
    public interface IUsuarioReadRepository
    {
        Task<bool> ValidateCPFExistAsync(string cpf);
        Task<bool> ValidateEmailExistAsync(string email);
        Task<Usuario> GetUsuarioByEmailAsync(string email);
        Task<Usuario> GetUsuarioByIdAsync(Guid id);
        Task<List<Usuario>> GetAllUsuarioAsync();
    }
}
