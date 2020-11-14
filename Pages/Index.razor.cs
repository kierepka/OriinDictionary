using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using OriinDic.Components;
using OriinDic.Models;

using System;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Store.Languages;
using OriinDic.Store.Search;
using System.Linq;

namespace OriinDic.Pages
{
    public partial class Index : DicBasePage
    {
        private Language? _currentLanguage1;
        private Language? _currentLanguage2;

        private long _searchPageNr = 1;
        private long _itemsPerPage = Const.DefaultItemsPerPage;
        public Index()
        {
            _currentLanguage1 = new Language { Code = Const.PlLangShortcut, Id = Const.PlLangId, Name = Const.PlLangName, SpecialCharacters = Const.PlSpecialChars };
            _currentLanguage2 = new Language { Code = Const.EnLangShortcut, Id = Const.EnLangId, Name = Const.EnLangName, SpecialCharacters = Const.EnSpecialChars };
        }

        public bool ConfirmedResults { get; set; } = false;
        [Parameter] public string SearchText { get; set; } = string.Empty;

        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private IState<SearchState>? SearchState { get; set; }
        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();
            if (!(LocalStorage is null))
            {
                _itemsPerPage = LocalStorage.ContainKey(Const.ItemsPerPageKey)
                    ? LocalStorage.GetItem<long>(Const.ItemsPerPageKey)
                    : Const.DefaultItemsPerPage;
            }
            if (!LanguagesState?.Value?.Languages?.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

        }

        private void ButtonSearchClicked()
        {
            GoSearch();
        }

        private void ClickedDropdownItem1(object l)
        {
            var langId = (long)l;

            _currentLanguage1 = LanguagesState?.Value.GetLanguage(langId);
            GoSearch();
        }

        private void ClickedDropdownItem2(object l)
        {
            var langId = (long)l;
            _currentLanguage2 = LanguagesState?.Value.GetLanguage(langId);
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
                    current: ConfirmedResults, MyText?.noResults ?? string.Empty));
            else
            {
                Dispatcher?.Dispatch(new SearchTranslationsAction(searchText: SearchText, baseTermLangId: currLang2Id,
                    translationLangId: currLang1Id, searchPageNr: 1, itemsPerPage: _itemsPerPage,
                    current: ConfirmedResults, MyText?.noResults ?? string.Empty));
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
                    translationLangId: currLang2Id,  itemsPerPage: _itemsPerPage, searchPageNr: _searchPageNr,  current: ConfirmedResults, 
                    MyText?.noResults ?? string.Empty));
        }


        private void SwapLanguages()
        {

            var cl1 = _currentLanguage1;
            _currentLanguage1 = _currentLanguage2;
            _currentLanguage2 = cl1;
            StateHasChanged();
            GoSearch();

        }
    }
}