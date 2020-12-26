using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using OriinDic.Services;

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

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _isLoading = true;

            if (AuthService is null) return;
            

            LocalStorage?.Clear();

            if (NavigationManager is null) return;
            NavigationManager.NavigateTo("/");

            _isLoading = false;
        }
    }
}