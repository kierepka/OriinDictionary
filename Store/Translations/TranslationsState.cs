using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsState
    {
        public EActionState LastActionState { get; }
        public long BaseTermId { get; }
        public long TranslationId { get; }
        public Translation? Translation { get; }
        public BaseTerm? BaseTerm { get; }
        public List<OriinLink>? Links { get; }
        public List<Comment>? Comments { get; }
        public string Token { get; }
        public string SearchText { get; }
        public long BaseTermLangId { get; }
        public long LangId { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool Current { get; }
        public bool IsLoading { get; }
        public RootObject<ResultBaseTranslation>? RootObject { get; }


        public TranslationsState(bool current, bool isLoading, string searchText, string token, long translationId,
            long baseTermLangId, long langId, int searchPageNr, long itemsPerPage,
            RootObject<ResultBaseTranslation>? rootObject, Translation? translation,
            BaseTerm? baseTerm, List<OriinLink>? links, List<Comment>? comments)
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
            Links = links;
            Comments = comments;
            LastActionState = EActionState.Initialized;
        }

        public TranslationsState(long translationId, string token, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            Token = token;
            LastActionState = lastActionState;
        }

        public TranslationsState(List<Comment> comments, EActionState lastActionState)
        {
            IsLoading = false;
            Comments = comments;
            LastActionState = lastActionState;
        }

        public TranslationsState(Translation translation, BaseTerm baseTerm, List<OriinLink> links, List<Comment> comments, EActionState lastActionState)
        {
            IsLoading = false;
            Translation = translation;
            BaseTerm = baseTerm;
            Links = links;
            Comments = comments;
            LastActionState = lastActionState;
        }

        public TranslationsState(Translation translation, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Adding);
            LastActionState = lastActionState;
            
            Translation = translation;
        }

        public TranslationsState(long translationId, Translation translation, string token, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            Translation = translation;
            Token = token;
            LastActionState = lastActionState;
        }

        public TranslationsState(long baseTermId, bool isBaseTermId, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermId = baseTermId;
            LastActionState = lastActionState;
        }

        public TranslationsState(BaseTerm baseTerm, EActionState lastActionState)
        {
            IsLoading = false;
            BaseTerm = baseTerm;
            LastActionState = lastActionState;
        }

        public TranslationsState(long translationId, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            LastActionState = lastActionState;
        }

        public TranslationsState(RootObject<ResultBaseTranslation> rootObject, EActionState lastActionState)
        {
            LastActionState = lastActionState;
            IsLoading = false;
            RootObject = rootObject ?? new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(string searchText, long baseTermLangId, long langId, int searchPageNr, long itemsPerPage, bool current, EActionState lastActionState)
        {
            IsLoading = true;
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            LangId = langId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            LastActionState = lastActionState;
        }
    }
}