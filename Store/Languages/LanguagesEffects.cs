using Blazorise.Snackbar;

using Fluxor;

using OriinDictionary7.Helpers;
using OriinDictionary7.Models;
using OriinDictionary7.Store.Notifications;

using System.Net.Http.Json;

namespace OriinDictionary7.Store.Languages;

public class LanguagesEffects
{
    private readonly HttpClient _httpClient;

    public LanguagesEffects(HttpClient http)
    {
        _httpClient = http;
    }

    [EffectMethod]
    public async Task HandleFetchDataAction(LanguagesFetchDataAction action, IDispatcher dispatcher)
    {
        if (action.LocalStorage is null)
        {
            return;
        }

        var languages =
            action.LocalStorage.GetItem<List<Language>>(Const.LanguagesKey) ?? new List<Language>();

        if (languages.Count == 0)
        {
            languages = await GetLanguages(dispatcher);
            action.LocalStorage.SetItem(Const.LanguagesKey, languages);
        }
        else
        {
            languages = action.LocalStorage.GetItem<List<Language>>(Const.LanguagesKey);
        }

        dispatcher.Dispatch(new LanguagesFetchDataResultAction(languages));
    }

    /// <summary>
    /// Get all Languages
    /// </summary>
    /// <param name="dispatcher"></param>
    /// <returns></returns>
    private async Task<List<Language>> GetLanguages(IDispatcher dispatcher)
    {
        var languageList = new List<Language>();
        var uriStr = $"{Const.GetLanguages}?page=1&per_page={Const.DefaultItemsPerPage}";
        RootObject<Language>? languageResult;
        try
        {
            languageResult = await _httpClient.GetFromJsonAsync<RootObject<Language>>
                (uriStr, Const.HttpClientOptions);
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
            return languageList;
        }

        if (languageResult is null)
            return new List<Language>();


        if (languageResult.Pages <= 1) return languageResult.Results;

        var pagesCount = languageResult!.Pages + 1;
        for (var i = 1; i < pagesCount; i++)
        {
            uriStr = $"{Const.GetLanguages}?page={i}&per_page={Const.DefaultItemsPerPage}";
            try
            {
                languageResult = await _httpClient.GetFromJsonAsync<RootObject<Language>>
                    (uriStr, Const.HttpClientOptions);
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new NotificationAction(e.Message, SnackbarColor.Danger));
                return languageList;
            }

            if (languageResult is not null) languageList.AddRange(languageResult.Results);
        }


        return languageResult?.Results ?? new List<Language>();
    }
}