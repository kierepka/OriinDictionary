using System.Collections.Generic;
using System.Linq;
using Blazorise;

using Microsoft.AspNetCore.Components;

using OriinDic.Models;

using System.Threading.Tasks;
using Blazored.LocalStorage;
using Fluxor;
using OriinDic.Helpers;
using OriinDic.Store.Languages;

using Text = OriinDic.I18nText.Text;

namespace OriinDic.Components
{
    /// <summary>
    ///     Kontrolka do wyszukiwania
    /// </summary>
    public partial class MySearch : ComponentBase
    {
        private Text _myText = new Text();
        
        private Language? _currentLanguage1;
        private Language? _currentLanguage2;

        [Inject] protected ISyncLocalStorageService? LocalStorage { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] private Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }

        [Parameter] public EventCallback<string> OnSearch { get; set; }

        [Parameter] public EventCallback<long> OnLangChange1 { get; set; }
        [Parameter] public EventCallback<long> OnLangChange2 { get; set; }

        [Parameter] public string PlaceholderText { get; set; } = string.Empty;
        [Parameter] public string SearchText { get; set; } = string.Empty;

        [Parameter]
        public Language? CurrentLanguage1
        {
            get => _currentLanguage1;
            set
            {
                if (_currentLanguage1 == value) return;
                _currentLanguage1 = value;
                CurrentLanguage1Changed.InvokeAsync(value);
            }

        }
        [Parameter] public EventCallback<Language?> CurrentLanguage1Changed { get; set; }

        [Parameter]
        public Language? CurrentLanguage2
        {
            get => _currentLanguage2;

            set
            {
                if (_currentLanguage2 == value) return;
                _currentLanguage2 = value;
                CurrentLanguage2Changed.InvokeAsync(value);
            }
        }
        [Parameter] public EventCallback<Language?> CurrentLanguage2Changed { get; set; }
        public Color ButtonEnColor { get; set; }
        public Color ButtonPlColor { get; set; }

        protected Dropdown DropdownLanguage { get; set; } = new Dropdown();

        public MySearch() : base()
        {
        }


        private async Task ClickedDropdownItem1(object l)
        {
            var langId = (long)l;
            CurrentLanguage1 = LanguagesState?.Value.GetLanguage(langId);
            if (OnLangChange1.HasDelegate) 
                await OnLangChange1.InvokeAsync(langId);
        }
        private async Task ClickedDropdownItem2(object l)
        {
            var langId = (long)l;
            CurrentLanguage2 = LanguagesState?.Value.GetLanguage(langId);

            if (OnLangChange1.HasDelegate)
                await OnLangChange2.InvokeAsync(langId);
        }

        private void OnKeyboardKey(string k)
        {
            SearchText += k;
        }
        protected override async Task OnInitializedAsync()
        {

            if (!(I18NText is null))
                _myText = await I18NText.GetTextTableAsync<Text>(this);

            if (!LanguagesState?.Value.Languages.Any() ?? true)
                Dispatcher?.Dispatch(new LanguagesFetchDataAction());
            

        }

        private void SwapLangs()
        {

            var cl1 = CurrentLanguage1;
            CurrentLanguage1 = CurrentLanguage2;
            CurrentLanguage2 = cl1;
            if (CurrentLanguage1 is null) return;
            if (CurrentLanguage2 is null) return;
            StateHasChanged();
        }

        private async Task ButtonSearchClicked()
        {
            await OnSearch.InvokeAsync(SearchText);
        }


    }
}