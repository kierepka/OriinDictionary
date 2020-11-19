using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Fluxor;

using OriinDic.Helpers;
using OriinDic.Models;

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


            var languages = await GetLanguages();
            dispatcher.Dispatch(new LanguagesFetchDataResultAction(languages));
        }

        private async Task<IEnumerable<Language>> GetLanguages()
        {
            var languageResult = await _httpClient.GetFromJsonAsync<RootObject<Language>>
                (Const.ApiGetLanguages, Const.HttpClientOptions);

            if (languageResult is null) return new List<Language>();
            if (languageResult.Pages > 1)
            {
                //TODO: pobierać więcej danych
            }

            return languageResult.Results;

        }

        [EffectMethod]
        public async Task HandleStoreLocalDataAction(LanguagesFetchDataStoreAction action, IDispatcher dispatcher)
        {

            if (action.LocalStorage is null) return;

            var languages = (await GetLanguages()).ToList();

            action.LocalStorage.SetItem(Const.LanguagesKey, languages);

            dispatcher.Dispatch(new LanguagesFetchDataStoreResultAction(languages));
        }
    }
}