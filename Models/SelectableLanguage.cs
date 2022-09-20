namespace OriinDictionary7.Models;

public record SelectableLanguage : Language
{

    public bool Selected { get; set; }

    public SelectableLanguage(Language language, bool selected)
        => (Id, Name, Code, SpecialCharacters, Selected) =
        (language.Id, language.Name, language.Code, language.SpecialCharacters, selected);

}
