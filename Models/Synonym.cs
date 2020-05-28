namespace OriinDic.Models
{
    public class Synonym : IExampleSynonym
    {
        public string Value { get; set; }
        public Synonym(string val)
        {
            Value = val;
        }
        public Synonym()
        {
            Value = string.Empty;
        }
    }
}