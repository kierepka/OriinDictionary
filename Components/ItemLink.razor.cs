using Microsoft.AspNetCore.Components;

using OriinDic.Models;

namespace OriinDic.Components
{
    public partial class ItemLink

    {
        [Parameter] public OriinLink? MyLink { get; set; }

    }
}