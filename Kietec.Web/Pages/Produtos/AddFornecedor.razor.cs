using Kietec.Core.Handlers;
using Kietec.Core.Requests.ProdutoRequest;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Kietec.Web.Pages.Produtos;

public partial class AddFornecedorPage : ComponentBase
{
    public bool IsBusy { get; set; } = false;
    public AddSupplierRequest AddSupplierModel { get; set; } = new();

    [Inject] 
    public IProdutoHandler Handler { get; set; } = null!;

    [Inject] //Injecting use of C# to navigate 
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    
    public async Task OnValidAddSupplierSubmitAsync()
    {
        IsBusy = true;

        try
        {

            var result = await Handler.AddSuppierAsync(AddSupplierModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/produtos");
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