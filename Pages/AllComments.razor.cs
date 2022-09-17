using Blazorise.DataGrid;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDictionary7.Helpers;
using OriinDictionary7.Models;
using OriinDictionary7.Store.Comments;


namespace OriinDictionary7.Pages;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class AllComments
{
    private long _itemsPerPage = Const.DefaultItemsPerPage;

    private bool _reloadData = true;
    private string _token = string.Empty;
    private int _totalComments;

    private Comment? _selectedComment;

    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    [Inject] private IState<CommentsState>? CommentState { get; set; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    [Inject] private IDispatcher? Dispatcher { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        ReadLocalSettings();
    }

    private void OnRowRemoved(Comment comment)
    {
        _selectedComment = comment;

        ReadLocalSettings();
        Dispatcher?.Dispatch(
            new CommentsDeleteAction(
                comment.Id,
                _token,
                MyText?.Deleted ?? string.Empty));

        UpdateLocalData();
    }


    private void OnReadData(DataGridReadDataEventArgs<Comment> e)
    {
        if (!_reloadData) return;
        ReadLocalSettings();
        Dispatcher?.Dispatch(
            new CommentsFetchDataAction(
                _token,
                e.Page,
                _itemsPerPage,
                MyText?.Loaded ?? string.Empty));
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