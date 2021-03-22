using Blazorise;
using Blazorise.Snackbar;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using OriinDic.Store.Notifications;

using System;
using System.Threading.Tasks;

namespace OriinDic.Components
{
    public partial class PageHeader      : IDisposable
    {

        [Inject] private IActionSubscriber? ActionSubscriber { get; set; }

        private string _currentAlertText = string.Empty;

        [Parameter] public string CurrentAlertText
        {
            get => _currentAlertText;
            set
            {
                _currentAlertText = value;
                if (string.IsNullOrEmpty(_currentAlertText))
                    MyAlert?.Hide();
                else
                {
                    MyAlert?.Show();
                }
            }
        }

        [Parameter] public string CurrentAlertHeader { get; set; } = string.Empty;
        [Parameter] public string CurrentAlertOk { get; set; } = string.Empty;
        [Parameter] public string CurrentAlertCancel { get; set; } = string.Empty;


        [Parameter] public string HeaderText { get; set; } = string.Empty;
        [Parameter] public bool IsLoading { get; set; }
        [Parameter] public string LoadingText { get; set; } = string.Empty;
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        private Snackbar? MyAlert { get; set; } = null;
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        private Alert? MyAlertYesNo { get; set; } = null;
        [Parameter] public EventCallback<long> OnOkEvent { get; set; }
        [Parameter] public EventCallback<long> OnCancelEvent { get; set; }

        private SnackbarStack? _snackbarStack;

        protected override Task OnInitializedAsync()
        {
            ActionSubscriber?.SubscribeToAction<NotificationAction>(this, async action =>
            {
                await _snackbarStack?.PushAsync(
                    action.Text,
                    color: action.SnackbarColor,
                    options: null)!;
                    
            });
            return base.OnInitializedAsync();
        }

        void IDisposable.Dispose()
        {
            base.Dispose();
            // IMPORTANT: Unsubscribe to avoid memory leaks!
            ActionSubscriber?.UnsubscribeFromAllActions(this);
        }

        private async Task OnOk()
        {
            MyAlertYesNo?.Hide();
            if (OnOkEvent.HasDelegate)
                await OnOkEvent.InvokeAsync();
        }

        private async Task OnCancel()
        {
            MyAlertYesNo?.Hide();
            if (OnCancelEvent.HasDelegate)
                await OnCancelEvent.InvokeAsync();
        }
    }
}