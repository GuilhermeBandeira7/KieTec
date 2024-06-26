using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.FornecedorRequest;
using Kietec.Core.Requests.ProdutoRequest;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Kietec.Web.Pages.Fornecedores;
public partial class GetAllFornecedoresPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Fornecedor> Fornecedores { get; set; } = [];

    #endregion

    #region Services

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    public IFornecedorHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new ReadFornecedorRequest();
            var result = await Handler.ReadAsync(request);
            if (result.IsSuccess)
                Fornecedores = result.Data ?? [];
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
            $"Ao prosseguir o fornecedor {nome} será removido. Deseja continuar?",
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
            var request = new DeleteFornecedorRequest()
            {
                Id = id
            };
            await Handler.DeleteAsync(request);
            Fornecedores.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Fornecedor {nome} removido", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    public async void OnEditAsync(int id, Fornecedor fornecedor)
    {
        try
        {
            var request = new EditFornecedorRequest()
            {
                Id = id,
                Nome = fornecedor.Nome,
                Telefone = fornecedor.Telefone
            };
            var response = await Handler.EditAsync(request);
            if (response.IsSuccess)
                Snackbar.Add($"Fornedor {fornecedor.Nome} alterado", Severity.Info);
            else
                Snackbar.Add($"Falha ao alterar o fornecedor", Severity.Error);

        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}