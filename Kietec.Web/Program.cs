using Kietec.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Kietec.Web;
using MudBlazor.Services;
using Kietec.Core.Handlers;
using Kietec.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Using MudBlazor services 
builder.Services.AddMudServices();

//Configurando comunicação com a API
builder.Services.AddHttpClient(WebConfiguration.HttpClientName, ops =>
{
    ops.BaseAddress = new Uri(Configuration.BackendUrl);
});

builder.Services.AddTransient<IProdutoHandler, ProdutoHandler>();
builder.Services.AddTransient<IFornecedorHandler, FornecedorHandler>();

await builder.Build().RunAsync();
