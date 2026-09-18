using Microsoft.EntityFrameworkCore;
using IntrabankChallenge.Domain.Entities;

namespace IntrabankChallenge.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Isso diz ao EF Core para criar uma tabela chamada "Clientes" baseada na sua classe
        public DbSet<ClienteEmpresarial> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeamento e Regras das Colunas
            modelBuilder.Entity<ClienteEmpresarial>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RazaoSocial).IsRequired().HasMaxLength(150);
                entity.Property(e => e.NomeFantasia).HasMaxLength(150);
                entity.Property(e => e.Cnpj).IsRequired().HasMaxLength(14);
                entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18,2)");
            });
        }
    }
}
