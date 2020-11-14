using Fluxor;

using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsFeature : Feature<CommentsState>
    {
        public override string GetName() => "Comments";

        protected override CommentsState GetInitialState() => new CommentsState(
            isLoading: false, searchPageNr: 0, itemsPerPage: 0, commentId: 0, translationId: 0,
            token: string.Empty, statusCode: string.Empty,
            comment: new Comment(),
            rootObject: new RootObject<Comment>(),
            deleteResponse: new DeletedObjectResponse(),
            lastActionState: EActionState.Initializing);


    }
}