using System;
using Blazorise;
using Fluxor;

using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchFeature : Feature<SearchState>
    {
        public override string GetName() => "Search";
        protected override SearchState GetInitialState() => new SearchState(searchItems: Array.Empty<SearchItem>(),
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
            currentBaseLangPl: true, confirmedResults: true, buttonPlColor: Color.Light,
            buttonEnColor: string.Empty, 
            noBaseTermName: string.Empty, 
            noTranslationName: string.Empty, 
            noResults: string.Empty,
            searchPageNr: 1);

    }

}