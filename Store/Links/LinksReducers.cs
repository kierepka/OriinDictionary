using Fluxor;


namespace OriinDic.Store.Links
{
    public static class LinksReducers
    {

        [ReducerMethod]
        public static LinksState ReduceAddAction(LinksState state, LinksAddAction action) =>
            new LinksState(link: action.Link, token:action.Token, tokenAdd: true, lastActionState: EActionState.Adding);
        
        [ReducerMethod]
        public static LinksState ReduceAddResultAction(LinksState state, LinksAddResultAction action) =>
            new LinksState(link: action.Link, statusCode: action.StatusCode, lastActionState: EActionState.Added);


        [ReducerMethod]
        public static LinksState ReduceDeleteAction(LinksState state, LinksDeleteAction action) =>
            new LinksState(linkId: action.LinkId, lastActionState: EActionState.Deleting);

        [ReducerMethod]
        public static LinksState ReduceDeleteResultAction(LinksState state, LinksDeleteResultAction action) =>
            new LinksState(deleteResponse: action.DelteResponse, lastActionState: EActionState.Deleted);


        [ReducerMethod]
        public static LinksState ReduceFetchDataAction(LinksState state, LinksFetchDataAction action) =>
            new LinksState(
                token: action.Token,
                searchPageNr: action.SearchPageNr,
                itemsPerPage: action.ItemsPerPage,
                lastActionState: EActionState.FetchingData
                );

        [ReducerMethod]
        public static LinksState ReduceFetchDataResultAction(LinksState state, LinksFetchDataResultAction action) =>
            new LinksState(rootObject: action.RootObject, lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static LinksState ReduceFetchForBaseTermAction(LinksState state, LinksFetchForBaseTermAction action) =>
            new LinksState(
                baseTermId: action.BaseTermId,
                token: action.Token,
                lastActionState: EActionState.FetchingData
                );

        [ReducerMethod]
        public static LinksState ReduceFetchForBaseTermResultAction(LinksState state, LinksFetchForBaseTermResultAction action) =>
            new LinksState(rootObject: action.RootObject, lastActionState: EActionState.FetchedData);


    }
}