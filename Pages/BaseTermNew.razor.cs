
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;

using OriinDic.Models;
using OriinDic.Components;
using OriinDic.Helpers;
using Toolbelt.Blazor.SpeechSynthesis;
using OriinDic.Store.BaseTerms;

namespace OriinDic.Pages
{
    public partial class BaseTermNew : DicBasePage
    {
        public BaseTermNew() : base()
        {

        }

        public BaseTermNew(ISyncLocalStorageService localStorage,
            Toolbelt.Blazor.I18nText.I18nText i18NText
        ) : this()
        {
            LocalStorage = localStorage;
            I18NText = i18NText;
        }


        [Inject]
        private IState<BaseTermsState>? BaseTermsState { get; set; } 
        
        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] SpeechSynthesis? SpeechSynthesis { get; set; }

        private string BaseTermLanguage => BaseLanguage.Name;

        private readonly Language BaseLanguage = new Language { Code = Const.PlLangShortcut, Id = Const.PlLangId, Name = Const.PlLangName, SpecialCharacters = Const.PlSpecialChars };

        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (BaseTermsState?.Value?.BaseTerm is null)
            {
                ShowAlert(MyText.saveError);
                return;
            }
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);
            var baseTerm = BaseTermsState.Value.BaseTerm;

            if (baseTerm != null)
            {
                baseTerm.LanguageId = BaseLanguage.Id;

                Dispatcher?.Dispatch(new BaseTermsAddAction(baseTerm: baseTerm, token: token.AuthToken));
            }
        }

        private void OnSpeechPlClicked()
        {
            if (SpeechSynthesis is null) return;
            if (BaseTermsState?.Value?.BaseTerm is null) return;
            
                var utterance = new SpeechSynthesisUtterance
            {
                Text = BaseTermsState?.Value?.BaseTerm.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis.Speak(utterance);
        }

        private void OnExampleAdd(Example example)
        {
            BaseTermsState?.Value?.BaseTerm.Examples.Add(example.Value);
        }

        private void OnSynonymAdd(Synonym synonym)
        {
            BaseTermsState?.Value?.BaseTerm.Synonyms.Add(synonym.Value);
        }
    }
}