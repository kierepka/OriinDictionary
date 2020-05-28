using System.Threading.Tasks;
using OriinDic.Models;

namespace OriinDic.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginInput loginModel);

        Task Logout();
    }
}