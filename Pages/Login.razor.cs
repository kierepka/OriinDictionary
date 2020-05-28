using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Models;
using OriinDic.Services;

namespace OriinDic.Pages
{
    public partial class Login : DicBasePage
    {
        private readonly LoginInput _loginModel = new LoginInput();

        public bool isLoading = false;

        public Login()   : base()
        {
        }

        public Login(Toolbelt.Blazor.I18nText.I18nText i18NText,
            IAuthService authService,
            NavigationManager navigationManager
        ) : this()
        {
            I18NText = i18NText;
            AuthService = authService;
            NavigationManager = navigationManager;
        }

        [Inject] private IAuthService AuthService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private async Task HandleLogin()
        {
            isLoading = true;
            var result = await AuthService.Login(_loginModel);

            if (!(MyText is null)) 
                if (result.Successful)
                    NavigationManager.NavigateTo("/");
                else
                    ShowAlert(MyText.loginError + result.Error);

            isLoading = false;
        }

    }
}