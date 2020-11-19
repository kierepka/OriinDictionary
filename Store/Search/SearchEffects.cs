using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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
            
            if (Const.BaseLanguagesList.Contains(action.BaseTermLangId))
                dispatcher.Dispatch(new SearchBaseTermsAction(searchText: action.SearchText,
                    baseTermLangId: action.BaseTermLangId, translationLangId: action.TranslationLangId, action.SearchPageNr,
                    itemsPerPage: action.ItemsPerPage, current: action.Current, action.NoResults));
            else
            {
                dispatcher.Dispatch(new SearchTranslationsAction(searchText: action.SearchText,
                    baseTermLangId: action.BaseTermLangId, translationLangId: action.TranslationLangId, action.SearchPageNr,
                    itemsPerPage: action.ItemsPerPage, current: action.Current, action.NoResults));
            }
            
            
        }

        [EffectMethod]
        public async Task HandleSearchBaseTermsAction(SearchBaseTermsAction action, IDispatcher dispatcher)
        {

            var currentString = "true";
            if (!action.Current) currentString = "false";
            var translationResult = new RootObject<ResultBaseTranslation>();

            var queryString =
                $"{Const.ApiBaseTerms}?text={action.SearchText}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}&base_term_language_id={action.BaseTermLangId}";
            if (action.TranslationLangId != Const.PlLangId) queryString += $"&translation_language_id={action.TranslationLangId}";

            try
            {

                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(
                                        queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new ShowNotificationAction(e.Message));
            }

            if (translationResult is null)
            {
                dispatcher.Dispatch(new SearchBaseTermsResultAction(new RootObject<ResultBaseTranslation>()));
            }
            else
            {

                if (translationResult.Count == 0)
                {
                    //brakuje danych
                    dispatcher.Dispatch(new ShowNotificationAction(action.NoResults));
                    return;
                }

                dispatcher.Dispatch(new SearchBaseTermsResultAction(translationResult));
            }
            
        }

        [EffectMethod]
        public async Task HandleSearchTranslationsAction(SearchTranslationsAction action, IDispatcher dispatcher)
        {

            var currentString = "true";
            if (!action.Current) currentString = "false";
            var translationResult = new RootObject<ResultBaseTranslation>();
            var queryString =
                $"{Const.ApiTranslations}?text={action.SearchText}&language_id={action.TranslationLangId}&base_term_language_id={action.BaseTermLangId}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}";
            try
            {

                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new ShowNotificationAction(e.ToString())); 
            }

            dispatcher.Dispatch(new SearchTranslationsResultAction(translationResult ?? new RootObject<ResultBaseTranslation>()));
        }


      

    }
}