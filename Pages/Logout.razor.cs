using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Services;

namespace OriinDic.Pages
{
    public partial class Logout : DicBasePage
    {
        public bool isLoading = false;
        public Logout()
        {
        }
        [Inject] protected ISyncLocalStorageService? LocalStorage { get; set; }

        public Logout(IAuthService authService,
            Toolbelt.Blazor.I18nText.I18nText i18NText,
            NavigationManager navigationManager
        ) : this()
        {
            AuthService = authService;
            I18NText = i18NText;
            NavigationManager = navigationManager;
        }

        [Inject] private IAuthService? AuthService { get; set; }
        [Inject] private NavigationManager? NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            isLoading = true;

            if (AuthService is null) return;
            await AuthService.Logout();

            LocalStorage?.Clear();

            if (NavigationManager is null) return;
            NavigationManager.NavigateTo("/");

            isLoading = false;
        }
    }
}