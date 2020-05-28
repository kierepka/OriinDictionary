using Fluxor;

namespace OriinDic.Store.Translations
{
    public class TranslationsFeature : Feature<TranslationsState>
    {
        public override string GetName() => "Translations";


        protected override TranslationsState GetInitialState() => new TranslationsState(current: false,
            isLoading: false, searchText: string.Empty, token: string.Empty, translationId: 0,
            baseTermLangId: 0, langId: 0, searchPageNr: 0, itemsPerPage: 0,
            rootObject: null, translation: null, baseTerm: null, links: null, comments: null);
    }
}