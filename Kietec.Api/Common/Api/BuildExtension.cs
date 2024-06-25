using Kietec.Api.Data;
using Kietec.Api.Handlers;
using Kietec.Core;
using Kietec.Core.Handlers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Kietec.Api.Common.Api;

public static class BuildExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }
    
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
    
    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<AppDbContext>(
                x =>
                {
                    x.UseSqlite("Data Source=kietec.db");
                });
    }
    
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }
    
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => 
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder
            .Services
            .AddTransient<IProdutoHandler, ProdutoHandler>();

        builder
            .Services
            .AddTransient<IFornecedorHandler, FornecedorHandler>();
    }
}