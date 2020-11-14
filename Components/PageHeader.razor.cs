using Blazorise;
using Blazorise.Snackbar;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using OriinDic.Store.Notifications;

using System.Threading.Tasks;

namespace OriinDic.Components
{
    public partial class PageHeader : FluxorComponent
    {

        [Inject]
        private IState<NotificationsState>? State { get; set; }
        private string currentAlertText = string.Empty;
        public PageHeader()
        {
        }

        [Parameter]
        public string CurrentAlertText
        {
            get => currentAlertText;
            set
            {
                currentAlertText = value;
                if (string.IsNullOrEmpty(currentAlertText))
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
        public Snackbar? MyAlert { get; set; } = null;
        public Alert? MyAlertYesNo { get; set; } = null;
        [Parameter] public EventCallback<long> OnOkEvent { get; set; }
        [Parameter] public EventCallback<long> OnCancelEvent { get; set; }

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