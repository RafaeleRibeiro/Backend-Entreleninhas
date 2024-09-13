using System.Collections.Generic;

namespace Entrelinhas.Models
{
    public class Autor
    {
        public Guid AutorId { get; set; }
        public string Nome { get; set; }
        public string Biografia { get; set; }

        // Navigation property
        public ICollection<Livro> Livros { get; set; }
    }
}