
using Microsoft.AspNetCore.Components;
using OriinDic.Models;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Store.Languages;
using OriinDic.Store.Search;
using System.Linq;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using Blazorise.DataGrid;

namespace OriinDic.Pages
{
    public partial class Index
    {
        private Language? _currentLanguage1;
        private Language? _currentLanguage2;

        private bool _showAuthorized = false;
        private long _searchPageNr = 1;
        private bool _currentTranslations = true;
        private long _itemsPerPage = Const.DefaultItemsPerPage;

        public Index()
        {
            _currentLanguage1 = new Language { Code = Const.PlLangShortcut, Id = Const.PlLangId, Name = Const.PlLangName, SpecialCharacters = Const.PlSpecialChars };
            _currentLanguage2 = new Language { Code = Const.EnLangShortcut, Id = Const.EnLangId, Name = Const.EnLangName, SpecialCharacters = Const.EnSpecialChars };
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
            if (!(MyText is null)) _currentHeader = MyText.HeaderShowDashboardBase;

            if (!(LocalStorage is null))
            {
                _currentTranslations = LocalStorage.GetItem<bool>(Const.CurrentTranslations);
                _itemsPerPage = LocalStorage.ContainKey(Const.ItemsPerPageKey)
                    ? LocalStorage.GetItem<long>(Const.ItemsPerPageKey)
                    : Const.DefaultItemsPerPage;
            }
            if (!LanguagesState?.Value?.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            await base.OnInitializedAsync();
        }

        private void ButtonSearchClicked()
        {
            GoSearch();
        }


        void OnReadData(DataGridReadDataEventArgs<SearchItem> e)
        {
            var currLang1Id = Const.PlLangId;
            if (!(_currentLanguage1 is null)) currLang1Id = _currentLanguage1.Id;
            var currLang2Id = Const.EnLangId;
            if (!(_currentLanguage2 is null)) currLang2Id = _currentLanguage2.Id;

            _searchPageNr = e.Page;
            Dispatcher?.Dispatch(new SearchPageNrChangeAction(e.Page.ToString(), searchText: SearchText, baseTermLangId: currLang1Id,
                    translationLangId: currLang2Id, itemsPerPage: _itemsPerPage, searchPageNr: _searchPageNr, current: _currentTranslations,
                    MyText?.NoResults ?? string.Empty));

            

        }



        private void ClickedDropdownItem1(object l)
        {
            var langId = (long)l;

            _currentLanguage1 = LanguagesState?.Value.GetLanguage(langId);
            GoSearch();
        }

        private void ClickedDropdownItem2(object l)
        {

            _currentLanguage2 = (Language)l;
            GoSearch();
        }

        private void GoSearch()
        {
            var currLang1Id = Const.PlLangId;
            if (!(_currentLanguage1 is null)) currLang1Id = _currentLanguage1.Id;
            var currLang2Id = Const.EnLangId;
            if (!(_currentLanguage2 is null)) currLang2Id = _currentLanguage2.Id;


            if (Const.BaseLanguagesList.Contains(currLang1Id))
                Dispatcher?.Dispatch(new SearchBaseTermsAction(searchText: SearchText, baseTermLangId: currLang1Id,
                    translationLangId: currLang2Id, searchPageNr: 1, itemsPerPage: _itemsPerPage,
                    current: _currentTranslations, MyText?.NoResults ?? string.Empty));
            else
            {
                Dispatcher?.Dispatch(new SearchTranslationsAction(searchText: SearchText, baseTermLangId: currLang2Id,
                    translationLangId: currLang1Id, searchPageNr: 1, itemsPerPage: _itemsPerPage,
                    current: _currentTranslations, MyText?.NoResults ?? string.Empty));
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
            if (!(_currentLanguage1 is null)) currLang1Id = _currentLanguage1.Id;
            var currLang2Id = Const.EnLangId;
            if (!(_currentLanguage2 is null)) currLang2Id = _currentLanguage2.Id;

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


            Dispatcher?.Dispatch(new SearchPageNrChangeAction(pageActionName, searchText: SearchText, baseTermLangId: currLang1Id,
                    translationLangId: currLang2Id, itemsPerPage: _itemsPerPage, searchPageNr: _searchPageNr, current: _currentTranslations,
                    MyText?.NoResults ?? string.Empty));
        }


        private void SwapLanguages()
        {


            var cl1 = _currentLanguage1;
            _currentLanguage1 = _currentLanguage2;
            _currentLanguage2 = cl1;
            if (!(MyText is null))
            {
                if (_currentLanguage1 is null)
                    _currentHeader = MyText.HeaderShowDashboardBase;
                else
                    if (_currentLanguage1.Id == Const.PlLangId)
                    _currentHeader = MyText.HeaderShowDashboardBase;
                else
                    _currentHeader = MyText.HeaderShowDashboardTrans;
            }
            _showAuthorized = !_showAuthorized;
            StateHasChanged();
            GoSearch();

        }
    }
}