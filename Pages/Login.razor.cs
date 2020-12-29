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
    public partial class Login
    {
        private readonly LoginInput _loginModel = new();

        private bool _isLoading;
        private string _emailToReset = string.Empty;
        private string SelectedTab { get; set; } = "login";
        
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IAuthService? AuthService { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private NavigationManager? NavigationManager { get; set; }

        private async Task HandleLogin()
        {
            _isLoading = true;
            if (AuthService is null) return;

            var result = await AuthService.Login(_loginModel);

            if (MyText is not null) 
                if (result.Successful)
                    NavigationManager?.NavigateTo("/");
                else
                    ShowAlert(MyText.LoginError + result.Error);

            _isLoading = false;
        }
        
        private static void ValidatePassword(ValidatorEventArgs e)
        {
            e.Status = Convert.ToString(e.Value)?.Length >= 6 ? ValidationStatus.Success : ValidationStatus.Error;
        }
        private void HandlePasswordReset()
        {
            
            if (LocalStorage is null) return;

            if (MyText is null) return;

            var upr = new UserPwdReset
            {
                Email = _emailToReset
            };
            try
            {
                var token = LocalStorage.GetItem<Token>(Const.TokenKey);

                Dispatcher?.Dispatch(
                    new UsersPasswordResetAction(
                        user: upr,
                        token: token.AuthToken,
                        userPasswordResetMessage: MyText?.PasswordResetSend ?? string.Empty));
            }
            catch
            {
                ShowAlert(MyText?.DataSavedNOk ?? string.Empty);
            }
            
        }
        private void OnSelectedTabChanged(string name)
        {
            SelectedTab = name;
        }

    }
}