namespace Entrelinhas.Models
{
    public class Carrinho
    {
        public Guid CarrinhoId { get; set; }
        public string NumeroPedido { get; set; }
        public int TotalPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public string Cupom { get; set; }

    }
}
