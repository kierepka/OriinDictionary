using Blazored.LocalStorage;

namespace OriinDic.Store.Languages
{
    public class LanguagesFetchDataStoreAction
    {
        public ISyncLocalStorageService LocalStorage { get; }

        public LanguagesFetchDataStoreAction(ISyncLocalStorageService localStorage)
        {
            LocalStorage = localStorage;
        }
    }
}