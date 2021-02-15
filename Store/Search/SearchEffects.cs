using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazorise.Snackbar;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Notifications;

namespace OriinDic.Store.Search
{
    public class SearchEffects
    {
        private readonly HttpClient _httpClient;

        public SearchEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleSearchPageNrChange(SearchPageNrChangeAction action, IDispatcher dispatcher)
        {
            await HandleSearchTranslationsAction(
                new SearchTranslationsAction(
                    searchText: action.SearchText,
                    baseTermLangId: action.BaseTermLangId, translationLangId: action.TranslationLangId,
                    action.SearchPageNr,
                    itemsPerPage: action.ItemsPerPage, current: action.Current, action.NoResults,
                    action.SearchTranslationMessage), dispatcher);
        }

        [EffectMethod]
        public async Task HandleSearchBaseTermsAction(SearchBaseTermsAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            var currentString = "true";
            if (!action.Current) currentString = "false";
            var translationResult = new RootObject<ResultBaseTranslation>();

            var hasTranslations = action.HasTranslations switch
            {
                EnumHasTranslations.WithTranslations => "true",
                EnumHasTranslations.WithoutTranslations => "false",
                _ => string.Empty
            };

            var queryString =
                $"{Const.BaseTerms}?text={action.SearchText}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}&base_term_language_id={action.BaseTermLangId}&has_translations={hasTranslations}";
            if (action.TranslationLangId != Const.PlLangId)
                queryString += $"&translation_language_id={action.TranslationLangId}";

            try
            {
                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(
                    queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            if (translationResult is null)
            {
                dispatcher.Dispatch(new SearchBaseTermsResultAction(
                    new RootObject<ResultBaseTranslation>(),
                    returnCode: returnCode));
                dispatcher.Dispatch(new NotificationAction(action.NoResults, SnackbarColor.Warning));
                return;
            }

            if (translationResult.Count == 0)
            {
                //no data result
                dispatcher.Dispatch(new NotificationAction(action.NoResults, SnackbarColor.Warning));
            }

            dispatcher.Dispatch(new SearchBaseTermsResultAction(translationResult,
                returnCode: returnCode));
            
            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.SearchBaseTermMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleSearchTranslationsAction(SearchTranslationsAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            var currentString = "true";
            if (!action.Current) currentString = "false";
            var translationResult = new RootObject<ResultBaseTranslation>();
            var queryString =
                $"{Const.Translations}?text={action.SearchText}&language_id={action.TranslationLangId}&base_term_language_id={action.BaseTermLangId}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}";
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

            dispatcher.Dispatch(new SearchTranslationsResultAction(
                translationResult ?? new RootObject<ResultBaseTranslation>(),
                httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.SearchTranslationMessage, SnackbarColor.Success));
        }
    }
}