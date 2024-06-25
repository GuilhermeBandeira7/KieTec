using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Kietec.Core.Responses;
using System.Net.Http.Json;

namespace Kietec.Web.Handlers
{
    public class ProdutoHandler(IHttpClientFactory httpClientFactory) : IProdutoHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Produto?>> AddSuppierAsync(AddSupplierRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/produtos/{request.Id}/{request.FornecedorId}", request);
            return await result.Content.ReadFromJsonAsync<Response<Produto?>>() //Lê um json e converte para uma Response<Produto?>
                   ?? new Response<Produto?>(null, 400, "Falha ao adicionar o produto a um fornecedor");
        }

        public async Task<Response<Produto?>> CreateAsync(CreateProdutoRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/produtos", request);
            return await result.Content.ReadFromJsonAsync<Response<Produto?>>()
                ?? new Response<Produto?>(null, 400, "Falha ao criar produto");
        }

        public async Task<Response<Produto?>> DeleteAsync(DeleteProdutoRequest request)
        {
            var result = await _client.DeleteAsync($"v1/produtos/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Produto?>>()
                   ?? new Response<Produto?>(null, 400, "Falha ao excluir a categoria");
        }

        public async Task<Response<Produto?>> DetailsAsync(DetailsProdutoRequest request)
            => await _client.GetFromJsonAsync<Response<Produto?>>($"v1/produtos/{request.Id}")
                ?? new Response<Produto?>(null, 400, "Não foi possível obter detahes do produto");

        public async Task<Response<Produto?>> EditAsync(EditProdutoRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/produtos/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Produto?>>()
                   ?? new Response<Produto?>(null, 400, "Falha ao atualizar a categoria");
        }

        public async Task<PagedResponse<List<Produto>?>> IndexAsync(IndexProdutoRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Produto>?>>($"v1/produtos")
                ?? new PagedResponse<List<Produto>?>(null, 400, "Não foi possível obter detahes do produto");
    }
}
