using Entrelinhas.Models;

namespace Entrelinhas.Models
{
    public class Avaliacao
    {
        public Guid AvaliacaoId { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; }

        // Foreign keys
        public Guid UsuarioId { get; set; }
        public Guid LivroId { get; set; }

        // Navigation properties
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
    }
}