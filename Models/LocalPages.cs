using Blazorise;

namespace OriinDic.Models
{
    public class LocalPages
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
                : Color.None;
        }

        public LocalPages()
        {
            
        }
    }
}