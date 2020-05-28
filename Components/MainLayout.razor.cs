using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Sidebar;
using Microsoft.AspNetCore.Components;
using OriinDic.Helpers;
using Text = OriinDic.I18nText.Text;


namespace OriinDic.Components
{
    public partial class MainLayout : LayoutComponentBase
    {
        private bool _collapseNavMenu = true;

        private string _currentLanguage = "Language";

        private Text _myText = new Text();

        public MainLayout()      : base()
        {
        }

        public MainLayout(Toolbelt.Blazor.I18nText.I18nText i18NText,
            ISyncLocalStorageService localStorage) : this()
        {
            I18NText = i18NText ?? throw new ArgumentNullException(nameof(i18NText));
            LocalStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        }

        [Parameter] public BarDropdownToggle DropDownToggle { get; set; }

        [Inject] private Toolbelt.Blazor.I18nText.I18nText I18NText { get; set; }

        [Inject] private ISyncLocalStorageService LocalStorage { get; set; }

        public BarDropdown MyDropdown { get; set; }
        public Sidebar MySidebar { get; set; }

        private bool Disposed;
        private IDisposable StateSubscription;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await CheckLanguage();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    StateSubscription.Dispose();
                }
                Disposed = true;
            }
        }

        /// <summary>
        ///     Sprawdzenie języków - czy są poprawnie wczytane
        /// </summary>
        /// <returns></returns>
        private async Task CheckLanguage()
        {
            _myText = await I18NText.GetTextTableAsync<Text>(this);
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
            LocalStorage.SetItem(Const.LanguageKey, _currentLanguage);
            await I18NText.SetCurrentLanguageAsync(_currentLanguage.ToLower());
        }

        private async Task PlUiLanguageClicked()
        {
            _currentLanguage = Const.PlLangShortcut;
            LocalStorage.SetItem(Const.LanguageKey, _currentLanguage);
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

        #endregion
    }
}