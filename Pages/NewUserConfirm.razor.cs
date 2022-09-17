using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDictionary7.Helpers;
using OriinDictionary7.Models;
using OriinDictionary7.Services;
using OriinDictionary7.Store.Users;

namespace OriinDictionary7.Pages;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class NewUserConfirm
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


    protected override void OnParametersSet()
    {
        if (PageRoute is null) return;
        if (LocalStorage is null) return;

        if (MyText is null) return;


        var s = PageRoute.Split('/');

        if (s.Length == 2)
        {
            UserId = s[0];
            Token = s[1];
        }

        if (string.IsNullOrEmpty(UserId)) return;
        if (string.IsNullOrEmpty(Token)) return;

        User.UserId = UserId;
        User.Token = Token;

        try
        {
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);

            Dispatcher?.Dispatch(
                new UsersCreationConfirmAction(
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