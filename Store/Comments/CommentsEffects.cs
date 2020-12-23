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

namespace OriinDic.Store.Comments
{
    public class CommentsEffects
    {
        private readonly HttpClient _httpClient;


        public CommentsEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleAddDataAction(CommentsAddAction action, IDispatcher dispatcher)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var returnCode = HttpStatusCode.OK;
            var response = await _httpClient.PostAsJsonAsync(
                $"{Const.Comments}", action.Comment);

            var returnData = await response.Content.ReadFromJsonAsync<Comment>();
            string returnString = response.IsSuccessStatusCode ? string.Empty : response.StatusCode.ToString();

            var userResult = new RootObject<Comment>();

            try
            {
                userResult = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(
                    requestUri: Const.Comments, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new CommentsAddResultAction(
                    comment: returnData ?? new Comment(),
                    statusCode: returnString,
                    rootObject: userResult ?? new RootObject<Comment>(),
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.AddDataSuccessMessage, SnackbarColor.Success));
        }


        [EffectMethod]
        public async Task HandleDeleteAction(CommentsDeleteAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            HttpResponseMessage? response;


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
                    $"{Const.Comments}{action.CommentId}/");
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
                dispatcher.Dispatch(
                    new CommentsDeleteResultAction(
                        deleteResponse: new DeletedObjectResponse(),
                        rootObject: new RootObject<Comment>(),
                        httpStatusCode: returnCode));

                return;
            }


            try
            {
                returnCode = response.StatusCode;
                returnObject = await response.Content.ReadFromJsonAsync<DeletedObjectResponse>();
                if (response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.NoContent ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    if (returnObject is not null)
                        returnObject.Deleted = true;
                }
                else
                {
                    if (returnObject is not null)
                    {
                        returnObject.Deleted = false;
                        returnObject.Detail = $"Error: {response.StatusCode}";
                    }

                    dispatcher.Dispatch(new NotificationAction($"Error: {response.StatusCode}",
                        SnackbarColor.Danger));
                }
            }
            catch (Exception e)
            {
                if (returnObject is not null)
                    returnObject.Detail = $"Error {e}";
                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
            }

            var userResult = new RootObject<Comment>();

            try
            {
                userResult = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(
                    requestUri: Const.Comments, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
            }

            dispatcher.Dispatch(
                new CommentsDeleteResultAction(
                    deleteResponse: returnObject ?? new DeletedObjectResponse(),
                    rootObject: userResult ?? new RootObject<Comment>(),
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.CommentDeletedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(CommentsFetchDataAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var userResult = new RootObject<Comment>();

            var queryString = Const.Comments;

            if (action.ItemsPerPage != 0 && action.SearchPageNr != 0)
                queryString += $"?page={action.SearchPageNr}&per_page={action.ItemsPerPage}";

            try
            {
                userResult = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new CommentsFetchDataResultAction(
                    userResult ?? new RootObject<Comment>(),
                    httpStatusCode: returnCode));
            
            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.CommentsLoadedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleFetchForTranslationAction(CommentsFetchForTranslationAction action,
            IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            RootObject<Comment>? returnData = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var url = $"{Const.Comments}?translation_id={action.TranslationId}";

            try
            {
                returnData = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(new CommentsFetchForTranslationResultAction(
                returnData ?? new RootObject<Comment>(),
                httpStatusCode: returnCode));
            
            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.FetchedTranslationMessage, SnackbarColor.Success));
        }
    }
}