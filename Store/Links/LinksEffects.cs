using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Notifications;

namespace OriinDic.Store.Links
{
    public class LinksEffects
    {
        private readonly HttpClient _httpClient;


        public LinksEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleAddDataAction(LinksAddAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            var response = await _httpClient.PostAsJsonAsync(
                $"{Const.Links}", action.Link);

            var returnData = new OriinLink();
            var returnString = string.Empty;
            if (!(response.Content is null))
            {
                returnData = await response.Content.ReadFromJsonAsync<OriinLink>();
                returnString = response.IsSuccessStatusCode ? string.Empty : response.StatusCode.ToString();
            }


            dispatcher.Dispatch(new LinksAddResultAction(returnData ?? new OriinLink(), returnString));
        }


        [EffectMethod]
        public async Task HandleDeleteAction(LinksDeleteAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            var returnObject = new DeletedObjectResponse
            {
                Deleted = false,
                Detail = "Null response"
            };

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Token", action.Token);
                var response = await _httpClient.DeleteAsync(
                    $"{Const.Links}{action.LinkId}/");

                if (!(response is null))
                {
                    if (response.Content != null)
                        returnObject = await response.Content.ReadFromJsonAsync<DeletedObjectResponse>();
                    if (response.StatusCode == HttpStatusCode.Accepted ||
                        response.StatusCode == HttpStatusCode.NoContent ||
                        response.StatusCode == HttpStatusCode.OK)
                    {
                        if (!(returnObject is null)) 
                            returnObject.Deleted = true;

                        dispatcher.Dispatch(new ShowNotificationAction($"Link: {action.LinkId} - deleted"));
                    }
                    else
                    {
                        if (!(returnObject is null))
                        {
                            returnObject.Deleted = false;
                            dispatcher.Dispatch(new ShowNotificationAction($"Error: {response.StatusCode}"));
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (!(returnObject is null))
                    returnObject.Detail = $"Error {e}";

                dispatcher.Dispatch(new ShowNotificationAction($"Error: {e.Message}"));
            }


            var userResult = new RootObject<OriinLink>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var queryString = Const.Links;

            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new ShowNotificationAction($"Error: {e.Message}"));
            }

            dispatcher.Dispatch(
                new LinksDeleteResultAction(
                    delteResponse: returnObject ?? new DeletedObjectResponse(),
                    rootObject:  userResult ?? new RootObject<OriinLink>()));
        }

        [EffectMethod]
        public async Task HandleFetchBaseTermAction(LinksFetchForBaseTermAction action, IDispatcher dispatcher)
        {
            var userResult = new RootObject<OriinLink>();
            
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var queryString = $"{Const.Links}?base_term_id={action.BaseTermId}";
            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new ShowNotificationAction($"Error: {e.Message}"));
            }

            dispatcher.Dispatch(new LinksFetchForBaseTermResultAction(userResult ?? new RootObject<OriinLink>()));
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(LinksFetchDataAction action, IDispatcher dispatcher)
        {

            var userResult = new RootObject<OriinLink>();
            var queryString = Const.Links;
            if (action.SearchPageNr>0)
                queryString += $"?page={action.SearchPageNr}&per_page={action.ItemsPerPage}";
            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new ShowNotificationAction($"Error: {e.Message}"));
            }

            dispatcher.Dispatch(new LinksFetchDataResultAction(userResult ?? new RootObject<OriinLink>()));
        }

 
    }
}