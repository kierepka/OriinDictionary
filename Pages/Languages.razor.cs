using Fluxor;

using Microsoft.AspNetCore.Components;

using OriinDic.Store.Languages;

using System.Threading.Tasks;


namespace OriinDic.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Languages
    {

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IState<LanguagesState>? LanguagesState { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IDispatcher? Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Dispatcher?.Dispatch(new LanguagesFetchDataAction(LocalStorage));
        }
    }
}