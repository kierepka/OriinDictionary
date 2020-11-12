using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;

using OriinDic.Models;
using OriinDic.Components;
using OriinDic.Helpers;
using Toolbelt.Blazor.SpeechSynthesis;
using OriinDic.Store.BaseTerms;
using OriinDic.Store.Languages;

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

        public bool isLoading = false;
        private BaseTerm baseTerm { get; set; } = new BaseTerm();

        private List<OriinLink> Links { get; set; } = new List<OriinLink>();

        [Inject] private IState<BaseTermsState>? BaseTermsState { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] private SpeechSynthesis? SpeechSynthesis { get; set; }

        private string BaseTermLanguage
        {
            get
            {
                if (BaseTermsState?.Value.BaseTerm is null)
                    return Const.PlLangShortcut;

                var retStr = Const.PlLangShortcut;

                if (LocalStorage is null) return retStr;
                if (LanguagesState is null) return retStr;

                return LanguagesState.Value.GetLanguageName(BaseTermsState.Value.BaseTerm.LanguageId);
            }
        }

        public long BaseTermId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            
            if (LanguagesState is null)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());
        }

        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (BaseTermsState?.Value.BaseTerm is null)
            {
                ShowAlert(MyText.saveError);
                return;
            }
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);

            if (baseTerm != null)
            {
                Dispatcher?.Dispatch(new BaseTermsAddAction(baseTerm: baseTerm, token: token.AuthToken));
            }
        }

        private void OnSpeechPlClicked()
        {
            if (SpeechSynthesis is null) return;
            var utterance = new SpeechSynthesisUtterance
            {
                Text = baseTerm.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis.Speak(utterance);
        }

        private void OnExampleAdd(Example example)
        {
            baseTerm?.Examples.Add(example.Value);
        }

        private void OnSynonymAdd(Synonym synonym)
        {
            baseTerm?.Synonyms.Add(synonym.Value);
        }
    }
}