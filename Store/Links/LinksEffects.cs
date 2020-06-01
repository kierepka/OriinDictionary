using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;

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
                $"{Const.ApiLinks}", action.Link);

            var returnData = new OriinLink();
            var returnString = string.Empty;
            if (!(response.Content is null))
            {
                returnData = await response.Content.ReadFromJsonAsync<OriinLink>();
                returnString = response.IsSuccessStatusCode ? string.Empty : response.StatusCode.ToString();
            }


            dispatcher.Dispatch(new LinksAddResultAction(returnData, returnString));
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
                    $"{Const.ApiLinks}{action.LinkId}/");

                if (!(response is null))
                {
                    if (response.Content != null)
                        returnObject = await response.Content.ReadFromJsonAsync<DeletedObjectResponse>();
                    if (response.StatusCode == HttpStatusCode.Accepted ||
                        response.StatusCode == HttpStatusCode.NoContent ||
                        response.StatusCode == HttpStatusCode.OK)
                    {
                        returnObject.Deleted = true;
                    }
                    else
                    {
                        returnObject.Deleted = false;
                        returnObject.Detail = $"Error: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                returnObject.Detail = $"Error {e}";
            }

            dispatcher.Dispatch(new LinksDeleteResultAction(returnObject));
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(LinksFetchDataAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var userResult = new RootObject<OriinLink>();
            var queryString = Const.ApiLinks;
            if (action.SearchPageNr>0)
                queryString += $"?page={action.SearchPageNr}&per_page={action.ItemsPerPage}";
            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                var a = e;
            }

            dispatcher.Dispatch(new LinksFetchDataResultAction(userResult));
        }


       

 
    }
}