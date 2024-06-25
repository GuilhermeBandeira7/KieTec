using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Produtos;

public class DeleteProdutoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Produtos: Delete")
            .WithSummary("Exclui um produto")
            .WithDescription("Exclui um produto")
            .WithOrder(3)
            .Produces<Response<Produto?>>();

    private static async Task<IResult> HandleAsync(
        IProdutoHandler handler,
        int id)
    {
        var request = new DeleteProdutoRequest()
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}