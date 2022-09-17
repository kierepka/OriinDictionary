using OriinDictionary7.Models;

namespace OriinDictionary7.Services;

public interface IAuthService
{
    Task<LoginResult> Login(LoginInput loginModel);

    Task Logout();
}