using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;
using OriinDic.Components;
using OriinDic.Helpers;
using OriinDic.Models;
using OriinDic.Store.Languages;

namespace OriinDic.Pages
{
    public partial class Settings : DicBasePage
    {

        private bool _currentBaseLangPl;
        private bool isLoading = false;
       
        private LoginInput _loginModel = new LoginInput();

        private long _rowsPerPage;
        private int _selectedLanguage;
        private bool _currentTranslations;
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }

        public Settings()
        {
        }

        public Settings(ISyncLocalStorageService localStorage,
            Toolbelt.Blazor.I18nText.I18nText i18NText
        ) : this()
        {
            LocalStorage = localStorage;
            I18NText = i18NText;
        }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            isLoading = true;

            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());

            if (!(LocalStorage is null))
            {
                _currentBaseLangPl = LocalStorage!.GetItem<bool>(Const.CurrentBaseLangKey);
                _rowsPerPage = LocalStorage.GetItem<int>(Const.ItemsPerPageKey);
                _currentTranslations = LocalStorage.GetItem<bool>(Const.CurrentTranslations);
            }

            if (_currentBaseLangPl) _selectedLanguage = 1;
            if (_rowsPerPage == 0) _rowsPerPage = Const.DefaultItemsPerPage;

            isLoading = false;
        }


        private void HandleSave()
        {
            isLoading = true;
            if (!(LocalStorage is null))
            {
                LocalStorage!.SetItem(Const.CurrentBaseLangKey, _selectedLanguage == 1);
                LocalStorage!.SetItem(Const.ItemsPerPageKey, _rowsPerPage);
                LocalStorage!.SetItem(Const.CurrentTranslations, _currentTranslations);
                
            }
            isLoading = false;
        }
    }
}