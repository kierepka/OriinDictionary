
using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksState
    {
        public EActionState LastActionState { get; private set; }
        public long BaseTermId { get; private set; } 
        public string Token { get; private set; } 
        public int SearchPageNr { get; private set; } 
        public long ItemsPerPage { get; private set; } 
        public bool IsLoading { get; private set; } 
        public RootObject<OriinLink> RootObject { get; private set; } 

        public DeletedObjectResponse DeleteResponse { get; private set; } 
        public string StatusCode { get; private set; } 
        public long LinkId { get; private set; } 
        public OriinLink Link { get; private set; }


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

            BaseTermId = long.MinValue;
            LinkId = long.MinValue;

        }

        public LinksState(bool isLoading, RootObject<OriinLink> rootObject, EActionState lastActionState)
        {
            IsLoading = isLoading;
            LastActionState = lastActionState;
            RootObject = rootObject ?? new RootObject<OriinLink>();

            BaseTermId = long.MinValue;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            DeleteResponse = new DeletedObjectResponse();
            StatusCode = string.Empty;
            LinkId = long.MinValue;
            Link = new OriinLink();
        }

        public LinksState(string token, int searchPageNr, long itemsPerPage, EActionState lastActionState)
        {
            IsLoading = true;
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            RootObject = new RootObject<OriinLink>();
            DeleteResponse = new DeletedObjectResponse();
            StatusCode = string.Empty;
            LinkId = long.MinValue;
            Link = new OriinLink();


        }

        public LinksState(int searchPageNr, long itemsPerPage, EActionState lastActionState)
        {
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            Token = string.Empty;
            IsLoading = false;
            RootObject = new RootObject<OriinLink>();
            DeleteResponse = new DeletedObjectResponse();
            StatusCode = string.Empty;
            LinkId = long.MinValue;
            Link = new OriinLink();

        }
        public LinksState(OriinLink link, string token, bool tokenAdd, EActionState lastActionState)
        {
            IsLoading = true;
            Token = token;
            LastActionState = lastActionState;
            Link = link ?? new OriinLink();

            BaseTermId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            IsLoading = false;
            RootObject = new RootObject<OriinLink>();
            DeleteResponse = new DeletedObjectResponse();
            StatusCode = string.Empty;
            LinkId = long.MinValue;
        }

        public LinksState(OriinLink link, string statusCode, EActionState lastActionState)
        {
            IsLoading = false;
            StatusCode = statusCode;
            LastActionState = lastActionState;
            Link = link ?? new OriinLink();

            BaseTermId = long.MinValue;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            RootObject = new RootObject<OriinLink>();
            DeleteResponse = new DeletedObjectResponse();
            LinkId = long.MinValue;
        }

        

        public LinksState(long linkId, EActionState lastActionState)
        {
            IsLoading = true;
            LinkId = linkId;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            IsLoading = false;
            RootObject = new RootObject<OriinLink>();
            DeleteResponse = new DeletedObjectResponse();
            StatusCode = string.Empty;
            Link = new OriinLink();
        }



        public LinksState(DeletedObjectResponse deleteResponse, EActionState lastActionState)
        {
            IsLoading = false;
            DeleteResponse = deleteResponse;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            IsLoading = false;
            RootObject = new RootObject<OriinLink>();
            StatusCode = string.Empty;
            LinkId = long.MinValue;
            Link = new OriinLink();

        }

        public LinksState(RootObject<OriinLink> rootObject, EActionState lastActionState)
        {
            IsLoading = false;
            RootObject = rootObject;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            DeleteResponse = new DeletedObjectResponse();
            StatusCode = string.Empty;
            LinkId = long.MinValue;
            Link = new OriinLink();
        }

        public LinksState(long baseTermId, string token, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermId = baseTermId;
            LastActionState = lastActionState;
            Token = token;

            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            RootObject = new RootObject<OriinLink>();
            DeleteResponse = new DeletedObjectResponse();
            StatusCode = string.Empty;
            LinkId = long.MinValue;
            Link = new OriinLink();
        }

    }
}