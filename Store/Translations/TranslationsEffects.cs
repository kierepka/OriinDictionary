using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Fluxor;

using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Notifications;

namespace OriinDic.Store.Translations
{
    // ReSharper disable once UnusedType.Global
    public class TranslationsEffects
    {
        private readonly HttpClient _httpClient;


        public TranslationsEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleApproveAction(TranslationsAproveAction action, IDispatcher dispatcher)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            HttpContent httpContent = new StringContent(string.Empty);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PutAsync(
                requestUri: $"{Const.Translations}{action.TranslationId}/approve_translation/", httpContent);


            var returnCode = response.StatusCode;
            var url = $"{Const.Translations}{action.TranslationId}/";
            var translation = new Translation();
            try
            {
                translation = await _httpClient.GetFromJsonAsync<Translation>(url, Const.HttpClientOptions);
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }


            dispatcher.Dispatch(
                new TranslationsApproveResultAction(returnCode,
                    translation: translation ?? new Translation()));
        }


        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleAddDataAction(TranslationsAddAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var response = await _httpClient.PostAsJsonAsync(
                requestUri: $"{Const.Translations}", action.Translation);

            var returnData = await response.Content.ReadFromJsonAsync<Translation>();


            dispatcher.Dispatch(
                new TranslationsAddResultAction(
                          translation: returnData ?? new Translation(),
                          resultCode: response.StatusCode));
        }



        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetchDataAction(TranslationsFetchDataAction action, IDispatcher dispatcher)
        {

            var currentString = "true";
            if (!action.Current) currentString = "false";
            var translationResult = new RootObject<ResultBaseTranslation>();
            var queryString =
                $"{Const.Translations}?text={action.SearchText}&language_id={action.LangId}&base_term_language_id={action.BaseTermLangId}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}";

            var returnCode = System.Net.HttpStatusCode.OK;
            try
            {

                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new ShowNotificationAction(e.Message));
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }
            finally
            {
                dispatcher.Dispatch(new ShowNotificationAction(action.DataLoadedMessage));
            }
            dispatcher.Dispatch(
                new TranslationsFetchDataResultAction(
                     rootObject: translationResult ?? new RootObject<ResultBaseTranslation>(),
                     httpStatusCode: returnCode
                     ));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetch4EditAction(TranslationsFetch4EditAction action, IDispatcher dispatcher)
        {
            var returnCode = System.Net.HttpStatusCode.OK;
            var url = $"{Const.Translations}{action.TranslationId}/";
            var translation = new Translation();
            try
            {
                translation = await _httpClient.GetFromJsonAsync<Translation>(url, Const.HttpClientOptions);
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }


            ResultBaseTranslation? baseTermResult = null;
            try
            {
                if (translation != null)
                {
                    url = $"{Const.BaseTerms}{translation.BaseTermId}/";
                    baseTermResult = await _httpClient.GetFromJsonAsync<ResultBaseTranslation>(url, Const.HttpClientOptions);
                }
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }


            var comments = new RootObject<Comment>();

            try
            {
                if (!string.IsNullOrEmpty(action.Token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
                    url = $"{Const.Comments}?translation_id={action.TranslationId}";
                    comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url, Const.HttpClientOptions);
                }
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }

            url = $"{Const.Links}?translation_id={action.TranslationId}";
            var links = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(url, Const.HttpClientOptions);

            dispatcher.Dispatch(
                new TranslationsFetch4EditResultAction(
                    translation: translation ?? new Translation(),
                    baseTerm: baseTermResult?.BaseTerm ?? new BaseTerm(),
                    links: links?.Results ?? new System.Collections.Generic.List<OriinLink>(),
                    comments: comments?.Results ?? new System.Collections.Generic.List<Comment>(),
                    httpStatusCode: returnCode)
                );

            dispatcher.Dispatch(new ShowNotificationAction(action.DataLoadedMessage));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleAddCommentsAction(TranslationsCommentAddAction action, IDispatcher dispatcher)
        {
            var comments = new RootObject<Comment>();
            var returnCode = System.Net.HttpStatusCode.OK;
            try
            {
                if (!string.IsNullOrEmpty(action.Token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

                    var response = await _httpClient.PostAsJsonAsync(
                        $"{Const.Comments}", action.Comment);

                    _ = await response.Content.ReadFromJsonAsync<Comment>();

                    var url = $"{Const.Comments}?translation_id={action.TranslationId}";
                    comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url, Const.HttpClientOptions);
                }
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new TranslationsFetchCommentsResultAction(
                    comments: comments?.Results ?? new System.Collections.Generic.List<Comment>(),
                    httpStatusCode: returnCode));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetchCommentsAction(TranslationsFetchCommentsAction action, IDispatcher dispatcher)
        {

            var comments = new RootObject<Comment>();
            var returnCode = System.Net.HttpStatusCode.OK;
            try
            {
                if (!string.IsNullOrEmpty(action.Token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
                    var url = $"{Const.Comments}?translation_id={action.TranslationId}";
                    comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url, Const.HttpClientOptions);
                }
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new TranslationsFetchCommentsResultAction(
                    comments: comments?.Results ?? new System.Collections.Generic.List<Comment>(),
                    httpStatusCode: returnCode));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetchBaseTermAction(TranslationsFetchBaseTermAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.BaseTerms}{action.BaseTermId}/";
            var returnCode = System.Net.HttpStatusCode.OK;
            var resBaseTransl = new ResultBaseTranslation();

            try
            {
                resBaseTransl = await _httpClient.GetFromJsonAsync<ResultBaseTranslation>(url, Const.HttpClientOptions);
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }


            resBaseTransl ??= new ResultBaseTranslation();

            resBaseTransl.BaseTerm ??= new BaseTerm
            {
                LanguageId = Const.PlLangId,
                Id = action.BaseTermId
            };

            resBaseTransl.Translation ??= new Translation
            {
                LanguageId = resBaseTransl.BaseTerm.LanguageId,
                BaseTermId = resBaseTransl.BaseTerm.Id
            };
            resBaseTransl.Translations ??= new System.Collections.Generic.List<Translation> { resBaseTransl.Translation };

            dispatcher.Dispatch(
                new TranslationsFetchBaseTermResultAction(
                    baseTranslation: resBaseTransl,
                    httpStatusCode: returnCode));
        }


        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetchOneAction(TranslationsFetchOneAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.BaseTerms}{action.TranslationId}/";

            var returnCode = System.Net.HttpStatusCode.OK;
            var returnData = new Translation();
            try
            {
                returnData = await _httpClient.GetFromJsonAsync<Translation>(url, Const.HttpClientOptions);
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }
            dispatcher.Dispatch(
                new TranslationsFetchOneResultAction(
                    translation: returnData ?? new Translation(),
                    httpStatusCode: returnCode));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleUpdateAction(TranslationsUpdateAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var response = await _httpClient.PutAsJsonAsync(
                $"{Const.BaseTerms}{action.TranslationId}/",
                action.Translation);

            var returnCode = System.Net.HttpStatusCode.OK;
            var returnData = new Translation();
            try
            {
                returnData = await response.Content.ReadFromJsonAsync<Translation>();
            }
            catch
            {
                returnCode = System.Net.HttpStatusCode.BadRequest;
            }


            dispatcher.Dispatch(
                new TranslationsAddResultAction(
                    translation: returnData ?? new Translation(),
                    resultCode: returnCode));
        }
    }
}