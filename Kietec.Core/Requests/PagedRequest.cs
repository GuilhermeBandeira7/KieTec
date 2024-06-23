namespace Kietec.Core.Requests;

//Essa é uma classe de paginação de requisições
public class PagedRequest : Request
{
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
}