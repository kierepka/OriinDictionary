
using Microsoft.AspNetCore.Components;

using OriinDictionary7.Models;

namespace OriinDictionary7.Components;

public partial class ItemComment

{
    [Parameter] public Comment? MyComment { get; set; }

}