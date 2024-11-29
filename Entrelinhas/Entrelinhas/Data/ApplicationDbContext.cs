using Entrelinhas.Models;
using Microsoft.EntityFrameworkCore;

namespace Entrelinhas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participacao> Participacoes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar GUID como chave primária
            modelBuilder.Entity<Usuario>().Property(u => u.UsuarioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Evento>().Property(e => e.EventoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Participacao>().Property(p => p.ParticipacaoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Venda>().Property(v => v.VendaId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Avaliacao>().Property(a => a.AvaliacaoId).HasDefaultValueSql("NEWID()");
        }

    }
}
