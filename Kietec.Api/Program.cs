using Kietec.Api;
using Kietec.Api.Common.Api;
using Kietec.Api.Data;
using Kietec.Api.Endpoint;
using Kietec.Api.Handlers;
using Kietec.Core.Handlers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Extension methods abaixo foram criados para resolver todas as dependências
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();
