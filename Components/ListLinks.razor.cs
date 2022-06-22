using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using OriinDic.Models;

using Text = OriinDic.I18nText.Text;

namespace OriinDic.Components
{
    public partial class ListLinks
    {
        private Validations? _validations;

        private string _myValue = string.Empty;

        [Inject] private Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }

        private List<OriinLink> _links = new();
        private Text _myText = new();

        [Parameter] public EventCallback<OriinLink> OnLinkCallback { get; set; }

        [Parameter]
        public IEnumerable<OriinLink> Links
        {
            get => from t in _links select t;
            set => _links = value.ToList();
        }

        private async Task OnAddObject()
        {
            if (_validations is null) return;
            var result = await _validations.ValidateAll();
            if (!result) return;
            var link = new OriinLink{ Link= _myValue};
            _links.Add(link);
            _myValue = string.Empty;

            _ = OnLinkCallback.InvokeAsync(link);
            _ = _validations.ClearAll();
        }

        protected override async Task OnInitializedAsync()
        {
            if (I18NText !=null)
                _myText = await I18NText.GetTextTableAsync<Text>(this);
        }
    }
}