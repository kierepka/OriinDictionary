using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersEffects
    {
        private readonly HttpClient _httpClient;


        public UsersEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleAddDataAction(UsersAddAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            var response = await _httpClient.PostAsJsonAsync(
                $"{Const.ApiAddUser}", action.User);

            var returnData = new User();
            var returnString = string.Empty;
            if (!(response.Content is null))
            {
                returnData = await response.Content.ReadFromJsonAsync<User>();
                returnString = response.IsSuccessStatusCode ? string.Empty : response.StatusCode.ToString();
            }


            dispatcher.Dispatch(new UsersAddResultAction(returnData ?? new User(), returnString));
        }

        [EffectMethod]
        public async Task HandleAnonymizeDataAction(UsersAnonymizeAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            var response = await _httpClient.PostAsJsonAsync(
                $"{Const.ApiUsers}{action.User.Id}/anonymize/", action.User);

            var returnData = new User();
            var returnString = string.Empty;
            if (!(response.Content is null))
            {
                returnData = await response.Content.ReadFromJsonAsync<User>();
                returnString = response.IsSuccessStatusCode ? string.Empty : response.StatusCode.ToString();
            }


            dispatcher.Dispatch(new UsersAddResultAction(returnData ?? new User(), returnString));
        }

        [EffectMethod]
        public async Task HandleDeleteDataAction(UsersDeleteAction action, IDispatcher dispatcher)
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
                    $"{Const.ApiUsers}{action.UserId}/");

                if (!(response is null))
                {
                    if (response.Content != null)
                        returnObject = await response.Content.ReadFromJsonAsync<DeletedObjectResponse>();
                    if (response.StatusCode == HttpStatusCode.Accepted ||
                        response.StatusCode == HttpStatusCode.NoContent ||
                        response.StatusCode == HttpStatusCode.OK)
                    {
                        if (returnObject != null)
                            returnObject.Deleted = true;
                    }
                    else
                    {
                        if (returnObject != null)
                        {
                            returnObject.Deleted = false;
                            returnObject.Detail = $"Error: {response.StatusCode}";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (returnObject!=null)
                    returnObject.Detail = $"Error {e}";
            }

            dispatcher.Dispatch(new UsersDeleteResultAction(returnObject ?? new DeletedObjectResponse()));
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(UsersFetchDataAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var userResult = new RootObject<User>();
            var queryString =
                $"{Const.ApiUsers}?page={action.SearchPageNr}&per_page={action.ItemsPerPage}";
            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<User>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                var a = e;
            }

            dispatcher.Dispatch(new UsersFetchDataResultAction(userResult ??  new RootObject<User>()));
        }

        [EffectMethod]
        public async Task HandleFetchOneAction(UsersFetchOneAction action, IDispatcher dispatcher)
        {

            var url = $"{Const.ApiUsers}{action.UserId}/";
            var returnData = await _httpClient.GetFromJsonAsync<User>(url, Const.HttpClientOptions);


            dispatcher.Dispatch(new UsersFetchOneResultAction(returnData ?? new User()));
        }


        [EffectMethod]
        public async Task HandleUpdateAction(UsersUpdateAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var response = await _httpClient.PutAsJsonAsync(
                $"{Const.ApiUsers}{action.UserId}/",
                action.User);

            var returnData = await response.Content.ReadFromJsonAsync<User>();


            dispatcher.Dispatch(new UsersUpdateResultAction(returnData ?? new User()));
        }
    }
}