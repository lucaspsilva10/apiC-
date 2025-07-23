using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Usuarios;
using APIEstudo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace APIEstudo.Infrastructure.Repositories.Usuarios
{
    public class UsuarioReadRepository : IUsuarioReadRepository

    {
        private readonly AppDbContext _context;

        public UsuarioReadRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ValidateCPFExistAsync(string cpf)
        {
            return await _context.Usuarios.AnyAsync(u => u.Cpf == cpf);
        }

        public async Task<bool> ValidateEmailExistAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
