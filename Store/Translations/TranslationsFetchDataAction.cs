namespace OriinDic.Store.Translations
{
    public class TranslationsFetchDataAction
    {
        
        public string SearchText { get; private set; }

        public long BaseTermLangId { get; private set; }
        public long LangId { get; private set; }
        public int SearchPageNr { get; private set; }
        public long ItemsPerPage { get; private set; }

        public bool Current { get; private set; }

        public TranslationsFetchDataAction(string searchText, long baseTermLangId, long langId, int searchPageNr, long itemsPerPage, bool current)
        {
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            LangId = langId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
        }

        
    }
}