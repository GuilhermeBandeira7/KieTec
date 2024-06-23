using System.ComponentModel.DataAnnotations;

namespace Kietec.Core.Requests.ProdutoRequest;

public class CreateProdutoRequest : Request
{
    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(80, ErrorMessage = "O Nome deve conter até 80 caracteres")]
    [MinLength(5, ErrorMessage = "O Nome deve conter no mínimo 5 caracteres")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Descrição inválida")]
    [MaxLength(120, ErrorMessage = "O Nome A descrição deve conter até 120 caracteres")]
    public string Descricao { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Preço inválido")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C0}")]
    public decimal? Preco { get; set; }
}