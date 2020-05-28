using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;
using OriinDic.Store.Languages;


namespace OriinDic.Store
{
    public class StoreInitializedEffect : Effect<StoreInitializedAction>
    {
        private readonly HttpClient HttpClient;
        [Inject] protected ISyncLocalStorageService? LocalStorage { get; set; }

        public StoreInitializedEffect(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected override Task HandleAsync(StoreInitializedAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new LanguagesFetchDataStoreAction(LocalStorage));
            return Task.CompletedTask;
        }

    }
}