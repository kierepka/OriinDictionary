using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksState
    {
        public EActionState LastActionState { get; }
        public string Token { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool IsLoading { get; }
        public RootObject<OriinLink>? RootObject { get; }

        public DeletedObjectResponse? DeleteResponse { get; }
        public string StatusCode { get; }
        public long LinkId { get; }
        public OriinLink? Link { get; }


        public LinksState(bool isLoading, int searchPageNr, long itemsPerPage, string token, string statusCode,
            OriinLink? link, RootObject<OriinLink>? rootObject, DeletedObjectResponse? deleteResponse)
        {
            LastActionState = EActionState.Initializing;
            IsLoading = isLoading;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Token = token;
            StatusCode = statusCode;
            Link = link;
            RootObject = rootObject;
            DeleteResponse = deleteResponse;
            LastActionState = EActionState.Initialized;
        }

        public LinksState(bool isLoading, RootObject<OriinLink> rootObject, EActionState lastActionState)
        {
            IsLoading = isLoading;
            LastActionState = lastActionState;
            RootObject = rootObject ?? new RootObject<OriinLink>();
        }

        public LinksState(string token, int searchPageNr, long itemsPerPage, EActionState lastActionState)
        {
            IsLoading = true;
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LastActionState = lastActionState;
        }

        public LinksState(int searchPageNr, long itemsPerPage, EActionState lastActionState)
        {
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LastActionState = lastActionState;
        }
        public LinksState(OriinLink link, string token, bool tokenAdd, EActionState lastActionState)
        {
            IsLoading = true;
            Token = token;
            LastActionState = lastActionState;
            Link = link ?? new OriinLink();
        }

        public LinksState(OriinLink link, string statusCode, EActionState lastActionState)
        {
            IsLoading = false;
            StatusCode = statusCode;
            LastActionState = lastActionState;
            Link = link ?? new OriinLink();
        }

        public LinksState(long linkId, EActionState lastActionState)
        {
            IsLoading = true;
            LinkId = linkId;
            LastActionState = lastActionState;
        }


        public LinksState(DeletedObjectResponse deleteResponse, EActionState lastActionState)
        {
            IsLoading = false;
            DeleteResponse = deleteResponse;
            LastActionState = lastActionState;
        }

        public LinksState(RootObject<OriinLink> rootObject, EActionState lastActionState)
        {
            IsLoading = false;
            RootObject = rootObject;
            LastActionState = lastActionState;
        }
    }
}