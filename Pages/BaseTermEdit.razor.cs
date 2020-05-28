using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.BaseTerms;
using OriinDic.Store.Languages;
using Toolbelt.Blazor.SpeechSynthesis;

namespace OriinDic.Pages
{
    public partial class BaseTermEdit : DicBasePage
    {
        private BaseTerm baseTerm;

        public BaseTermEdit() : base()
        {

        }

        public BaseTermEdit(ISyncLocalStorageService localStorage,
            Toolbelt.Blazor.I18nText.I18nText i18NText, 
            SpeechSynthesis speechSynthesis
        ) : this()
        {
            LocalStorage = localStorage;
            I18NText = i18NText;
            SpeechSynthesis = speechSynthesis;
        }
        [Parameter] public long? BaseTermId { get; set; }
        [Parameter] public string BaseTermSlug { get; set; }

        public string Information { get; set; } = string.Empty;
        private string BaseTermLanguage
        {
            get
            {
                if (BaseTermsState.Value.BaseTerm is null)
                    return Const.PlLangShortcut;
                return LocalStorage is null ? Const.PlLangShortcut : LanguagesState.Value.GetLanguageName(BaseTermsState.Value.BaseTerm.LanguageId);
            }
        }

        [Inject] private IState<BaseTermsState> BaseTermsState { get; set; }
        [Inject] private IState<LanguagesState> LanguagesState { get; set; }
        [Inject] private IDispatcher Dispatcher { get; set; }

        private List<OriinLink> Links { get; set; }
        [Inject] SpeechSynthesis? SpeechSynthesis { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (!LanguagesState.Value.Languages.Any())
                Dispatcher.Dispatch(new LanguagesFetchDataAction());

            Dispatcher.Dispatch(BaseTermId is null
                ? new BaseTermsFetchDataAction(slug: BaseTermSlug)
                : new BaseTermsFetchDataAction(baseTermId: BaseTermId.Value));

            BaseTermsState.StateChanged += BaseTermsState_StateChanged;

        }

        private void BaseTermsState_StateChanged(object sender, BaseTermsState e)
        {
            if (BaseTermsState.Value.BaseTerm is null) return;
            baseTerm = BaseTermsState.Value.BaseTerm;
            GetLinks();

            ShowAlert($"{MyText?.translationSaved} {BaseTermsState.Value.BaseTerm.Id}");
        }

        private void GetLinks()
        {
             
        }

        private async Task OnExampleAdd(Example example)
        {
            baseTerm?.Examples.Add(example.Value);
        }

        private async Task OnLinkAdd(OriinLink link)
        {
            //link
        }

        private async Task OnSaveClicked()
        {

            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (BaseTermsState.Value.BaseTerm is null) {
                ShowAlert(MyText.saveError);
                return;
            }
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);
            if (BaseTermId != null)
            {
                Dispatcher?.Dispatch(new BaseTermsUpdateAction(baseTermId: BaseTermId.Value, baseTerm: baseTerm,
                    token: token.AuthToken));
            }

        }

        private void OnSpeechPlClicked()
        {
            if (SpeechSynthesis is null) return;
            var utterance = new SpeechSynthesisUtterance
            {
                Text = baseTerm?.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis.Speak(utterance);
        }
        private async Task OnSynonymAdd(Synonym synonym)
        {
            baseTerm?.Synonyms.Add(synonym.Value);
        }
    }
}