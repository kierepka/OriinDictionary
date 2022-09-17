using Blazorise.Snackbar;

using Fluxor;

using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Notifications;

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

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
        public async Task HandleApproveAction(TranslationsApproveAction action, IDispatcher dispatcher)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            HttpContent httpContent = new StringContent(string.Empty);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpStatusCode returnCode;

            try
            {
                var response = await _httpClient.PutAsync(
                    requestUri: $"{Const.Translations}{action.TranslationId}/approve_translation/", httpContent);
                returnCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new NotificationAction(ex.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }


            var url = $"{Const.Translations}{action.TranslationId}/";
            var translation = new Translation();
            try
            {
                translation = await _httpClient.GetFromJsonAsync<Translation>(url, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            if (translation is null) translation = new Translation();
            translation.CheckNulls();

            dispatcher.Dispatch(
                new TranslationsApproveResultAction(returnCode,
                    translation: translation));

            if (returnCode != HttpStatusCode.BadRequest)
            {
                dispatcher.Dispatch(new NotificationAction(action.TranslationApproved, SnackbarColor.Success));
            }
        }


        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleAddDataAction(TranslationsAddAction action, IDispatcher dispatcher)
        {
            try
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
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                return;
            }


            dispatcher.Dispatch(new NotificationAction(action.DataAddedMessage, SnackbarColor.Success));
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

            var returnCode = HttpStatusCode.OK;
            try
            {
                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new TranslationsFetchDataResultAction(
                    rootObject: translationResult ?? new RootObject<ResultBaseTranslation>(),
                    httpStatusCode: returnCode
                ));

            if (returnCode != HttpStatusCode.BadRequest)
            {
                dispatcher.Dispatch(new NotificationAction(action.DataLoadedMessage, SnackbarColor.Success));
            }
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetch4EditAction(TranslationsFetch4EditAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            var url = $"{Const.Translations}{action.TranslationId}/";
            var translation = new Translation();
            try
            {
                translation = await _httpClient.GetFromJsonAsync<Translation>(url, Const.HttpClientOptions);
            }
            catch (Exception eTrans)
            {
                dispatcher.Dispatch(
                    new NotificationAction(eTrans.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }
            if (translation is null) translation = new Translation();
            translation.CheckNulls();


            ResultBaseTranslation? baseTermResult = null;
            try
            {
                if (translation is not null)
                {
                    url = $"{Const.BaseTerms}{translation.BaseTermId}/";
                    baseTermResult =
                        await _httpClient.GetFromJsonAsync<ResultBaseTranslation>(url, Const.HttpClientOptions);
                }
            }
            catch (Exception eBase)
            {
                dispatcher.Dispatch(
                    new NotificationAction(eBase.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }


            var comments = new RootObject<Comment>();

            try
            {
                if (!string.IsNullOrEmpty(action.Token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Token", action.Token);
                    url = $"{Const.Comments}?translation_id={action.TranslationId}";
                    comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url, Const.HttpClientOptions);
                }
            }
            catch (Exception eComments)
            {
                dispatcher.Dispatch(
                    new NotificationAction(eComments.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            var links = new RootObject<OriinLink>();
            try
            {
                url = $"{Const.Links}?translation_id={action.TranslationId}";
                links = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(url, Const.HttpClientOptions);
            }
            catch (Exception eLinks)
            {
                dispatcher.Dispatch(
                    new NotificationAction(eLinks.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new TranslationsFetch4EditResultAction(
                    translation: translation ?? new Translation(),
                    baseTerm: baseTermResult?.BaseTerm ?? new BaseTerm(),
                    links: links?.Results ?? new System.Collections.Generic.List<OriinLink>(),
                    comments: comments?.Results ?? new System.Collections.Generic.List<Comment>(),
                    httpStatusCode: returnCode)
            );

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.DataLoadedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleAddCommentsAction(TranslationsCommentAddAction action, IDispatcher dispatcher)
        {
            var comments = new RootObject<Comment>();
            var returnCode = HttpStatusCode.OK;
            try
            {
                if (!string.IsNullOrEmpty(action.Token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Token", action.Token);

                    var response = await _httpClient.PostAsJsonAsync(
                        $"{Const.Comments}", action.Comment);

                    _ = await response.Content.ReadFromJsonAsync<Comment>();

                    var url = $"{Const.Comments}?translation_id={action.TranslationId}";
                    comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url, Const.HttpClientOptions);
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(
                    new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new TranslationsFetchCommentsResultAction(
                    comments: comments?.Results ?? new System.Collections.Generic.List<Comment>(),
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.CommentAddedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetchCommentsAction(TranslationsFetchCommentsAction action, IDispatcher dispatcher)
        {
            var comments = new RootObject<Comment>();
            var returnCode = HttpStatusCode.OK;
            try
            {
                if (!string.IsNullOrEmpty(action.Token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Token", action.Token);
                    var url = $"{Const.Comments}?translation_id={action.TranslationId}";
                    comments = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url, Const.HttpClientOptions);
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(
                    new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new TranslationsFetchCommentsResultAction(
                    comments: comments?.Results ?? new System.Collections.Generic.List<Comment>(),
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.CommentsFetchedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetchBaseTermAction(TranslationsFetchBaseTermAction action, IDispatcher dispatcher)
        {
            var url = $"{Const.BaseTerms}{action.BaseTermId}/";
            var returnCode = HttpStatusCode.OK;
            var resBaseTransl = new ResultBaseTranslation();

            try
            {
                resBaseTransl = await _httpClient.GetFromJsonAsync<ResultBaseTranslation>(url, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(
                    new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
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
            resBaseTransl.Translation.CheckNulls();

            resBaseTransl.Translations ??= new System.Collections.Generic.List<Translation> { resBaseTransl.Translation };

            dispatcher.Dispatch(
                new TranslationsFetchBaseTermResultAction(
                    baseTranslation: resBaseTransl,
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.FetchBaseSuccessMessage, SnackbarColor.Success));
        }


        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleFetchOneAction(TranslationsFetchOneAction action, IDispatcher dispatcher)
        {
            var url = $"{Const.BaseTerms}{action.TranslationId}/";

            var returnCode = HttpStatusCode.OK;
            var returnData = new Translation();
            try
            {
                returnData = await _httpClient.GetFromJsonAsync<Translation>(url, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(
                    new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }
            returnData ??= new Translation();
            returnData.CheckNulls();

            dispatcher.Dispatch(
                new TranslationsFetchOneResultAction(
                    translation: returnData,
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.FetchOneSuccessMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        // ReSharper disable once UnusedMember.Global
        public async Task HandleUpdateAction(TranslationsUpdateAction action, IDispatcher dispatcher)
        {
            HttpStatusCode returnCode = HttpStatusCode.BadRequest;
            HttpResponseMessage response = new();
            Translation? returnData = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            try
            {
                response = await _httpClient.PutAsJsonAsync(
                    $"{Const.Translations}{action.TranslationId}/",
                    action.Translation);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(
                    new NotificationAction(e.Message, SnackbarColor.Danger));
            }

            try
            {
                returnData = await response.Content.ReadFromJsonAsync<Translation>();
                returnCode = response.StatusCode;
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(
                    new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            returnData ??= new Translation();
            returnData.CheckNulls();

            dispatcher.Dispatch(
                new TranslationsAddResultAction(
                    translation: returnData ?? new Translation(),
                    resultCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(
                        $"{action.TranslationUpdateMessage}{returnData?.Id}", SnackbarColor.Success));
        }
    }
}