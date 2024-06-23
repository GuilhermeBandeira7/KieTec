using System.ComponentModel.DataAnnotations;

namespace Kietec.Core.Requests.ProdutoRequest;

public class AddSupplierRequest : Request
{
    [Required(ErrorMessage = "É necessário informar o Id do Produto")]
    //Id do produto
    public int Id { get; set; }
    [Required(ErrorMessage = "É necessário informar o Id do Fornecedor")]
    public int FornecedorId { get; set; }
    
}