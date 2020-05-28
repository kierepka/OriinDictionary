using Microsoft.AspNetCore.Components;

using OriinDic.Models;

namespace OriinDic.Components
{
    public partial class ItemExample

    {
        [Parameter] public Example? MyExample { get; set; }

    }
}