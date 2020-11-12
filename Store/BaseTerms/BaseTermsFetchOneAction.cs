namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneAction
    {
        public long BaseTermId { get; init;
        }
        public string Token { get; init; }

        public BaseTermsFetchOneAction(long baseTermId, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
        }
    }
}