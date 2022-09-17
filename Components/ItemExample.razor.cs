using Microsoft.AspNetCore.Components;

using OriinDictionary7.Models;

namespace OriinDictionary7.Components;

public partial class ItemExample

{
    [Parameter] public Example? MyExample { get; set; }

}