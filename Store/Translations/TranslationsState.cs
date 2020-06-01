using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsState
    {
        public EActionState LastActionState { get; private set; }
        public long BaseTermId { get; private set; }
        public long TranslationId { get; private set; }
        public Translation? Translation { get; private set; }
        public BaseTerm? BaseTerm { get; private set; }
        public List<OriinLink>? Links { get; private set; }
        public List<Comment>? Comments { get; private set; }
        public string Token { get; private set; }
        public string SearchText { get; private set; }
        public long BaseTermLangId { get; private set; }
        public long LangId { get; private set; }
        public int SearchPageNr { get; private set; }
        public long ItemsPerPage { get; private set; }
        public bool Current { get; private set; }
        public bool IsLoading { get; private set; }
        public RootObject<ResultBaseTranslation>? RootObject { get; private set; }


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