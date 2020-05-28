using System.Threading.Tasks;

using Blazored.LocalStorage;

using Blazorise;

using Fluxor.Blazor.Web.Components;

using Microsoft.AspNetCore.Components;

namespace OriinDic.Components
{
    public class DicBasePage : FluxorComponent
    {
        public I18nText.Text? MyText;

        public DicBasePage(I18nText.Text? myText = null, Toolbelt.Blazor.I18nText.I18nText? i18NText = null)
        {
            MyText = myText;
            I18NText = i18NText;
        }

        [Inject] protected Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }

        [Inject] protected ISyncLocalStorageService? LocalStorage { get; set; }
        public string CurrentAlert { get; set; } = string.Empty;
        public Alert? MyAlert { get; set; }

        protected override async Task OnInitializedAsync() 
        {
            await base.OnInitializedAsync();

            if (!(I18NText is null))
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
