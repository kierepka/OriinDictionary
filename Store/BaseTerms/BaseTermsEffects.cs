﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Notifications;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsEffects
    {

        private readonly HttpClient _httpClient;

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

            var hasTranslations = string.Empty;
            switch (action.HasTranslations)
            {
                case EnumHasTranslations.WithTranslations:
                    hasTranslations = "true";
                    break;
                case EnumHasTranslations.WithoutTranslations:
                    hasTranslations = "false";
                    break;
                case EnumHasTranslations.None:
                default:
                    break;
            }
            var queryString =
                $"{Const.BaseTerms}?text={action.SearchText}&page={action.SearchPageNr}&per_page={action.ItemsPerPage}&current={currentString}&base_term_language_id={action.BaseTermLangId}&has_translations={hasTranslations}";
            if (action.TranslationLangId != Const.PlLangId) queryString += $"&translation_language_id={action.TranslationLangId}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
                translationResult = await _httpClient.GetFromJsonAsync<RootObject<ResultBaseTranslation>>(
                    queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message));
            }

            dispatcher.Dispatch(new BaseTermsFetchDataResultAction(translationResult ?? new RootObject<ResultBaseTranslation>()));

        }

        [EffectMethod]
        public async Task HandleAddDataAction(BaseTermsAddAction baseTermAction, IDispatcher dispatcher)
        {

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Token", baseTermAction.Token);
                var response = await _httpClient.PostAsJsonAsync(
                    requestUri: $"{Const.BaseTerms}", baseTermAction.BaseTerm);
                var returnData = await response.Content.ReadFromJsonAsync<BaseTerm>();
                dispatcher.Dispatch(new BaseTermsAddResultAction(returnData ?? new BaseTerm()));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message));
            }
        }

        [EffectMethod]
        public async Task HandleFetchOneAction(BaseTermsFetchOneAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.BaseTerms}{action.BaseTermId}/";
            var returnData = await _httpClient.GetFromJsonAsync<ResultBaseTranslation>(url, Const.HttpClientOptions);

            RootObject<OriinLink>? userResult = null;

            if (!(returnData?.BaseTerm is null))
                url = $"{Const.Links}?base_term_id={returnData.BaseTerm.Id}";
            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: url, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message));
            }


            dispatcher.Dispatch(
                new BaseTermsFetchOneResultAction(
                    returnData ?? new ResultBaseTranslation(),
                    links: userResult?.Results ?? new System.Collections.Generic.List<OriinLink>()));
          
        }

        [EffectMethod]
        public async Task HandleFetchOneSlugAction(BaseTermsFetchOneSlugAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.BaseTerms}{action.Slug}/by_slug/";
            ResultBaseTranslation? returnData = new ResultBaseTranslation();
            try
            {
                returnData = await _httpClient.GetFromJsonAsync<ResultBaseTranslation>(url, Const.HttpClientOptions);
            }
            catch (Exception e1)
            {
                dispatcher.Dispatch(new NotificationAction(e1.Message));
            }

            RootObject<OriinLink>? userResult = null;

            if (!(returnData?.BaseTerm is null))
                url = $"{Const.Links}?base_term_id={returnData.BaseTerm.Id}";
            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: url, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message));
            }


            dispatcher.Dispatch(
                new BaseTermsFetchOneResultAction(
                        returnData ?? new ResultBaseTranslation(),
                        links: userResult?.Results ?? new System.Collections.Generic.List<OriinLink>()));
           
        }

        [EffectMethod]
        public async Task HandleUpdateAction(BaseTermsUpdateAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var response = await _httpClient.PutAsJsonAsync(
                $"{Const.BaseTerms}{action.BaseTermId}/",
                action.BaseTerm);

            var returnData = await response.Content.ReadFromJsonAsync<BaseTerm>();


            dispatcher.Dispatch(new BaseTermsUpdateResultAction(returnData ?? new BaseTerm()));
        }

    }
}