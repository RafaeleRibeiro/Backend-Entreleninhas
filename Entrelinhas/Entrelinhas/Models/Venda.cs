namespace Entrelinhas.Models
{
    public class Venda
    {
        public Guid VendaId { get; set; }
        public Guid UsuariosId { get; set; }
        public string? GoogleBooksId { get; set; }
        public string? Titulo { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTimeOffset Data { get; set; }

        // Navigation property
        public Usuario? Usuario { get; set; }
    }
}
