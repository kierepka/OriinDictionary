using System.Threading.Tasks;

using Blazorise.DataGrid;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Comments;


namespace OriinDic.Pages
{
    public partial class AllComments : DicBasePage
    {

        private int _itemsPerPage = Const.DefaultItemsPerPage;

        private bool _reloadData = true;
        private string _token = string.Empty;
        private int _totalComments;

        private Comment? _selectedComment;

        [Inject]
        private IState<CommentsState> CommentState { get; set; }
        [Inject]
        private IDispatcher Dispatcher { get; set; }

        public AllComments()
        {
        }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Dispatcher.Dispatch(new CommentsFetchDataAction());
            ReadLocalSettings();
        }

        private void OnRowRemoved(Comment comment)
        {
            _selectedComment = comment;

            ReadLocalSettings();
            Dispatcher.Dispatch(new CommentsDeleteAction(comment.Id, _token));
            CommentState.StateChanged += CommentState_StateChanged;

            UpdateLocalData();
        }

        private void CommentState_StateChanged(object sender, CommentsState e)
        {
            if (e.DeleteResponse is null) return;
            if (e.DeleteResponse.Deleted)
            {
                ShowAlert(MyText?.youWhereDeleted ?? string.Empty);
                _reloadData = true;
            }
            else
            {
                ShowAlert(MyText?.deletionError ?? $"error! {e.DeleteResponse.Detail}");
            }

        }

        private void OnReadData(DataGridReadDataEventArgs<Comment> e)
        {
            if (!_reloadData) return;
            ReadLocalSettings();
            Dispatcher.Dispatch(new CommentsFetchDataAction(_token, e.Page, _itemsPerPage));
            UpdateLocalData();
            _reloadData = false;
        }

        private void ReadLocalSettings()
        {
            if (LocalStorage is null) return;
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);
            _token = token.AuthToken;

            int? itemsPerPage = LocalStorage.GetItem<int>(Const.ItemsPerPageKey);
            _itemsPerPage = itemsPerPage.Value;
            if (_itemsPerPage == 0) _itemsPerPage = Const.DefaultItemsPerPage;
        }

        private void UpdateLocalData()
        {
            if (CommentState.Value is null) return;
            if (CommentState.Value.RootObject.Results != null) _totalComments = CommentState.Value.RootObject.Results.Count;
            // always call StateHasChanged!
            StateHasChanged();
        }
    }
}