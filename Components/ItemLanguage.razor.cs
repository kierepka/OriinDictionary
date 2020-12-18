using Microsoft.AspNetCore.Components;

using OriinDic.Models;

using System;

namespace OriinDic.Components
{
    public partial class ItemLanguage

    {
        [Parameter] public SelectableLanguage? Language { get; set; }
        [Parameter] public Action<bool>? StatusChanged { get; set; }

        void OnCheckedChanged(bool isChecked)
        {
            if (Language is null) return;
            
            Language.Selected = isChecked;
            StatusChanged?.Invoke(isChecked);
        }
    }
}