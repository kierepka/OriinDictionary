using Microsoft.AspNetCore.Components;

namespace OriinDictionary7.Components;

public partial class SurveyPrompt
{
    [Parameter] public string Title { get; set; } = string.Empty;
}