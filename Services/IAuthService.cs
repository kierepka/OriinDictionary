using OriinDic.Models;

using System.Threading.Tasks;

namespace OriinDic.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginInput loginModel);

        Task Logout();
    }
}