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
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        //Domyślny Ctor
        public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException("httpClient");
            _localStorage = localStorage ?? throw new ArgumentNullException("localStorage");
        }

        //Zaznacza użytkownika jako zautoryzowanego
        public async Task MarkUserAsAuthenticated(Token token)
        {
            await _localStorage.SetItemAsync(Const.TokenKey, token);
            NotifyAuthenticationStateChanged(CreateAuthenticatedState(token));
        }

        //Wylogowuje użytkownika
        public async Task MarkUserAsLoggedOut()
        {
            await _localStorage.RemoveItemAsync(Const.TokenKey);
            NotifyAuthenticationStateChanged(CreateAnomymousState());
        }

        //Potwierdza użytkownika zautoryzowanego
        private async Task<AuthenticationState> CreateAuthenticatedState(Token token)
        {
            var claims = await ParseClaimsFromUserInfo(token);
            //no user info - not logged in or other error
            if (claims is null) return await CreateAnomymousState();
            //ok - claims should be done
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "apiauth"));
            return await Task.FromResult(new AuthenticationState(authenticatedUser));
        }

        //Ustawia stan na anonimowy
        private static async Task<AuthenticationState> CreateAnomymousState()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            return await Task.FromResult(new AuthenticationState(anonymousUser));
        }

        //Sprawdza stan użytkownika
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<Token>(Const.TokenKey);
            //no token - anonymous user
            if (token is null) return await CreateAnomymousState();
            if (string.IsNullOrWhiteSpace(token.AuthToken)) return await CreateAnomymousState();
            //there is token - check user
            return await CreateAuthenticatedState(token);
        }

        //Pobiera dane z API serwera
        private async Task<User> GetUserInfoAsync(Token token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(Const.TokenApiKey, token.AuthToken);
            var userInfo = await _httpClient.GetFromJsonAsync<User>(Const.ApiUsersMe);
            await _localStorage.SetItemAsync(Const.UserKey, userInfo);
            return userInfo;
        }

        //Sprawdza updawnienia użytkownika i zapisue podstawowe dane w obiekcie
        private async Task<List<Claim>?> ParseClaimsFromUserInfo(Token token)
        {
            if (token is null) throw new ArgumentNullException("token");

            List<Claim>? result = null;
            var userInfo = await _localStorage.GetItemAsync<User>(Const.UserKey) ?? await GetUserInfoAsync(token);

            var identity = new ClaimsIdentity();
            if (!(userInfo is null))
            {
                result = new List<Claim>();
                if (!string.IsNullOrWhiteSpace(userInfo.UserName))
                    result.Add(new Claim(ClaimTypes.Name, userInfo.UserName));
                else
                    result.Add(new Claim(ClaimTypes.Name, "Edenic"));

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

                if (!(userInfo.TranslatingLanguages is null))
                    if (userInfo.TranslatingLanguages.Count > 0)
                        result.Add(new Claim(ClaimTypes.Role, Const.RoleTranslator));

                if (!(userInfo.CoordinatingLanguages is null))
                    if (userInfo.CoordinatingLanguages.Count > 0)
                        result.Add(new Claim(ClaimTypes.Role, Const.RoleCoordinator));
            }

            return result;
        }
    }
}