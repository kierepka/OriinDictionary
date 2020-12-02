using System.Linq;
using System.Threading.Tasks;

using Fluxor;

using Microsoft.AspNetCore.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Languages;
using OriinDic.Store.Translations;

using Toolbelt.Blazor.SpeechSynthesis;

namespace OriinDic.Pages
{
    public partial class TranslationNew
    {
        [Parameter] public long BaseTermId { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<TranslationsState>? TranslationsState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }    
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private SpeechSynthesis? SpeechSynthesis { get; set; }

        private string BaseTermLanguage
        {
            get
            {
                var retVal = Const.PlLangShortcut;
                if (TranslationsState?.Value?.BaseTranslation.BaseTerm is null) return retVal;
                if (LocalStorage is null) return retVal;
                return LanguagesState is null ? retVal : LanguagesState.Value.GetLanguageName(TranslationsState.Value.BaseTranslation.BaseTerm.LanguageId);
            }
        }

      
        private string TranslationLanguage
        {
            get
            {
                var retVal = Const.PlLangShortcut;
                if (TranslationsState?.Value?.BaseTranslation.Translation is null) return retVal;
                if (LocalStorage is null) return retVal;
                return LanguagesState is null ? retVal : LanguagesState.Value.GetLanguageName(TranslationsState.Value.BaseTranslation.Translation.LanguageId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            Dispatcher?.Dispatch(new TranslationsFetchBaseTermAction(BaseTermId));
        }

        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (TranslationsState?.Value?.BaseTranslation.Translation is null) 
            {
                ShowAlert(MyText.SaveError);
                return;
            }
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);
            

            Dispatcher?.Dispatch(
                new TranslationsAddAction(TranslationsState.Value.BaseTranslation.Translation, 
                    token.AuthToken));


        }
        private void OnSpeechEnClicked()
        {
            if (TranslationsState?.Value?.BaseTranslation.Translation is null) return;

            var utterance = new SpeechSynthesisUtterance
            {
                Text = TranslationsState.Value.Translation.Name,
                Lang = Func.GetLangSpeech(TranslationsState.Value.Translation.LanguageId), // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis?.Speak(utterance);
        }

        private void OnSpeechPlClicked()
        {
            if (TranslationsState?.Value?.BaseTranslation.BaseTerm is null) return;

            var utterance = new SpeechSynthesisUtterance
            {
                Text = TranslationsState.Value.BaseTerm.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis?.Speak(utterance);
        }
    }
}