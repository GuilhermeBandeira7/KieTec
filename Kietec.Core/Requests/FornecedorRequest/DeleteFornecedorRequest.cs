using System.ComponentModel.DataAnnotations;

namespace Kietec.Core.Requests.FornecedorRequest;

public class DeleteFornecedorRequest : Request
{
    [Required(ErrorMessage = "É necessário informar o Id do Fornecedor")]
    public int Id { get; set; }
}