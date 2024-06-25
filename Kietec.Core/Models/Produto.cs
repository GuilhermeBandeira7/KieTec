namespace Kietec.Core.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal? Preco { get; set; }
    
    public int FornecedorId { get; set; }
    //Essa propriedade serve para carregar as informações do fornecedor
    public Fornecedor? Fornecedor { get; set; }
    
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    //A prop UserId faz referência ao usuário que for manipular um produto
    public string UserId { get; set; } = string.Empty;
}