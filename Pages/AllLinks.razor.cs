using System.Threading.Tasks;

using Blazorise.DataGrid;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Links;

namespace OriinDic.Pages
{
    public partial class AllLinks : DicBasePage
    {

        private long _itemsPerPage = Const.DefaultItemsPerPage;
        private string _token = string.Empty;
        private OriinLink? selectedOriinLink;

        [Inject] private IState<LinksState>? LinksState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }

        public AllLinks()
        {
        }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksFetchDataAction(token: _token));
            StateHasChanged();
        }

        private void OnRowRemoved(OriinLink oriinLink)
        {
            selectedOriinLink = oriinLink;
            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksDeleteAction(oriinLink.Id, _token ));

            StateHasChanged();
        }


        private void OnReadData(DataGridReadDataEventArgs<OriinLink> e)
        {

            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksFetchDataAction(_token, searchPageNr: e.Page, _itemsPerPage));

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