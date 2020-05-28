using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        //loguje użytkownika do serwisu
        public async Task<LoginResult> Login(LoginInput loginModel)
        {
            var lr = new LoginResult
            {
                Successful = false,
                Error = ""
            };
            //Console.WriteLine("Login begin");
            var token = await GetAuthToken(loginModel.Username, loginModel.Password);
            //Console.WriteLine(token.auth_token);
            await _localStorage.SetItemAsync(Const.TokenKey, token);

            if (token is null) return lr;
            if (string.IsNullOrWhiteSpace(token.AuthToken)) return lr;
            //Console.WriteLine("mark as authenticated");
            await ((ApiAuthenticationStateProvider) _authenticationStateProvider).MarkUserAsAuthenticated(token);

            //Console.WriteLine("add to _httpClient");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(Const.TokenApiKey, token.AuthToken);

            
            lr.Successful = true;
            lr.Token = token.AuthToken;
            //Console.WriteLine(lr.ToString());
            return lr;
        }

        public async Task Logout()
        {
            //await _localStorage.RemoveItemAsync(Const.TokenKey);
            //await _localStorage.RemoveItemAsync(Const.LanguageKey);
            //await _localStorage.RemoveItemAsync(Const.UserKey);
            await _localStorage.ClearAsync();

            await ((ApiAuthenticationStateProvider) _authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        //autoryzuje użytkownika i pobiera token
        public async Task<Token> GetAuthToken(string user, string pwd)
        {
            var json = "{\"username\": \"" + user + "\",\"password\": \"" + pwd + "\"}";
            
            using HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(Const.ApiToken, c);
            //Console.WriteLine("END:"+response.ToString());
            //Console.WriteLine(response.Content);            
            var ret = await response.Content.ReadFromJsonAsync<Token>();
            //Console.WriteLine(ret.ToString());
            return ret;
        }
    }
}