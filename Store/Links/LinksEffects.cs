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
            var returnCode = HttpStatusCode.OK;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            var response = await _httpClient.PostAsJsonAsync(
                $"{Const.Links}", action.Link);
            OriinLink returnData = new();
            try
            {
                returnData = await response.Content.ReadFromJsonAsync<OriinLink>() ?? new OriinLink();
                returnCode = response.StatusCode;
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(new LinksAddResultAction(returnData, returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.LinksAddedMessage, SnackbarColor.Success));
        }


        [EffectMethod]
        public async Task HandleDeleteAction(LinksDeleteAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
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

                returnObject = await response.Content.ReadFromJsonAsync<DeletedObjectResponse>();
                returnCode = response.StatusCode;
                if (response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.NoContent ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    if (returnObject is not null)
                        returnObject.Deleted = true;

                    dispatcher.Dispatch(new NotificationAction($"Link: {action.LinkId} - deleted", SnackbarColor.Info));
                }
                else
                {
                    if (returnObject is not null)
                    {
                        returnObject.Deleted = false;
                        dispatcher.Dispatch(new NotificationAction($"Error: {response.StatusCode}",
                            SnackbarColor.Danger));
                    }
                }
            }
            catch (Exception e)
            {
                if (returnObject is not null)
                    returnObject.Detail = $"Error {e}";

                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }


            var userResult = new RootObject<OriinLink>();

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "Token", action.Token);



            try
            {
                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: Const.Links, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new LinksDeleteResultAction(
                    delteResponse: returnObject ?? new DeletedObjectResponse(),
                    rootObject: userResult ?? new RootObject<OriinLink>(),
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.DeleteLinkMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleFetchBaseTermAction(LinksFetchForBaseTermAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            var userResult = new RootObject<OriinLink>();

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var queryString = $"{Const.Links}?base_term_id={action.BaseTermId}";
            try
            {
                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new LinksFetchForBaseTermResultAction(
                    rootObject: userResult ?? new RootObject<OriinLink>(),
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.LinkFetchedMessage, SnackbarColor.Success));
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(LinksFetchDataAction action, IDispatcher dispatcher)
        {
            var returnCode = HttpStatusCode.OK;
            var userResult = new RootObject<OriinLink>();
            var queryString = Const.Links;
            if (action.SearchPageNr > 0)
                queryString += $"?page={action.SearchPageNr}&per_page={action.ItemsPerPage}";
            try
            {
                userResult = await _httpClient.GetFromJsonAsync<RootObject<OriinLink>>(
                    requestUri: queryString, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction($"Error: {e.Message}", SnackbarColor.Danger));
                returnCode = HttpStatusCode.BadRequest;
            }

            dispatcher.Dispatch(
                new LinksFetchDataResultAction(
                    userResult ?? new RootObject<OriinLink>(),
                    httpStatusCode: returnCode));

            if (returnCode != HttpStatusCode.BadRequest)
                dispatcher.Dispatch(
                    new NotificationAction(action.LinkFetchedMessage, SnackbarColor.Success));
        }
    }
}