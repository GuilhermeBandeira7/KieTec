using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Kietec.Web.Pages.Produtos;

public partial class GetAllProdutosPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Produto> Produtos { get; set; } = [];

    #endregion

    #region Services

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    public IProdutoHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new IndexProdutoRequest();
            var result = await Handler.IndexAsync(request);
            if (result.IsSuccess)
                Produtos = result.Data ?? [];
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

    #endregion
    
    public async void OnDeleteButtonClickedAsync(int id, string nome)
    {
        var result = await Dialog.ShowMessageBox(
            "ATENÇÃO",
            $"Ao prosseguir o produto {nome} será removido. Deseja continuar?",
            yesText: "Excluir",
            cancelText: "Cancelar");

        if (result is true)
            await OnDeleteAsync(id, nome);

        StateHasChanged();
    }

    public async Task OnDeleteAsync(int id, string nome)
    {
        try
        {
            var request = new DeleteProdutoRequest()
            {
                Id = id
            };
            await Handler.DeleteAsync(request);
            Produtos.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Produto {nome} removido", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}