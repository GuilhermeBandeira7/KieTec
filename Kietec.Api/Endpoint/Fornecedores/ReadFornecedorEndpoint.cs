using Kietec.Api.Common.Api;
using Kietec.Core;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kietec.Api.Endpoint.Fornecedores;

public class ReadFornecedorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Fornecedores: Read")
            .WithSummary("Recupera todos os fornecedores")
            .WithDescription("Recupera todos os fornecedores")
            .WithOrder(4)
            .Produces<PagedResponse<List<Fornecedor>?>>();
    
    private static async Task<IResult> HandleAsync(
        IFornecedorHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new ReadFornecedorRequest()
        {
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.ReadAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}