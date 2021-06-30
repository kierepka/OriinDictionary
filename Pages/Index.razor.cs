
using Microsoft.AspNetCore.Components;
using OriinDic.Models;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Store.Languages;
using OriinDic.Store.Search;
using System.Linq;
using System;
using Blazorise;
using Blazorise.DataGrid;

namespace OriinDic.Pages
{
    public partial class Index
    {
        private Language? _currentLanguage1;
        private Language? _currentLanguage2;


        public long CurrentLanguage2Id => _currentLanguage2?.Id ?? Const.EnLangId;

        private Language? _currentLanguage3;

        private bool _showOptionForBaseTerms = true;
        private EnumHasTranslations _optionHasTranslations = EnumHasTranslations.None;
        private long _searchPageNr = 1;
        private bool _currentTranslations = true;
        private long _itemsPerPage = Const.DefaultItemsPerPage;

        [CascadingParameter] protected Theme? Theme { get; set; }

        public Index()
        {
            _currentLanguage1 = new Language { Code = Const.PlLangShortcut, Id = Const.PlLangId, Name = Const.PlLangName, SpecialCharacters = Const.PlSpecialChars };
            _currentLanguage2 = new Language { Code = Const.EnLangShortcut, Id = Const.EnLangId, Name = Const.EnLangName, SpecialCharacters = Const.EnSpecialChars };
            _currentLanguage3 = new Language { Code = Const.PlLangShortcut, Id = Const.PlLangId, Name = Const.PlLangName, SpecialCharacters = Const.PlSpecialChars };
        }

        private string _currentHeader = string.Empty;

        [Parameter] public string SearchText { get; set; } = string.Empty;
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<SearchState>? SearchState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (MyText is not null)
                _currentHeader = MyText.HeaderShowDashboardBase;

            if (LocalStorage is not null)
            {
                _currentTranslations = LocalStorage.GetItem<bool>(Const.CurrentTranslations);
                _itemsPerPage = LocalStorage.ContainKey(Const.ItemsPerPageKey)
                    ? LocalStorage.GetItem<long>(Const.ItemsPerPageKey)
                    : Const.DefaultItemsPerPage;
                UpdateTheme();


            }
            if (!LanguagesState?.Value?.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction(LocalStorage));

            await base.OnInitializedAsync();
        }

        private void UpdateTheme()
        {
            if (Theme is null) return;
            if (LocalStorage is null) return;

            var themeColor = LocalStorage.GetItem<string>(Const.ThemePrimaryColor);
            var themeEnabled = LocalStorage.GetItem<bool>(Const.ThemeIsEnabled);
            var themeRounded = LocalStorage.GetItem<bool>(Const.ThemeIsRounded);


            if (string.IsNullOrEmpty(themeColor)) themeColor = Theme.ColorOptions.Primary;
            Theme.Enabled = themeEnabled;
            Theme.IsRounded = themeRounded;
            Theme.ColorOptions ??= new ThemeColorOptions();

            Theme.BackgroundOptions ??= new ThemeBackgroundOptions();

            Theme.TextColorOptions ??= new ThemeTextColorOptions();

            Theme.ColorOptions.Primary = themeColor;
            Theme.BackgroundOptions.Primary = themeColor;
            Theme.TextColorOptions.Primary = themeColor;

            Theme.InputOptions ??= new ThemeInputOptions();

            Theme.InputOptions.Color = themeColor;
            Theme.InputOptions.CheckColor = themeColor;
            Theme.InputOptions.SliderColor = themeColor;
            Theme.ThemeHasChanged();
        }

        private void ButtonSearchClicked()
        {
            GoSearch();
        }


        private void OnReadData(DataGridReadDataEventArgs<SearchItem> e)
        {
            var currLang1Id = Const.PlLangId;
            if (_currentLanguage1 is not null) currLang1Id = _currentLanguage1.Id;
            var currLang2Id = Const.EnLangId;
            if (_currentLanguage2 is not null) currLang2Id = _currentLanguage2.Id;
            if (_currentLanguage3 is not null)
            {
                currLang1Id = _currentLanguage3.Id;
                if (_currentLanguage3.Id == Const.PlLangId)
                {
                    currLang2Id = Const.EnLangId;
                }
                else
                {
                    currLang2Id = _currentLanguage3.Id;
                }
            }


            _searchPageNr = e.Page;
            Dispatcher?.Dispatch(
                new SearchPageNrChangeAction(e.Page.ToString(), searchText: SearchText, baseTermLangId: currLang1Id,
                    translationLangId: currLang2Id, itemsPerPage: _itemsPerPage, searchPageNr: _searchPageNr, current: _currentTranslations,
                    noResults: MyText?.NoResults ?? string.Empty,
                    searchTranslationMessage: MyText?.Loaded ?? string.Empty));



        }

        private void ClickedTranslationOption(object baseTermOpt)
        {
            EnumHasTranslations enumHasTranslations = (EnumHasTranslations)Convert.ToByte(baseTermOpt);
            _optionHasTranslations = enumHasTranslations;
            GoSearch();

        }

        private void ClickedDropdownItem2(object l)
        {
            _currentLanguage2 = (Language)l;
            GoSearch();
        }

        private void ClickedDropdownItem3(object l)
        {
            _currentLanguage3 = (Language)l;
            GoSearch();
        }

        private void GoSearch()
        {
            if (_currentLanguage1 is null)
            {
                _currentLanguage1 = Const.BaseLanguagesList[0];
            }

            bool goBaseLang = Const.BaseLanguagesList.Contains(_currentLanguage1);

            var currLang1Id = _currentLanguage1.Id;
            var currLang2Id = Const.EnLangId;
            
            if (_currentLanguage2 is not null)
                currLang2Id = _currentLanguage2.Id;

            if (_currentLanguage3 is not null)
            {


                if (_currentLanguage3.Id == Const.PlLangId)
                {
                    currLang2Id = Const.EnLangId;
                    currLang1Id = _currentLanguage3.Id;
                    goBaseLang = true;
                }
                else
                {
                    currLang1Id = Const.PlLangId;
                    currLang2Id = _currentLanguage3.Id;
                    goBaseLang = false;
                }
            }

            if (goBaseLang)
                Dispatcher?.Dispatch(
                    new SearchBaseTermsAction(searchText: SearchText, baseTermLangId: currLang1Id,
                        translationLangId: currLang2Id, searchPageNr: 1, itemsPerPage: _itemsPerPage,
                        current: _currentTranslations, noResults: MyText?.NoResults ?? string.Empty,
                        hasTranslations: _optionHasTranslations, searchBaseTermMessage: MyText?.Loaded ?? string.Empty));
            else
            {
                Dispatcher?.Dispatch(new SearchTranslationsAction(searchText: SearchText, baseTermLangId: currLang1Id,
                    translationLangId: currLang2Id, searchPageNr: 1, itemsPerPage: _itemsPerPage,
                    current: _currentTranslations, noResults: MyText?.NoResults ?? string.Empty,
                    searchTranslationMessage: MyText?.Loaded ?? string.Empty));
            }
        }

        private void GoSearchText(string text)
        {
            SearchText = text;
            GoSearch();
        }

        private void OnKeyboardKey(string k)
        {
            SearchText += k;
        }

        //Pagination clicked
        private void OnPageClick(string pageActionName)
        {
            var currLang1Id = Const.PlLangId;
            if (_currentLanguage1 is not null) currLang1Id = _currentLanguage1.Id;
            var currLang2Id = Const.EnLangId;
            if (_currentLanguage2 is not null) currLang2Id = _currentLanguage2.Id;

            if (_searchPageNr < 1) _searchPageNr = 1;
            switch (pageActionName)
            {
                case Const.PaginationBackName:
                    _searchPageNr--;
                    break;

                case Const.PaginationNextName:
                    _searchPageNr++;
                    break;

                default:
                    _searchPageNr = int.Parse(pageActionName);
                    break;
            }
            if (_searchPageNr < 1) _searchPageNr = 1;


            Dispatcher?.Dispatch(
                new SearchPageNrChangeAction(
                    pageActionName: pageActionName, searchText: SearchText, baseTermLangId: currLang1Id,
                    translationLangId: currLang2Id, itemsPerPage: _itemsPerPage, searchPageNr: _searchPageNr,
                    current: _currentTranslations, noResults: MyText?.NoResults ?? string.Empty,
                    searchTranslationMessage: MyText?.Loaded ?? string.Empty));
        }


        private void SwapLanguages()
        {


            var cl1 = _currentLanguage1;
            _currentLanguage1 = _currentLanguage2;
            _currentLanguage2 = cl1;
            _showOptionForBaseTerms = true;

            if (MyText is not null)
            {
                if (_currentLanguage1 is null)
                {
                    _currentHeader = MyText.HeaderShowDashboardBase;
                }
                else
                {
                    if (_currentLanguage1.Id == Const.PlLangId)
                    {
                        _currentHeader = MyText.HeaderShowDashboardBase;
                    }
                    else
                    {
                        _currentHeader = MyText.HeaderShowDashboardTrans;
                        _showOptionForBaseTerms = false;
                    }
                }
            }

            StateHasChanged();
            GoSearch();

        }
    }
}