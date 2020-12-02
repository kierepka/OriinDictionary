using Microsoft.AspNetCore.Components;

namespace OriinDic.Components
{
    public partial class SurveyPrompt
    {
        [Parameter] public string Title { get; set; } = string.Empty;
    }
}