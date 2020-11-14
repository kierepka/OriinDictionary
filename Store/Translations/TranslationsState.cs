using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsState
    {
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public ResultBaseTranslation BaseTranslation { get; init; } = new ResultBaseTranslation();
        public Translation Translation { get; init; } = new Translation();
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();
        public List<OriinLink> Links { get; init; } = new List<OriinLink>();
        public List<Comment> Comments { get; init; } = new List<Comment>();
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new RootObject<ResultBaseTranslation>();
        public long BaseTermId { get; init; } = 0;
        public long TranslationId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;
        public string SearchText { get; init; } = string.Empty;
        public long BaseTermLangId { get; init; } = 0;
        public long LangId { get; init; } = 0;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;
        public bool Current { get; init; } = false;
        public bool IsLoading { get; init; } = false;


        public TranslationsState(
            bool current, 
            bool isLoading, 
            string searchText, 
            string token, 
            long translationId,
            long baseTermId,
            long baseTermLangId, 
            long langId,
            long itemsPerPage,
            int searchPageNr,             
            RootObject<ResultBaseTranslation> rootObject,
            ResultBaseTranslation baseTranslation,
            Translation translation,
            BaseTerm baseTerm, 
            List<OriinLink> links, 
            List<Comment> comments,
            EActionState lastActionState)
        {
            LastActionState = EActionState.Initializing;
            Current = current;
            IsLoading = isLoading;
            SearchText = searchText;
            Token = token;
            TranslationId = translationId;
            BaseTermLangId = baseTermLangId;
            LangId = langId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            RootObject = rootObject;
            Translation = translation;
            BaseTerm = baseTerm;
            BaseTermId = baseTermId;
            BaseTranslation = baseTranslation;
            Links = links;
            Comments = comments;
            LastActionState = lastActionState;
        }

    }
}