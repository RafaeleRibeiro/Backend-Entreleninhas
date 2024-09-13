namespace Entrelinhas.Models
{
    public class ItensCarrinho
    {
        public Guid ItensCarrinhoId { get; set; }
        public Guid CarrinhoId { get; set; }
        public Carrinho? Carrinho { get; set; }
        public Guid LivroId { get; set; }
        public Livro? Livro { get; set; }
        public int QtadeLivro { get; set; }
        public decimal TotalItem { get; set; }

    }
}
