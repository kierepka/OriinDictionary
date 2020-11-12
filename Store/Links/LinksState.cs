using Microsoft.VisualBasic.CompilerServices;

using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksState
    {
        public EActionState LastActionState { get; init; }
        public long BaseTermId { get; init; } = long.MinValue;
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; } = int.MinValue;
        public long ItemsPerPage { get; init; } = long.MinValue;
        public bool IsLoading { get; init; } = false;
        public RootObject<OriinLink> RootObject { get; init; } = new RootObject<OriinLink>();

        public DeletedObjectResponse DeleteResponse { get; init; } = new DeletedObjectResponse();
        public string StatusCode { get; init; } = string.Empty;
        public long LinkId { get; init; } = long.MinValue;
        public OriinLink Link { get; init; } = new OriinLink();


        public LinksState(bool isLoading, int searchPageNr, long itemsPerPage, string token, string statusCode,
            OriinLink link, RootObject<OriinLink> rootObject, DeletedObjectResponse deleteResponse)
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

        public LinksState(long baseTermId, string token, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermId = baseTermId;
            LastActionState = lastActionState;
            Token = token;
        }

    }
}