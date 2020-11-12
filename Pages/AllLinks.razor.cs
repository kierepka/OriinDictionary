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
        private bool _reloadData = true;
        private string _token = string.Empty;
        private int _totalOriinLinks;
        private OriinLink? selectedOriinLink;

        [Inject]
        private IState<LinksState>? LinksState { get; set; }

        [Inject]
        private IDispatcher? Dispatcher { get; set; }

        public AllLinks()
        {
        }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksFetchDataAction(token: _token));
        }

        private void OnRowRemoved(OriinLink oriinLink)
        {
            selectedOriinLink = oriinLink;

            ReadLocalSettings();

            Dispatcher?.Dispatch(new LinksDeleteAction(oriinLink.Id, _token));

            UpdateLocalData();
        }


        private void OnReadData(DataGridReadDataEventArgs<OriinLink> e)
        {

            if (!_reloadData) return;

            ReadLocalSettings();
            Dispatcher?.Dispatch(new LinksFetchDataAction(_token, searchPageNr: e.Page, _itemsPerPage));
            UpdateLocalData();
            _reloadData = false;


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

        private void UpdateLocalData()
        {
            if (LinksState?.Value is null) return;
            if (!(LinksState.Value.RootObject?.Results is null))
                _totalOriinLinks = LinksState.Value.RootObject.Results.Count;
            // always call StateHasChanged!
            StateHasChanged();
        }
    }
}