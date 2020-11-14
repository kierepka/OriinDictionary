using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchDataResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new RootObject<ResultBaseTranslation>();

        public TranslationsFetchDataResultAction(RootObject<ResultBaseTranslation> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
