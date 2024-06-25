using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Produtos;

public class AddSupplierEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}/{supplierId}", HandleAsync)
            .WithName("Produtos: AddSupplier")
            .WithSummary("Adiciona um fornecedor ao produto")
            .WithDescription("Adiciona um fornecedor ao produto")
            .WithOrder(6)
            .Produces<Response<Produto?>>();
    
    private static async Task<IResult> HandleAsync(
        IProdutoHandler handler,
        int id,
        int supplierId)
    {
        var request = new AddSupplierRequest()
        {
            UserId = ApiConfiguration.UserId,
            Id = id,
            FornecedorId = supplierId
        };
        
        var result = await handler.AddSuppierAsync(request);
        
        return result.IsSuccess
            //Typed results retorna uma resposta tipada
            ? TypedResults.Created($"v1/produtos/{result.Data?.Id}/{result.Data?.FornecedorId}", result)
            : TypedResults.BadRequest(request);
    }
}