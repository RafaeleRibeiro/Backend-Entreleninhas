using Entrelinhas.Models;
using Microsoft.EntityFrameworkCore;

namespace Entrelinhas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Entrelinhas.Models.Autor> Autor { get; set; } = default!;
        public DbSet<Entrelinhas.Models.Avaliacao> Avaliacao { get; set; } = default!;
        public DbSet<Entrelinhas.Models.Doacao> Doacao { get; set; } = default!;
        public DbSet<Entrelinhas.Models.Livro> Livro { get; set; } = default!;
        public DbSet<Entrelinhas.Models.Participacao> Participacao { get; set; } = default!;
        public DbSet<Entrelinhas.Models.Usuario> Usuario { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Livro>().ToTable("Livros");
            modelBuilder.Entity<Autor>().ToTable("Autores");
            modelBuilder.Entity<Avaliacao>().ToTable("Avaliacoes");
            modelBuilder.Entity<Doacao>().ToTable("Doacoes");
            modelBuilder.Entity<Evento>().ToTable("Eventos");
            modelBuilder.Entity<Participacao>().ToTable("Participacao");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Carrinho>().ToTable("Carrinho");
            modelBuilder.Entity<ItensCarrinho>().ToTable("ItensCarrinho");

        }
        public DbSet<Entrelinhas.Models.Carrinho> Carrinho { get; set; } = default!;
        public DbSet<Entrelinhas.Models.ItensCarrinho> ItensCarrinho { get; set; } = default!;




    }
}
