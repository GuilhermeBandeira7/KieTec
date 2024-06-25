using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Produtos;

public class DetailProdutoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Produtos: Details")
            .WithSummary("Recupera detalhes de um produto")
            .WithDescription("Recupera detalhes de um produto")
            .WithOrder(5)
            .Produces<Response<string?>>();
    
    private static async Task<IResult> HandleAsync(
        IProdutoHandler handler,
        int id)
    {
        var request = new DetailsProdutoRequest()
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };
        
        var result = await handler.DetailsAsync(request);
        
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}