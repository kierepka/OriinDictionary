using System;
using System.Collections.Generic;
using System.Linq;
using OriinDic.Helpers;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public class LanguagesState
    {
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public bool IsLoading { get; init; } = false;
        public IEnumerable<Language> Languages { get; init; } = new List<Language>();

        public LanguagesState(bool isLoading, IEnumerable<Language> languages, EActionState lastActionState)
        {
            LastActionState = EActionState.Initializing;
            IsLoading = isLoading;
            Languages = languages ?? Array.Empty<Language>();
            LastActionState = EActionState.Initialized;
        }


        public Language GetLanguage(long langId)

        { 
            var retValue = Languages.FirstOrDefault(l => l.Id == langId);
            return retValue ?? new Language { Code = Const.PlLangShortcut, Id = Const.PlLangId, Name = Const.PlLangName, SpecialCharacters = Const.PlSpecialChars };                

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