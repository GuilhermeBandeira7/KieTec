namespace Kietec.Core.Requests;

//Essa é uma classe base, padrão em todas as requisições.
public abstract class Request
{
    //Todas as requisições(de todos os tipos) para a API, terão, obrigatoriamente, o Id do usuário
    public string UserId { get; set; } = string.Empty;
}