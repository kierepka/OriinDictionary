using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using OriinDic.Models;

using Text = OriinDic.I18nText.Text;

namespace OriinDic.Components
{
    public partial class ListSynonyms : ComponentBase
    {
        private Validations? _validations;

        private string _myValue = string.Empty;

        [Inject] private Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }

        private List<Synonym> _synonyms = new();
        private Text _myText = new();

        [Parameter] public EventCallback<Synonym> OnSynonymCallback { get; set; }

        [Parameter]
        public IEnumerable<Synonym> Synonyms
        {
            get => from t in _synonyms select t;
            set => _synonyms = value.ToList();
        }

        private void OnAddObject()
        {
            if (_validations is null) return;
            if (!_validations.ValidateAll()) return;
            var synonym = new Synonym {Value = _myValue};
            _synonyms.Add(synonym);
            _myValue = string.Empty;

            OnSynonymCallback.InvokeAsync(synonym);
            _validations.ClearAll();
        }

        protected override async Task OnInitializedAsync()
        {
            if (I18NText!=null) 
                _myText = await I18NText.GetTextTableAsync<Text>(this);
        }

    }
}