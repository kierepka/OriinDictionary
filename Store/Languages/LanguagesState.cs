using System;
using System.Collections.Generic;
using System.Linq;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public class LanguagesState
    {
        public EActionState LastActionState { get; private set; }
        public bool IsLoading { get; }
        public IEnumerable<Language> Languages { get; private set; }

        public LanguagesState(bool isLoading, IEnumerable<Language> languages, EActionState lastActionState)
        {
            LastActionState = EActionState.Initializing;
            IsLoading = isLoading;
            Languages = languages ?? Array.Empty<Language>();
            LastActionState = EActionState.Initialized;
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
        
        public IEnumerable<Language> TranslationLanguages
        {
            get
            {
                return
                    Languages.Where(l => 
                        Const.BaseLanguagesList.All(l2 => l2 != l.Id)).ToList().AsReadOnly();
            }
        }

    }
}