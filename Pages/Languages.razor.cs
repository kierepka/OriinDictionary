using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using OriinDic.Components;
using OriinDic.Store.Languages;


namespace OriinDic.Pages
{
    public partial class Languages : DicBasePage
    {
        [Inject]
        private IState<LanguagesState> LanguagesState { get; set; }
        [Inject]
        private IDispatcher Dispatcher { get; set; }

        public Languages()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Dispatcher.Dispatch(new LanguagesFetchDataAction());
        }
    }
}