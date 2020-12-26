using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazorise.DataGrid;
using Blazorise.Snackbar;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Notifications;

namespace OriinDic.Store.Languages
{
    public class LanguagesEffects
    {
        private readonly HttpClient _httpClient;

        public LanguagesEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(LanguagesFetchDataAction action, IDispatcher dispatcher)
        {
            if (action.LocalStorage is null)
            {
                return;
            }

            var languages =
                action.LocalStorage.GetItem<List<Language>>(Const.LanguagesKey) ?? new List<Language>();

            if (languages.Count == 0)
            {
                languages = await GetLanguages(dispatcher);
                action.LocalStorage.SetItem(Const.LanguagesKey, languages);
            }
            else
            {
                languages = action.LocalStorage.GetItem<List<Language>>(Const.LanguagesKey);
            }

            dispatcher.Dispatch(new LanguagesFetchDataResultAction(languages));
        }

        /// <summary>
        /// Get all Languages
        /// </summary>
        /// <param name="dispatcher"></param>
        /// <returns></returns>
        private async Task<List<Language>> GetLanguages(IDispatcher dispatcher)
        {
            var languageList = new List<Language>();
            var uriStr = $"{Const.GetLanguages}?page=1&per_page={Const.DefaultItemsPerPage}";
            RootObject<Language>? languageResult;
            try
            {
                languageResult = await _httpClient.GetFromJsonAsync<RootObject<Language>>
                    (uriStr, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                return languageList;
            }

            if (languageResult is null)
                return new List<Language>();


            if (languageResult.Pages <= 1) return languageResult.Results;

            var pagesCount = languageResult!.Pages + 1;
            for (var i = 1; i < pagesCount; i++)
            {
                uriStr = $"{Const.GetLanguages}?page={i}&per_page={Const.DefaultItemsPerPage}";
                try
                {
                    languageResult = await _httpClient.GetFromJsonAsync<RootObject<Language>>
                        (uriStr, Const.HttpClientOptions);
                }
                catch (Exception e)
                {
                    dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                    return languageList;
                }

                if (languageResult is not null) languageList.AddRange(languageResult.Results);
            }


            return languageResult?.Results ?? new List<Language>();
        }
    }
}