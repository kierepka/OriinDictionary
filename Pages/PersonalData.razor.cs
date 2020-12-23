using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Fluxor;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class PersonalData
    {
        private List<Language> _coordinatingLanguages = new();
        private string selectedTab = "profile";

        private List<Language> _translatingLanguages = new();
        private User User { get; set; } = new();

        private UserPwdUpdate UserPwdUpdate { get; set; } = new();
        private bool IsSuperUser { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<UsersState>? UserState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction(LocalStorage));

            if (LocalStorage is not null)
            {
                User = LocalStorage.GetItem<User>(Const.UserKey);
            }

            
            LoadUserData(User);


            if (AuthenticationStateProvider is not null)
            {
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                IsSuperUser = (user.IsInRole(Const.RoleSuperUser));
            }

            if (UserState is null) return;
            UserState.StateChanged += UserState_StateChanged;
        }

        private void UserState_StateChanged(object sender, UsersState e)
        {

            
            if (UserState?.Value.User != null) User = UserState.Value.User;

            LoadUserData(User);
            LocalStorage?.SetItem(Const.UserKey, User);
        }

        private void LoadUserData(User user)
        {

            if (LocalStorage is null) return;
            if (MyText is null) return;

            _translatingLanguages = new List<Language>();
            _coordinatingLanguages = new List<Language>();
            foreach (var lt in user.TranslatingLanguages)
            {
                var lang = LanguagesState?.Value.GetLanguage(lt);
                if (lang is not null)
                    _translatingLanguages.Add(item: lang);
            }

            foreach (var lt in user.CoordinatingLanguages)
            {
                var lang = LanguagesState?.Value.GetLanguage(lt);
                if (lang is not null)
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
                Dispatcher?.Dispatch(
                    new UsersAnonymizeAction(
                        user: User, 
                        token: token.AuthToken,
                        MyText?.Anonymized ?? string.Empty));
            }
            catch
            {
                ShowAlert(MyText?.DataSavedNOk ?? string.Empty);
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
                    UserName = User.UserName,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Email = User.Email,
                    Gender = User.Gender
                };
                if (User.LanguageId.HasValue) uu.LanguageId = User.LanguageId.Value;


                Dispatcher?.Dispatch(
                    new UsersUpdateAction(
                        userId: User.Id, 
                        user: User, 
                        token: token.AuthToken,
                        userUpdatedMessage: MyText?.Updated ?? string.Empty));

            }
            catch
            {
                ShowAlert(MyText?.DataSavedNOk ?? string.Empty);
            }

        }

        private void HandlePasswordChange()
        {
            
        }

        private static void ValidatePassword( ValidatorEventArgs e )
        {
            e.Status = Convert.ToString( e.Value )?.Length >= 6 ? ValidationStatus.Success : ValidationStatus.Error;
        }

        private static void ValidatePassword3( ValidatorEventArgs e )
        {
            e.Status = Convert.ToString( e.Value )?.Length >= 6 ? ValidationStatus.Success : ValidationStatus.Error;
        }

        private void ValidatePassword2( ValidatorEventArgs e )
        {
            

            if ( UserPwdUpdate.ReNewPassword.Length < 6 )
            {
                e.Status = ValidationStatus.Error;
            }
            else if ( UserPwdUpdate.ReNewPassword != UserPwdUpdate.NewPassword )
            {
                e.Status = ValidationStatus.Error;
            }
            else
            {
                e.Status = ValidationStatus.Success;
            }
        }

    }
}