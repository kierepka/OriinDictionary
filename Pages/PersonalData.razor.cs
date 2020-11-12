using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Fluxor;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    public partial class PersonalData : DicBasePage
    {
        private List<Language> _coordinatingLanguages = new List<Language>();


        private string _languageSet = string.Empty;
        private List<Language> _translatingLanguages = new List<Language>();
        public User _user { get; set; } = new User();
        public bool isSuperUser { get; set; } = false;

        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private IState<UsersState>? UserState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }

        [Inject] private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        public PersonalData() : base()
        {
        }



        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();


            if (LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

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

            if (!(UserState is null)) UserState.StateChanged += UserState_StateChanged;
        }

        private void UserState_StateChanged(object sender, UsersState e)
        {
            if (MyText is null) return;

            switch (e.LastActionState)
            {
                case EActionState.Anonymized:
                    ShowAlert(MyText.anonimized);
                    break;
                case EActionState.Updated:
                    ShowAlert(MyText.updated);
                    break;
            }


            if (!string.IsNullOrEmpty(UserState!.Value.StatusCode))
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
            if (LanguagesState is null) return;

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

        private void HandleAnonymize()
        {
            if (LocalStorage is null) return;
            if (MyText is null) return;

            try
            {
                var token = LocalStorage.GetItem<Token>(Const.TokenKey);
                Dispatcher?.Dispatch(new UsersAnonymizeAction(_user, token.AuthToken));
            }
            catch
            {
                ShowAlert(MyText.dataSavedNOk);
            }

        }


        private void HandleSave()
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


                Dispatcher?.Dispatch(new UsersUpdateAction(_user, token.AuthToken));

            }
            catch
            {
                ShowAlert(MyText.dataSavedNOk);
            }

        }
    }
}