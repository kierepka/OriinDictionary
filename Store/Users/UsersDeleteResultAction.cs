using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersDeleteResultAction
    {
        public DeletedObjectResponse DeleteResponse { get; init; } = new();
        public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;
        
        public UsersDeleteResultAction(DeletedObjectResponse deleteResponse, HttpStatusCode resultCode)
        {
            DeleteResponse = deleteResponse;
            ResultCode = resultCode;
        }
    }
}
