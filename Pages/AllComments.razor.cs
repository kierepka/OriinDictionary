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

        private long _itemsPerPage = Const.DefaultItemsPerPage;

        private bool _reloadData = true;
        private string _token = string.Empty;
        private int _totalComments;

        private Comment? _selectedComment;

        [Inject]
        private IState<CommentsState>? CommentState { get; set; } 
        [Inject]
        private IDispatcher? Dispatcher { get; set; }

        public AllComments()
        {
        }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ReadLocalSettings();
            Dispatcher?.Dispatch(new CommentsFetchDataAction(_token));

        }

        private void OnRowRemoved(Comment comment)
        {
            _selectedComment = comment;

            ReadLocalSettings();
            Dispatcher?.Dispatch(new CommentsDeleteAction(comment.Id, _token));

            UpdateLocalData();
        }


        private void OnReadData(DataGridReadDataEventArgs<Comment> e)
        {
            if (!_reloadData) return;
            ReadLocalSettings();
            Dispatcher?.Dispatch(new CommentsFetchDataAction(_token, e.Page, _itemsPerPage));
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
            if (CommentState?.Value is null) return; 
            _totalComments = CommentState.Value.RootObject.Results.Count;
            // always call StateHasChanged!
            StateHasChanged();
        }

        
    }
}