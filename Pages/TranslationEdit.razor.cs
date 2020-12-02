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
    public partial class TranslationEdit
    {
        private Token _token = new Token();

        [Parameter] public long TranslationId { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private SpeechSynthesis? SpeechSynthesis { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<TranslationsState>? TranslationsState { get; set; }

        private string BaseTermLanguage
        {
            get
            {
                const string retVal = Const.PlLangShortcut;
                if (TranslationsState?.Value.BaseTerm is null) return retVal;
                if (LocalStorage is null) return retVal;
                return LanguagesState is null ? retVal : LanguagesState.Value.GetLanguageName(TranslationsState.Value.BaseTerm.LanguageId);
            }
        }



        private string TranslationLanguage
        {
            get
            {
                var retVal = Const.PlLangShortcut;
                if (TranslationsState?.Value.Translation is null) return retVal;
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

            var token = string.Empty;
            if (!(LocalStorage is null))
            {
                _token = LocalStorage.GetItem<Token>(Const.TokenKey);
                token = _token?.AuthToken ?? string.Empty;
            }

            Dispatcher?.Dispatch(new TranslationsFetch4EditAction(TranslationId, token,
                MyText?.NoData ?? string.Empty,
                MyText?.Loaded ?? string.Empty));

        }

        private void OnCommentAdd(Comment comment)
        {
            if (TranslationsState?.Value?.Translation == null) return;
            
            comment.TranslationId = TranslationsState.Value.Translation.Id;

            if (!(LocalStorage is null))
                comment.User = Func.GetCurrentUser(LocalStorage);

            Dispatcher?.Dispatch(
                new TranslationsCommentAddAction(
                    comment, _token.AuthToken, TranslationsState.Value.Translation.Id));

        }


        private void OnApprove()
        {
            if (MyText is null) return;
            if (TranslationsState?.Value?.Translation == null)
            {
                ShowAlert(MyText.SaveError);
                return;
            }
            Dispatcher?.Dispatch(new TranslationsAproveAction(TranslationId, _token.AuthToken));

        }
        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (TranslationsState?.Value?.Translation == null)
            {
                ShowAlert(MyText.SaveError);
                return;
            }
            Dispatcher?.Dispatch(new TranslationsUpdateAction(TranslationId, TranslationsState.Value.Translation, _token.AuthToken));

        }

        private void OnSpeechEnClicked()
        {
            if (TranslationsState?.Value?.Translation is null) return;
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
            var utterance = new SpeechSynthesisUtterance
            {
                Text = TranslationsState?.Value.BaseTerm.Name,
                Lang = Const.PlLangSpeechCode, // BCP 47 language tag
                Pitch = 1.0, // 0.0 ~ 2.0 (Default 1.0)
                Rate = 1.0, // 0.1 ~ 10.0 (Default 1.0)
                Volume = 1.0 // 0.0 ~ 1.0 (Default 1.0)
            };
            SpeechSynthesis?.Speak(utterance);
        }


    }
}