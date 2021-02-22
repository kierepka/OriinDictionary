using Fluxor;
using Microsoft.AspNetCore.Components;

using OriinDic.Models;
using OriinDic.Helpers;
using Toolbelt.Blazor.SpeechSynthesis;
using OriinDic.Store.BaseTerms;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class BaseTermNew
    {



        [Inject]
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private IState<BaseTermsState>? BaseTermsState { get; set; } 
        
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private SpeechSynthesis? SpeechSynthesis { get; set; }

        private string BaseTermLanguage => Const.BaseLanguagesList[0].Name;

        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (BaseTermsState?.Value?.BaseTerm is null)
            {
                ShowAlert(MyText.SaveError);
                return;
            }
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);
            var baseTerm = BaseTermsState.Value.BaseTerm;

            baseTerm.LanguageId = Const.BaseLanguagesList[0].Id;

            Dispatcher?.Dispatch(
                new BaseTermsAddAction(
                    baseTerm: baseTerm,
                    token: token.AuthToken,
                    baseTermAddedMessage: MyText.DataSavedOk));
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