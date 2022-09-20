using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Translations;

public record TranslationsUpdateAction
{
    public long TranslationId { get; }
    public string Token { get; } = string.Empty;
    public Translation Translation { get; } = new();
    public string TranslationUpdateMessage { get; }

    public TranslationsUpdateAction(long translationId, Translation translation,
        string token, string translationUpdateMessage)
    {
        TranslationId = translationId;
        Token = token;
        TranslationUpdateMessage = translationUpdateMessage;
        Translation = translation;
    }
}