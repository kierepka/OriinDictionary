using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Fluxor;

using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsEffects
    {
        private readonly HttpClient _httpClient;
        private static readonly System.Text.Json.JsonSerializerOptions _options =
            new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true
            };

        public CommentsEffects(HttpClient http)
        {
            _httpClient = http;
        }

        [EffectMethod]
        public async Task HandleAddDataAction(CommentsAddAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);

            var response = await _httpClient.PostAsJsonAsync(
                $"{Const.ApiComments}", action.Comment);

            var returnData = new Comment();
            var returnString = string.Empty;
            if (!(response.Content is null))
            {
                returnData = await response.Content.ReadFromJsonAsync<Comment>();
                returnString = response.IsSuccessStatusCode ? string.Empty : response.StatusCode.ToString();
            }


            dispatcher.Dispatch(new CommentsAddResultAction(returnData, returnString));
        }


        [EffectMethod]
        public async Task HandleDeleteAction(CommentsDeleteAction action, IDispatcher dispatcher)
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
                    $"{Const.ApiComments}{action.CommentId}/");

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

            dispatcher.Dispatch(new CommentsDeleteResultAction(returnObject));
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(CommentsFetchDataAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Token", action.Token);

            var userResult = new RootObject<Comment>();
            var queryString =
                $"{Const.ApiComments}?page={action.SearchPageNr}&per_page={action.ItemsPerPage}";
            try
            {

                userResult = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(
                    requestUri: queryString,
                    _options);
            }
            catch (Exception e)
            {
                var a = e;
            }

            dispatcher.Dispatch(new CommentsFetchDataResultAction(userResult));
        }


        [EffectMethod]
        public async Task HandleFetchForTranslationAction(CommentsFetchForTranslationAction action, IDispatcher dispatcher)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", action.Token);
            var url= $"{Const.ApiComments}?translation_id={action.TranslationId}";

            
            var returnData = await _httpClient.GetFromJsonAsync<RootObject<Comment>>(url);


            dispatcher.Dispatch(new CommentsFetchForTranslationResultAction(returnData));
        }

 
    }
}