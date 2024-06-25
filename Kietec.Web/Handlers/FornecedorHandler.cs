using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Responses;
using System.Net.Http.Json;

namespace Kietec.Web.Handlers
{
    public class FornecedorHandler(IHttpClientFactory httpClientFactory) : IFornecedorHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<Response<Fornecedor?>> CreateAsync(CreateFornecedorRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/fornecedores", request);
            return await result.Content.ReadFromJsonAsync<Response<Fornecedor?>>()
                ?? new Response<Fornecedor?>(null, 400, "Falha ao criar fornecedor");
        }

        public async Task<Response<Fornecedor?>> DeleteAsync(DeleteFornecedorRequest request)
        {
            var result = await _client.DeleteAsync($"v1/fornecedores/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Fornecedor?>>()
                   ?? new Response<Fornecedor?>(null, 400, "Falha ao excluir fornecedor");
        }

        public async Task<Response<Fornecedor?>> EditAsync(EditFornecedorRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/fornecedores/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Fornecedor?>>()
                   ?? new Response<Fornecedor?>(null, 400, "Falha ao atualizar fornecedor");
        }

        public async Task<PagedResponse<List<Fornecedor>?>> ReadAsync(ReadFornecedorRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Fornecedor>?>>("v1/fornecedores")
           ?? new PagedResponse<List<Fornecedor>?>(null, 400, "Não foi possível obter os fornecedores");
    }
}
