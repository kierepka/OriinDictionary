using System.Collections.Generic;
using Blazorise;
using Microsoft.AspNetCore.Components;
using OriinDic.Models;

namespace OriinDic.Components
{
    public partial class MyPagination : ComponentBase
    {
        private const string BackName = "prev";
        private const string NextName = "next";

        [Parameter] public long? SearchPageNr { get; set; }

        [Parameter] public long? LastPage { get; set; }

        [Parameter] public List<LocalPages>? LocalPages { get; set; }

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
            return SearchPageNr >= LastPage;
        }

        private Color GetNextColor()
        {
            return GetNextIsDisabled() ? Color.Secondary : Color.None;
        }
    }
}