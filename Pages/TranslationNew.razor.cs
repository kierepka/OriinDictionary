using System.Linq;
using System.Threading.Tasks;

using Blazored.LocalStorage;
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

        [Inject] private IState<TranslationsState>? TranslationsState { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] SpeechSynthesis? SpeechSynthesis { get; set; }
        private Translation? _oldTranslation;

        public BaseTerm? BaseTerm { get; set; }
        public string BaseTermInformation { get; set; } = string.Empty;

        public string Information { get; set; } = string.Empty;

        public Translation? Translation { get; set; } = new Translation();
        [Parameter] public long BaseTermId { get; set; }


        public TranslationNew() : base()
        {
         
        }





        private string BaseTermLanguage
        {
            get
            {              
                var retVal = Const.PlLangShortcut;
                if (TranslationsState is null) return retVal;
                if (TranslationsState.Value.BaseTerm is null) return retVal;
                if (LocalStorage is null) return retVal;
                if (LanguagesState is null) return retVal;

                return LanguagesState.Value.GetLanguageName(TranslationsState.Value.BaseTerm.LanguageId);
            }
        }

  

        private string TranslationLanguage
        {
            get
            {
                var retVal = Const.PlLangShortcut;
                if (TranslationsState is null) return retVal;
                if (TranslationsState.Value.Translation is null) return retVal;
                if (LocalStorage is null) return retVal;
                if (LanguagesState is null) return retVal;

                return LanguagesState.Value.GetLanguageName(TranslationsState.Value.Translation.LanguageId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            Dispatcher?.Dispatch(new TranslationsFetchBaseTermAction(BaseTermId));
            if (TranslationsState != null) TranslationsState.StateChanged += TranslationsState_StateChanged;
        }

        private void TranslationsState_StateChanged(object sender, TranslationsState e)
        {
            if (e.LastActionState == EActionState.FetchedBase)
            {
                if (MyText is null) return;
                ShowAlert($"{MyText.loaded} {Translation?.Id}");
            }


            if (e.LastActionState != EActionState.Saved) return;

            if (TranslationsState?.Value.BaseTerm is null) return;
            BaseTerm = TranslationsState.Value.BaseTerm;
            _oldTranslation = Translation;
            CreateInformation();
            CreateBaseInformation();

            if (MyText is null) return;
            ShowAlert($"{MyText.translationSaved} {Translation?.Id}");
        }

        private void CreateBaseInformation()
        {
            if (MyText is null) return;
            if (BaseTerm is null) return;
            var langName = BaseTermLanguage;
            var lastEdit = BaseTerm?.LastEdit?.User?.UserName;

            BaseTermInformation = $"{MyText.baseTermLanguage}:{langName}, {MyText.baseTermLastEdit}:{lastEdit}";
        }

        private void CreateInformation()
        {
            if (MyText is null) return;
            if (!(Translation is null))
                Information =
                    $"{MyText.translationLastEdit}:{Translation?.LastEdit?.User?.UserName}, {MyText.translationLastApproval}:{Translation?.LastApproval.User.UserName}, {MyText.translationTitle}:{Translation?.Id}";
        }

        private void OnResetClicked()
        {
            if (_oldTranslation is null)
            {
                if (Translation is null) return;
                Translation.Name = string.Empty;
                Translation.Definition = string.Empty;
                Translation.Current = false;
                return;
            }

            if (Translation is null) return;

            Translation.Name = _oldTranslation.Name;
            Translation.Definition = _oldTranslation.Definition;
            Translation.Current = _oldTranslation.Current;

            StateHasChanged();
        }



        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (LocalStorage is null) return;

            if (Translation is null)
            {
                ShowAlert(MyText.saveError);
                return;
            }
            var token = LocalStorage.GetItem<Token>(Const.TokenKey);

            Dispatcher?.Dispatch(new TranslationsAddAction(Translation, token.AuthToken));


        }
        private void OnSpeachEnClicked()
        {
            var utterancet = new SpeechSynthesisUtterance
            {
                Text = Translation?.Name,
                Lang = Func.GetLangSpeech(Translation?.LanguageId), // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis?.Speak(utterancet);
        }

        private void OnSpeachPlClicked()
        {

            var utterancet = new SpeechSynthesisUtterance
            {
                Text = BaseTerm?.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis?.Speak(utterancet);
        }
    }
}