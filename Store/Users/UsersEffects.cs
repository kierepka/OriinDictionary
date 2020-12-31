using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazorise.Snackbar;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Notifications;

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
            var returnCode = HttpStatusCode.OK;
            HttpResponseMessage? response = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            try
            {
                response = await _httpClient.PostAsJsonAsync(
                    $"{Const.AddUser}", action.User);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            var returnData = new User();
            try
            {
                if (response is not null)
                {
                    returnData = await response.Content.ReadFromJsonAsync<User>();
                    returnCode = response.StatusCode;
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }


            dispatcher.Dispatch(
                new UsersAddResultAction(
                    user: returnData ?? new User(),
                    resultCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.UserAddedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleAnonymizeDataAction(UsersAnonymizeAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            HttpResponseMessage? response = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            try
            {
                response = await _httpClient.PostAsJsonAsync(
                    $"{Const.Users}{action.User.Id}/anonymize/", action.User);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            var returnData = new User();
            try
            {
                if (response is not null)
                {
                    returnData = await response.Content.ReadFromJsonAsync<User>();
                    returnCode = response.StatusCode;
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }


            dispatcher.Dispatch(
                new UsersAnonymizeResultAction(
                    user: returnData ?? new User(),
                    resultCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.UserAnonymizedMessage, SnackbarColor.Success));
        }


        [EffectMethod]
        public async Task HandlePasswordResetAction(UsersPasswordResetAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            HttpResponseMessage? response = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            try
            {
                response = await _httpClient.PostAsJsonAsync(
                    $"{Const.PasswordChange}", action.User);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            if (response is not null) returnCode = response.StatusCode;


            dispatcher.Dispatch(
                new UsersPasswordChangeResultAction(statusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.UserPasswordResetMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandlePasswordChangeAction(UsersPasswordChangeAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            HttpResponseMessage? response = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            try
            {
                response = await _httpClient.PostAsJsonAsync(
                    $"{Const.PasswordChange}", action.User);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            if (response is not null) returnCode = response.StatusCode;


            dispatcher.Dispatch(
                new UsersPasswordChangeResultAction(statusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.UserPasswordChangeMessage, SnackbarColor.Success));
        }
        
        
        [EffectMethod]
        public async Task HandleDeleteDataAction(UsersDeleteAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            HttpResponseMessage? response = null;
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
                response = await _httpClient.DeleteAsync(
                    $"{Const.Users}{action.UserId}/");
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }


            if (response != null)
            {
                try
                {
                    returnObject = await response.Content.ReadFromJsonAsync<DeletedObjectResponse>();

                    if (response.StatusCode == HttpStatusCode.Accepted ||
                        response.StatusCode == HttpStatusCode.NoContent ||
                        response.StatusCode == HttpStatusCode.OK)
                    {
                        if (returnObject != null)
                        {
                            returnObject.Deleted = true;
                            dispatcher.Dispatch(
                                new NotificationAction(action.UserDeleteMessage, SnackbarColor.Success));
                        }
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
                catch (Exception e)
                {
                    dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                    returnCode = HttpStatusCode.BadRequest;
                }
            }

            dispatcher.Dispatch(
                new UsersDeleteResultAction(
                    deleteResponse: returnObject ?? new DeletedObjectResponse(),
                    resultCode: returnCode));
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(UsersFetchDataAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var userResult = new RootObject<User>();

            var queryString =
                $"{Const.Users}?page={action.SearchPageNr}&per_page={action.ItemsPerPage}";

            try
            {
                userResult = await _httpClient.GetFromJsonAsync<RootObject<User>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new UsersFetchDataResultAction(
                    rootObject: userResult ?? new RootObject<User>(),
                    resultCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.UserFetchedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleFetchOneAction(UsersFetchOneAction action, IDispatcher dispatcher)
        {
            var url = $"{Const.Users}{action.UserId}/";
            User? returnData = null;
            var returnCode = HttpStatusCode.OK;

            try
            {
                returnData = await _httpClient.GetFromJsonAsync<User>(url, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }


            dispatcher.Dispatch(
                new UsersFetchOneResultAction(
                    user: returnData ?? new User(),
                    resultCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.UserFetchedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleUpdateAction(UsersUpdateAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            User? returnData = null;
            HttpResponseMessage? response = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            try
            {
                response = await _httpClient.PutAsJsonAsync(
                    $"{Const.Users}{action.UserId}/",
                    action.User);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            if (response is not null)
            {
                try
                {
                    returnData = await response.Content.ReadFromJsonAsync<User>();
                    returnCode = response.StatusCode;
                }
                catch (Exception e)
                {
                    dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                    returnCode = HttpStatusCode.BadRequest;
                }
            }
            
            dispatcher.Dispatch(
                new UsersUpdateResultAction(
                    user: returnData ?? new User(),
                    resultCode: returnCode));
            
            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.UserUpdatedMessage, SnackbarColor.Success));
        }
    }
}