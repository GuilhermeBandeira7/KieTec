using System.Text.Json.Serialization;

namespace Kietec.Core.Responses;

//Classe genérica base para uma resposta
public abstract class Response<TData>
{
    private int _code = Configuration.DefaultStatusCode;
    
    [JsonConstructor] //Define este construtor como padrão para serialização
    public Response()
        => _code = Configuration.DefaultStatusCode;
    
    //Todas as respostas de requisições terão esse padrão ou apenas o status code
    public Response(
        TData? data,
        //Parâmetros opcionais
        int code = Configuration.DefaultStatusCode,
        string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }

    //TData pode assumir dois tipos: Produto e Fornecedor
    public TData? Data { get; set; }
    public string? Message { get; set; }
    
    
    [JsonIgnore] //Ignora a propriedade na serialização
    public bool IsSuccess => _code is >= 200 and <= 299;
}