using Blazorise;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDictionary7.Helpers;
using OriinDictionary7.Store.Languages;

namespace OriinDictionary7.Pages;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Settings
{

    private bool _currentBaseLangPl;
    private bool _isLoading;

    private long _rowsPerPage;
    private int _selectedLanguage;
    private bool _currentTranslations;

    private string ThemeColor { get; set; } = string.Empty;

    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    [Inject] private IDispatcher? Dispatcher { get; set; }

    [CascadingParameter] protected Theme? Theme { get; set; }
    private bool ThemeEnabled { get; set; }
    private bool ThemeRounded { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _isLoading = true;

        if (!LanguagesState?.Value.Languages.Any() ?? true)
            Dispatcher?.Dispatch(new LanguagesFetchDataAction(LocalStorage));

        if (LocalStorage is not null)
        {
            _currentBaseLangPl = LocalStorage.GetItem<bool>(Const.CurrentBaseLangKey);
            _rowsPerPage = LocalStorage.GetItem<int>(Const.ItemsPerPageKey);
            _currentTranslations = LocalStorage.GetItem<bool>(Const.CurrentTranslations);

            ThemeColor = LocalStorage.GetItem<string>(Const.ThemePrimaryColor);
            ThemeEnabled = LocalStorage.GetItem<bool>(Const.ThemeIsEnabled);
            ThemeRounded = LocalStorage.GetItem<bool>(Const.ThemeIsRounded);
        }



        UpdateTheme();



        if (_currentBaseLangPl) _selectedLanguage = 1;
        if (_rowsPerPage == 0) _rowsPerPage = Const.DefaultItemsPerPage;

        _isLoading = false;
    }

    private void UpdateTheme()
    {
        if (Theme is null) return;
        if (string.IsNullOrEmpty(ThemeColor)) ThemeColor = Theme.ColorOptions.Primary;
        Theme.Enabled = ThemeEnabled;
        Theme.IsRounded = ThemeRounded;
        Theme.ColorOptions ??= new ThemeColorOptions();

        Theme.BackgroundOptions ??= new ThemeBackgroundOptions();

        Theme.TextColorOptions ??= new ThemeTextColorOptions();

        Theme.ColorOptions.Primary = ThemeColor;
        Theme.BackgroundOptions.Primary = ThemeColor;
        Theme.TextColorOptions.Primary = ThemeColor;

        Theme.InputOptions ??= new ThemeInputOptions();

        Theme.InputOptions.Color = ThemeColor;
        Theme.InputOptions.CheckColor = ThemeColor;
        Theme.InputOptions.SliderColor = ThemeColor;
        Theme.ThemeHasChanged();
    }

    private void HandleSave()
    {
        _isLoading = true;
        if (LocalStorage is null)
        {
            _isLoading = false;
            return;
        }

        LocalStorage!.SetItem(Const.CurrentBaseLangKey, _selectedLanguage == 1);
        LocalStorage!.SetItem(Const.ItemsPerPageKey, _rowsPerPage);
        LocalStorage!.SetItem(Const.CurrentTranslations, _currentTranslations);
        LocalStorage!.SetItem(Const.ThemeIsEnabled, ThemeEnabled);
        LocalStorage!.SetItem(Const.ThemeIsRounded, ThemeRounded);
        LocalStorage!.SetItem(Const.ThemePrimaryColor, ThemeColor);

        UpdateTheme();

        _isLoading = false;


    }

    private void OnThemeEnabledChanged(bool value)
    {
        if (Theme is null)
            return;
        ThemeEnabled = value;
        Theme.Enabled = ThemeEnabled;
        Theme.ThemeHasChanged();
    }

    private void OnRoundedChanged(bool value)
    {
        if (Theme == null)
            return;
        ThemeRounded = value;
        Theme.IsRounded = value;
        Theme.ThemeHasChanged();
    }

    private void OnThemeColorChanged(string value)
    {
        ThemeColor = value;
        UpdateTheme();
    }
}