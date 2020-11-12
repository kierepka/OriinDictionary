using Fluxor;

namespace OriinDic.Store.Links
{
    public class LinksFeature: Feature<LinksState>
    {
        public override string GetName() => "Links";

        protected override LinksState GetInitialState() => new LinksState(isLoading: false, searchPageNr: 0,
            itemsPerPage: 0, token: string.Empty, statusCode: string.Empty,
            link: new Models.OriinLink(), rootObject: new Models.RootObject<Models.OriinLink>(), deleteResponse: new Models.DeletedObjectResponse());
    }
}