using Microsoft.AspNetCore.Components;

using OriinDic.Models;

namespace OriinDic.Components
{
    public partial class ItemSynonym

    {
        [Parameter] public Synonym? MySynonym { get; set; }

    }
}