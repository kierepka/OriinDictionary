using Blazored.LocalStorage;

namespace OriinDictionary7.Store.Languages;

public record LanguagesFetchDataAction
{
    public ISyncLocalStorageService? LocalStorage { get; }

    public LanguagesFetchDataAction(ISyncLocalStorageService? localStorage)
    {
        LocalStorage = localStorage;
    }
}