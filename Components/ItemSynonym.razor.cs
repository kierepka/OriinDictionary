using Microsoft.AspNetCore.Components;

using OriinDictionary7.Models;

namespace OriinDictionary7.Components;

public partial class ItemSynonym

{
    [Parameter] public Synonym? MySynonym { get; set; }

}