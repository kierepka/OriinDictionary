using Blazored.LocalStorage;

using Blazorise;

using Fluxor.Blazor.Web.Components;

using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace OriinDic.Components
{
    public class DicBasePage : FluxorComponent
    {
        protected I18nText.Text? MyText;


        [Inject] protected Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }

        [Inject] protected ISyncLocalStorageService? LocalStorage { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
        protected string CurrentAlert { get; set; } = string.Empty;
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private Alert? MyAlert { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (I18NText is not null)
                MyText = await I18NText.GetTextTableAsync<I18nText.Text>(this);

        }

        protected void ShowAlert(string alert)
        {
            CurrentAlert = alert;
            MyAlert?.Show();
        }

        protected void ShowAlertYesNo(string alertHeader, string alert, string yes, string no)
        {
            CurrentAlert = alert;
            MyAlert?.Show();
        }
    }
}
