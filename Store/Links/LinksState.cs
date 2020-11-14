using Microsoft.VisualBasic.CompilerServices;

using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksState
    {
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public long BaseTermId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;
        public bool IsLoading { get; init; } = false;
        public string StatusCode { get; init; } = string.Empty;
        public long LinkId { get; init; } = 0;
        public OriinLink Link { get; init; } = new OriinLink();
        public RootObject<OriinLink> RootObject { get; init; } = new RootObject<OriinLink>();
        public DeletedObjectResponse DeleteResponse { get; init; } = new DeletedObjectResponse();

        public LinksState(
            bool isLoading, 
            int searchPageNr, 
            long itemsPerPage, 
            string token, 
            string statusCode,
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
            StatusCode = statusCode;
            Link = link;
            RootObject = rootObject;
            DeleteResponse = deleteResponse;
            LastActionState = lastActionState;
            LinkId = linkId;
            BaseTermId = baseTermId;
        }

  

    }
}