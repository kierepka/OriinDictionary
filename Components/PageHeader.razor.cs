using Blazorise;
using Blazorise.Snackbar;
using Microsoft.AspNetCore.Components;

namespace OriinDic.Components
{
    public partial class PageHeader : ComponentBase
    {

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
        
    }
}