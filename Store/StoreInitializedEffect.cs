using Blazored.LocalStorage;

using Fluxor;

using OriinDictionary7.Store.Languages;


namespace OriinDictionary7.Store;

public class StoreInitializedEffect : Effect<StoreInitializedAction>
{
    private readonly HttpClient _httpClient;
    private readonly ISyncLocalStorageService _localStorage;

    public StoreInitializedEffect(HttpClient httpClient, ISyncLocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public override Task HandleAsync(StoreInitializedAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LanguagesFetchDataAction(_localStorage));
        //dispatcher.Dispatch(new LanguagesFetchDataAction());
        return Task.CompletedTask;
    }

}