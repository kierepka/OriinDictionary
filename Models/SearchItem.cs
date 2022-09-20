namespace OriinDictionary7.Models;

public record SearchItem
{
    public string? BaseName { get; set; }
    public string? BaseNameToolTip { get; set; }
    public long? BaseTermId { get; set; }
    public string? BaseTermSlug { get; set; }
    public long? TranslateId { get; set; }
    public string? TranslateName { get; set; }
    public string? TranslateNameToolTip { get; set; }
}
