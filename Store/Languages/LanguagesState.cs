using System;
using System.Collections.Generic;
using System.Linq;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public class LanguagesState
    {
        public EActionState LastActionState { get; }
        public bool IsLoading { get; }
        public IEnumerable<Language> Languages { get; }

        public LanguagesState(bool isLoading, IEnumerable<Language> languages, EActionState lastActionState)
        {
            IsLoading = isLoading;
            Languages = languages ?? Array.Empty<Language>();
        }


        public Language GetLanguage(long langId)
        {
            return Languages.FirstOrDefault(l => l.Id == langId);
        }


        public string GetLanguageName(long langId)
        {

            var lang = Languages.FirstOrDefault(l => l.Id == langId);
            return lang is null ? Const.PlLangShortcut : lang.Name;

        }

    }
}