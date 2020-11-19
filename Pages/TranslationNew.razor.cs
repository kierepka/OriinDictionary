using System.Linq;
using System.Threading.Tasks;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store;
using OriinDic.Store.Languages;
using OriinDic.Store.Translations;

using Toolbelt.Blazor.SpeechSynthesis;

namespace OriinDic.Pages
{
    public partial class TranslationNew : DicBasePage
    {
        [Parameter] public long BaseTermId { get; set; } =0;
        [Inject] private IState<TranslationsState>? TranslationsState { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }        
        [Inject] private SpeechSynthesis? SpeechSynthesis { get; set; }

        private Translation? _oldTranslation;

        public TranslationNew() : base()
        {
        }


        private string BaseTermLanguage
        {
            get
            {
                var retVal = Const.PlLangShortcut;
                if (TranslationsState?.Value?.BaseTranslation?.BaseTerm is null) return retVal;
                if (LocalStorage is null) return retVal;
                if (LanguagesState is null) return retVal;

               
                return LanguagesState.Value.GetLanguageName(TranslationsState.Value.BaseTranslation.BaseTerm.LanguageId);
            }
        }

      
        private string TranslationLanguage
        {
            get
            {
                var retVal = Const.PlLangShortcut;
                if (TranslationsState?.Value?.BaseTranslation?.Translation is null) return retVal;
                if (LocalStorage is null) return retVal;
                if (LanguagesState is null) return retVal;

               
                return LanguagesState.Value.GetLanguageName(TranslationsState.Value.BaseTranslation.Translation.LanguageId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            Dispatcher?.Dispatch(new TranslationsFetchBaseTermAction(BaseTermId));
        }


        private void OnResetClicked()
        {
            if (TranslationsState?.Value?.BaseTranslation?.Translation is null) return;

            if (_oldTranslation is null)
            {
                
                TranslationsState.Value.BaseTranslation.Translation.Name = string.Empty;
                TranslationsState.Value.BaseTranslation.Translation.Definition = string.Empty;
                TranslationsState.Value.BaseTranslation.Translation.Current = false;
                return;
            }

            TranslationsState.Value.BaseTranslation.Translation.Name = _oldTranslation.Name;
            TranslationsState.Value.BaseTranslation.Translation.Definition = _oldTranslation.Definition;
            TranslationsState.Value.BaseTranslation.Translation.Current = _oldTranslation.Current;

            StateHasChanged();
        }



        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (TranslationsState?.Value?.BaseTranslation?.Translation is null) 
            {
                ShowAlert(MyText.saveError);
                return;
            }
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);
            
            _oldTranslation = TranslationsState.Value.BaseTranslation.Translation;


            Dispatcher?.Dispatch(
                new TranslationsAddAction(TranslationsState.Value.BaseTranslation.Translation, 
                    token.AuthToken));


        }
        private void OnSpeachEnClicked()
        {
            if (TranslationsState?.Value?.BaseTranslation?.Translation is null) return;

            var utterancet = new SpeechSynthesisUtterance
            {
                Text = TranslationsState.Value.Translation.Name,
                Lang = Func.GetLangSpeech(TranslationsState.Value.Translation.LanguageId), // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis?.Speak(utterancet);
        }

        private void OnSpeachPlClicked()
        {
            if (TranslationsState?.Value?.BaseTranslation?.BaseTerm is null) return;

            var utterancet = new SpeechSynthesisUtterance
            {
                Text = TranslationsState.Value.BaseTerm.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis?.Speak(utterancet);
        }
    }
}