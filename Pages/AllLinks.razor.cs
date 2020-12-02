using System.Threading.Tasks;

using Blazorise.DataGrid;

using Fluxor;

using Microsoft.AspNetCore.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Links;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class AllLinks
    {

        private long _itemsPerPage = Const.DefaultItemsPerPage;
        private string _token = string.Empty;
        private OriinLink? _selectedOriinLink;

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LinksState>? LinksState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksFetchDataAction(0,0));
            StateHasChanged();
        }

        private void OnRowRemoved(OriinLink oriinLink)
        {
            _selectedOriinLink = oriinLink;
            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksDeleteAction(oriinLink.Id, _token ));

            StateHasChanged();
        }


        private void OnReadData(DataGridReadDataEventArgs<OriinLink> e)
        {

            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksFetchDataAction(searchPageNr: e.Page, _itemsPerPage));

            StateHasChanged();
        }

        private void ReadLocalSettings()
        {
            if (LocalStorage is null) return;
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);
            _token = token.AuthToken;

            int? itemsPerPage = LocalStorage.GetItem<int>(Const.ItemsPerPageKey);
            _itemsPerPage = itemsPerPage.Value;
            if (_itemsPerPage == 0) _itemsPerPage = Const.DefaultItemsPerPage;
        }

    }
}