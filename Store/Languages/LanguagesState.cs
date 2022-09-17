using OriinDictionary7.Helpers;
using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Languages;

public record LanguagesState
{
    public EActionState LastActionState { get; } = EActionState.Initializing;
    public bool IsLoading { get; }
    public IEnumerable<Language> Languages { get; } = new List<Language>();

    public LanguagesState(bool isLoading, IEnumerable<Language> languages, EActionState lastActionState)
    {
        LastActionState = EActionState.Initializing;
        IsLoading = isLoading;
        Languages = languages ?? Array.Empty<Language>();
        LastActionState = EActionState.Initialized;
    }


    public Language GetLanguage(long langId)

    {
        var retValue = Languages.FirstOrDefault(l => l.Id == langId);
        return retValue ?? new Language { Code = Const.PlLangShortcut, Id = Const.PlLangId, Name = Const.PlLangName, SpecialCharacters = Const.PlSpecialChars };

    }


    public string GetLanguageName(long langId)
    {

        var lang = Languages.FirstOrDefault(l => l.Id == langId);
        return lang is null ? Const.PlLangShortcut : lang.Name;

    }

    public IEnumerable<Language> TranslationLanguages
    {
        get
        {
            return
                Languages.Where(l =>
                    Const.BaseLanguagesList.All(l2 => l2.Id != l.Id)).ToList().AsReadOnly();
        }
    }

}