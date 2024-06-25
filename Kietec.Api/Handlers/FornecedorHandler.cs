using Kietec.Api.Data;
using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kietec.Api.Handlers;

public class FornecedorHandler(AppDbContext context) : IFornecedorHandler
{
    public async Task<Response<Fornecedor?>> CreateAsync(CreateFornecedorRequest request)
    {
        var fornecedor = new Fornecedor()
        {
            UserId = request.UserId,
            Nome = request.Nome,
            Telefone = request.Telefone
        };

        try
        {
            await context.Fornecedors.AddAsync(fornecedor);
            await context.SaveChangesAsync();
            
            return new Response<Fornecedor?>(fornecedor, 201, "Fornecedor criado com sucesso!");
        }
        catch 
        {
            return new Response<Fornecedor?>(null, 500, "Não foi possível criar fornecedor.");
        }
    }

    public async Task<Response<Fornecedor?>> DeleteAsync(DeleteFornecedorRequest request)
    {
        try
        {
            var fornecedor = await context
                .Fornecedors
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (fornecedor is null)
                return new Response<Fornecedor?>(null, 404, "Fornecedor não encontrado.");

            context.Fornecedors.Remove(fornecedor);
            await context.SaveChangesAsync();

            return new Response<Fornecedor?>(fornecedor, message: "Fornecedor excluído com sucesso!");
        }
        catch
        {
            return new Response<Fornecedor?>(null, 500, "Não foi possível excluir o fornecedor");
        }
    }

    public async Task<Response<Fornecedor?>> EditAsync(EditFornecedorRequest request)
    {
        try
        {
            var fornecedor = await context
                .Fornecedors
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (fornecedor is null)
                return new Response<Fornecedor?>(null, 404, "Fornecedor não encontrado.");

            fornecedor.Nome = request.Nome;
            fornecedor.Telefone = request.Telefone;

            context.Fornecedors.Update(fornecedor);
            await context.SaveChangesAsync();
            
            return new Response<Fornecedor?>(fornecedor, message: "Fornecedor editado com sucesso!");
        }
        catch
        {
            return new Response<Fornecedor?>(null, 500, "Não foi possível alterar o fornecedor");
        }
    }

    public async Task<PagedResponse<List<Fornecedor>?>> ReadAsync(ReadFornecedorRequest request)
    {
        try
        {
            var query = context
                .Fornecedors
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.Nome);
            
            var fornecedores = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            
            var count = await query.CountAsync();
            
            return new PagedResponse<List<Fornecedor>?>(
                fornecedores,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch 
        {
            return new PagedResponse<List<Fornecedor>?>(null, 500, "Não foi possível consultar os fornecedores.");
        }
    }
}