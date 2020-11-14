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
        private RootObject<User>? _localData;
        private bool _reloadData = true;
        private string _token = string.Empty;
        private int _totalUsers;
        private List<User>? _usersList;
        private User? _selectedUser;

        [Inject] private IDispatcher? Dispatcher { get; set; }

        [Inject] private IState<UsersState>? UsersState { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }

        public Users(RootObject<User>? localData) : base()
        {
            _localData = localData;
        }

        private string GetLanguageName(int langId) => (LanguagesState?.Value.GetLanguageName(langId) ?? string.Empty);

        public Users(Toolbelt.Blazor.I18nText.I18nText i18NText,
           ISyncLocalStorageService localStorage, RootObject<User>? localData) : this(localData)
        {
            I18NText = i18NText ?? throw new ArgumentNullException(nameof(i18NText));
            LocalStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            ReadLocalSettings();

            if (UsersState is null) return;
            UsersState.StateChanged += UsersState_StateChanged;
        }

        private void UsersState_StateChanged(object sender, UsersState e)
        {

            switch (e.LastActionState)
            {
                
                case EActionState.Deleted:
                    if (!(e.DeleteResponse is null))
                    {
                        if (e.DeleteResponse.Deleted)
                        {
                            ShowAlert(MyText?.youWhereDeleted ?? string.Empty);
                            _reloadData = true;
                        }
                        else
                        {
                            ShowAlert(MyText?.userDeletionError ?? $"error! {e.DeleteResponse.Detail}");
                        }
                    }
                    break;
                case EActionState.Added:
                    if (!(MyText is null))
                    {
                        if (e.User is null)
                        {
                            ShowAlert(MyText.dataSavedNOk);
                        }
                        else
                        {
                            ShowAlert(MyText.dataSavedOk);
                            _reloadData = true;
                        }
                    }

                    if (!string.IsNullOrEmpty(e.StatusCode))
                            ShowAlert(e.StatusCode);

                    break;
                case EActionState.Updated:
                    if (!(MyText is null))
                    {
                        if (e.User is null)
                        {
                            ShowAlert(MyText.dataSavedNOk);
                        }
                        else
                        {
                            ShowAlert(MyText.dataSavedOk);
                            _reloadData = true;
                        }
                    }
                    break;
                case EActionState.FetchedData:
                    _reloadData = false;

                    if (!(MyText is null))
                        ShowAlert($"{MyText.loaded}");
                    
                    break;
                
            }

            UpdateLocalData();
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

        private void UpdateLocalData()
        {
            if (_localData is null) return;

            _usersList = _localData.Results;
            _totalUsers = (int)_localData.Count;
            // always call StateHasChanged!
            StateHasChanged();
        }
    }
}