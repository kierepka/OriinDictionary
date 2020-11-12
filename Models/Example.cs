namespace OriinDic.Models
{
    public class Example : IExampleSynonym
    {
        public string Value { get; set; } = string.Empty;

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