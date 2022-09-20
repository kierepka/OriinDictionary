using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Users;

public record UsersPasswordResetConfirmAction
{
    public string Token { get; } = string.Empty;
    public UserPwdResetUpdate User { get; } = new();
    public string UserPasswordResetConfirmMessage { get; } = string.Empty;

    public UsersPasswordResetConfirmAction(
        UserPwdResetUpdate user, string token, string userPasswordResetConfirmMessage)
    {
        Token = token;
        UserPasswordResetConfirmMessage = userPasswordResetConfirmMessage;
        User = user;
    }
}