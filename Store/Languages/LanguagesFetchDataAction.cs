using Blazored.LocalStorage;

namespace OriinDic.Store.Languages
{
    public record LanguagesFetchDataAction
    {
        public ISyncLocalStorageService? LocalStorage { get; }

        public LanguagesFetchDataAction(ISyncLocalStorageService? localStorage)
        {
            LocalStorage = localStorage;
        }
    }
}