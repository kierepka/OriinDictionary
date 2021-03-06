using System.Linq;
using System.Threading.Tasks;

using Fluxor;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Languages;
using OriinDic.Store.Users;

namespace OriinDic.Pages
{
    public partial class OriinUser
    {

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<UsersState>? UserState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject]  private IDispatcher? Dispatcher { get; set; }

        private User User { get; } = new();
        private bool IsSuperUser { get; set; }
   
        [Parameter] public long UserId { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction(LocalStorage));

            Token? token = null;

            if (LocalStorage is not null)
            {
                token = LocalStorage.GetItem<Token>(Const.TokenKey);
            }

            if (token != null) 
                Dispatcher?.Dispatch(
                    new UsersFetchOneAction(
                        userId: UserId, 
                        token.AuthToken, 
                        userFetchedMessage: MyText?.Loaded ?? string.Empty));

            if (AuthenticationStateProvider is not null)
            {
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                IsSuperUser = user.IsInRole(Const.RoleSuperUser);
            }

        }

    }
}