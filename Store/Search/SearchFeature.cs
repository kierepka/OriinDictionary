﻿using System;

using Blazorise;

using Fluxor;

using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchFeature : Feature<SearchState>
    {
        public override string GetName() => "Search";
        protected override SearchState GetInitialState() =>
            new SearchState(
                rootObject: null,
                searchItems: Array.Empty<SearchItem>(),
                localPages: Array.Empty<LocalPages>(),
                currentLanguage1: new Language
                {
                    Code = Const.PlLangShortcut,
                    Id = Const.PlLangId,
                    Name = Const.PlLangName
                },
                currentLanguage2: new Language
                {
                    Code = Const.EnLangShortcut,
                    Id = Const.EnLangId,
                    Name = Const.EnLangName
                },
                confirmedResults: true,
                currentBaseLangPl: true,
                buttonEnColor: string.Empty,
                buttonPlColor: Color.Light,
                searchPageNr:1,
                totalSearchItems: 0,
                totalPages: 0,
                itemsPerPage: 0,
                translationLangId: 0,
                baseTermLangId: 0,
                searchText: string.Empty,
                noBaseTermName: string.Empty,
                noTranslationName: string.Empty,
                noResults: string.Empty,
                isLoading: false,
                current: false,
                paginationShow: false,
                lastActionState: EActionState.Initializing);

    }

}