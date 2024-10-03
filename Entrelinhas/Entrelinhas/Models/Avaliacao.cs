namespace Entrelinhas.Models
{
    public class Avaliacao
    {
        public Guid AvaliacaoId { get; set; }
        public long UsuariosId { get; set; }
        public string? GoogleBooksId { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }

        // Navigation property
        public Usuario? Usuario { get; set; }
    }
}
