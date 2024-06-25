namespace Kietec.Api.Common.Api;

//Essa classe serve para padronizar os Endpoints da API
public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}