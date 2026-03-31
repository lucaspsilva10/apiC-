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
        public DbSet<Lancamento> Lancamentos { get; set; }


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

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.ToTable("lancamentos");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(36)");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("char(36)")
                    .IsRequired();

                entity.Property(e => e.BancoId)
                    .HasColumnName("banco_id")
                    .HasColumnType("char(36)")
                    .IsRequired();

                entity.Property(e => e.CategoriaId)
                    .HasColumnName("categoria_id")
                    .HasColumnType("char(36)")
                    .IsRequired();

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(255);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();

                entity.Property(e => e.DataLancamento)
                    .HasColumnName("data_lancamento")
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasConversion<string>()
                    .HasMaxLength(1)
                    .IsRequired();

                entity.Property(e => e.CriadoEm)
                    .HasColumnName("criado_em")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .IsRequired();

                entity.HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey(e => e.UsuarioId);

                entity.HasOne<Banco>()
                    .WithMany()
                    .HasForeignKey(e => e.BancoId);

                entity.HasOne<Categoria>()
                    .WithMany()
                    .HasForeignKey(e => e.CategoriaId);
            });

        }
    }
}
