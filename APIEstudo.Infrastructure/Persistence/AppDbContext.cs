using APIEstudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }

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
        }
    }
}
