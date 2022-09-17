using Microsoft.AspNetCore.Components;

using OriinDictionary7.Models;

namespace OriinDictionary7.Components;

public partial class ItemLink

{
    [Parameter] public OriinLink? MyLink { get; set; }

}