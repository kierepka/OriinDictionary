using Blazorise;

namespace OriinDictionary7.Models;

public record LocalPages
{
    public long Number { get; set; }

    public string Name => Number == 0 ? "[..]" : Number.ToString();

    public bool ButtonIsDisabled(long? searchPageNr)
    {
        if (searchPageNr.HasValue)
            return Number == 0 || Number == searchPageNr;

        return true;

    }


    public Color ButtonColor(long? searchPageNr)
    {
        return ButtonIsDisabled(searchPageNr)
            ? Color.Primary
            : Color.Default;
    }
}