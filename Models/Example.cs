namespace OriinDic.Models
{
    public record Example : IExampleSynonym
    {
        public string Value { get; set; }
        public Example(string val)
        {
            Value = val;
        }
        public Example()
        {
            Value = string.Empty;
        }

    }
}