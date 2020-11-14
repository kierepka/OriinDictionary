namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneAction
    {
        public long BaseTermId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;  

        public BaseTermsFetchOneAction(long baseTermId, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
        }
    }
}