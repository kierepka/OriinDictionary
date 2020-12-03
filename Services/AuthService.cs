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

        /// <summary>
        /// Login user to service
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<LoginResult> Login(LoginInput loginModel)
        {
            var lr = new LoginResult
            {
                Successful = false,
                Error = ""
            };
            var token = await GetAuthToken(loginModel.Username, loginModel.Password);
            await _localStorage.SetItemAsync(Const.TokenKey, token);

            if (string.IsNullOrWhiteSpace(token.AuthToken)) return lr;
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(token);

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(Const.TokenApiKey, token.AuthToken);


            lr.Successful = true;
            lr.Token = token.AuthToken;
            return lr;
        }

        public async Task Logout()
        {
            await _localStorage.ClearAsync();

            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        /// <summary>
        /// User authorization and token retrieve
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        private async Task<Token> GetAuthToken(string user, string pwd)
        {

            var json = "{\"username\": \"" + user + "\",\"password\": \"" + pwd + "\"}";

            using HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PostAsync(Const.Token, content);

            if (!response.IsSuccessStatusCode)
            {
                // set error message for display, log to console and return
                return new Token();
            }

            // convert response data to Article object
            var token = await response.Content.ReadFromJsonAsync<Token>();


            //Console.WriteLine(ret.ToString());
            return token ?? new Token();
        }
    }
}