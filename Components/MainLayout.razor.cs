using System.Threading.Tasks;

using Blazored.LocalStorage;

using Blazorise;
using Blazorise.Sidebar;

using Microsoft.AspNetCore.Components;

using OriinDic.Helpers;

using Text = OriinDic.I18nText.Text;


namespace OriinDic.Components
{
    public partial class MainLayout
    {
        private bool _collapseNavMenu = true;

        private string _currentLanguage = "Language";

        private Text _myText = new Text();


        [Parameter] public BarDropdownToggle DropDownToggle { get; set; } = new BarDropdownToggle();

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private ISyncLocalStorageService? LocalStorage { get; set; }

        [CascadingParameter] protected Theme? Theme { get; set; }
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        private Sidebar MySidebar { get; set; } = new Sidebar();

  
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await CheckLanguage();
        }

 
        /// <summary>
        /// Checking languages - are they proper loaded?
        /// </summary>
        /// <returns></returns>
        private async Task CheckLanguage()
        {
            if (I18NText is null) return;
            _myText = await I18NText.GetTextTableAsync<Text>(this);
            if (LocalStorage is null) return;
            var lang = LocalStorage.GetItem<string>(Const.LanguageKey);

            if (string.IsNullOrEmpty(lang))
            {
                lang = Const.PlLangShortcut;
                LocalStorage.SetItem(Const.LanguageKey, lang);
            }

            _currentLanguage = lang;
        }

        #region menu / UI

        private async Task EnUiLanguageClicked()
        {
            _currentLanguage = Const.EnLangShortcut;

            LocalStorage?.SetItem(Const.LanguageKey, _currentLanguage);

            if (!(I18NText is null))
                await I18NText.SetCurrentLanguageAsync(_currentLanguage.ToLower());
        }

        private async Task PlUiLanguageClicked()
        {
            _currentLanguage = Const.PlLangShortcut;
            if (!(LocalStorage is null))
                LocalStorage.SetItem(Const.LanguageKey, _currentLanguage);
            if (!(I18NText is null))
                await I18NText.SetCurrentLanguageAsync(_currentLanguage.ToLower());
        }

        protected void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }

        private void ToggleSidebar()
        {
            MySidebar.Toggle();
        }

        void OnThemeEnabledChanged(bool value)
        {
            if (Theme == null)
                return;

            Theme.Enabled = value;

            Theme.ThemeHasChanged();
        }

        void OnGradientChanged(bool value)
        {
            if (Theme == null)
                return;

            Theme.IsGradient = value;

            //if ( Theme.GradientOptions == null )
            //    Theme.GradientOptions = new GradientOptions();

            //Theme.GradientOptions.BlendPercentage = 80;

            Theme.ThemeHasChanged();
        }

        void OnRoundedChanged(bool value)
        {
            if (Theme == null)
                return;

            Theme.IsRounded = value;

            Theme.ThemeHasChanged();
        }

        void OnThemeColorChanged(string value)
        {
            if (Theme == null)
                return;

            if (Theme.ColorOptions == null)
                Theme.ColorOptions = new ThemeColorOptions();

            if (Theme.BackgroundOptions == null)
                Theme.BackgroundOptions = new ThemeBackgroundOptions();

            if (Theme.TextColorOptions == null)
                Theme.TextColorOptions = new ThemeTextColorOptions();

            Theme.ColorOptions.Primary = value;
            Theme.BackgroundOptions.Primary = value;
            Theme.TextColorOptions.Primary = value;

            if (Theme.InputOptions == null)
                Theme.InputOptions = new ThemeInputOptions();

            //Theme.InputOptions.Color = value;
            Theme.InputOptions.CheckColor = value;
            Theme.InputOptions.SliderColor = value;

            Theme.ThemeHasChanged();
        }
        #endregion
    }
}