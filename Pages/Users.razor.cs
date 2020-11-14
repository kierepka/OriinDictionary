using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using Blazorise.DataGrid;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    public partial class Users : DicBasePage
    {

        private long _itemsPerPage = Const.DefaultItemsPerPage;
        private bool _reloadData = true;
        private string _token = string.Empty;

        private User? _selectedUser;

        [Inject] private IDispatcher? Dispatcher { get; set; }

        [Inject] private IState<UsersState>? UsersState { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }

        public Users() : base()
        {

        }

        private string GetLanguageName(int langId) => (LanguagesState?.Value.GetLanguageName(langId) ?? string.Empty);


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            ReadLocalSettings();

            Dispatcher?.Dispatch(new UsersFetchDataAction(_token, searchPageNr: 1, _itemsPerPage));

        }


        void OnRowInserted(SavedRowItem<User, Dictionary<string, object>> e)
        {
            var user = e.Item;

            if (user is null) return;

            _selectedUser = user;

            if (MyText is null) return;

            ReadLocalSettings();
            var userAdd = new UserAdd
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = Func.CreatePassword(12, Func.EnumPasswordOptions.All)
            };

            Dispatcher?.Dispatch(new UsersAddAction(userAdd, _token));

        }

        void OnRowUpdated(SavedRowItem<User, Dictionary<string, object>> e)
        {
            var user = e.Item;
            if (user is null) return;

            _selectedUser = user;

            if (MyText is null) return;

            ReadLocalSettings();

            Dispatcher?.Dispatch(new UsersUpdateAction(user, _token));

        }

        void OnRowRemoved(User user)
        {
            _selectedUser = user;

            if (_selectedUser is null) return;
            ReadLocalSettings();

            if (_selectedUser != null) Dispatcher?.Dispatch(new UsersDeleteAction(_selectedUser.Id, _token));
        }



        void OnReadData(DataGridReadDataEventArgs<User> e)
        {
            if (!_reloadData) return;
            ReadLocalSettings();

            Dispatcher?.Dispatch(new UsersFetchDataAction(_token, searchPageNr: e.Page, _itemsPerPage));

        }

        private void ReadLocalSettings()
        {
            if (LocalStorage is null) return;

            Token? token = LocalStorage.GetItem<Token>(Const.TokenKey);
            _token = token.AuthToken;

            int? itemsPerPage = LocalStorage.GetItem<int>(Const.ItemsPerPageKey);
            _itemsPerPage = itemsPerPage.Value;
            if (_itemsPerPage == 0) _itemsPerPage = Const.DefaultItemsPerPage;


        }

    }
}