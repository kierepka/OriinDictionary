using Blazored.LocalStorage;

using Blazorise;

using Microsoft.AspNetCore.Components;
using OriinDic.Components;
using OriinDic.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Store;
using OriinDic.Store.BaseTerms;
using OriinDic.Store.Languages;
using OriinDic.Store.Translations;

namespace OriinDic.Pages
{
    public partial class Index : DicBasePage
    {
        private long _itemsPerPage = Const.DefaultItemsPerPage;

        private long _lastPage = 1;

        private List<LocalPages> _localPages = new List<LocalPages>();

        private int _searchPageNr = 1;

        private bool CurrentBaseLangPl;

        

        private string searchText;

        public Index() : base()
        {
            CurrentLanguage1 = new Language
            {
                Code = Const.PlLangShortcut,
                Id = Const.PlLangId,
                Name = Const.PlLangName
            };
            CurrentLanguage2 = new Language
            {
                Code = Const.EnLangShortcut,
                Id = Const.EnLangId,
                Name = Const.EnLangName
            };
            CurrentTranslation = true;
            CurrentBaseLangPl = true;
        }

        public Index(Toolbelt.Blazor.I18nText.I18nText i18NText,
            ISyncLocalStorageService localStorage) : this()
        {
            I18NText = i18NText ?? throw new ArgumentNullException(nameof(i18NText));
            LocalStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));

        }
        public string ButtonEnColor { get; private set; } = string.Empty;
        public Color ButtonPlColor { get; private set; } = Color.Light;
        public bool CurrentTranslation { get; set; } = true;
        public List<LocalTempDic> DataModels { get; set; }
        public bool PaginationShow { get; set; }
        [Parameter] public string SearchText { get; set; }

        public long TotalLocalTempDic { get; set; }
        [Inject] private IState<BaseTermsState> BaseTermsState { get; set; }

        private Language? CurrentLanguage1 { get; set; }
        private Language? CurrentLanguage2 { get; set; }
        [Inject] private IDispatcher Dispatcher { get; set; }

        private bool isLoading => BaseTermsState.Value.IsLoading || TranslationsState.Value.IsLoading;

        [Inject] private IState<TranslationsState> TranslationsState { get; set; }
        [Inject] private IState<LanguagesState> LanguagesState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
   
            if (!(LocalStorage is null))
            {

                if (LocalStorage.ContainKey(Const.CurrentBaseLangKey))
                    CurrentBaseLangPl = LocalStorage.GetItem<bool>(Const.CurrentBaseLangKey);

                CheckButtonColors();
                _itemsPerPage = LocalStorage.GetItem<long>(Const.ItemsPerPageKey);
            }
            if (_itemsPerPage == 0) _itemsPerPage = 100;

            BaseTermsState.StateChanged += BaseTermsState_StateChanged;
            TranslationsState.StateChanged += TranslationsState_StateChanged;

        }

        private void BaseTermsState_StateChanged(object sender, BaseTermsState e)
        {
            if (e.LastActionState != EActionState.FetchedData) return;

            if (e.RootObject is null)
            {
                if (MyText != null) ShowAlert(MyText.noResults);
                return;
            }

            if (e.RootObject.Results is null)
            {
                if (MyText != null) ShowAlert(MyText.noResults);
                return;
            }

            UpdateTempData(e.RootObject);
        }

        private void CheckButtonColors()
        {
            if (CurrentBaseLangPl)
            {
                ButtonPlColor = Color.Primary;
                ButtonEnColor = "has-background-light";
            }
            else
            {
                ButtonPlColor = Color.Secondary;
                ButtonEnColor = "has-background-primary";
            }
        }

        private async Task GetResults()
        {
            MyAlert?.Hide();
            if (CurrentBaseLangPl)
                await LoadBase();
            else
                await LoadTranslations();
        }

        private async Task LoadBase()
        {

            if (MyText is null) return;
            if (CurrentLanguage1 is null) return;
            if (CurrentLanguage2 is null) return;

            Dispatcher.Dispatch(new BaseTermsFetchDataAction(
                searchText: SearchText,
                baseTermLangId: CurrentLanguage1.Id,
                translationLangId: CurrentLanguage2.Id,
                searchPageNr: _searchPageNr,
                itemsPerPage: _itemsPerPage,
                current: CurrentTranslation));

        }

        private async Task LoadTranslations()
        {

            if (MyText is null) return;
            if (CurrentLanguage1 is null) return;
            if (CurrentLanguage2 is null) return;

            Dispatcher.Dispatch(new TranslationsFetchDataAction(
                searchText: SearchText,
                baseTermLangId: CurrentLanguage1.Id,
                langId: CurrentLanguage2.Id,
                searchPageNr: _searchPageNr,
                itemsPerPage: _itemsPerPage,
                current: CurrentTranslation));


        }

        private async Task OnCurrentTranslationClick(bool value)
        {
            CurrentTranslation = value;
            await UpdateBaseLangAsync();
        }

        private async Task OnItemsPerPageChanged(string value)
        {
            if (LocalStorage is null) return;

            _itemsPerPage = int.Parse(value);
            LocalStorage.SetItem(Const.ItemsPerPageKey, _itemsPerPage);
            await GetResults();
        }

        private async Task OnLangChange1(long langId)
        {
            CurrentBaseLangPl = (langId == Const.PlLangId);

            CurrentLanguage1 = LanguagesState.Value.GetLanguage(langId);
            CheckButtonColors();
            await GetResults();
        }

        private async Task OnLangChange2(long langId)
        {
            CurrentBaseLangPl = (langId != Const.PlLangId);

            CurrentLanguage2 = LanguagesState.Value.GetLanguage(langId);
            CheckButtonColors();
            await GetResults();
        }

        //Pagination clicked
        private async Task OnPageClick(string pageName)
        {
            switch (pageName)
            {
                case "prev":
                    _searchPageNr--;
                    break;

                case "next":
                    _searchPageNr++;
                    break;

                default:
                    _searchPageNr = int.Parse(pageName);
                    break;
            }

            await GetResults();
        }

        //Search text changed
        private async Task OnSearchClick(string value)
        {
            SearchText = value;
            await GetResults();
        }

        private void TranslationsState_StateChanged(object sender, TranslationsState e)
        {
            if (e.LastActionState != EActionState.FetchedData) return;
            if (e.RootObject is null)
            {
                if (MyText != null) ShowAlert(MyText.noResults);
                return;
            }

            if (e.RootObject.Results is null)
            {
                if (MyText != null) ShowAlert(MyText.noResults);
                return;
            }

            UpdateTempData(e.RootObject);
        }
        private async Task UpdateBaseLangAsync()
        {
            if (LocalStorage is null) return;

            LocalStorage.SetItem(Const.CurrentBaseLangKey, CurrentBaseLangPl);
            await GetResults();
        }

        //Update local temp data based on API request
        private void UpdateTempData(RootObject<ResultBaseTranslation> dictResult)
        {
            if (MyText is null) return;

            if (dictResult is null) return;
            
            if (dictResult.Count == 0)
            {
                //brakuje danych
                ShowAlert(MyText.noResults);
                return;
            }

            PaginationShow = false;

            if (dictResult.Pages > 1)
            {
                PaginationShow = true;
                _lastPage = dictResult.Pages;
                _localPages = new List<LocalPages>();
                if (_lastPage > 20)
                {
                    for (var i = 1; i <= 7; ++i) _localPages.Add(new LocalPages { Number = i });
                    _localPages.Add(new LocalPages { Number = 0 });
                    for (var i = _lastPage - 7; i <= _lastPage; ++i) _localPages.Add(new LocalPages { Number = i });
                }
                else
                {
                    for (var i = 1; i <= _lastPage; ++i) _localPages.Add(new LocalPages { Number = i });
                }
            }

            TotalLocalTempDic = dictResult.Count;

            DataModels = new List<LocalTempDic>();

            if (TotalLocalTempDic <= 0) return;
            if (!(dictResult.Results is null))
                foreach (var dic in dictResult.Results)
                {
                    var ltd = new LocalTempDic();
                    //Console.WriteLine(JsonSerializer.Serialize(dic));
                    if (!(dic.BaseTerm is null))
                    {
                        ltd.BaseTermId = dic.BaseTerm.Id;
                        ltd.BaseTermSlug = string.IsNullOrEmpty(dic.BaseTerm.Slug) ? MyText.noBaseTermName : dic.BaseTerm.Slug;
                        ltd.BaseName = string.IsNullOrEmpty(dic.BaseTerm.Name) ? MyText.noBaseTermName : dic.BaseTerm.Name;
                    }

                    if (!(dic.Translation is null))
                    {
                        ltd.TranslateId = dic.Translation.Id;
                        ltd.TranslateName = string.IsNullOrEmpty(dic.Translation.Name) ? MyText.noTranslationName : dic.Translation.Name;
                    }
                    //Console.WriteLine(JsonSerializer.Serialize(ltd));
                    DataModels.Add(ltd);
                }

            ;
        }

        ///Temporary data store
        public class LocalTempDic
        {
            public string? BaseName { get; set; }
            public long? BaseTermId { get; set; }
            public string? BaseTermSlug { get; set; }
            public long? TranslateId { get; set; }
            public string? TranslateName { get; set; }
        }
    }
}