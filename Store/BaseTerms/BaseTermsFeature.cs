using Fluxor;

namespace OriinDictionary7.Store.BaseTerms;

public class BaseTermsFeature : Feature<BaseTermsState>
{
    public override string GetName() => "BaseTerms";

    protected override BaseTermsState GetInitialState() =>
        new(
            isLoading: false,
            current: false,
            searchPageNr: 0,
            baseTermLangId: 0,
            translationLangId: 0,
            baseTermId: 0,
            itemsPerPage: 0,
            searchText: string.Empty,
            token: string.Empty,
            baseTermSlug: string.Empty,
            baseTerm: new Models.BaseTerm(),
            rootObject: new Models.RootObject<Models.ResultBaseTranslation>(),
            resultBaseTranslation: new Models.ResultBaseTranslation(),
            links: new List<Models.OriinLink>(),
            lastActionState: EActionState.Initializing);

}