using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Fornecedores;

public class CreateFornecedorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Fornecedor: Create")
            .WithSummary("Cria um novo fornecedor")
            .WithDescription("Cria um novo fornecedor")
            .WithOrder(1)
            .Produces<Response<Fornecedor?>>();
    
    private static async Task<IResult> HandleAsync(
        IFornecedorHandler handler,
        CreateFornecedorRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSuccess
            //Typed results retorna uma resposta tipada
            ? TypedResults.Created($"v1/fornecedores/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}