using Fluxor;

namespace OriinDic.Store.Translations
{
    public class TranslationsFeature : Feature<TranslationsState>
    {
        public override string GetName() => "Translations";


        protected override TranslationsState GetInitialState() => new TranslationsState(
            current: false,
            isLoading: false,
            searchText: string.Empty,
            token: string.Empty,
            translationId: 0,
            baseTermId: 0,
            baseTermLangId: 0,
            langId: 0,
            itemsPerPage: 0,
            searchPageNr: 0,
            rootObject: new Models.RootObject<Models.ResultBaseTranslation>(),
            baseTranslation: new Models.ResultBaseTranslation(),
            translation: new Models.Translation(),
            baseTerm: new Models.BaseTerm(),
            links: new System.Collections.Generic.List<Models.OriinLink>(),
            comments: new System.Collections.Generic.List<Models.Comment>(),
            resultCode: System.Net.HttpStatusCode.BadRequest,
            lastActionState: EActionState.Initializing);
    }
}