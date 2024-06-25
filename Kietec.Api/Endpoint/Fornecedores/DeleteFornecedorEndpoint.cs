using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Fornecedores;

public class DeleteFornecedorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Fornecedor: Delete")
            .WithSummary("Exclui um fornecedor")
            .WithDescription("Exclui um fornecedor")
            .WithOrder(2)
            .Produces<Response<Fornecedor?>>();
    
    private static async Task<IResult> HandleAsync(
        IFornecedorHandler handler,
        int id)
    {
        var request = new DeleteFornecedorRequest()
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