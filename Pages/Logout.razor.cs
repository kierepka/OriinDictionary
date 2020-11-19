using System.Threading.Tasks;

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