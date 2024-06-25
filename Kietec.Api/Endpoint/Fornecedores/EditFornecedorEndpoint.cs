using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Fornecedores;

public class EditFornecedorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Fornecedores: Update")
            .WithSummary("Atualiza um fornecedor")
            .WithDescription("Atualiza um fornecedor")
            .WithOrder(3)
            .Produces<Response<Fornecedor?>>();

    private static async Task<IResult> HandleAsync(
        IFornecedorHandler handler,
        EditFornecedorRequest request,
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