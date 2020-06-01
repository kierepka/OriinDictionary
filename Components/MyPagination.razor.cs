using System.Collections.Generic;
using Blazorise;
using Microsoft.AspNetCore.Components;
using OriinDic.Models;

namespace OriinDic.Components
{
    public partial class MyPagination : ComponentBase
    {
        

        [Parameter] public long? SearchPageNr { get; set; }

        [Parameter] public long? TotalPages { get; set; }

        [Parameter] public IEnumerable<LocalPages>? LocalPages { get; set; }

        [Parameter] public string? PrevText { get; set; }

        [Parameter] public string? NextText { get; set; }

        [Parameter] public EventCallback<string> OnClickCallback { get; set; }


        private bool GetBackIsDisabled()
        {
            return SearchPageNr <= 1;
        }

        private Color GetBackColor()
        {
            return GetBackIsDisabled() ? Color.Secondary : Color.None;
        }

        private bool GetNextIsDisabled()
        {
            return SearchPageNr >= TotalPages;
        }

        private Color GetNextColor()
        {
            return GetNextIsDisabled() ? Color.Secondary : Color.None;
        }
    }
}