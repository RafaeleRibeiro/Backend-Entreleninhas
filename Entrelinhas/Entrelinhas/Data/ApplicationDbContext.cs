using Entrelinhas.Models;
using Microsoft.EntityFrameworkCore;

namespace Entrelinhas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participacao> Participacoes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais podem ser feitas aqui, se necessário
        }



    }
}
