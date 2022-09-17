using Blazored.LocalStorage;

using Fluxor;

using OriinDic.Store.Languages;

using System.Net.Http;
using System.Threading.Tasks;


namespace OriinDic.Store
{
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
}