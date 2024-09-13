using Entrelinhas.Models;
using System;

namespace Entrelinhas.Models
{
    public class Doacao
    {
        public Guid DoacaoId { get; set; }
        public DateTimeOffset Data { get; set; }

        // Foreign keys
        public Guid UsuarioId { get; set; }
        public Guid LivroId { get; set; }

        // Navigation properties
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
    }
}