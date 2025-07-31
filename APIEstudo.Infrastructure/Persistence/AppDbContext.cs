using APIEstudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace APIEstudo.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100);
                entity.Property(e => e.Cpf).HasMaxLength(11);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Senha).HasMaxLength(60);
                entity.Property(e => e.CriadoEm)
                    .HasColumnType("datetime")
                    .IsRequired();
            });

            modelBuilder.Entity<Banco>(entity => 
            {
                entity.ToTable("bancos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100);
                entity.Property(e => e.CriadoEm)
                    .HasColumnType("datetime")
                    .IsRequired();
            });

            modelBuilder.Entity<Categoria>(entity => 
            {
                entity.ToTable("categorias");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(150);
                entity.Property(e => e.CriadoEm)
                    .HasColumnType("datetime")
                    .IsRequired();
            });
        }
    }
}
