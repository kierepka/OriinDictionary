using System.Net.Http;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using Fluxor;


namespace OriinDic.Store
{
    public class StoreInitializedEffect : Effect<StoreInitializedAction>
    {
        private readonly HttpClient HttpClient;
        private readonly ISyncLocalStorageService LocalStorage;

        public StoreInitializedEffect(HttpClient httpClient, ISyncLocalStorageService localStorage)
        {
            HttpClient = httpClient;
            LocalStorage = localStorage;
        }

        protected override Task HandleAsync(StoreInitializedAction action, IDispatcher dispatcher)
        {
            //dispatcher.Dispatch(new LanguagesFetchDataStoreAction(LocalStorage));
            //dispatcher.Dispatch(new LanguagesFetchDataAction());
            return Task.CompletedTask;
        }

    }
}