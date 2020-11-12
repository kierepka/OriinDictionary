using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store;
using OriinDic.Store.Comments;
using OriinDic.Store.Languages;
using OriinDic.Store.Translations;

using Toolbelt.Blazor.SpeechSynthesis;

namespace OriinDic.Pages
{
    public partial class TranslationEdit : DicBasePage
    {
        private Translation? _oldTranslation;
        private Token _token = new Token();

        public TranslationEdit()
        {
        }


        public BaseTerm? BaseTerm { get; set; }

        public string BaseTermInformation { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public string Information { get; set; } = string.Empty;

        public Translation? Translation { get; set; }

        [Parameter] public long TranslationId { get; set; } = long.MinValue;

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

        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private SpeechSynthesis? SpeechSynthesis { get; set; }        
        [Inject] private IState<TranslationsState>? TranslationsState { get; set; }

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

            if (LocalStorage is null) return;

            _token = LocalStorage.GetItem<Token>(Const.TokenKey);

            var token = _token.AuthToken ?? string.Empty;

            Dispatcher?.Dispatch(new TranslationsFetch4EditAction(TranslationId, token, MyText?.noData ?? string.Empty));

            if (TranslationsState != null) TranslationsState.StateChanged += TranslationsState_StateChanged;
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

        private void OnCommentAdd(Comment comment)
        {
            if (Translation == null) return;
            comment.TranslationId = Translation.Id;
            if (!(LocalStorage is null))
                comment.User = Func.GetCurrentUser(LocalStorage);

            if (_token == null) return;
            Dispatcher?.Dispatch(new CommentsAddAction(comment, _token.AuthToken));
            Dispatcher?.Dispatch(new TranslationsFetchCommentsAction(Translation.Id, _token.AuthToken));
        }

        private void OnResetClicked()
        {
            if (Translation is null) return;

            Translation.Name = _oldTranslation?.Name ?? string.Empty;
            Translation.Definition = _oldTranslation?.Definition ?? string.Empty;
            Translation.Current = _oldTranslation?.Current ?? false;
            StateHasChanged();
        }

        private void OnSaveClicked()
        {
            if (MyText is null) return;
            if (Translation is null)
            {
                ShowAlert(MyText.saveError);
                return;
            }
            _oldTranslation = Translation;
            Dispatcher?.Dispatch(new TranslationsUpdateAction(TranslationId, Translation, _token.AuthToken));

        }

        private void OnSpeechEnClicked()
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

        private void OnSpeechPlClicked()
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

        private void TranslationsState_StateChanged(object sender, TranslationsState e)
        {
            
            Translation = TranslationsState?.Value.Translation;
            
            
            BaseTerm = TranslationsState?.Value.BaseTerm;
            Comments = TranslationsState?.Value.Comments ?? new List<Comment>();
            
            CreateInformation();
            CreateBaseInformation();

            switch (e.LastActionState)
            {
                case EActionState.Updated:
                    if (MyText is null) return;
                    ShowAlert($"{MyText.translationSaved} {Translation?.Id}");
                    break;
                case EActionState.FetchedComments:
                    if (MyText is null) return;
                    ShowAlert($"{MyText.addedComment} {Translation?.Id}");
                    break;
                case EActionState.FetchedForEdit:
                    if (MyText is null) return;
                    ShowAlert($"{MyText.loaded} {Translation?.Id}");
                    break;
            }
            StateHasChanged();
        }
    }
}