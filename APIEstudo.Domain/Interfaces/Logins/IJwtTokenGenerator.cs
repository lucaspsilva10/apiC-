using APIEstudo.Domain.Entities;

namespace APIEstudo.Domain.Interfaces.Logins
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Usuario usuario);
    }
}
