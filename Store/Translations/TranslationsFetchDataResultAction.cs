using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchDataResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; }

        public TranslationsFetchDataResultAction(RootObject<ResultBaseTranslation> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
