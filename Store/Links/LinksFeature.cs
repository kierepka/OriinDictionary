using Fluxor;

using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Links;

public class LinksFeature : Feature<LinksState>
{
    public override string GetName() => "Links";

    protected override LinksState GetInitialState() => new(
        isLoading: false,
        searchPageNr: 0,
        itemsPerPage: 0,
        linkId: 0,
        baseTermId: 0,
        token: string.Empty,
        httpStatusCode: HttpStatusCode.OK,
        link: new OriinLink(),
        rootObject: new RootObject<OriinLink>(),
        deleteResponse: new DeletedObjectResponse(),
        lastActionState: EActionState.Initializing);
}