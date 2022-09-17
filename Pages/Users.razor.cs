using Blazorise.DataGrid;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Dispatcher?.Dispatch(new LanguagesFetchDataAction(LocalStorage));

            ReadLocalSettings();

            Dispatcher?.Dispatch(
                new UsersFetchDataAction(
                    token: _token,
                    searchPageNr: 1,
                    itemsPerPage: _itemsPerPage,
                    MyText?.Loaded ?? string.Empty));
        }


        private void OnRowInserted(SavedRowItem<User, Dictionary<string, object>> e)
        {
            var user = e.Item;

            if (user is null) return;

            try
            {
                user.UserName = Convert.ToString(e.Values["UserName"]) ?? user.UserName;
                user.FirstName = Convert.ToString(e.Values["FirstName"]) ?? user.FirstName;
                user.LastName = Convert.ToString(e.Values["LastName"]) ?? user.LastName;
                user.Email = Convert.ToString(e.Values["Email"]) ?? user.Email;
            }
            catch { }

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

            Dispatcher?.Dispatch(
                new UsersAddAction(
                    user: userAdd,
                    token: _token,
                    MyText?.AddedUser ?? string.Empty));
        }

        private void OnRowUpdated(SavedRowItem<User, Dictionary<string, object>> e)
        {
            var user = e.Item;

            if (user is null) return;

            try
            {
                user.UserName = Convert.ToString(e.Values["UserName"]) ?? user.UserName;
                user.FirstName = Convert.ToString(e.Values["FirstName"]) ?? user.FirstName;
                user.LastName = Convert.ToString(e.Values["LastName"]) ?? user.LastName;
                user.Email = Convert.ToString(e.Values["Email"]) ?? user.Email;

                user.IsSuperuser = Convert.ToBoolean(e.Values["IsSuperuser"]);
                user.Assistant = Convert.ToBoolean(e.Values["Assistant"]);

                var corLang = (List<int>)e.Values["CoordinatingLanguages"];
                var tranLang = (List<int>)e.Values["TranslatingLanguages"];
                user.CoordinatingLanguages = corLang ?? user.CoordinatingLanguages;
                user.TranslatingLanguages = tranLang ?? user.TranslatingLanguages;

                //user.CoordinatingLanguages = Convert.ToBoolean(e.Values["Assistant"]);
            }
            catch
            {
                return;
            }



            _selectedUser = user;

            if (MyText is null) return;

            ReadLocalSettings();

            Dispatcher?.Dispatch(
                new UsersUpdateAction(
                    userId: user.Id,
                    user: user,
                    token: _token,
                    MyText?.Updated ?? string.Empty));
        }


        private void OnRowRemoved(User user)
        {
            _selectedUser = user;

            if (_selectedUser is null) return;
            ReadLocalSettings();

            if (_selectedUser != null)
                Dispatcher?.Dispatch(
                    new UsersDeleteAction(
                        userId: _selectedUser.Id,
                        token: _token,
                        userDeleteMessage: MyText?.Deleted ?? string.Empty));
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

            Dispatcher?.Dispatch(
                new UsersFetchDataAction(
                    token: _token,
                    searchPageNr: e.Page,
                    itemsPerPage: _itemsPerPage,
                    MyText?.Loaded ?? string.Empty));
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