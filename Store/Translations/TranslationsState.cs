using System.Collections.Generic;

using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsState
    {
        public EActionState LastActionState { get; private set; }
        public long BaseTermId { get; private set; } 
        public long TranslationId { get; private set; } 
        public ResultBaseTranslation BaseTranslation { get; private set; } 
        public Translation Translation { get; private set; } 
        public BaseTerm BaseTerm { get; private set; } 
        public List<OriinLink> Links { get; private set; } 
        public List<Comment> Comments { get; private set; } 
        public string Token { get; private set; } 
        public string SearchText { get; private set; } 
        public long BaseTermLangId { get; private set; } 
        public long LangId { get; private set; } 
        public int SearchPageNr { get; private set; } 
        public long ItemsPerPage { get; private set; } 
        public bool Current { get; private set; } 
        public bool IsLoading { get; private set; } 
        public RootObject<ResultBaseTranslation> RootObject { get; private set; } 


        public TranslationsState(bool current, bool isLoading, string searchText, string token, long translationId,
            long baseTermLangId, long langId, int searchPageNr, long itemsPerPage,
            RootObject<ResultBaseTranslation> rootObject, Translation translation,
            BaseTerm baseTerm, List<OriinLink> links, List<Comment> comments)
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

            BaseTranslation = new ResultBaseTranslation();
            BaseTermId = long.MinValue;
        }

        public TranslationsState(long translationId, string token, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            Token = token;
            LastActionState = lastActionState;


            BaseTermId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Translation = new Translation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(List<Comment> comments, EActionState lastActionState)
        {
            IsLoading = false;
            Comments = comments;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            TranslationId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Translation = new Translation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(Translation translation, BaseTerm baseTerm, List<OriinLink> links, List<Comment> comments, EActionState lastActionState)
        {
            IsLoading = false;
            Translation = translation;
            BaseTerm = baseTerm;
            Links = links;
            Comments = comments;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            TranslationId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(Translation translation, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Adding);
            LastActionState = lastActionState;
            Translation = translation;

            BaseTermId = long.MinValue;
            TranslationId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(long translationId, Translation translation, string token, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            Translation = translation;
            Token = token;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(long baseTermId, bool isBaseTermId, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermId = baseTermId;
            LastActionState = lastActionState;

            TranslationId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Translation = new Translation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(BaseTerm baseTerm, EActionState lastActionState)
        {
            IsLoading = false;
            BaseTerm = baseTerm;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            TranslationId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Translation = new Translation();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }


        public TranslationsState(long translationId, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Translation = new Translation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public TranslationsState(RootObject<ResultBaseTranslation> rootObject, EActionState lastActionState)
        {
            LastActionState = lastActionState;
            IsLoading = false;
            RootObject = rootObject ?? new RootObject<ResultBaseTranslation>();

            BaseTermId = long.MinValue;
            TranslationId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Translation = new Translation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            LangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
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

            BaseTermId = long.MinValue;
            TranslationId = long.MinValue;
            BaseTranslation = new ResultBaseTranslation();
            Translation = new Translation();
            BaseTerm = new BaseTerm();
            Links = new List<OriinLink>();
            Comments = new List<Comment>();
            Token = string.Empty;
            RootObject = new RootObject<ResultBaseTranslation>();
        }
    }
}