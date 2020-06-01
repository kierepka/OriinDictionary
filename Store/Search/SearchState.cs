using System;
using System.Collections.Generic;
using System.Linq;
using Blazorise;
using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchState
    {
        public IReadOnlyCollection<SearchItem> SearchItems { get; private set; }
        public long TotalSearchItems { get; private set; }
        public long TotalPages { get; private set; }
        public IReadOnlyCollection<LocalPages> LocalPages { get; private set; }
        public Language? CurrentLanguage1 { get; private set; }
        public Language? CurrentLanguage2 { get; private set; }
        public bool ConfirmedResults { get; private set; }
        public bool CurrentBaseLangPl { get; private set; }
        public string ButtonEnColor { get; private set; }
        public Color ButtonPlColor { get; private set; }
        public string NoBaseTermName { get; private set; }
        public string NoTranslationName { get; private set; }
        public string NoResults { get; private set; }
        public EActionState LastActionState { get; private set; }
        public bool Current { get; private set; }
        public long ItemsPerPage { get; private set; }
        public long SearchPageNr { get; private set; }
        public long TranslationLangId { get; private set; }
        public long BaseTermLangId { get; private set; }
        public string SearchText { get; private set; }
        public bool IsLoading { get; private set; }
        public bool PaginationShow { get; private set; }

        public SearchState(IEnumerable<SearchItem> searchItems, Language? currentLanguage1, Language? currentLanguage2,
            bool confirmedResults, bool currentBaseLangPl, string buttonEnColor, Color buttonPlColor, long searchPageNr,
            string noBaseTermName, string noTranslationName, string noResults)
        {
            IsLoading = true;
            CurrentLanguage1 = currentLanguage1;
            CurrentLanguage2 = currentLanguage2;
            ConfirmedResults = confirmedResults;
            CurrentBaseLangPl = currentBaseLangPl;
            SearchPageNr = searchPageNr;
            ButtonEnColor = buttonEnColor;
            ButtonPlColor = buttonPlColor;
            NoBaseTermName = noBaseTermName;
            NoTranslationName = noTranslationName;
            NoResults = noResults;
            SearchItems = (searchItems ?? Array.Empty<SearchItem>()).ToList().AsReadOnly();
            CheckButtonColors();
            IsLoading = false;
        }

        public SearchState(string searchText, long baseTermLangId, long translationLangId, long searchPageNr,
            long itemsPerPage, bool current, EActionState lastActionState)
        {
            IsLoading = true;
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            LastActionState = lastActionState;
        }

        public SearchState(SearchState s, string pageActionName)
        {

            
            CurrentLanguage1 = s.CurrentLanguage1;
            CurrentLanguage2 = s.CurrentLanguage2;
            ConfirmedResults = s.ConfirmedResults;
            CurrentBaseLangPl = s.CurrentBaseLangPl;
            ButtonEnColor = s.ButtonEnColor;
            ButtonPlColor = s.ButtonPlColor;
            NoBaseTermName = s.NoBaseTermName;
            NoTranslationName = s.NoTranslationName;
            NoResults = s.NoResults;
            SearchItems = s.SearchItems;
            TotalSearchItems = s.TotalSearchItems;
            TotalPages = s.TotalPages;
            LocalPages = s.LocalPages;
            PaginationShow = s.PaginationShow;

        }
        public SearchState(RootObject<ResultBaseTranslation> rootObject, EActionState lastActionState)
        {
            LastActionState = lastActionState;
            IsLoading = false;
            UpdateTempData(rootObject);
            CheckButtonColors();
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

        private void UpdateTempData(RootObject<ResultBaseTranslation> dictResult)
        {
            if (dictResult is null) return;

            PaginationShow = false;

            if (dictResult.Pages > 1)
            {
                PaginationShow = true;
                TotalPages = dictResult.Pages;
                var localPages = new List<LocalPages>();
                if (TotalPages > 20)
                {
                    for (var i = 1; i <= 7; ++i) localPages.Add(new LocalPages {Number = i});
                    localPages.Add(new LocalPages {Number = 0});
                    for (var i = TotalPages - 7; i <= TotalPages; ++i) localPages.Add(new LocalPages {Number = i});
                }
                else
                {
                    for (var i = 1; i <= TotalPages; ++i) localPages.Add(new LocalPages {Number = i});
                }

                LocalPages = localPages.AsReadOnly();
            }

            TotalSearchItems = dictResult.Count;

            var searchItems = new List<SearchItem>();

            if (TotalSearchItems <= 0) return;
            if (!(dictResult.Results is null))
            {
                foreach (var dic in dictResult.Results)
                {
                    var ltd = new SearchItem();
                    //Console.WriteLine(JsonSerializer.Serialize(dic));
                    if (!(dic.BaseTerm is null))
                    {
                        ltd.BaseTermId = dic.BaseTerm.Id;
                        ltd.BaseTermSlug = string.IsNullOrEmpty(dic.BaseTerm.Slug)
                            ? NoBaseTermName
                            : dic.BaseTerm.Slug;
                        ltd.BaseName = string.IsNullOrEmpty(dic.BaseTerm.Name)
                            ? NoBaseTermName
                            : dic.BaseTerm.Name;
                    }

                    if (!(dic.Translation is null))
                    {
                        ltd.TranslateId = dic.Translation.Id;
                        ltd.TranslateName = string.IsNullOrEmpty(dic.Translation.Name)
                            ? NoTranslationName
                            : dic.Translation.Name;
                    }

                    //Console.WriteLine(JsonSerializer.Serialize(ltd));
                    searchItems.Add(ltd);
                }
            }

            SearchItems = searchItems.AsReadOnly();
        }
    }
}