using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsEffects
    {
        private readonly HttpClient _httpClient;
        private static readonly System.Text.Json.JsonSerializerOptions _options =
            new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true
            };

        public TranslationsEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleAddDataAction(TranslationsAddAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var response = await _httpClient.PostAsJsonAsync(
                requestUri: $"{Const.ApiBaseTerms}", action.Translation);

            var returnData = await response.Content.ReadFromJsonAsync<Translation>();


            dispatcher.Dispatch(new TranslationsAddResultAction(returnData));
        }



        [EffectMethod]
        public async Task HandleFetchDataAction(TranslationsFetchDataAction action, IDispatcher dispatcher)
        {

            var currentString = "true";
            if (!action.Current) currentString = "false";
            var translationResult = new RootObject<ResultBaseTranslation>();
            var queryString =
                $"{Const.ApiTranslations}?text={action.SearchText}&language_id={action.LangId}&base_term_language_id={action.BaseTermLangId}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}";
            try
            {

                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(
                    requestUri: queryString,
                    _options);
            }
            catch (Exception e)
            {
                var a = e;
            }

            dispatcher.Dispatch(new TranslationsFetchDataResultAction(translationResult));
        }

        [EffectMethod]
        public async Task HandleFetch4EditAction(TranslationsFetch4EditAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.ApiBaseTerms}{action.TranslationId}/";
            var translation = await _httpClient.GetFromJsonAsync<Translation>(url);
            
            url = $"{Const.ApiBaseTerms}{translation.BaseTermId}/";
            var baseTerm = await _httpClient.GetFromJsonAsync<BaseTerm>(url);
            var comments = new RootObject<Comment>();

            if (!string.IsNullOrEmpty(action.Token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
                url = $"{Const.ApiComments}?translation_id={action.TranslationId}";
                comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url);
            }

            url = $"{Const.ApiLinks}?translation_id={action.TranslationId}";
            var links = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(url);
            
            dispatcher.Dispatch(new TranslationsFetch4EditResultAction(translation: translation, baseTerm: baseTerm,
                links: links.Results, comments: comments.Results));
        }

        [EffectMethod]
        public async Task HandleFetchCommentsAction(TranslationsFetchCommentsAction action, IDispatcher dispatcher)
        {

            var comments = new RootObject<Comment>();

            if (!string.IsNullOrEmpty(action.Token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
                var url = $"{Const.ApiComments}?translation_id={action.TranslationId}";
                comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url);
            }

            dispatcher.Dispatch(new TranslationsFetchCommentsResultAction(comments.Results));
        }

        [EffectMethod]
        public async Task HandleFetchBaseTermAction(TranslationsFetchBaseTermAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.ApiBaseTerms}{action.BaseTermId}/";
            var baseTerm = await _httpClient.GetFromJsonAsync<BaseTerm>(url);
            dispatcher.Dispatch(new TranslationsFetchBaseTermResultAction(baseTerm));
        }


        [EffectMethod]
        public async Task HandleFetchOneAction(TranslationsFetchOneAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.ApiBaseTerms}{action.TranslationId}/";
            var returnData = await _httpClient.GetFromJsonAsync<Translation>(url);


            dispatcher.Dispatch(new TranslationsFetchOneResultAction(returnData));
        }

        [EffectMethod]
        public async Task HandleUpdateAction(TranslationsUpdateAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var response = await _httpClient.PutAsJsonAsync(
                $"{Const.ApiBaseTerms}{action.TranslationId}/",
                action.Translation);

            var returnData = await response.Content.ReadFromJsonAsync<Translation>();


            dispatcher.Dispatch(new TranslationsAddResultAction(returnData));
        }
    }
}