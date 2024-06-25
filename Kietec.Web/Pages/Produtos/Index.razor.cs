using Kietec.Core.Handlers;
using Kietec.Core.Models;
using Kietec.Core.Requests.ProdutoRequest;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Kietec.Web.Pages.Produtos
{
    public partial class IndexProdutoPage : ComponentBase
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
    }
}
