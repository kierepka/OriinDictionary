using System;
using System.Collections.Generic;
using System.Linq;

using Blazorise;

using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchState
    {
        public IReadOnlyCollection<SearchItem> SearchItems { get; private set; } = (Array.Empty<SearchItem>()).ToList().AsReadOnly();
        public IReadOnlyCollection<LocalPages> LocalPages { get; private set; } = (Array.Empty<LocalPages>()).ToList().AsReadOnly();
        public Language CurrentLanguage1 { get; init; } = new Language();
        public Language CurrentLanguage2 { get; init; } = new Language();
        public int TotalSearchItems { get; private set; } = 0;
        public long TotalPages { get; private set; } = 0;
        public bool ConfirmedResults { get; init; } = false;
        public bool CurrentBaseLangPl { get; init; } = false;
        public string ButtonEnColor { get; private set; } = string.Empty;
        public Color ButtonPlColor { get; private set; } = Color.None;
        public string NoBaseTermName { get; init; } = string.Empty;
        public string NoTranslationName { get; init; } = string.Empty;
        public string NoResults { get; init; } = string.Empty;
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public bool Current { get; init; } = false;
        public long ItemsPerPage { get; init; } = 0;
        public long SearchPageNr { get; init; } = 0;
        public long TranslationLangId { get; init; } = 0;
        public long BaseTermLangId { get; init; } = 0;
        public string SearchText { get; init; } = string.Empty;
        public bool IsLoading { get; init; } = false;
        public bool PaginationShow { get; private set; } = false;

        public SearchState(
            RootObject<ResultBaseTranslation>? rootObject,
            IEnumerable<SearchItem> searchItems,
            IEnumerable<LocalPages> localPages,
            Language currentLanguage1,
            Language currentLanguage2,
            bool confirmedResults,
            bool currentBaseLangPl,
            string buttonEnColor,
            Color buttonPlColor,
            long searchPageNr,
            int totalSearchItems,
            long totalPages,
            long itemsPerPage,
            long translationLangId,
            long baseTermLangId,
            string searchText,
            string noBaseTermName,
            string noTranslationName,
            string noResults,
            bool isLoading,
            bool current,
            bool paginationShow,
            EActionState lastActionState)
        {
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
            SearchItems = searchItems.ToList().AsReadOnly();
            LocalPages = localPages.ToList().AsReadOnly();
            TotalSearchItems = totalSearchItems;
            TotalPages = totalPages;
            Current = current;
            ItemsPerPage = itemsPerPage;
            TranslationLangId = translationLangId;
            BaseTermLangId = baseTermLangId;
            SearchText = searchText;
            IsLoading = isLoading;
            PaginationShow = paginationShow;
            LastActionState = lastActionState;

            if (!(rootObject is null)) UpdateTempData(rootObject);
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
            PaginationShow = false;

            if (dictResult.Pages > 1)
            {
                PaginationShow = true;
                TotalPages = dictResult.Pages;
                var localPages = new List<LocalPages>();
                if (TotalPages > 20)
                {
                    for (var i = 1; i <= 7; ++i) localPages.Add(new LocalPages { Number = i });
                    localPages.Add(new LocalPages { Number = 0 });
                    for (var i = TotalPages - 7; i <= TotalPages; ++i) localPages.Add(new LocalPages { Number = i });
                }
                else
                {
                    for (var i = 1; i <= TotalPages; ++i) localPages.Add(new LocalPages { Number = i });
                }

                LocalPages = localPages.AsReadOnly();
            }

            TotalSearchItems = dictResult.Count;

            var searchItems = new List<SearchItem>();

            if (TotalSearchItems <= 0) return;

            foreach (var dic in dictResult.Results)
            {
                var ltd = new SearchItem();
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

                if (!searchItems.Contains(ltd))
                    searchItems.Add(ltd);
            }


            SearchItems = searchItems.AsReadOnly();
        }
    }
}