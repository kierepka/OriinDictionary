
using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public record LinksState
    {
        public EActionState LastActionState { get; } = EActionState.Initializing;
        public long BaseTermId { get; }
        public string Token { get; } = string.Empty;
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool IsLoading { get; }
        
        public HttpStatusCode HttpStatusCode { get; }
        public long LinkId { get; }
        public OriinLink Link { get; } = new();
        public RootObject<OriinLink> RootObject { get; } = new();
        public DeletedObjectResponse DeleteResponse { get; } = new();

        public LinksState(
            bool isLoading, 
            int searchPageNr, 
            long itemsPerPage, 
            string token, 
            HttpStatusCode httpStatusCode,
            long linkId,
            long baseTermId,
            OriinLink link, 
            RootObject<OriinLink> rootObject, 
            DeletedObjectResponse deleteResponse, 
            EActionState lastActionState)
        {
            
            IsLoading = isLoading;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Token = token;
            HttpStatusCode = httpStatusCode;
            Link = link;
            RootObject = rootObject;
            DeleteResponse = deleteResponse;
            LastActionState = lastActionState;
            LinkId = linkId;
            BaseTermId = baseTermId;
        }

  

    }
}