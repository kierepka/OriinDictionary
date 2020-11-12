using System.Collections.Generic;
using System.Threading.Tasks;

using Fluxor;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    public partial class OriinUser : DicBasePage
    {

        [Inject] private IState<UsersState>? UserState { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }

        [Inject]  private IDispatcher? Dispatcher { get; set; }

        [Parameter] public long UserId { get; set; }

        [Inject] private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        private List<Language> _coordinatingLanguages = new List<Language>();

        private string _languageSet = string.Empty;
        private List<Language> _translatingLanguages = new List<Language>();

        public OriinUser()
        {
        }



        public User _user { get; set; } = new User();
        public bool IsSuperUser { get; set; }
   


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (LanguagesState is null)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            Token? token = null;

            if (!(LocalStorage is null))
            {
                token = LocalStorage.GetItem<Token>(Const.TokenKey);
            }

            if (token != null) Dispatcher?.Dispatch(new UsersFetchOneAction(UserId, token.AuthToken));



            if (!(_user is null)) LoadUserData(_user);


            if (!(AuthenticationStateProvider is null))
            {
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                IsSuperUser = user.IsInRole(Const.RoleSuperUser);
            }

        }

        private void LoadUserData(User user)
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (LanguagesState is null) return;

            _languageSet = user.LanguageId.HasValue ? LanguagesState.Value.GetLanguageName(user.LanguageId.Value) : MyText.noData;

            

            _translatingLanguages = new List<Language>();
            _coordinatingLanguages = new List<Language>();
            foreach (var lt in user.TranslatingLanguages)
            {
                var lang = LanguagesState.Value.GetLanguage(lt);
                if (!(lang is null))
                    _translatingLanguages.Add(lang);
            }

            foreach (var lt in user.CoordinatingLanguages)
            {
                var lang = LanguagesState.Value.GetLanguage(lt);
                if (!(lang is null))
                    _coordinatingLanguages.Add(lang);
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
    }
}