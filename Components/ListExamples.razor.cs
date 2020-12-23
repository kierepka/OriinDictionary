using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using OriinDic.Models;

using Text = OriinDic.I18nText.Text;

namespace OriinDic.Components
{
    public partial class ListExamples
    {
        private Validations? _validations;

        private string _myValue = string.Empty;
        [Inject] private Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }
        private Text _myText = new();

        private List<Example> _examples = new();

        [Parameter] public EventCallback<Example> OnExampleCallback { get; set; }

        [Parameter]
        public IEnumerable<Example> Examples
        {
            get => from t in _examples select t;
            set => _examples = value.ToList();
        }

        private async Task OnAddObject()
        {
            if (_validations is null) return;
            if (!_validations.ValidateAll()) return;
            var example = new Example {Value = _myValue};
            _examples.Add(example);
            _myValue = string.Empty;

            await OnExampleCallback.InvokeAsync(example);

            _validations.ClearAll();
        }


        protected override async Task OnInitializedAsync()
        {
            if (I18NText != null)
                _myText = await I18NText.GetTextTableAsync<Text>(this);

        }
    }
}