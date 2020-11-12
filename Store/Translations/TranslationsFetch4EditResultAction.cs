using System.Collections.Generic;

using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetch4EditResultAction
    {
        public Translation Translation { get; }
        public BaseTerm BaseTerm { get; }
        public List<OriinLink> Links { get; }
        public List<Comment> Comments { get; }



        public TranslationsFetch4EditResultAction(Translation translation, BaseTerm baseTerm, List<OriinLink> links, List<Comment> comments)
        {
            Translation = translation;
            BaseTerm = baseTerm;
            Links = links;
            Comments = comments;
        }
    }
}
