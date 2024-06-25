using Kietec.Api.Common.Api;
using Kietec.Api.Endpoint.Fornecedores;
using Kietec.Api.Endpoint.Produtos;

namespace Kietec.Api.Endpoint;

public static class Endpoint 
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });
        
        endpoints.MapGroup("v1/produtos")
            .WithTags("Produtos")
            .MapEndpoint<CreateProdutoEndpoint>()
            .MapEndpoint<EditProdutoEndpoint>()
            .MapEndpoint<DeleteProdutoEndpoint>()
            .MapEndpoint<IndexProdutoEndpoint>()
            .MapEndpoint<DetailProdutoEndpoint>()
            .MapEndpoint<AddSupplierEndpoint>();

        endpoints.MapGroup("v1/fornecedores")
            .WithTags("Fornecedores")
            .RequireAuthorization()
            .MapEndpoint<CreateFornecedorEndpoint>()
            .MapEndpoint<DeleteFornecedorEndpoint>()
            .MapEndpoint<EditFornecedorEndpoint>()
            .MapEndpoint<ReadFornecedorEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}