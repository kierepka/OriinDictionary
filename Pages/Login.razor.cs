using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using OriinDic.Models;
using OriinDic.Services;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Login
    {
        private readonly LoginInput _loginModel = new();

        private bool _isLoading;


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

    }
}