using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchCommentsResultAction
    {
        public List<Comment> Comments { get; init; } = new List<Comment>();

        public TranslationsFetchCommentsResultAction(List<Comment> comments)
        {
            Comments = comments;
        }
    }
}
