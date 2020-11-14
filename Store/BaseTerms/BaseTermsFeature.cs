using Fluxor;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFeature: Feature<BaseTermsState>
    {
        public override string GetName() => "BaseTerms";

        protected override BaseTermsState GetInitialState() => new BaseTermsState(isLoading: false, current: false, searchPageNr: 0, baseTermLangId: 0,
            translationLangId: 0, baseTermId: 0, itemsPerPage: 0, searchText: string.Empty, token: string.Empty, baseTermSlug: string.Empty,
            rootObject: new Models.RootObject<Models.ResultBaseTranslation>(),
            resultBaseTranslation: new Models.ResultBaseTranslation(), EActionState.Initializing);
    }
}