using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.BaseTerms;
using OriinDic.Store.Languages;
using OriinDic.Store.Links;

using Toolbelt.Blazor.SpeechSynthesis;

namespace OriinDic.Pages
{
    public partial class BaseTermEdit : DicBasePage
    {
        
        private Token _token = new Token();

        public BaseTermEdit() : base()
        {
        }

        [Parameter] public long? BaseTermId { get; set; }
        [Parameter] public string? BaseTermSlug { get; set; }

        [Inject] private IState<BaseTermsState>? BaseTermsState { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] SpeechSynthesis? SpeechSynthesis { get; set; }

        private string BaseTermLanguage
        {
            get
            {
                var retValue = Const.PlLangShortcut;
                if (BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm is null)
                    return retValue;

                BaseTerm baseTerm1 = BaseTermsState.Value.ResultBaseTranslation.BaseTerm;
                retValue = LanguagesState?.Value.GetLanguageName(baseTerm1.LanguageId);
                if (string.IsNullOrEmpty(retValue)) retValue = Const.PlLangShortcut;
                return retValue;
            }
        }

        
        
        

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            bool doLangFetch = LanguagesState is null;
            if (LanguagesState != null) doLangFetch = !LanguagesState.Value.Languages.Any();
            if (doLangFetch)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            if (LocalStorage is null) return;

            _token = LocalStorage.GetItem<Token>(Const.TokenKey);

            
            var token = _token?.AuthToken ?? string.Empty;

            Dispatcher?.Dispatch(BaseTermId is null
                ? new BaseTermsFetchOneSlugAction(slug: BaseTermSlug ?? string.Empty, token: token)
                : new BaseTermsFetchOneAction(baseTermId: BaseTermId.Value, token: token));
            

        }


        private void OnExampleAdd(Example example)
        {

            if (BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm is null) return;

            if (BaseTermsState.Value.ResultBaseTranslation.BaseTerm.Examples is null)
                BaseTermsState.Value.ResultBaseTranslation.BaseTerm.Examples = new List<string>();

            BaseTermsState.Value.ResultBaseTranslation.BaseTerm.Examples.Add(example.Value);
        }

        private void OnLinkAdd(OriinLink link)
        {
            if (BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm is null) return;

            link.BaseTermId = BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm.Id;

            var token = _token.AuthToken ?? string.Empty;

            Dispatcher?.Dispatch(new LinksAddAction(link, token));


            Dispatcher?.Dispatch(
                    new LinksFetchForBaseTermAction(link?.BaseTermId ?? 0, token));

        }

        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm is null)
            {
                ShowAlert(MyText.saveError);
                return;
            }

            var bt = BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm;

            var token = LocalStorage.GetItem<Token>(Const.TokenKey);

            if (!(bt is null))
                Dispatcher?.Dispatch(
                    new BaseTermsUpdateAction(baseTermId: bt.Id, baseTerm: bt,
                    token: token.AuthToken));

        }

        private void OnSpeechPlClicked()
        {
            if (SpeechSynthesis is null) return;
            var utterance = new SpeechSynthesisUtterance
            {
                Text = BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm?.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis.Speak(utterance);
        }

        private void OnSynonymAdd(Synonym synonym)
        {

            if (BaseTermsState?.Value.ResultBaseTranslation?.BaseTerm is null) return;
            if (BaseTermsState.Value.ResultBaseTranslation.BaseTerm.Synonyms is null)
                BaseTermsState.Value.ResultBaseTranslation.BaseTerm.Synonyms = new List<string>();

            BaseTermsState.Value.ResultBaseTranslation.BaseTerm.Synonyms.Add(synonym.Value);
        }
    }
}