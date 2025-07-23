using APIEstudo.Infrastructure.Persistence;
using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Usuarios;


namespace APIEstudo.Infrastructure.Repositories.Usuarios
{
    public class UsuarioWriteRepository : IUsuarioWriteRepository
    {
        private readonly AppDbContext _context;
        public UsuarioWriteRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
