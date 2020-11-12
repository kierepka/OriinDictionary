namespace OriinDic.Models
{
    public class Synonym : IExampleSynonym
    {
        public string Value { get; set; } = string.Empty;
        public Synonym(string val)
        {
            Value = val;
        }
        public Synonym()
        {
        }
    }
}