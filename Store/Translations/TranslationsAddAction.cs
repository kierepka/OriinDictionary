using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public record TranslationsAddAction
    {
        public string Token { get; } = string.Empty;
        public string DataAddedMessage { get; } = string.Empty;
        public Translation Translation { get; } = new();

        public TranslationsAddAction(Translation translation, string token, string dataAddedMessage)
        {
            Token = token;
            DataAddedMessage = dataAddedMessage;
            Translation = translation;
        }
    }
}