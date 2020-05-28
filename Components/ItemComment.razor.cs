
using Microsoft.AspNetCore.Components;

using OriinDic.Models;

namespace OriinDic.Components
{
    public partial class ItemComment

    {
        [Parameter] public Comment? MyComment { get; set; }

    }
}