using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazorise.DataGrid;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Users
    {

        private long _itemsPerPage = Const.DefaultItemsPerPage;
        private bool _reloadData = true;
        private string _token = string.Empty;

        private User? _selectedUser;

        private DataGrid<User>? UsersGrid { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<UsersState>? UsersState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }

        private string GetLanguageName(int langId) => LanguagesState?.Value.GetLanguageName(langId) ?? string.Empty;


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            ReadLocalSettings();

            Dispatcher?.Dispatch(new UsersFetchDataAction(_token, searchPageNr: 1, _itemsPerPage));

        }


        private void OnRowInserted(SavedRowItem<User, Dictionary<string, object>> e)
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

        private void OnRowUpdated(SavedRowItem<User, Dictionary<string, object>> e)
        {
            var user = e.Item;
            if (user is null) return;

            _selectedUser = user;

            if (MyText is null) return;

            ReadLocalSettings();

            Dispatcher?.Dispatch(new UsersUpdateAction(user.Id, user, _token));

        }


        private void OnRowRemoved(User user)
        {
            _selectedUser = user;

            if (_selectedUser is null) return;
            ReadLocalSettings();

            if (_selectedUser != null) Dispatcher?.Dispatch(new UsersDeleteAction(_selectedUser.Id, _token));
        }

        private void OnTransLangStatusChanged(SelectableLanguage selectableLanguage)
        {
            if (_selectedUser is null) return;
            if (selectableLanguage.Selected)
            {
                if (_selectedUser.TranslatingLanguages.Contains((int)selectableLanguage.Id))
                    return;

                _selectedUser.TranslatingLanguages.Add((int)selectableLanguage.Id);
            }
            else
            {
                if (_selectedUser.TranslatingLanguages.Contains((int)selectableLanguage.Id))
                    _selectedUser.TranslatingLanguages.Remove((int)selectableLanguage.Id);
            }

            StateHasChanged();
        }

        private void OnCoordLangStatusChanged(SelectableLanguage selectableLanguage)
        {
            if (_selectedUser is null) return;


            if (selectableLanguage.Selected)
            {
                if (_selectedUser.CoordinatingLanguages.Contains((int)selectableLanguage.Id))
                    return;
                _selectedUser.CoordinatingLanguages.Add((int)selectableLanguage.Id);
            }
            else
            {
                if (_selectedUser.CoordinatingLanguages.Contains((int)selectableLanguage.Id))
                    _selectedUser.CoordinatingLanguages.Remove((int)selectableLanguage.Id);
            }

            StateHasChanged();
        }

        private void OnReadData(DataGridReadDataEventArgs<User> e)
        {
            if (!_reloadData) return;
            ReadLocalSettings();

            Dispatcher?.Dispatch(new UsersFetchDataAction(_token, searchPageNr: e.Page, _itemsPerPage));

        }

        private void ReadLocalSettings()
        {
            if (LocalStorage is null) return;

            if (string.IsNullOrEmpty(_token))
            {
                var token = LocalStorage.GetItem<Token>(Const.TokenKey);
                _token = token.AuthToken;
            }

            if (_itemsPerPage != 0) return;
            int? itemsPerPage = LocalStorage.GetItem<int>(Const.ItemsPerPageKey);
            _itemsPerPage = itemsPerPage.Value;
            if (_itemsPerPage == 0) _itemsPerPage = Const.DefaultItemsPerPage;


        }


        private async Task OnEdit(CommandContext<User> context)
        {
            _selectedUser = context.Item;
            await context.Clicked.InvokeAsync();
        }
    }
}