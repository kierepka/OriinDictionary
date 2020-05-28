using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsEffects
    {
        private readonly HttpClient _httpClient;
        private static readonly System.Text.Json.JsonSerializerOptions _options =
            new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true
            };

        public BaseTermsEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(BaseTermsFetchDataAction action, IDispatcher dispatcher)
        {

            var currentString = "true";
            if (!action.Current) currentString = "false";
            var translationResult = new RootObject<ResultBaseTranslation>();

            var queryString =
                $"{Const.ApiBaseTerms}?text={action.SearchText}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}&base_term_language_id={action.BaseTermLangId}";
            if (action.TranslationLangId != Const.PlLangId) queryString += $"&translation_language_id={action.TranslationLangId}";

            try
            {

                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(queryString, _options);
            }
            catch (Exception e)
            {
                var a = e;
            }

            dispatcher.Dispatch(new BaseTermsFetchDataResultAction(translationResult));
        }

        [EffectMethod]
        public async Task HandleAddDataAction(BaseTermsAddAction baseTermAction, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", baseTermAction.Token);
            var response = await _httpClient.PostAsJsonAsync(
                requestUri: $"{Const.ApiBaseTerms}", baseTermAction.BaseTerm);

            var returnData = await response.Content.ReadFromJsonAsync<BaseTerm>();


            dispatcher.Dispatch(new BaseTermsAddResultAction(returnData));
        }

        [EffectMethod]
        public async Task HandleFetchOneAction(BaseTermsFetchOneAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.ApiBaseTerms}{action.BaseTermId}/";
            var returnData = await _httpClient.GetFromJsonAsync<BaseTerm>(url);


            dispatcher.Dispatch(new BaseTermsFetchOneResultAction(returnData));
        }

        [EffectMethod]
        public async Task HandleFetchOneSlugAction(BaseTermsFetchOneSlugAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.ApiBaseTerms}{action.Slug}/by_slug/";
            var returnData = await _httpClient.GetFromJsonAsync<BaseTerm>(url);
            dispatcher.Dispatch(new BaseTermsFetchOneResultAction(returnData));
        }

        [EffectMethod]
        public async Task HandleUpdateAction(BaseTermsUpdateAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var response = await _httpClient.PutAsJsonAsync(
                $"{Const.ApiBaseTerms}{action.BaseTermId}/",
                action.BaseTerm);

            var returnData = await response.Content.ReadFromJsonAsync<BaseTerm>();


            dispatcher.Dispatch(new BaseTermsUpdateResultAction(returnData));
        }

    }
}