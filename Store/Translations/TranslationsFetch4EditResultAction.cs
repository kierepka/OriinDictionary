using System.Collections.Generic;

using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetch4EditResultAction
    {
        public Translation Translation { get; init; } = new Translation();
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();
        public List<OriinLink> Links { get; init; } = new List<OriinLink>();
        public List<Comment> Comments { get; init; } = new List<Comment>();



        public TranslationsFetch4EditResultAction(Translation translation, BaseTerm baseTerm, List<OriinLink> links, List<Comment> comments)
        {
            Translation = translation;
            BaseTerm = baseTerm;
            Links = links;
            Comments = comments;
        }
    }
}
