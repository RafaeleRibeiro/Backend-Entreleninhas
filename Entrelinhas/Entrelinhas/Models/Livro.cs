using Entrelinhas.Models;

namespace Entrelinhas.Models
{
    public class Livro
    {
        public Guid LivroId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Nacional { get; set; }

        // Foreign key
        public Guid AutorId { get; set; }

        // Navigation properties
        public Autor Autor { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; }
        public ICollection<Doacao> Doacoes { get; set; }
    }
}