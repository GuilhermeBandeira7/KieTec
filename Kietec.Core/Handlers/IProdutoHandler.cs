using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Core.Handlers;

//Este handler define a implementação dos padrões de requisião e resposta
public interface IProdutoHandler
{
    Task<Response<Produto?>> AddSuppierAsync(AddSupplierRequest request);
    Task<Response<Produto?>> CreateAsync(CreateProdutoRequest request);
    Task<Response<Produto?>> DeleteAsync(DeleteProdutoRequest request);
    Task<Response<Produto?>> DetailsAsync(DetailsProdutoRequest request);
    Task<Response<Produto?>> EditAsync(EditProdutoRequest request);
    Task<PagedResponse<List<Produto?>>> IndexAsync(IndexProdutoRequest request);
}