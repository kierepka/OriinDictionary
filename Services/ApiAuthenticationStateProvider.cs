using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Services
{
    public class AuthenticationStateProvider : Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        }

        /// <summary>
        /// Marks user as authenticated
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task MarkUserAsAuthenticated(Token token)
        {
            await _localStorage.SetItemAsync(Const.TokenKey, token);
            NotifyAuthenticationStateChanged(CreateAuthenticatedState(token));
        }

        /// <summary>
        /// Logouts user
        /// </summary>
        /// <returns></returns>
        public async Task MarkUserAsLoggedOut()
        {
            await _localStorage.RemoveItemAsync(Const.TokenKey);
            NotifyAuthenticationStateChanged(CreateAnonymouslyState());
        }

        /// <summary>
        /// Set user as authenticated
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<AuthenticationState> CreateAuthenticatedState(Token token)
        {
            var claims = await ParseClaimsFromUserInfo(token);
            //no user info - not logged in or other error
            if (claims is null) return await CreateAnonymouslyState();
            //ok - claims should be done
            // ReSharper disable once StringLiteralTypo
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "apiauth"));
            return await Task.FromResult(new AuthenticationState(authenticatedUser));
        }

        /// <summary>
        /// Sets user state to anonymous
        /// </summary>
        /// <returns></returns>
        private static async Task<AuthenticationState> CreateAnonymouslyState()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            return await Task.FromResult(new AuthenticationState(anonymousUser));
        }

        /// <summary>
        /// Checks user state
        /// </summary>
        /// <returns></returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<Token>(Const.TokenKey);
            //no token - anonymous user
            if (token is null) return await CreateAnonymouslyState();
            if (string.IsNullOrWhiteSpace(token.AuthToken)) return await CreateAnonymouslyState();
            //there is token - check user
            return await CreateAuthenticatedState(token);
        }

        /// <summary>
        /// Gets user data from server 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<User> GetUserInfoAsync(Token token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(Const.TokenApiKey, token.AuthToken);
            var userInfo = await _httpClient.GetFromJsonAsync<User>(Const.UsersMe, Const.HttpClientOptions);
            await _localStorage.SetItemAsync(Const.UserKey, userInfo);
            return userInfo ?? new User();
        }

        /// <summary>
        /// Checks user rights
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<List<Claim>?> ParseClaimsFromUserInfo(Token token)
        {
            if (token is null) throw new ArgumentNullException(nameof(token));

            var userInfo = await _localStorage.GetItemAsync<User>(Const.UserKey) ?? await GetUserInfoAsync(token);

            var result = new List<Claim>
            {
                !string.IsNullOrWhiteSpace(userInfo.UserName)
                    ? new Claim(ClaimTypes.Name, userInfo.UserName)
                    : new Claim(ClaimTypes.Name, "Eden's")
            };

            if (!string.IsNullOrWhiteSpace(userInfo.FirstName))
                result.Add(new Claim(ClaimTypes.GivenName, userInfo.FirstName));

            if (!string.IsNullOrWhiteSpace(userInfo.LastName))
                result.Add(new Claim(ClaimTypes.Surname, userInfo.LastName));

            if (!string.IsNullOrWhiteSpace(userInfo.Email))
                result.Add(new Claim(ClaimTypes.Email, userInfo.Email));

            if (userInfo.IsSuperuser)
                result.Add(new Claim(ClaimTypes.Role, Const.RoleSuperUser));

            if (userInfo.Assistant)
                result.Add(new Claim(ClaimTypes.Role, Const.RoleAssistant));

            if (userInfo.TranslatingLanguages.Count > 0)
                result.Add(new Claim(ClaimTypes.Role, Const.RoleTranslator));


            if (userInfo.CoordinatingLanguages.Count > 0)
                result.Add(new Claim(ClaimTypes.Role, Const.RoleCoordinator));

            return result;
        }
    }
}