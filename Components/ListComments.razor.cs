using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OriinDic.Models;

using Text = OriinDic.I18nText.Text;

namespace OriinDic.Components
{
    public partial class ListComments
    {
        Validations? validations;
        private string _myValue = string.Empty;
        [Inject] private Toolbelt.Blazor.I18nText.I18nText? I18NText { get; set; }
        private Text _myText = new();

        private List<Comment> _comments = new();

        [Parameter] public EventCallback<Comment> OnCommentAdd { get; set; }

        [Parameter]
        public IEnumerable<Comment> Comments
        {
            get => from t in _comments select t;
            set => _comments = value.ToList();
        }

        private async Task OnAddObject()
        {
            if (validations is null) return;
            
            if (await validations.ValidateAll())
            {

                var comment = new Comment { Text = _myValue, Date = DateTimeOffset.Now };
                _comments.Add(comment);
                _myValue = string.Empty;
                _ = validations.ClearAll();
                await OnCommentAdd.InvokeAsync(comment);
            }
        }

        private async Task KeyPressedText(KeyboardEventArgs keyboard)
        {
            if (keyboard.Code == "Enter" || keyboard.Code == "NumpadEnter")
            {

                await OnAddObject();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (I18NText != null) _myText = await I18NText.GetTextTableAsync<Text>(this);
        }
    }
}