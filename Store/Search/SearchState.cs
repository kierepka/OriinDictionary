using Blazorise;

using OriinDictionary7.Helpers;
using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Search;

public record SearchState
{
    public IReadOnlyCollection<SearchItem> SearchItems { get; private set; } = Array.Empty<SearchItem>().ToList().AsReadOnly();
    public IReadOnlyCollection<LocalPages> LocalPages { get; private set; } = Array.Empty<LocalPages>().ToList().AsReadOnly();
    public Language CurrentLanguage1 { get; } = new();
    public Language CurrentLanguage2 { get; } = new();
    public int TotalSearchItems { get; private set; }
    public long TotalPages { get; private set; }
    public bool ConfirmedResults { get; }
    public bool CurrentBaseLangPl { get; }
    public Color ButtonEnColor { get; private set; } = Color.Info;
    public Color ButtonPlColor { get; private set; } = Color.Default;
    public string NoBaseTermName { get; } = string.Empty;
    public string NoTranslationName { get; } = string.Empty;
    public string NoResults { get; } = string.Empty;
    public EActionState LastActionState { get; } = EActionState.Initializing;
    public bool Current { get; }
    public long ItemsPerPage { get; }
    public long SearchPageNr { get; }
    public long TranslationLangId { get; }
    public long BaseTermLangId { get; }
    public string SearchText { get; } = string.Empty;
    public bool IsLoading { get; }
    public bool PaginationShow { get; private set; }

    public SearchState(
        RootObject<ResultBaseTranslation> rootObject,
        IEnumerable<SearchItem> searchItems,
        IEnumerable<LocalPages> localPages,
        Language currentLanguage1,
        Language currentLanguage2,
        bool confirmedResults,
        bool currentBaseLangPl,
        Color buttonEnColor,
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

        UpdateTempData(rootObject);
        CheckButtonColors();
    }





    private void CheckButtonColors()
    {
        if (CurrentBaseLangPl)
        {
            ButtonPlColor = Color.Primary;
            ButtonEnColor = Color.Light;
        }
        else
        {
            ButtonPlColor = Color.Light;
            ButtonEnColor = Color.Primary;
        }
    }

    private void UpdateTempData(RootObject<ResultBaseTranslation> dictResult)
    {
        PaginationShow = false;
        var searchItems = new List<SearchItem>();

        if (dictResult is not null)
        {
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
            foreach (var dic in dictResult.Results)
            {
                var ltd = new SearchItem();
                if (dic.BaseTerm is not null)
                {
                    ltd.BaseTermId = dic.BaseTerm.Id;
                    ltd.BaseTermSlug = string.IsNullOrEmpty(dic.BaseTerm.Slug)
                        ? NoBaseTermName
                        : dic.BaseTerm.Slug;
                    var baseName = string.IsNullOrEmpty(dic.BaseTerm.Name)
                        ? NoBaseTermName
                        : dic.BaseTerm.Name;
                    ltd.BaseName = baseName.Truncate(Const.ShownCharactersInTable);
                    ltd.BaseNameToolTip = baseName;
                }

                if (dic.Translation is not null)
                {
                    ltd.TranslateId = dic.Translation.Id;
                    var translateName = string.IsNullOrEmpty(dic.Translation.Name)
                        ? NoTranslationName
                        : dic.Translation.Name;
                    ltd.TranslateName = translateName.Truncate(Const.ShownCharactersInTable);
                    ltd.TranslateNameToolTip = translateName;
                }

                if (!searchItems.Contains(ltd))
                    searchItems.Add(ltd);
            }
        }
        else
        {
            TotalSearchItems = 0;
        }
        SearchItems = searchItems.AsReadOnly();
    }
}