using Kietec.Api.Common.Api;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;

namespace Kietec.Api.Endpoint.Produtos;

//Essa é a classe que mapeia o endpoint 
public class CreateProdutoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Produtos: Create")
            .WithSummary("Cria um novo produto")
            .WithDescription("Cria um novo produto")
            .WithOrder(1)
            .Produces<Response<Produto?>>();
    
    //Este método tem as dependências que estão resolvidas no Program.cs
    //e é responsável por lidar com a requisição e devolver uma resposta
    private static async Task<IResult> HandleAsync(
        IProdutoHandler handler,
        CreateProdutoRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSuccess
        //Typed results retorna uma resposta tipada
            ? TypedResults.Created($"v1/produtos/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}