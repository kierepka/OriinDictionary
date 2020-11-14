using Blazored.LocalStorage;

namespace OriinDic.Store.Languages
{
    public class LanguagesFetchDataStoreAction
    {
        public ISyncLocalStorageService LocalStorage { get; init; } 

        public LanguagesFetchDataStoreAction(ISyncLocalStorageService localStorage)
        {
            LocalStorage = localStorage;
        }
    }
}