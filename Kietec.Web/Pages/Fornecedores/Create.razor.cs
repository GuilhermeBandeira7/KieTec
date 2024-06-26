using Kietec.Core.Handlers;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Requests.ProdutoRequest;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Kietec.Web.Pages.Fornecedores;

public partial class CreateFornecedorPage : ComponentBase
{
    public bool IsBusy { get; set; } = false;
    public CreateFornecedorRequest InputModel { get; set; } = new();
    
    
    [Inject] 
    public IFornecedorHandler Handler { get; set; } = null!;

    [Inject] 
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {

            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/fornecedores");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
}