using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Core.Handlers;

//Este handler define a implementação dos padrões de requisião e resposta
public interface IFornecedorHandler
{
    Task<Response<Fornecedor?>> CreateAsync(CreateFornecedorRequest request);
    Task<Response<Fornecedor?>> DeleteAsync(DeleteFornecedorRequest request);
    Task<Response<Fornecedor?>> EditAsync(EditFornecedorRequest request);
    Task<PagedResponse<List<Fornecedor>?>> ReadAsync(ReadFornecedorRequest request);
}