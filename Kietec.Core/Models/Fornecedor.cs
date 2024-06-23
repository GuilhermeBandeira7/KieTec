namespace Kietec.Core.Models;

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Telefone { get; set; }
    //A propriedade UserId faz referência ao usuário que for manipular um fornecedor
    public string UserId { get; set; } = string.Empty;
}