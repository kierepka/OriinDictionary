using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Services;
using OriinDic.Store;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    public partial class PersonalData : DicBasePage
    {
        private List<Language> _coordinatingLanguages = new List<Language>();
        private string _currentAlert = string.Empty;

        private string _languageSet = string.Empty;
        private List<Language> _translatingLanguages = new List<Language>();
        public User _user { get; set; } = new User();
        public bool isSuperUser { get; set; }

        [Inject] private IState<LanguagesState> LanguagesState { get; set; }
        [Inject] private IState<UsersState> UserState { get; set; }
        [Inject] private IDispatcher Dispatcher { get; set; }

        public PersonalData() : base()
        {
        }


        public PersonalData(ISyncLocalStorageService localStorage,
            Toolbelt.Blazor.I18nText.I18nText i18NText,
            IAuthService authService,
            NavigationManager navigationManager,
            AuthenticationStateProvider authenticationStateProvider
        ) : this()
        {
            LocalStorage = localStorage;
            I18NText = i18NText;
            AuthService = authService;
            NavigationManager = navigationManager;
            AuthenticationStateProvider = authenticationStateProvider;
        }

        [Inject] private IAuthService? AuthService { get; set; }
        [Inject] private NavigationManager? NavigationManager { get; set; }
        [Inject] private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (!LanguagesState.Value.Languages.Any())
                Dispatcher.Dispatch(new LanguagesFetchDataAction());

            if (!(LocalStorage is null))
            {
                _user = LocalStorage.GetItem<User>(Const.UserKey);
            }

            if (!(_user is null))
                LoadUserData(_user);


            if (!(AuthenticationStateProvider is null))
            {
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                isSuperUser = (user.IsInRole(Const.RoleSuperUser));
            }

            UserState.StateChanged += UserState_StateChanged;
        }

        private void UserState_StateChanged(object sender, UsersState e)
        {

            switch (e.LastActionState)
            {
                case EActionState.Anonymized:
                    ShowAlert(MyText?.anonimized);
                    break;
                case EActionState.Updated:
                    ShowAlert(MyText?.updated);
                    break;
            }


            if (!string.IsNullOrEmpty(UserState.Value.StatusCode))
                ShowAlert(UserState.Value.StatusCode);
            if (UserState.Value.User != null) _user = UserState.Value.User;

            if (_user == null) return;
            LoadUserData(_user);
            LocalStorage?.SetItem(Const.UserKey, _user);
        }

        private void LoadUserData(User user)
        {

            if (LocalStorage is null) return;
            if (MyText is null) return;

            _languageSet = user.LanguageId.HasValue ? LanguagesState.Value.GetLanguageName(user.LanguageId.Value) : MyText.noData;

            _translatingLanguages = new List<Language>();
            _coordinatingLanguages = new List<Language>();
            foreach (var lt in user.TranslatingLanguages)
            {
                var lang = LanguagesState.Value.GetLanguage(lt);
                if (!(lang is null))
                    _translatingLanguages.Add(item: lang);
            }
            foreach (var lt in user.CoordinatingLanguages)
            {
                var lang = LanguagesState.Value.GetLanguage(lt);
                if (!(lang is null))
                    _coordinatingLanguages.Add(item: lang);
            }
        }

        private bool CheckTranslation(Language lang)
        {
            return _translatingLanguages.Contains(lang);
        }

        private bool CheckCoordination(Language lang)
        {
            return _coordinatingLanguages.Contains(lang);
        }

        private async Task HandleAnonymize()
        {
            if (LocalStorage is null) return;
            if (MyText is null) return;

            try
            {
                var token = LocalStorage.GetItem<Token>(Const.TokenKey);
                Dispatcher.Dispatch(new UsersAnonymizeAction(_user, token.AuthToken));
            }
            catch
            {
                ShowAlert(MyText.dataSavedNOk);
            }
            
        }


        private async Task HandleSave()
        {
            if (LocalStorage is null) return;
            
            if (MyText is null) return;

            try
            {
            
                var token = LocalStorage.GetItem<Token>(Const.TokenKey);

                var uu = new UserUpdate
                {
                    UserName = _user.UserName,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Email = _user.Email,
                    Gender = _user.Gender
                };
                if (_user.LanguageId.HasValue) uu.LanguageId = _user.LanguageId.Value;


                Dispatcher.Dispatch(new UsersUpdateAction(_user, token.AuthToken));

            }
            catch
            {
                ShowAlert(MyText.dataSavedNOk);
            }
            
        }
    }
}