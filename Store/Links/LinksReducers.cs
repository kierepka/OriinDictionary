using Fluxor;

namespace OriinDictionary7.Store.Links;

public static class LinksReducers
{

    [ReducerMethod]
    public static LinksState ReduceAddAction(LinksState state, LinksAddAction action) =>
       new(
            isLoading: state.IsLoading,
            searchPageNr: state.SearchPageNr,
            itemsPerPage: state.ItemsPerPage,
            token: action.Token,
            httpStatusCode: state.HttpStatusCode,
            linkId: state.LinkId,
            baseTermId: state.BaseTermId,
            link: action.Link,
            rootObject: state.RootObject,
            deleteResponse: state.DeleteResponse,
            lastActionState: EActionState.Adding);


    [ReducerMethod]
    public static LinksState ReduceAddResultAction(LinksState state, LinksAddResultAction action) =>
        new(
            isLoading: state.IsLoading,
            searchPageNr: state.SearchPageNr,
            itemsPerPage: state.ItemsPerPage,
            token: state.Token,
            httpStatusCode: action.HttpStatusCode,
            linkId: state.LinkId,
            baseTermId: state.BaseTermId,
            link: action.Link,
            rootObject: state.RootObject,
            deleteResponse: state.DeleteResponse,
            lastActionState: EActionState.Added);

    [ReducerMethod]
    public static LinksState ReduceDeleteAction(LinksState state, LinksDeleteAction action) =>
        new(
            isLoading: state.IsLoading,
            searchPageNr: state.SearchPageNr,
            itemsPerPage: state.ItemsPerPage,
            token: state.Token,
            httpStatusCode: state.HttpStatusCode,
            linkId: action.LinkId,
            baseTermId: state.BaseTermId,
            link: state.Link,
            rootObject: state.RootObject,
            deleteResponse: state.DeleteResponse,
            lastActionState: EActionState.Deleting);

    [ReducerMethod]
    public static LinksState ReduceDeleteResultAction(LinksState state, LinksDeleteResultAction action) =>
        new(
            isLoading: state.IsLoading,
            searchPageNr: state.SearchPageNr,
            itemsPerPage: state.ItemsPerPage,
            token: state.Token,
            httpStatusCode: state.HttpStatusCode,
            linkId: state.LinkId,
            baseTermId: state.BaseTermId,
            link: state.Link,
            rootObject: action.RootObject,
            deleteResponse: action.DelteResponse,
            lastActionState: EActionState.Deleted);

    [ReducerMethod]
    public static LinksState ReduceFetchDataAction(LinksState state, LinksFetchDataAction action) =>
        new(
            isLoading: state.IsLoading,
            searchPageNr: action.SearchPageNr,
            itemsPerPage: action.ItemsPerPage,
            token: state.Token,
            httpStatusCode: state.HttpStatusCode,
            linkId: state.LinkId,
            baseTermId: state.BaseTermId,
            link: state.Link,
            rootObject: state.RootObject,
            deleteResponse: state.DeleteResponse,
            lastActionState: EActionState.FetchingData);

    [ReducerMethod]
    public static LinksState ReduceFetchDataResultAction(LinksState state, LinksFetchDataResultAction action) =>
        new(
            isLoading: state.IsLoading,
            searchPageNr: state.SearchPageNr,
            itemsPerPage: state.ItemsPerPage,
            token: state.Token,
            httpStatusCode: state.HttpStatusCode,
            linkId: state.LinkId,
            baseTermId: state.BaseTermId,
            link: state.Link,
            rootObject: action.RootObject,
            deleteResponse: state.DeleteResponse,
            lastActionState: EActionState.FetchedData);

    [ReducerMethod]
    public static LinksState ReduceFetchForBaseTermAction(LinksState state, LinksFetchForBaseTermAction action) =>
        new(
            isLoading: state.IsLoading,
            searchPageNr: state.SearchPageNr,
            itemsPerPage: state.ItemsPerPage,
            token: action.Token,
            httpStatusCode: state.HttpStatusCode,
            linkId: state.LinkId,
            baseTermId: action.BaseTermId,
            link: state.Link,
            rootObject: state.RootObject,
            deleteResponse: state.DeleteResponse,
            lastActionState: EActionState.FetchingData);


    [ReducerMethod]
    public static LinksState ReduceFetchForBaseTermResultAction(LinksState state, LinksFetchForBaseTermResultAction action) =>
        new(
            isLoading: state.IsLoading,
            searchPageNr: state.SearchPageNr,
            itemsPerPage: state.ItemsPerPage,
            token: state.Token,
            httpStatusCode: state.HttpStatusCode,
            linkId: state.LinkId,
            baseTermId: state.BaseTermId,
            link: state.Link,
            rootObject: action.RootObject,
            deleteResponse: state.DeleteResponse,
            lastActionState: EActionState.FetchedData);

}