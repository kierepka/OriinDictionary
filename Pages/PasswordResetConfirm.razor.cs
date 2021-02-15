using System;
using System.Threading.Tasks;

using Blazorise;
using Fluxor;
using Microsoft.AspNetCore.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Services;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class PasswordResetConfirm
    {
        private bool _isLoading;

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IAuthService? AuthService { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private NavigationManager? NavigationManager { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }


        [Parameter]
        public string PageRoute { get; set; } = string.Empty;
        
        private UserPwdResetUpdate User { get; set; } = new UserPwdResetUpdate();

        private string UserId = string.Empty;
        private string Token = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _isLoading = true;




            _isLoading = false;
        }

        private static void ValidatePassword(ValidatorEventArgs e)
        {
            e.Status = Convert.ToString(e.Value)?.Length >= 6 ? ValidationStatus.Success : ValidationStatus.Error;
        }

        private void ValidatePassword2(ValidatorEventArgs e)
        {
            if (User.ReNewPassword.Length < 6)
            {
                e.Status = ValidationStatus.Error;
            }
            else if (User.ReNewPassword != User.NewPassword)
            {
                e.Status = ValidationStatus.Error;
            }
            else
            {
                e.Status = ValidationStatus.Success;
            }
        }

        protected override void OnParametersSet()
        {
            if (PageRoute is null) return;
            
            var s = PageRoute.Split('/');

            if (s.Length == 2) {
                UserId = s[0];
                Token = s[1];
            }
        }

        private void HandlePasswordReset()
        {
            if (LocalStorage is null) return;

            if (MyText is null) return;
            if (string.IsNullOrEmpty(UserId)) return;
            if (string.IsNullOrEmpty(Token)) return;

            User.UserId = UserId;
            User.Token = Token;

            try
            {
                var token = LocalStorage.GetItem<Token>(Const.TokenKey);

                Dispatcher?.Dispatch(
                    new UsersPasswordResetConfirmAction(
                        user: User,
                        token: token.AuthToken,
                        userPasswordResetConfirmMessage: MyText?.PasswordReseted ?? string.Empty));

                if (NavigationManager is null) return;
                NavigationManager.NavigateTo("/");
            }
            catch
            {
                ShowAlert(MyText?.DataSavedNOk ?? string.Empty);
            }
        }
    }
}