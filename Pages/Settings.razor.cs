using System.Linq;
using System.Threading.Tasks;

using Blazorise;

using Fluxor;

using Microsoft.AspNetCore.Components;
using OriinDic.Helpers;
using OriinDic.Store.Languages;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Settings
    {

        private bool _currentBaseLangPl;
        private bool _isLoading;

        private long _rowsPerPage;
        private int _selectedLanguage;
        private bool _currentTranslations;
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }

        [CascadingParameter] protected Theme? Theme { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _isLoading = true;

            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            if (!(LocalStorage is null))
            {
                _currentBaseLangPl = LocalStorage!.GetItem<bool>(Const.CurrentBaseLangKey);
                _rowsPerPage = LocalStorage.GetItem<int>(Const.ItemsPerPageKey);
                _currentTranslations = LocalStorage.GetItem<bool>(Const.CurrentTranslations);
            }

            if (_currentBaseLangPl) _selectedLanguage = 1;
            if (_rowsPerPage == 0) _rowsPerPage = Const.DefaultItemsPerPage;

            _isLoading = false;
        }


        private void HandleSave()
        {
            _isLoading = true;
            if (!(LocalStorage is null))
            {
                LocalStorage!.SetItem(Const.CurrentBaseLangKey, _selectedLanguage == 1);
                LocalStorage!.SetItem(Const.ItemsPerPageKey, _rowsPerPage);
                LocalStorage!.SetItem(Const.CurrentTranslations, _currentTranslations);
            }


            _isLoading = false;
        }

        void OnThemeEnabledChanged(bool value)
        {
            if (Theme == null)
                return;

            
            Theme.Enabled = value;

            _isLoading = true;
            if (!(LocalStorage is null))
            {
                LocalStorage!.SetItem(Const.ThemeIsEnabled, value );
            }
            _isLoading = false;

            Theme.ThemeHasChanged();

            
        }

        void OnGradientChanged(bool value)
        {
            if (Theme == null)
                return;

            Theme.IsGradient = value;

            _isLoading = true;
            if (!(LocalStorage is null))
            {
                LocalStorage!.SetItem(Const.ThemeIsGradient, value);
            }
            _isLoading = false;

            Theme.ThemeHasChanged();
        }

        void OnRoundedChanged(bool value)
        {
            if (Theme == null)
                return;

            Theme.IsRounded = value;


            _isLoading = true;
            if (!(LocalStorage is null))
            {
                LocalStorage!.SetItem(Const.ThemeIsRounded, value);
            }
            _isLoading = false;

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

            Theme.InputOptions.Color = value;
            Theme.InputOptions.CheckColor = value;
            Theme.InputOptions.SliderColor = value;


            _isLoading = true;
            if (!(LocalStorage is null))
            {
                LocalStorage!.SetItem(Const.ThemePrimaryColor, value);
            }
            _isLoading = false;


            Theme.ThemeHasChanged();
        }
    }
}