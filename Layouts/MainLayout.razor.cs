using System.Threading.Tasks;

using Blazored.LocalStorage;

using Blazorise;

using Microsoft.AspNetCore.Components;

using OriinDic.Helpers;

using Text = OriinDic.I18nText.Text;


namespace OriinDic.Layouts
{
    public partial class MainLayout
    {
        private string _currentLanguage = "Language";

        private Text _myText = new();

        RenderFragment customIcon = b =>
                {
                    b.OpenComponent<Image>(0);
                    b.AddAttribute(1, "Source", "favicon-32x32.png");
                    b.CloseComponent();
                };

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private ISyncLocalStorageService? LocalStorage { get; set; }



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

        private async Task EnUiLanguageClicked()
        {
            _currentLanguage = Const.EnLangShortcut;

            LocalStorage?.SetItem(Const.LanguageKey, _currentLanguage);

            if (I18NText is not null)
                await I18NText.SetCurrentLanguageAsync(_currentLanguage.ToLower());
        }

        private async Task PlUiLanguageClicked()
        {
            _currentLanguage = Const.PlLangShortcut;
            if (LocalStorage is not null)
                LocalStorage.SetItem(Const.LanguageKey, _currentLanguage);
            if (I18NText is not null)
                await I18NText.SetCurrentLanguageAsync(_currentLanguage.ToLower());
        }




    }
}