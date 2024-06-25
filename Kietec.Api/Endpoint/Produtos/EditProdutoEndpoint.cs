using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Produtos;

public class EditProdutoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Produtos: Update")
            .WithSummary("Atualiza um produto")
            .WithDescription("Atualiza um produto")
            .WithOrder(4)
            .Produces<Response<Produto?>>();

    private static async Task<IResult> HandleAsync(
        IProdutoHandler handler,
        EditProdutoRequest request,
        int id)
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;

        var result = await handler.EditAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}