using System.Linq;
using System.Threading.Tasks;
using Fluxor;

using Microsoft.AspNetCore.Components;
using OriinDic.Helpers;
using OriinDic.Store.Languages;

namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Settings
    {

        private bool _currentBaseLangPl;
        private bool _isLoading;

        private long _rowsPerPage;
        private int _selectedLanguage;
        private bool _currentTranslations;
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _isLoading = true;

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

            _isLoading = false;
        }


        private void HandleSave()
        {
            _isLoading = true;
            if (!(LocalStorage is null))
            {
                LocalStorage!.SetItem(Const.CurrentBaseLangKey, _selectedLanguage == 1);
                LocalStorage!.SetItem(Const.ItemsPerPageKey, _rowsPerPage);
                LocalStorage!.SetItem(Const.CurrentTranslations, _currentTranslations);
                
            }
            _isLoading = false;
        }
    }
}