using Kietec.Api.Common.Api;
using Kietec.Core;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kietec.Api.Endpoint.Produtos;

public class IndexProdutoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Produtos: Index")
            .WithSummary("Recupera todos os produtos")
            .WithDescription("Recupera todos os produtos")
            .WithOrder(2)
            .Produces<PagedResponse<List<Produto>?>>();
    
    private static async Task<IResult> HandleAsync(
        IProdutoHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new IndexProdutoRequest()
        {
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.IndexAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}